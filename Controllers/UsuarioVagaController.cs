using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Data;
using Cadastro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacioneJaApi.Controllers
{
    [Authorize(Roles = "2")]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioVagaController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UsuarioVagaController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> addUsuarioVaga (UsuarioVaga novoUsuarioVaga)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                .Include(u => u.UsuarioVagas).ThenInclude(uv => uv.Vaga)
                .FirstOrDefaultAsync(u => u.Id == novoUsuarioVaga.UsuarioId);

                if (usuario == null)
                    throw new System.Exception("Usuaro não encontrado para o Id Informado.");

                Vaga vaga = await _context.Vagas
                .FirstOrDefaultAsync(v => v.Id == novoUsuarioVaga.VagaId);

                if (vaga == null)
                    throw new System.Exception("Vaga não encontrada.");

                UsuarioVaga uv = new UsuarioVaga();
                uv.Usuario = usuario;
                uv.Vaga = vaga;
                await _context.UsuarioVagas.AddAsync(uv);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetVagaUsuario(int usuarioId)
        {
            try
            {
                List<UsuarioVaga> uvLista = new List<UsuarioVaga>();
                uvLista = await _context.UsuarioVagas
                .Include(p => p.Usuario)
                .Include(p => p.Vaga)
                .Where(p => p.Usuario.Id == usuarioId).ToListAsync();
                return Ok(uvLista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetVagas")]
        public async Task<IActionResult> GetVagas()
        {
            try
            {
                List<Vaga> vagas = new List<Vaga>();
                vagas = await _context.Vagas.ToListAsync();
                return Ok(vagas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteUsuarioVaga")]
        public async Task<IActionResult> DeleteAsync(UsuarioVaga uv)
        {
            try
            {
                UsuarioVaga uvRemover = await _context.UsuarioVagas
                    .FirstOrDefaultAsync(uvBusca => uvBusca.UsuarioId == uv.UsuarioId
                     && uvBusca.VagaId == uv.VagaId);
                if(uvRemover == null)
                    throw new System.Exception("Usuario ou Vaga não encontrados");

                _context.UsuarioVagas.Remove(uvRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}