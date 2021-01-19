using System.Collections.Generic;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_E_PLayers.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {

        [TempData]
        public string Mensagem { get; set; }
        Player playerModel = new Player();

        public IActionResult Index()
        {
            return View();
        }

         [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
             List<string> csv = playerModel.ReadAllLinesCSV("Database/Player.csv");
            
            var logado = csv.Find(
                x =>
                x.Split(";")[2] == form["Email"] &&
                x.Split(";")[3] == form["Senha"]
            );

             if(logado != null)
            {
                HttpContext.Session.SetString("_Username", logado.Split(";")[1]);
                return LocalRedirect("~/");
            }
             Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

    }
        
}
