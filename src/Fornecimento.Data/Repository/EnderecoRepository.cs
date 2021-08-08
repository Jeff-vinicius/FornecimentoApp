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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(FornecimentoDbContext context) : base(context) { }
        public async Task<Endereco> GetEnderecoByFornecedor(Guid FornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == FornecedorId);
        }
    }
}
