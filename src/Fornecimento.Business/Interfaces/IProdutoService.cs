using Fornecimento.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Business.Interfaces
{
    public interface IProdutoService
    {
        Task Add(Produto fornecedor);
        Task Update(Produto fornecedor);
        Task Remove(Guid id);
    }
}
