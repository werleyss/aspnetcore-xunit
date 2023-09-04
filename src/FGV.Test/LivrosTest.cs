using FGV.Web;
using FGV.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FGV.Test
{
    public class LivrosTest
    {
        private readonly LivrosService _livrosService;

        public LivrosTest()
        {
            _livrosService = new LivrosService();
        }

        [Fact]
        public void OrderByTituloAsc()
        {
            var listaLivros = _livrosService.OrdenarPorTitulo();

            var listaEsperada = _livrosService.ListaLivros().OrderBy(x => x.Titulo).ToList();

            Assert.True(listaEsperada.Select(x => x.Id).SequenceEqual(listaLivros.Select(x => x.Id)));
        }

        [Fact]
        public void OrderByAutorAscTituloDesc()
        {
            var listaLivros = _livrosService.OrdenarPorAutor();

            var listaEsperada = _livrosService.ListaLivros().OrderBy(x => x.Autor).ThenByDescending(x => x.Titulo).ToList();

            Assert.True(listaEsperada.Select(x => x.Id).SequenceEqual(listaLivros.Select(x => x.Id)));

        }

        [Fact]
        public void OrderByEdicaoAscAutorDescTituloAsc()
        {
            var listaLivros = _livrosService.OrdenarPorEdicao();

            var listaEsperada = _livrosService.ListaLivros().OrderByDescending(x => x.Edicao).ThenByDescending(x => x.Autor).ThenBy(x => x.Titulo).ToList();

            Assert.True(listaEsperada.Select(x => x.Id).SequenceEqual(listaLivros.Select(x => x.Id)));
        }

        [Fact]
        public void OrderByNull()
        {
            Assert.Throws<Exception>(() => _livrosService.OrdenarNull(null));
        }

        [Fact]
        public void OrderByVazio()
        {
            Assert.Empty(_livrosService.OrdenarVazio(""));
        }

    }
}