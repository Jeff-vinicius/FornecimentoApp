using Fornecimento.Business.Interfaces;
using Fornecimento.Business.Models;
using Fornecimento.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public async Task Add(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        }

        public async Task Update(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        }

        public async Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
