using Arcabee.Dominio.libs.Excecoes;

namespace Arcabee.Dominio.libs.Entidades
{
    public static class NumericoValidacao
    {
        /// <summary>
        /// Implementação para validação de atributo obrigatório.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   decimal.ValidarAtributoObrigatorio("Descricao do Atributo");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o atributo informado e menor ou igual a zero, se for dispara exceção.
        /// </summary>
        /// <exception cref="AtributoObrigatorioExcecao">
        /// Lançado quando o atributo informado for menor ou igual a zero.
        /// </exception>
        public static void ValidarAtributoObrigatorio(this decimal valor, string descricaoAtributo)
        {
            if (valor <= 0)
            {
                throw new AtributoObrigatorioExcecao(descricaoAtributo);
            }
        }

        /// <summary>
        /// Implementação para validação de atributo obrigatório.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   int.ValidarAtributoObrigatorio("Descricao do Atributo");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o atributo informado e menor ou igual a zero, se for dispara exceção.
        /// </summary>
        /// <exception cref="AtributoObrigatorioExcecao">
        /// Lançado quando o atributo informado for menor ou igual a zero.
        /// </exception>
        public static void ValidarAtributoObrigatorio(this int valor, string descricaoAtributo)
        {
            ValidarAtributoObrigatorio((decimal)valor, descricaoAtributo);
        }

        /// <summary>
        /// Implementação para validação de atributo obrigatório.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   long.ValidarAtributoObrigatorio("Descricao do Atributo");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o atributo informado e menor ou igual a zero, se for dispara exceção.
        /// </summary>
        /// <exception cref="AtributoObrigatorioExcecao">
        /// Lançado quando o atributo informado for menor ou igual a zero.
        /// </exception>
        public static void ValidarAtributoObrigatorio(this long valor, string descricaoAtributo)
        {
            ValidarAtributoObrigatorio((decimal)valor, descricaoAtributo);
        }

        /// <summary>
        /// Implementação para validação de atributo obrigatório.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   float.ValidarAtributoObrigatorio("Descricao do Atributo");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o atributo informado e menor ou igual a zero, se for dispara exceção.
        /// </summary>
        /// <exception cref="AtributoObrigatorioExcecao">
        /// Lançado quando o atributo informado for menor ou igual a zero.
        /// </exception>
        public static void ValidarAtributoObrigatorio(this float valor, string descricaoAtributo)
        {
            ValidarAtributoObrigatorio((decimal)valor, descricaoAtributo);
        }

        /// <summary>
        /// Implementação para validação de atributo obrigatório.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   double.ValidarAtributoObrigatorio("Descricao do Atributo");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o atributo informado e menor ou igual a zero, se for dispara exceção.
        /// </summary>
        /// <exception cref="AtributoObrigatorioExcecao">
        /// Lançado quando o atributo informado for menor ou igual a zero.
        /// </exception>
        public static void ValidarAtributoObrigatorio(this double valor, string descricaoAtributo)
        {
            ValidarAtributoObrigatorio((decimal)valor, descricaoAtributo);
        }        
    }
}
