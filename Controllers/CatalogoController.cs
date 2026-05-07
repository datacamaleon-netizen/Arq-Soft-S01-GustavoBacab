using Microsoft.AspNetCore.Mvc;
using Catalogo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        // Esta es la lista de datos en memoria
        private static List<Videojuego> juegos = new List<Videojuego>
        {
            new Videojuego { Id = 1, Titulo = "Elden Ring", Genero = "RPG", Consola = "PC", Anio = 2022, Descripcion = "Un mundo abierto épico." },
            new Videojuego { Id = 2, Titulo = "Halo", Genero = "Shooter", Consola = "Xbox", Anio = 2001, Descripcion = "Clásico de disparos." },
            new Videojuego { Id = 3, Titulo = "Zelda: BotW", Genero = "Aventura", Consola = "Switch", Anio = 2017, Descripcion = "Exploración pura." },
            new Videojuego { Id = 4, Titulo = "Final Fantasy VII", Genero = "RPG", Consola = "PS5", Anio = 2020, Descripcion = "Remake del clásico." },
            new Videojuego { Id = 5, Titulo = "Minecraft", Genero = "Aventura", Consola = "PC", Anio = 2011, Descripcion = "Construcción infinita." }
        };

        // Acción para la lista principal
        public IActionResult Index(string genero)
        {
            var listaMostrar = juegos;

            if (!string.IsNullOrEmpty(genero))
            {
                listaMostrar = juegos.Where(j => j.Genero == genero).ToList();
            }

            return View(listaMostrar);
        }

        // Acción para ver el detalle de un juego
        public IActionResult Detalle(int id)
        {
            var juego = juegos.FirstOrDefault(j => j.Id == id);
            return View(juego);
        }
    }
}
