using Fornecimento.Business.Interfaces;
using Fornecimento.Business.Models;
using Fornecimento.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(FornecimentoDbContext context) : base(context) { }

        public async Task<Fornecedor> GetFornecedorAndEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> GetFornecedorAndProdutosAndEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
