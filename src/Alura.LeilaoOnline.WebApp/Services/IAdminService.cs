using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IAdminService
    {
        public IEnumerable<Categoria> ConsultaCategorias();

        public IEnumerable<Leilao> ConsultaLeiloes();

        Leilao ConsultaLeilaoPorId(int id);

        void CadastrarLeilao(Leilao leilao);

        void ModificarLeilao(Leilao leilao);

        void RemoverLeilao(Leilao leilao);

        void IniciaPregaoDoLeilaoComId(int id);

        void FinalizaPregaoDoLeilaoComId(int id);
    }
}
