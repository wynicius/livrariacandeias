using livrariacandeias.Models;
using livrariacandeias.DataAccess.Repository.IRepository;
using livrariacandeias.DataAccess.Data;
using livrariacandeias.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using livrariacandeias.Utility;
using Microsoft.AspNetCore.Authorization;

namespace livrariacandeias.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // create
                return View(new Company());
            }
            else
            {
                // update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {
                if(CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                    TempData["success"] = "Company updated successfully";
                }
                
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            };
        }
        
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new {data = objCompanyList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(c => c.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new {sucess = false, message = "Error while deleting"});
            }

            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            return Json(new {sucess = true, message = "Delete successful"});
        }

        #endregion
    } 
}