using Fornecimento.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> GetFornecedorAndEndereco(Guid id);
        Task<Fornecedor> GetFornecedorAndProdutosAndEndereco(Guid id);
    }
}
