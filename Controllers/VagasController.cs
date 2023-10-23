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

namespace EstacioneJaApi.Controllers
{
    [Authorize(Roles = "1, 2")]
    [ApiController]
    [Route("[Controller]")]
    public class VagasController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VagasController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        private int ObterEstacionamentoId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Vaga v = await _context.Vagas
                .Include(s => s.Sensor)
                .Include(e => e.Estacionamento).ThenInclude(eu => eu.Usuario)
                .FirstOrDefaultAsync(vBusca => vBusca.Id == id);

                return Ok(v);
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
                List<Vaga> lista = await _context.Vagas
                .Include(s => s.Sensor)
                .Include(e => e.Estacionamento).ThenInclude(eu => eu.Usuario)
                .ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Vaga novaVaga)
        {
            try
            {
                if (novaVaga.Latitude == null && novaVaga.Latitude == null )
                {
                    throw new System.Exception("Preencha as coordenadas");                
                }

                novaVaga.Estacionamento = _context.Estacionamentos
                .FirstOrDefault(eBusca => eBusca.Id == ObterEstacionamentoId());

                var novoSensor = new Sensor
                {
                    Latitude = novaVaga.Latitude,
                    Longitude = novaVaga.Longitude,
                    Vaga = novaVaga
                };

                novaVaga.Sensor = novoSensor;

                 _context.Vagas.Add(novaVaga);
                
                _context.Sensores.Add(novoSensor);
                await _context.SaveChangesAsync();

                return Ok(novaVaga.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Vaga novaVaga)
        {
            try
            {

                novaVaga.Estacionamento = _context.Estacionamentos
                .FirstOrDefault(eBusca => eBusca.Id == ObterEstacionamentoId());

                var novoSensor = new Sensor
                {
                    Id = novaVaga.Id,
                    Latitude = novaVaga.Latitude,
                    Longitude = novaVaga.Longitude,
                    Vaga = novaVaga
                };

                _context.Vagas.Update(novaVaga);
                _context.Sensores.Update(novoSensor);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
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
                Vaga vRemover = await _context.Vagas
                   .FirstOrDefaultAsync(v => v.Id == id);

                Sensor sRemover = await _context.Sensores
                   .FirstOrDefaultAsync(s => s.Id == id);

                _context.Sensores.Remove(sRemover);
                _context.Vagas.Remove(vRemover);
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