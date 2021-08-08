using Fornecimento.Business.Interfaces;
using Fornecimento.Business.Models;
using Fornecimento.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(FornecimentoDbContext context) : base(context) { }

        public async Task<Produto> GetProdutoAndFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAndFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutosByFornecedor(Guid fornecedorId)
        {
            return await Search(p => p.FornecedorId == fornecedorId);
        }
    }
}
