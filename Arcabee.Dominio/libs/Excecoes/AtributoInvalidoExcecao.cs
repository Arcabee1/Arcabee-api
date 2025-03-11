using System.Runtime.Serialization;

namespace Arcabee.Dominio.libs.Excecoes
{
    [Serializable]
    public class AtributoInvalidoExcecao : RegraDeNegocioExcecao
    {
        public AtributoInvalidoExcecao(string atributo) : base(atributo + " inválido")
        {
        }

        protected AtributoInvalidoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
