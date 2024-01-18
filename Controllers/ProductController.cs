 using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using test.Models;

namespace test.Controllers
{
    public class ProductController : Controller
    {
        ProductSampleData sampleData = new ProductSampleData();

        #region First
        // public string showmsg()
        // {
        //     return "hello from first action";
        // }
        // public ContentResult showmg2()
        // {
        //     ContentResult contentresult = new ContentResult();
        //     contentresult.Content = "Local Msg";
        //     return contentresult;
        // }
        // public ViewResult ShowView()
        // {
        //     ViewResult result = new ViewResult();
        //     result.ViewName = "View1";
        //     return result;
        // }
        // public JsonResult ShowJson()
        // {
        //     JsonResult result = new JsonResult(new {Id=1,Name="Ramez"});
        //     return result;
        // }
        ////product/showmix/1
        ////product/showmix?1d=1&&age=23
        ////product/showmix/1?age=23
        // public IActionResult ShowMix(int id,int age)
        // {
        //     if (id % 2 == 0) {
        //         return Content("j");

        //     }
        //     else
        //     {
        //         return View("View1");
        //     }
        // }
        #endregion
        public IActionResult Details(int id)
        {
            //model
           Product productModel= sampleData.GetById(id);
            //sendview
            return View("ProductDetails",productModel);
        }
        public IActionResult Index()
        {
            List<Product> productListModel = sampleData.GetAll();
            return View("ShowAll",productListModel);
        }

    }


}
