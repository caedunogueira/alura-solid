using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class LeilaoDaoComEfCore : ILeilaoDao
    {
        private readonly AppDbContext _context;

        public LeilaoDaoComEfCore() => _context = new AppDbContext();

        public IEnumerable<Categoria> BuscarCategorias() => _context.Categorias.ToList();

        public IEnumerable<Leilao> BuscarTodos() =>
            _context.Leiloes
            .Include(l => l.Categoria)
            .ToList();

        public Leilao BuscarPorId(int id) => _context.Leiloes.First(l => l.Id == id);

        public void Incluir(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Alterar(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
