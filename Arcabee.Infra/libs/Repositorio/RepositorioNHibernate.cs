
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using System.Linq.Expressions;
using Arcabee.Dominio.libs.Consultas;
using Arcabee.Dominio.libs.Excecoes;
using Arcabee.Dominio.libs.Filtros.Enumeradores;
using Arcabee.Dominio.libs.Repositorios;
using NHibernate;
using NHibernate.Linq;

namespace Arcabee.Infra.libs.Repositorio
{
    public class RepositorioNHibernate<T> : IRepositorioNHibernate<T> where T : class
    {
        protected readonly ISession session;

        public RepositorioNHibernate(ISession session)
        {
            this.session = session;
        }

        public void Editar(T entidade)
        {
            session.Update(entidade);
        }

        public void Excluir(T entidade)
        {
            session.Delete(entidade);
        }

        public void Excluir(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                session.Delete(entidade);
            }
        }

        public void Inserir(T entidade)
        {
            session.Save(entidade);
        }

        public void Inserir(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                session.Save(entidade);
            }
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public IQueryable<T> QueryWithJoin(params Expression<Func<T, object>>[] entitySelectors)
        {
            if (entitySelectors == null || entitySelectors.Length == 0)
            {
                return Query();
            }

            var query = Query();

            foreach (var entitySelector in entitySelectors)
            {
                query = query.Fetch(entitySelector);
            }

            return query;
        }

        public PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd)
        {
            try
            {
                query = query.OrderBy(cpOrd + " " + tpOrd.ToString());
                return Paginar(query, qt, pg);
            }
            catch (ParseException)
            {
                throw new CampoParaOrdernacaoInformadoNaoEValidoExcecao(cpOrd);
            }
        }

        /// <summary>
        /// Método para paginar uma listagem de entidade, podendo ordenar por mais de um campo
        /// </summary>
        /// <param name="query">Query a ser paginada</param>
        /// <param name="qt">Quantidade</param>
        /// <param name="pg">Página</param>
        /// <param name="ordenacao">Tupla das ordenações</param>
        /// <typeparam name="T">Entidade da consulta</typeparam>
        /// <returns></returns>
        /// <exception cref="RegraDeNegocioExcecao"></exception>
        public PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, params (string, TipoOrdenacaoEnum)[] ordenacao)
        {
            try
            {
                string listaOrdenacao = string.Join(",", ordenacao.Select(x => x.Item1 + " " + x.Item2));
                query = query.OrderBy<T>(listaOrdenacao);
                return Paginar(query, qt, pg);
            }
            catch (ParseException)
            {
                string campos = string.Join(", ", ordenacao.Select(x => x.Item1));
                throw new CampoParaOrdernacaoInformadoNaoEValidoExcecao(campos);
            }
        }

        public T Recuperar(int id)
        {
            return session.Get<T>(id);
        }

        public T Recuperar(Expression<Func<T, bool>> expression)
        {
            return Query().Where(expression).SingleOrDefault();
        }

        public void Refresh(T entidade)
        {
            session.Refresh(entidade);
        }

        private static PaginacaoConsulta<T> Paginar(IQueryable<T> query, int qt, int pg)
        {
            return new PaginacaoConsulta<T>
            {
                Registros = query.Skip((pg - 1) * qt).Take(qt).ToList(),
                Total = query.LongCount(),
            };
        }

        public async Task InserirAsync(T entidade, CancellationToken cancelattionToken = default)
        {
            await session.SaveAsync(entidade, cancelattionToken);  
        }

        public async Task InserirAsync(IEnumerable<T> entidades, CancellationToken cancelattionToken = default)
        {
            foreach (T entidade in entidades)
            {
                await session.SaveAsync(entidade, cancelattionToken);
            }
        }

        public async Task EditarAsync(T entidade, CancellationToken cancelattionToken = default)
        {
            await session.UpdateAsync(entidade, cancelattionToken);
        }

        public async Task ExcluirAsync(T entidade, CancellationToken cancelattionToken = default)
        {
            await session.DeleteAsync(entidade, cancelattionToken);            
        }

        public async Task ExcluirAsync(IEnumerable<T> entidades, CancellationToken cancelattionToken = default)
        {
            foreach (T entidade in entidades)
            {
                await session.DeleteAsync(entidade, cancelattionToken);
            }
        }

        public async Task<T> RecuperarAsync(int id, CancellationToken cancelattionToken = default)
        {
            return await session.GetAsync<T>(id, cancelattionToken);
        }

        public async Task<T> RecuperarAsync(Expression<Func<T, bool>> expression, CancellationToken cancelattionToken = default)
        {
            return await Query().Where(expression).SingleOrDefaultAsync(cancelattionToken);
        }

        public async Task<PaginacaoConsulta<T>> ListarAsync(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd, CancellationToken cancelattionToken = default)
        {
            try
            {
                query = query.OrderBy(cpOrd + " " + tpOrd.ToString());
                return await PaginarAsync(query, qt, pg, cancelattionToken);
            }
            catch (ParseException)
            {
                throw new CampoParaOrdernacaoInformadoNaoEValidoExcecao(cpOrd);
            }
        }

        public async Task<PaginacaoConsulta<T>> ListarAsync(IQueryable<T> query, int qt, int pg,  (string, TipoOrdenacaoEnum)[] ordenacao, CancellationToken cancelattionToken = default)
        {
            try
            {
                string listaOrdenacao = string.Join(",", ordenacao.Select(x => x.Item1 + " " + x.Item2));
                query = query.OrderBy<T>(listaOrdenacao);
                return await PaginarAsync(query, qt, pg, cancelattionToken);
            }
            catch (ParseException)
            {
                string campos = string.Join(", ", ordenacao.Select(x => x.Item1));
                throw new CampoParaOrdernacaoInformadoNaoEValidoExcecao(campos);
            }
        }

        public async Task RefreshAsync(T entidade, CancellationToken cancelattionToken = default)
        {
            await session.RefreshAsync(entidade, cancelattionToken);
        }

        private async static Task<PaginacaoConsulta<T>> PaginarAsync(IQueryable<T> query, int qt, int pg, CancellationToken cancelattionToken = default)
        {
            return new PaginacaoConsulta<T>
            {
                Registros = await query.Skip((pg - 1) * qt).Take(qt).ToListAsync(cancelattionToken),
                Total = query.LongCount(),
            };
        }
    }
}