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
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }


        public async Task Add(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Add(produto);
        }

        public async Task Update(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Update(produto);
        }

        public async Task Remove(Guid id)
        {
            await _produtoRepository.Remove(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
