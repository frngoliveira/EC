using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DepartamentsController : Controller
    {
        private readonly IDepartamentService _departamentService;
        private readonly IMapper _mapper;
        public DepartamentsController(IDepartamentService departamentService, IMapper mapper)
        {
            _departamentService = departamentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var departament = await _departamentService.GetAll();
                return Ok(departament);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetById/{departamentId?}")]
        public async Task<IActionResult> GetById(int departamentId)
        {
            try
            {
                var departament = await _departamentService.GetById(departamentId);
                var result = _mapper.Map<Departaments>(departament);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(DepartamentDto _departament)
        {
            try
            {
                var departament = _mapper.Map<Departaments>(_departament);
                await _departamentService.Add(departament);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
            

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Departaments _departament)
        {
            try
            {
                await _departamentService.Update(_departament);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }
            
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Departaments _departament)
        {
            try
            {
                await _departamentService.Remove(_departament);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados Falhou {ex.Message}");
            }            
        }

    }
}
