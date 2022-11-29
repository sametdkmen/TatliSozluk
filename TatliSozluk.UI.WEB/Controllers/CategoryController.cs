using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TatliSozluk.UI.WEB.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet] // Sayfa yüklendiği zaman sadece sayfayi geri döndürecek, aşağıda butona tıklandıktan sonra post işlemine gidecek.
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost] // Ben sayfada bir butona tıkladığımda post edildiğinde bu çalışacak htppost attributeü sayesinde.
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();  //Ekleme işlemi sonrası beni tekrar listeleme işleminin olduğu metoda yönlendir dedim.
        }
    }
}