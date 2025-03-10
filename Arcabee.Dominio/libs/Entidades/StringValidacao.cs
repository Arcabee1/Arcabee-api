using Arcabee.Dominio.libs.Excecoes;

namespace Arcabee.Dominio.libs.Entidades
{
    public static class StringValidacao
    {
        /// <summary>
        /// Implementação para validação de atributo obrigatório.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   string.ValidarAtributoObrigatorio("Descricao do Atributo");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o atributo é nulo ou espaço em branco, se for dispara exceção.
        /// </summary>
        /// <exception cref="AtributoObrigatorioExcecao">
        /// Lançado quando o atributo informado é nulo ou espaço em branco.
        /// </exception>
        public static void ValidarAtributoObrigatorio(this string valor, string descricaoAtributo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new AtributoObrigatorioExcecao(descricaoAtributo);
            }
        }

        /// <summary>
        /// Implementação para validação de tamanho máximo do atributo.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   string.ValidarTamanhoMaximoDoAtributo("Descricao do Atributo", 100);
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o tamanho do atributo é maior que o tamanho máximo informado, se for dispara exceção.
        /// </summary>
        /// <exception cref="TamanhoDeAtributoInvalidoExcecao">
        /// Lançado quando o tamanho do atributo é maior que o tamanho máximo informado.
        /// </exception>
        public static void ValidarTamanhoMaximoDoAtributo(this string valor, string descricaoAtributo, int tamanhoMaximo)
        {
            if (valor.Length > tamanhoMaximo)
            {
                throw new TamanhoDeAtributoInvalidoExcecao(descricaoAtributo, 0, tamanhoMaximo);
            }
        }

        /// <summary>
        /// Implementação para validação de tamanho mínimo do atributo.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   string.ValidarTamanhoMinimoDoAtributo("Descricao do Atributo", 1);
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o tamanho do atributo é menor que o tamanho mínimo informado, se for dispara exceção.
        /// </summary>
        /// <exception cref="TamanhoDeAtributoInvalidoExcecao">
        /// Lançado quando o tamanho do atributo é menor que o tamanho mínimo informado.
        /// </exception>
        public static void ValidarTamanhoMinimoDoAtributo(this string valor, string descricaoAtributo, int tamanhoMinimo)
        {
            if (valor.Length < tamanhoMinimo)
            {
                throw new TamanhoDeAtributoInvalidoExcecao(descricaoAtributo, tamanhoMinimo, 0);
            }
        }

        /// <summary>
        /// Implementação para validação de atributo obrigatório e, caso informados, tamanho máximo e mínimo do atributo.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///  -- Somente atributo obrigatório
        ///   string.ValidarAtributos("Descricao do Atributo");
        ///  -- OU atributo obrigatório E tamanho máximo
        ///   string.ValidarAtributos("Descricao do Atributo", 10);
        ///  -- OU atributo obrigatório E tamanho mínimo
        ///   string.ValidarAtributos("Descricao do Atributo", 0, 1);
        ///  -- OU todas validações
        ///   string.ValidarAtributos("Descricao do Atributo", 10, 1);
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o atributo é nulo ou espaço em branco, se for dispara exceção.
        /// <br></br>
        /// Validar se o tamanho do atributo é maior que o tamanho máximo informado, se for dispara exceção.
        /// <br></br>
        /// Validar se o tamanho do atributo é menor que o tamanho mínimo informado, se for dispara exceção.
        /// </summary>
        /// <exception cref="AtributoObrigatorioExcecao">
        /// Lançado quando o atributo informado é nulo ou espaço em branco.
        /// </exception>
        /// <exception cref="TamanhoDeAtributoInvalidoExcecao">
        /// Lançado quando o tamanho do atributo é maior que o tamanho máximo informado.
        /// Lançado quando o tamanho do atributo é menor que o tamanho mínimo informado.
        /// </exception>
        public static void ValidarAtributos(this string valor, string descricaoAtributo, int tamanhoMaximo = 0, int tamanhoMinimo = 0)
        {
            ValidarAtributoObrigatorio(valor, descricaoAtributo);
            if (tamanhoMaximo > 0)
                ValidarTamanhoMaximoDoAtributo(valor, descricaoAtributo, tamanhoMaximo);
            if (tamanhoMinimo > 0)
                ValidarTamanhoMinimoDoAtributo(valor, descricaoAtributo, tamanhoMinimo);
        }
    }
}
