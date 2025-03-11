using System.Runtime.Serialization;

namespace Arcabee.Dominio.libs.Excecoes
{
    [Serializable]
    public class RegistroNaoFoiEncontradoExcecao : RegraDeNegocioExcecao
    {
        public RegistroNaoFoiEncontradoExcecao(string nomeDoRegistro) : base(nomeDoRegistro + " informado(a) não foi encontrado(a)")
        {

        }

        protected RegistroNaoFoiEncontradoExcecao(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
