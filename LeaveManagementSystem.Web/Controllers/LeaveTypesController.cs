using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Controllers
    {
    public class LeaveTypesController : Controller
        {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LeaveTypesController ( ApplicationDbContext context, IMapper mapper )
            {
            _context = context;
            _mapper = mapper;
            }

        // GET: LeaveTypes
        public async Task<IActionResult> Index ()
            {
            var leaveTypeList = await _context.LeaveTypes.ToListAsync();

            //convert the data model into a view model:
            // A: manual
            //var viewData = leaveTypeList.Select(v => new IndexViewModel()
            //    {
            //    Id = v.Id,
            //    Name = v.Name,
            //    NumberOfDays = v.NumberOfDays
            //    });

            //B: using AutoMapper
            var viewData = _mapper.Map<List<LeaveTypeReadOnlyViewModel>>(leaveTypeList);


            // return the view model to the view


            return View(viewData);
            }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details ( Guid? id )
            {
            if (id == null)
                {
                return NotFound();
                }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
                {
                return NotFound();
                }

            var viewData = _mapper.Map<LeaveTypeReadOnlyViewModel>(leaveType);

            return View(viewData);
            }

        // GET: LeaveTypes/Create
        public IActionResult Create ()
            {
            return View();
            }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ( [Bind("Id,Name,NumberOfDays")] LeaveType leaveType )
            {
            if (ModelState.IsValid)
                {
                leaveType.Id = Guid.NewGuid();
                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            return View(leaveType);
            }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit ( Guid? id )
            {
            if (id == null)
                {
                return NotFound();
                }

            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
                {
                return NotFound();
                }
            return View(leaveType);
            }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit ( Guid id, [Bind("Id,Name,NumberOfDays")] LeaveType leaveType )
            {
            if (id != leaveType.Id)
                {
                return NotFound();
                }

            if (ModelState.IsValid)
                {
                try
                    {
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                    }
                catch (DbUpdateConcurrencyException)
                    {
                    if (!LeaveTypeExists(leaveType.Id))
                        {
                        return NotFound();
                        }
                    else
                        {
                        throw;
                        }
                    }
                return RedirectToAction(nameof(Index));
                }
            return View(leaveType);
            }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete ( Guid? id )
            {
            if (id == null)
                {
                return NotFound();
                }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
                {
                return NotFound();
                }

            return View(leaveType);
            }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed ( Guid id )
            {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
                {
                _context.LeaveTypes.Remove(leaveType);
                }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }

        private bool LeaveTypeExists ( Guid id )
            {
            return _context.LeaveTypes.Any(e => e.Id == id);
            }
        }
    }
