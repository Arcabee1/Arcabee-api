using System.Runtime.Serialization;

namespace Arcabee.Dominio.libs.Excecoes
{
    [Serializable]
    public class AtributoObrigatorioExcecao : RegraDeNegocioExcecao
    {
        public AtributoObrigatorioExcecao(string atributo) : base(atributo + " é obrigatório")
        {

        }

        protected AtributoObrigatorioExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
