using System;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_AspNetCore.Controllers
{
    // localhost:5001/Equipe
    [Route("Equipes")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        
        [Route("Listar")]
        public IActionResult index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
            
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe NewEquipe = new Equipe();
            NewEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            NewEquipe.Name = form["Name"];
            NewEquipe.Image = form["Image"];

            equipeModel.Create(NewEquipe);
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}