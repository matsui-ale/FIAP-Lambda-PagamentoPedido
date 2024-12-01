using Amazon.DynamoDBv2.DataModel;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.TechChallenge.LambdaPagamentoPedido.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class FormaPagamento : EntityBase
    {
        [DynamoDBProperty("Nome")]
        public string Nome { get; set; }
    }
}
