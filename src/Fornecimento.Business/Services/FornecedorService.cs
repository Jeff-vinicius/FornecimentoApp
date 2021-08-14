using Fornecimento.Business.Interfaces;
using Fornecimento.Business.Models;
using Fornecimento.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        public async Task Add(Fornecedor fornecedor)
        {
            //Validar o estado da entidade 
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                && !ExecutarValidacao(new EnderecoValidation(),fornecedor.Endereco)) return;
        }

        public async Task Update(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;
        }

        public async Task UpdateEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
        }

        public async Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
