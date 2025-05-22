using Microsoft.EntityFrameworkCore;
using MVCexamenComics.Data;
using MVCexamenComics.Models;

namespace MVCexamenComics.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        public async Task<List<Comic>> GetComicsAsync()
        {
            return await context.Comics.ToListAsync();
        }

        public async Task<int> GetMaxId()
        {
            return await context.Comics.MaxAsync(c => c.Id);
        }

        public async Task CreateComicAsync(string nombre, string imagen)
        {
            Comic c = new Comic
            {
                Id = await GetMaxId() + 1,
                Nombre = nombre,
                Imagen = imagen
            };
            context.Comics.Add(c);
            await context.SaveChangesAsync();
        }
    }
}
