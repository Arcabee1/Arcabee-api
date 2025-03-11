using Arcabee.Dominio.libs.Excecoes;

namespace Arcabee.Dominio.libs.Entidades
{
    public static class ObjetoValidacao
    {
        /// <summary>
        /// Implementação para validação de atributo obrigatório.
        /// <example>
        /// <para>Exemplo:</para>
        /// <code>
        ///   object.ValidarAtributoObrigatorio("Descricao do Atributo");
        /// </code>
        /// </example>
        /// <br></br>
        /// Validar se o objeto é nulo, se for dispara exceção.
        /// </summary>
        /// <exception cref="AtributoObrigatorioExcecao">
        /// Lançado quando o objeto é nulo.
        /// </exception>
        public static void ValidarAtributoObrigatorio(this object valor, string descricaoAtributo)
        {
            if (valor == null)
            {
                throw new AtributoObrigatorioExcecao(descricaoAtributo);
            }
        }
    }
}
