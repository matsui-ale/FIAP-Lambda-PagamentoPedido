using Amazon.DynamoDBv2.DataModel;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.TechChallenge.LambdaPagamentoPedido.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Categoria : EntityBase
    {
        [DynamoDBProperty("nome")]
        public string Nome { get; set; }
    }
}
