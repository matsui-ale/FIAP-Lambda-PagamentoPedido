using Amazon.DynamoDBv2.DataModel;
using FIAP.TechChallenge.LambdaPagamentoPedido.Domain.Entities;

namespace FIAP.TechChallenge.LambdaPagamentoPedido.Infra.Data.Repositories
{
    public class PedidoRepository
    {
        private readonly IDynamoDBContext _context;

        public PedidoRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<Pedido> GetById(Guid Id)
        {
            try
            {
                return await _context.LoadAsync<Pedido>(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar pedido {Id}. {ex}");
            }
        }
        public async Task Update(Pedido pedido, Guid Id)
        {
            try
            {
                await _context.SaveAsync(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar pedido. {ex}");
            }
        }
    }
}
