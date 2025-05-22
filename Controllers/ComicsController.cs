using Microsoft.AspNetCore.Mvc;
using MVCexamenComics.Repositories;
using MVCexamenComics.Models;

namespace MVCexamenComics.Controllers
{
    public class ComicsController: Controller
    {
        private RepositoryComics repo;

        public ComicsController(RepositoryComics repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Comic> comics = await repo.GetComicsAsync();
            return View(comics);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string imagen)
        {
            await repo.CreateComicAsync(nombre, imagen);
            return RedirectToAction("Index");
        }
    }
}
