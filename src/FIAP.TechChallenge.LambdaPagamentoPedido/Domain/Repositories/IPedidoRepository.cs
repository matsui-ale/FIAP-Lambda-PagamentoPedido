using FIAP.TechChallenge.LambdaPagamentoPedido.Domain.Entities;
using FIAP.TechChallenge.LambdaPagamentoPedido.Domain.Entities.Enum;

namespace FIAP.TechChallenge.LambdaPagamentoPedido.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> Post(Pedido pedido);
        Task Update(Pedido pedido, Guid Id);
        Task<Pedido> GetById(Guid Id);
        Task<IList<Pedido>> GetAll();
        Task<IList<Pedido>> GetFiltrados();
        Task<IList<Pedido>> GetByStatus(StatusPedido status);
    }
}
