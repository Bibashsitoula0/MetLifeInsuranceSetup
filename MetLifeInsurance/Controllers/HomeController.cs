using MetLifeInsurance.Helpers;
using MetLifeInsurance.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OfficeOpenXml;
using System.Data;
using System.Diagnostics;

namespace MetLifeInsurance.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager; 
        }
       
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated != true)
            {
                return Redirect("/Identity/Account/Login");
            }
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

       /* [Route("ats/detail/export")]
        public async Task<ActionResult> getdata()
        {
            try
            {
                var data = await _homeRepository.GetAll();
                var op = data;

                DataTable datatable = new DataTable();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //datatable.Columns.Add("sn");
                datatable.Columns.Add("Id");
                datatable.Columns.Add("Full Name");
                datatable.Columns.Add("Email");

                for (int i = 0; i < data.Count; i++)
                {
                    datatable.Rows.Add(

                       data[i].Id,
                       data[i].UserName,
                       data[i].Email
                       );
                }

                var heading = "";
                var heading1 = "";
                var heading2 = "";
                var heading3 = "";
                byte[] filecontent = ExcelExportHelper.ExportExcel(datatable, heading, heading1, heading2, heading3, true);

                return File(filecontent, ExcelExportHelper.ExcelContentType, "Record.xlsx");
            }
            catch (Exception ex)
            {
                return View();
            }
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}