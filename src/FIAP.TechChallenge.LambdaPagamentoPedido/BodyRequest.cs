using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.TechChallenge.LambdaPagamentoPedido
{
    [ExcludeFromCodeCoverage]
    public class BodyRequest
    {
        [JsonProperty("idPedido")]
        public Guid IdPedido { get; set; }

        [JsonProperty("qrcode")]
        public string QrCode { get; set; }

        [JsonProperty("statusPagamento")]
        public string StatusPagamento { get; set; }
    }
}
