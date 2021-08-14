using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fornecimento.App.ViewModels;
using Fornecimento.Business.Interfaces;
using AutoMapper;
using Fornecimento.Business.Models;

namespace Fornecimento.App.Controllers
{
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IMapper mapper,
                                      IEnderecoRepository enderecoRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
        }


        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await GetFornecedorAndEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorRepository.Add(fornecedor);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = await GetFornecedorAndProdutosAndEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }
            return View(fornecedorViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorRepository.Update(fornecedor);

            return RedirectToAction("Index");  
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await GetFornecedorAndEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedorViewModel = await GetFornecedorAndEndereco(id);

            if (fornecedorViewModel == null) return NotFound();

            await _fornecedorRepository.Remove(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetEndereco(Guid id)
        {
            var fornecedor = await GetFornecedorAndEndereco(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsEndereco", fornecedor);
        }

        public async Task<IActionResult> UpdateEndereco(Guid id)
        {
            var fornecedor = await GetFornecedorAndEndereco(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return PartialView("_UpdateEndereco", new FornecedorViewModel { Endereco = fornecedor.Endereco });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEndereco(FornecedorViewModel fornecedorViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Documento");
            
            if (!ModelState.IsValid) return PartialView("_UpdateEndereco", fornecedorViewModel);

            await _enderecoRepository.Update(_mapper.Map<Endereco>(fornecedorViewModel.Endereco));

            var url = Url.Action("GetEndereco", "Fornecedores", new { id = fornecedorViewModel.Endereco.FornecedorId });
            return Json(new { success = true, url });
        }

        private async Task<FornecedorViewModel> GetFornecedorAndEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.GetFornecedorAndEndereco(id));
        }

        private async Task<FornecedorViewModel> GetFornecedorAndProdutosAndEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.GetFornecedorAndProdutosAndEndereco(id));
        }
    }
}
