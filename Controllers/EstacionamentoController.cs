using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cadastro.Data;
using Cadastro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Controllers
{
    [Authorize(Roles = "2")]
    [ApiController]
    [Route("[Controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EstacionamentoController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        private int ObterUsuarioId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        private string ObterPerfilUsuario()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Estacionamento e = await _context.Estacionamentos
                .Include(user => user.Usuario)
                .Include(v => v.Vagas).ThenInclude(vs => vs.Sensor)
                .FirstOrDefaultAsync(eBusca => eBusca.Id == id);

                return Ok(e);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Estacionamento> lista = await _context.Estacionamentos
                .Include(user => user.Usuario)
                .Include(v => v.Vagas).ThenInclude(vs => vs.Sensor)
                .ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Estacionamento novoEstacionamento)
        {
            try
            {
                if (novoEstacionamento.Nome == null)
                {
                    throw new System.Exception("O nome não pode estar vazio");
                }

                novoEstacionamento.Usuario = _context.Usuarios
                .FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());

                await _context.Estacionamentos.AddAsync(novoEstacionamento);
                await _context.SaveChangesAsync();

                return Ok(novoEstacionamento.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPut]
        public async Task<IActionResult> Update(Estacionamento novoEstacionamento)
        {
            try
            {
                if (novoEstacionamento.Nome == null)
                {
                    throw new System.Exception("O nome não pode estar vazio");
                }

                novoEstacionamento.Usuario = _context.Usuarios.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());
                
                _context.Estacionamentos.Update(novoEstacionamento);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Estacionamento eRemover = await _context.Estacionamentos.FirstOrDefaultAsync(p => p.Id == id);

                _context.Estacionamentos.Remove(eRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}