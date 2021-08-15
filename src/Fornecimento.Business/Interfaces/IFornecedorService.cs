using Fornecimento.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Business.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task Add(Fornecedor fornecedor);
        Task Update(Fornecedor fornecedor);
        Task Remove(Guid id);

        Task UpdateEndereco(Endereco endereco);

    }
}
