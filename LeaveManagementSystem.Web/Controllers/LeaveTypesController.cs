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
        private readonly string NameExistsValidationErrMsg="This name already exists!";
        private readonly string VacationNotAllowedErrMsg= "Name Cannot contain 'vacation'";

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
        public async Task<IActionResult> Create ( LeaveTypeCreateViewModel leaveTypeCreate )
            {
            //custom validations
          //  if (leaveTypeCreate.Name.Contains("vacation"))
            if (LeaveTypeNameContainsVacation(leaveTypeCreate.Name))
                {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), VacationNotAllowedErrMsg);
                }

            else if (await LeaveTypeNameExistAsync(leaveTypeCreate.Name))
                {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationErrMsg);
                }

            else if (ModelState.IsValid)
                {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);
                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            return View(leaveTypeCreate);
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

            var viewData = _mapper.Map<leaveTypeEditViewModel>(leaveType);

            return View(viewData);
            }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit ( Guid id, leaveTypeEditViewModel leaveTypeEdit )
            {
            if (id != leaveTypeEdit.Id)
                {
                return NotFound();
                }

            //custom validations
            //if (leaveTypeEdit.Name.Contains("vacation"))
            if (LeaveTypeNameContainsVacation(leaveTypeEdit.Name))
                {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), VacationNotAllowedErrMsg);
                }

            else if (await LeaveTypeNameExistAsync(leaveTypeEdit.Name))
                {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), NameExistsValidationErrMsg);
                }

            if (ModelState.IsValid)
                {
                try
                    {
                    var leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                    }
                catch (DbUpdateConcurrencyException)
                    {
                    if (await LeaveTypeExistsAsync(leaveTypeEdit.Id) is false)
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
            return View(leaveTypeEdit);
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

            var viewDate = _mapper.Map<LeaveTypeReadOnlyViewModel>(leaveType);
            return View(viewDate);
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

        #region Private Methods

        private async Task<bool> LeaveTypeExistsAsync ( Guid id )
            {
            var result = await _context.LeaveTypes.AnyAsync(e => e.Id == id);
            return result;
            }

        private async Task<bool> LeaveTypeNameExistAsync ( string name )
            {
            var nameToLowerCase = name.ToLower();
            var result = await _context.LeaveTypes.AnyAsync(lt => lt.Name.ToLower().Equals(nameToLowerCase));
            return result;
            }


            private bool LeaveTypeNameContainsVacation ( string name )
            {
                var nameToLowerCase = name.ToLower();
                var result = nameToLowerCase.Contains("vacation");
                return result;
            }

        #endregion
        }
    }
