using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.Runtime.SharedInterfaces;
using Amazon.SQS;
using Amazon.SQS.Model;
using FIAP.TechChallenge.LambdaPagamentoPedido.Domain.Entities.Enum;
using FIAP.TechChallenge.LambdaPagamentoPedido.Infra.Data.Repositories;
using Newtonsoft.Json;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FIAP.TechChallenge.LambdaPagamentoPedido
{
    public class Function
    {
        private readonly IDynamoDBContext _context;
        private readonly IAmazonSQS amazonSQS;
        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public Function()
        {
            IAmazonDynamoDB amazonDynamo = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
            _context = new DynamoDBContext(amazonDynamo);
            amazonSQS = new AmazonSQSClient(RegionEndpoint.USEast1);
        }


        /// <summary>
        /// This method is called for every Lambda invocation. This method takes in an SQS event object and can be used 
        /// to respond to SQS messages.
        /// </summary>
        /// <param name="evnt">The event for the Lambda function handler to process.</param>
        /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
        /// <returns></returns>
        public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
        {
            foreach (var message in evnt.Records)
            {
                await ProcessMessageAsync(message, context);
            }

            //amazonSQS.DeleteMessageAsync(new DeleteMessageRequest() { QueueUrl });
        }

        private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
        {
            BodyRequest request = JsonConvert.DeserializeObject<BodyRequest>(message.Body);

            var repository = new PedidoRepository(_context);

            var pedido = await repository.GetById(request.IdPedido);

            pedido.StatusPagamento = Enum.Parse<StatusPagamento>(request.StatusPagamento);

            await repository.Update(pedido, request.IdPedido);

            await Task.CompletedTask;
        }
    }
}