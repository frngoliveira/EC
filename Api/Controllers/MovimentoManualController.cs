using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MovimentoManualController : Controller
    {
        private readonly IMovimentoManualService _movimentoManualService;
        private readonly IProdutoCosifService _produtoCosifService;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public MovimentoManualController(IMovimentoManualService movimentoManualService,
                                         IProdutoCosifService produtoCosifService,
                                         IProdutoService produtoService,
                                         IMapper mapper)
        {
            _movimentoManualService = movimentoManualService;
            _produtoCosifService = produtoCosifService;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetProdutoAll")]
        public async Task<IActionResult> GetProdutoAll()
        {
            try
            {
                var produto = await _produtoService.GetAll();
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetProdutoCosifAll")]
        public async Task<IActionResult> GetProdutoCosifAll()
        {
            try
            {
                var prudutoCosif = await _produtoCosifService.GetAll();
                return Ok(prudutoCosif);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAllMovimentoManual")]
        public async Task<IActionResult> GetAllMovimentoManual()
        {
            try
            {
                var movimentoManual = await _movimentoManualService.GetAll();
                return Ok(movimentoManual);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(MOVIMENTO_MANUAL_DTO _movimentoManual)
        {
            try
            {
                var movimento = await _movimentoManualService.GetAll();

                var c = movimento.Count();

                _movimentoManual.COD_USUARIO = "Teste";
                _movimentoManual.DAT_MOVIMENTO = DateTime.Now;
                _movimentoManual.NUM_LANCAMENTO = c + 1;

                var movimentoManual = _mapper.Map<MOVIMENTO_MANUAL>(_movimentoManual);

                
                await _movimentoManualService.Add(movimentoManual);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }

        }        
    }
}
