using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using SweetBakery.Models.Entities;
using SweetBakery.Models.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace SweetBakery.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("~/Productos")]
        public IActionResult Productos()
        {
            SweetbakeryContext context = new();
            var data = context.Categorias.OrderBy(x=>x.Nombre).Select(x => new ProductosViewModel
            {
              
                Categoria = x.Nombre,
                Postres = x.Productos.OrderBy(x=>x.Nombre).Select(x => new PostreModel
                {
                    Id=x.Id,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion
                })
            });
            return View(data);
        }

        [Route("~/Recetas")]
        public IActionResult Recetas()
        {
            SweetbakeryContext context = new();
            RecetasViewModel vm = new();
            vm.Recetas = context.Recetas.Select(x => new RecetaModel
            {

                Id = x.Id,
                Descripcion = x.Descripcion ?? "",
                Nombre = x.Nombre ?? ""
            });
            return View(vm);
        }

        [Route("~/Receta/{id}")]
        public IActionResult Receta(string id)
        {
            SweetbakeryContext context = new();
            id = id.Replace("-"," ");
            var receta = context.Recetas.Where(x => x.Nombre == id).
               Select(x => new RecetaViewModel()
               {
                   Id = x.Id,
                   Ingredientes = x.Ingredientes,
                   Nombre = x.Nombre,
                   Procedimiento = x.Procedimiento,
                   Reseña = x.Reseña,
               }).FirstOrDefault();

            if (receta == null)
            {
                return RedirectToAction("Recetas");
            }

            Random r = new();
            receta.Recetas = context.Recetas.OrderBy(x => EF.Functions.Random()).Take(3)
                .Select(x => new RecetaModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre??""
                });

            return View(receta);
        }
    }
}
