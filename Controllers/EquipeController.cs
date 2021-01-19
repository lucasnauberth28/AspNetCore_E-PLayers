using System;
using System.IO;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eplayers_AspNetCore.Controllers
{
    // localhost:5001/Equipe
    [Route("Equipes")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        
        // [Route("Listar")]
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

            if(form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                NewEquipe.Image = file.FileName;
            }
            else
            {
               NewEquipe.Image = "padrao.png";
            }

            equipeModel.Create(NewEquipe);

            ViewBag.equipe = equipeModel.ReadAll();
            return LocalRedirect ("~/Equipes");
        }

        [Route("Equipe/{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipes");
        }
        
    }
}