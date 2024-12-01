﻿using Amazon.DynamoDBv2.DataModel;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.TechChallenge.LambdaPagamentoPedido.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class EntityBase
    {
        [DynamoDBProperty("id")]
        public int Id { get; set; }
    }
}
