using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FormularioIgv.Models;

namespace FormularioIgv.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto objProducto)
        {
            Double resultado = 0.0;
            Double total = 0.0;
            String message1 ="";
            String message2 ="";
             String message3 ="";

            total = objProducto.Precio * objProducto.Cantidad;

            resultado = total * 1.18;

            message1 = "El Precio del Producto es: " + total;
            message2 = "El Precio del Producto con IGV es: " + resultado;
            message3 = "Usted Buscó: " + objProducto.Nombre + " - " + objProducto.DatosProducto;


            ViewData["Message1"] = message1;
            ViewData["Message2"] = message2;
            ViewData["Message3"] = message3;
            return View("Index");            
        }

    }
}