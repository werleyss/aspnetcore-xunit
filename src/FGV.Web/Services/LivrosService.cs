using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGV.Web.Services
{
    public class LivrosService
    {
        public IEnumerable<Livros> ListaLivros()
        {
            Livros[] livros = {
                new Livros() { Id = 1, Titulo = "Java How to Program", Autor = "Deitel & Deitel", Edicao = "2007" },
                new Livros() { Id = 2, Titulo = "Patterns of Enterprise Application Architecture", Autor = "Martin Fowler", Edicao = "2002" },
                new Livros() { Id = 3, Titulo = "Head First Design Patterns", Autor = "Elisabeth Freeman", Edicao = "2004" },
                new Livros() { Id = 4, Titulo = "Internet & World Wide Web: How to  Program", Autor = "Deitel & Deitel", Edicao = "2007" }
            };

            return livros;
        }

        public List<Livros> OrdenarPorTitulo()
        {
            return ListaLivros().OrderBy(x => x.Titulo).ToList();
        }

        public List<Livros> OrdenarPorAutor()
        {
            return ListaLivros()
                .OrderBy(x => x.Autor)
                .ThenByDescending(x => x.Titulo).ToList();
        }

        public List<Livros> OrdenarPorEdicao()
        {
            return ListaLivros()
                 .OrderByDescending(x => x.Edicao)
                 .ThenByDescending(x => x.Autor)
                 .ThenBy(x => x.Titulo).ToList();
        }

        public string OrdenarNull(string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) throw new Exception();

            return orderBy;
        }

        public string OrdenarVazio(string orderBy)
        {
            if(string.IsNullOrEmpty(orderBy)) return string.Empty;

            throw new Exception();
        }


    }
}
