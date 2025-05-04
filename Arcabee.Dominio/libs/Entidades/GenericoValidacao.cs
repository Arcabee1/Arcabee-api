using Arcabee.Dominio.libs.Excecoes;

namespace Arcabee.Dominio.libs.Entidades
{
    public static class GenericoValidacao
    {
        /// <summary>
        /// Implementação para validação de regra de negócio.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   seuObjeto.LancarRegraDeNegocioSe(x => x == true, "Mensagem de Exceção");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se a expressão retorna verdadeiro, se for dispara exceção.
        /// </summary>
        /// <param name="objeto">Referência do próprio objeto</param>
        /// <param name="expressao">Delegate do objeto que retorna um booleano</param>
        /// <param name="mensagemExcecao">Mensagem da exceção</param>
        /// <exception cref="RegraDeNegocioExcecao">
        /// Lançado quando o retorno da expressão é verdadeiro.
        /// </exception>
        public static void LancarRegraDeNegocioSe<T>(this T objeto, Func<T, bool> expressao, string mensagemExcecao)
        {
            if (expressao(objeto))
            {
                throw new RegraDeNegocioExcecao(mensagemExcecao);
            }
        }

        /// <summary>
        /// Implementação para validação de atributo inválido.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   seuObjeto.LancarAtributoInvalidoSe(x => x == true,"Descricao do Atributo");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se a expressão retorna verdadeiro, se for dispara exceção.
        /// </summary>
        /// <param name="objeto">Referência do próprio objeto</param>
        /// <param name="expressao">Delegate do objeto que retorna um booleano</param>
        /// <param name="descricaoAtributo">Descrição do atributo</param>
        /// <exception cref="AtributoInvalidoExcecao">
        /// Lançado quando o retorno da expressão é verdadeiro.
        /// </exception>
        public static void LancarAtributoInvalidoSe<T>(this T objeto, Func<T, bool> expressao, string descricaoAtributo)
        {
            if (expressao(objeto))
            {
                throw new AtributoInvalidoExcecao(descricaoAtributo);
            }
        }

        /// <summary>
        /// Implementação para validação de registro não encontrado.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   seuObjeto.ValidarRegistroNaoFoiEncontrado("Descricao do seu Objeto");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o objeto é nulo, se for dispara exceção.
        /// </summary>
        /// <param name="objeto">Referência do próprio objeto</param>
        /// <param name="descricaoRegistro">Descrição do registro</param>
        /// <exception cref="RegistroNaoFoiEncontradoExcecao">
        /// Lançado quando o objeto é nulo.
        /// </exception>
        public static void ValidarRegistroNaoFoiEncontrado<T>(this T objeto, string descricaoRegistro)
        {
            if (objeto == null)
            {
                throw new RegistroNaoFoiEncontradoExcecao(descricaoRegistro);
            }
        }

        /// <summary>
        /// Implementação para validação de registro não encontrado.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   seuObjeto.LancarRegistroNaoFoiEncontradoSe(x => x == true,"Descricao do seu Objeto");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se a expressão retorna verdadeiro, se for dispara exceção.
        /// </summary>
        /// <param name="objeto">Referência do próprio objeto</param>
        /// <param name="expressao">Delegate do objeto que retorna um booleano</param>
        /// <param name="descricaoRegistro">Descrição do registro</param>
        /// <exception cref="RegistroNaoFoiEncontradoExcecao">
        /// Lançado quando o retorno da expressão é verdadeiro.
        /// </exception>
        public static void LancarRegistroNaoFoiEncontradoSe<T>(this T objeto, Func<T, bool> expressao, string descricaoRegistro)
        {
            if (expressao(objeto))
            {
                throw new RegistroNaoFoiEncontradoExcecao(descricaoRegistro);
            }
        }
    }
}
