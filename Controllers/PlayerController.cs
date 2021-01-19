using System;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_E_PLayers.Controllers
{
    [Route("Player")]
    public class PlayerController : Controller
    {

        Player playerModel = new Player();
        public IActionResult Index()
        {
            ViewBag.players = playerModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar (IFormCollection form)
        {
            Player newPlayer = new Player();
            newPlayer.IdPlayer = Int32.Parse(form ["IdPlayer"]);
            newPlayer.IdEquipe =  Int32.Parse(form["IdEquipe"]);
            newPlayer.Name = form["Nome"];
            newPlayer.Email = form["Email"];
            newPlayer.Senha = form["Senha"];

            playerModel.Create(newPlayer);
            ViewBag.Players = playerModel.ReadAll();

            return LocalRedirect("~/Player");
        }
    }

    
}