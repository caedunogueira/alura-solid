using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IProdutoService
    {
        public IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo);

        public IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao();

        public Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id);
    }
}
