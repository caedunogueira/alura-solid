using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        private readonly ILeilaoDao _dao;
        private readonly ICategoriaDao _categDao;

        public DefaultAdminService(ILeilaoDao dao, ICategoriaDao categoriaDao)
        {
            _dao = dao;
            _categDao = categoriaDao;
        }

        public void CadastrarLeilao(Leilao leilao) => _dao.Incluir(leilao);

        public IEnumerable<Categoria> ConsultaCategorias() => _categDao.BuscarTodos();

        public Leilao ConsultaLeilaoPorId(int id) => _dao.BuscarPorId(id);

        public IEnumerable<Leilao> ConsultaLeiloes() => _dao.BuscarTodos();

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = _dao.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _dao.Alterar(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = _dao.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Termino = DateTime.Now;
                _dao.Alterar(leilao);
            }
        }

        public void ModificarLeilao(Leilao leilao) => _dao.Alterar(leilao);

        public void RemoverLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
                _dao.Excluir(leilao);
        }
    }
}
