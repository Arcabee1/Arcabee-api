using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Arcabee.Dominio.libs.Consultas;
using Arcabee.Dominio.libs.Excecoes;
using Arcabee.Dominio.libs.Filtros;
using Arcabee.Dominio.libs.Filtros.Enumeradores;

namespace Arcabee.Dominio.libs.Extensions
{
    public static class PaginacaoExtension
    {
        /// <summary>
        /// Método para paginar uma listagem de entidade, igual ao método listar da classe 
        /// RepositorioNHibernate, seguindo as regras de paginação da Autoglass
        /// <br/><br/>
        /// Ao invés de usar:
        /// <code>
        /// var resultado = entidadesRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.tpOrd);
        /// </code>
        /// usar:
        /// <code>
        /// var resultado = query.Paginar(request.Qt, request.Pg, request.CpOrd, request.tpOrd);
        /// </code>
        /// </summary>
        /// <param name="lista">Lista a ser paginada</param>
        /// <param name="qt">Quantidade</param>
        /// <param name="pg">Página</param>
        /// <param name="cpOrd">Campo de Ordenação, utilizar as propriedades da classe</param>
        /// <param name="tpOrd">Tipo de Ordenação</param>
        /// <returns></returns>
        public static PaginacaoConsulta<T> Paginar<T>(this IQueryable<T> lista, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd) where T : class
        {
            PaginacaoConsulta<T> resultado = new PaginacaoConsulta<T>();
            try
            {
                lista = lista.OrderBy(cpOrd + " " + tpOrd);
                resultado.Registros = lista.Skip((pg - 1) * qt).Take(qt).ToList();
                resultado.Total = lista.LongCount();
                return resultado;
            }
            catch (ParseException)
            {
                throw new RegraDeNegocioExcecao($"Não foi possível ordenar a lista pelo campo ({cpOrd})");
            }
        }

        /// <summary>
        /// Método para paginar uma listagem de entidade, igual ao método listar da classe 
        /// RepositorioNHibernate, seguindo as regras de paginação da autoglass
        /// <br/><br/>
        /// Ao invés de usar:
        /// <code>
        /// var resultado = entidadesRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.tpOrd);
        /// </code>
        /// usar:
        /// <code>
        /// var resultado = query.Paginar(request);
        /// </code>
        /// </summary>
        /// <param name="query">Query a ser paginada</param>
        /// <param name="paginacaoFiltro">Classe padrão de filtros de paginação</param>
        /// <returns></returns>
        public static PaginacaoConsulta<T> Paginar<T>(this IQueryable<T> query, PaginacaoFiltro paginacaoFiltro) where T : class
        {
            return query.Paginar(paginacaoFiltro.Qt, paginacaoFiltro.Pg, paginacaoFiltro.CpOrd, paginacaoFiltro.TpOrd);
        }

        /// <summary>
        /// Método para paginar uma listagem de entidade ordenando por multiplos campos
        /// </summary>
        /// <param name="lista">Lista a ser paginada</param>
        /// <param name="qt">Quantidade</param>
        /// <param name="pg">Página</param>
        /// <param name="ordenacao">Tupla com campo de ordenação + tipo de ordenação</param>
        /// <returns></returns>
        /// <exception cref="RegraDeNegocioExcecao"></exception>
        public static PaginacaoConsulta<T> Paginar<T>(this IQueryable<T> lista, int qt, int pg, params (string, TipoOrdenacaoEnum)[] ordenacao) where T : class
        {
            PaginacaoConsulta<T> resultado = new PaginacaoConsulta<T>();
            try
            {
                string listaOrdenacao = string.Join(",", ordenacao.Select(x => $"{x.Item1} {x.Item2}"));
                lista = lista.OrderBy(listaOrdenacao);
                resultado.Registros = lista.Skip((pg - 1) * qt).Take(qt).ToList();
                resultado.Total = lista.LongCount();
                return resultado;
            }
            catch (ParseException)
            {
                IEnumerable<string> campos = ordenacao?.Select(x => x.Item1).ToList();
                if (campos?.Count() > 0)
                    throw new RegraDeNegocioExcecao($"Não foi possível ordenar a lista pelo(s) campo(s) ({string.Join(",", campos)})");
                throw new RegraDeNegocioExcecao("Não foi encontrado nenhum campo para realizar a ordenação da lista");
            }
        }

        /// <summary>
        /// Método para paginar uma query de entidade, retorna uma query paginada 
        /// </summary>
        /// <param name="query">Query a ser paginada</param>
        /// <param name="qt">Quantidade</param>
        /// <param name="pg">Página</param>
        /// <param name="cpOrd">Campo de Ordenação, utilizar as propriedades da classe</param>
        /// <param name="tpOrd">Tipo de Ordenação</param>
        /// <returns></returns>
        public static IQueryable<T> PaginarSimples<T>(this IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd) where T : class
        {
            try
            {
                query = query.OrderBy(cpOrd + " " + tpOrd);
                return query.Skip((pg - 1) * qt).Take(qt);
            }
            catch (ParseException)
            {
                throw new RegraDeNegocioExcecao($"Não foi possível ordenar a lista pelo campo ({cpOrd})");
            }
        }

        /// <summary>
        /// Método para paginar uma query de entidade, retorna uma query paginada 
        /// </summary>
        /// <param name="query">Query a ser paginada</param>
        /// <param name="paginacaoFiltro">Classe padrão de filtros de paginação</param>
        /// <returns></returns>
        public static IQueryable<T> PaginarSimples<T>(this IQueryable<T> query, PaginacaoFiltro paginacaoFiltro) where T : class
        {
            return query.PaginarSimples(paginacaoFiltro.Qt, paginacaoFiltro.Pg, paginacaoFiltro.CpOrd, paginacaoFiltro.TpOrd);
        }
    }
}