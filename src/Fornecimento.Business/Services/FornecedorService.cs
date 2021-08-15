using Fornecimento.Business.Interfaces;
using Fornecimento.Business.Models;
using Fornecimento.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecimento.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Add(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(),fornecedor.Endereco)) return;

            if (_fornecedorRepository.Search(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return;
            }

            await _fornecedorRepository.Add(fornecedor);
        }

        public async Task Update(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Search(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return;
            }

            await _fornecedorRepository.Update(fornecedor);
        }

        public async Task UpdateEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Update(endereco);
        }

        public async Task Remove(Guid id)
        {
            if (_fornecedorRepository.GetFornecedorAndProdutosAndEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            var endereco = await _enderecoRepository.GetEnderecoByFornecedor(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remove(endereco.Id);
            }

            await _fornecedorRepository.Remove(id);

            await _fornecedorRepository.Remove(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
