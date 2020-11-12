using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class CategoriaDaoComEfCore : ICategoriaDao
    {
        private readonly AppDbContext _context;

        public CategoriaDaoComEfCore() => _context = new AppDbContext();

        public Categoria BuscarPorId(int id) => _context.Categorias.First(c => c.Id == id);

        public IEnumerable<Categoria> BuscarTodos() => _context.Categorias.ToList();
    }
}
