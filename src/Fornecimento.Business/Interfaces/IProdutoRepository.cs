using Fornecimento.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutosByFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> GetProdutosAndFornecedores();
        Task<Produto> GetProdutoAndFornecedor(Guid id);

    }
}
