using Microsoft.AspNetCore.Mvc;
using MVCexamenComics.Repositories;
using MVCexamenComics.Models;
using MVCexamenComics.Services;


namespace MVCexamenComics.Controllers
{
    public class ComicsController: Controller
    {
        private RepositoryComics repo;
        private ServiceStorageS3 service;

        public ComicsController(RepositoryComics repo, ServiceStorageS3 service)
        {
            this.repo = repo;
            this.service = service;
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
        public async Task<IActionResult> Create(string nombre, IFormFile file)
        {
            using(Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync
                (file.FileName, stream);
            }

            await repo.CreateComicAsync(nombre, file.FileName);
            return RedirectToAction("Index");
        }
    }
}
