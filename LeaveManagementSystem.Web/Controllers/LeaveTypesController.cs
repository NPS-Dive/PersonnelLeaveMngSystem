using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Services.LeaveTypes;

namespace LeaveManagementSystem.Web.Controllers
    {
    public class LeaveTypesController(ILeaveTypeService leaveTypeService) : Controller
        {
       
        private readonly string NameExistsValidationErrMsg="This name already exists!";
        private readonly string VacationNotAllowedErrMsg= "Name Cannot contain 'vacation'";
        private readonly ILeaveTypeService _leaveTypeService = leaveTypeService;



        // GET: LeaveTypes
        public async Task<IActionResult> Index ()
        {
            var viewData = await  _leaveTypeService.GetAllAsync();
            return View(viewData);
            }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details ( Guid? id )
            {
            if (id == null)
                {
                return NotFound();
                }

                var leaveType = await _leaveTypeService.Get<LeaveTypeReadOnlyViewModel>(id.Value);

            if (leaveType == null)
                {
                return NotFound();
                }

            return View(leaveType);
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
            if (_leaveTypeService.LeaveTypeNameContainsVacation(leaveTypeCreate.Name))
                {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), VacationNotAllowedErrMsg);
                }

            else if (await _leaveTypeService.LeaveTypeNameExistAsync(leaveTypeCreate.Name))
                {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationErrMsg);
                }

            else if (ModelState.IsValid)
            {
                _leaveTypeService.CreateAsync(leaveTypeCreate);
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

                var leaveType = await _leaveTypeService.Get<leaveTypeEditViewModel>(id.Value);
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
        public async Task<IActionResult> Edit ( Guid id, leaveTypeEditViewModel leaveTypeEdit )
            {
            if (id != leaveTypeEdit.Id)
                {
                return NotFound();
                }

            //custom validations
            //if (leaveTypeEdit.Name.Contains("vacation"))
            if (_leaveTypeService.LeaveTypeNameContainsVacation(leaveTypeEdit.Name))
                {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), VacationNotAllowedErrMsg);
                }

            else if (await _leaveTypeService.LeaveTypeNameExistAsync(leaveTypeEdit.Name))
                {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), NameExistsValidationErrMsg);
                }

            if (ModelState.IsValid)
                {
                try
                {
                    await _leaveTypeService.EditAsync(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                    {
                    if (await _leaveTypeService.LeaveTypeExistsAsync(leaveTypeEdit.Id) is false)
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

                var leaveType = await _leaveTypeService.Get<LeaveTypeReadOnlyViewModel>(id.Value);
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
            _leaveTypeService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
            }

       
        }
    }
