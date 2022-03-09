using AppAngelLinan.DBContext;
using AppAngelLinan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAngelLinan.Controllers
{
    public class ClienteController : Controller
    {
        private readonly BdangellinanContext _context;

        public ClienteController(BdangellinanContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            var list = _context.Clientes
                .Include(x => x.Pais)
                .Select( x => new 
                { 
                    Id = x.Id,
                    Nombre = x.Nombre, 
                    Pais = x.Pais.Nombre, 
                    TipoEntidad = (x.TipoEntidad == "I" ? "Individuo" : "Compañia")
                }).ToList();
            return Json( new { data = list});
        }

        public JsonResult ListarPaises()
        {
            List<Paises> list = _context.Paises.ToList();
            return Json(list);
        }

        [HttpPost]
        public JsonResult Guardar([FromBody] Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Json(new { data = true });
        }

        [HttpDelete]
        public JsonResult Eliminar(int id)
        {
            _context.Clientes.Remove(_context.Clientes.Where(x => x.Id == id).FirstOrDefault());
            _context.SaveChanges();
            return Json(new { data = true });
        }
    }
}
