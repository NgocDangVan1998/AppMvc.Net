using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

namespace AppMvc.Net.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;

        private readonly ProductService _productService;
        //inject dịch vụ logger cho FirstController
        public FirstController(ILogger<FirstController> logger, ProductService productServices)
        {
            _logger = logger;
            _productService = productServices;
        }
        public string Index()
        {
            //_logger.LogInformation("Index Action");
            _logger.Log(LogLevel.Warning, "Thong bao a");

            _logger.LogWarning("Thong bao");
            _logger.LogCritical("thong bao");
            Console.WriteLine("Index Action");
            return "Tôi là Index của First";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("Hi", "Xin chao cac ban");
        }

        public object abc() => new int[] { 1, 2, 3 };

        public IActionResult ReadMe()
        {
            string content = @"Hello,


             Đây là Ngoc";

            return Content(content,"text/html");
        }

        public IActionResult IOC()
        {
            //Startup.StringRootPath;
            string filePath = Path.Combine(Startup.StringRootPath,"Files","ioc.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }

        public IActionResult IphonePrice()
        {
            var iphoneP = new
            {
                name = "iphone5s",
                price = 5000
            };
            return Json(iphoneP);
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy","Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url); //url cần chuyển hướng là local
        }

        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("Chuyen huong den " + url); //url chuyển hướng không phải local
            return Redirect(url);
        }

        public IActionResult HelloView(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Khách";
            }
            //return View((object)userName);
            return View("xinchao3",userName);
        }

        [TempData]
        public string StatusMessage { get; set; }
        public IActionResult ViewProduct(int? id)
        {
            var productById = _productService.Where(p => p.Id == id).FirstOrDefault();
            if(productById == null)
            {
                //Truyen du lieu tu trang nay sang trang khac
                //Su dung section cua he thong de luu du lieu

                //TempData["StatusMessage"] = "Khong co san pham";
                StatusMessage = "San pham ban yeu cau khong co";
                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                //model
                //return View(productById);

                //viewData
                //this.ViewData["product"] = productById;
                //ViewData["Title"] = productById.Name;
                //return View("ViewProduct2");

                

                //ViewBag
                ViewBag.product = productById;
                return View("ViewProduct3");

                

            }
            
            //return Content($"San pham ID = {productById}");


        }
    } 
}
