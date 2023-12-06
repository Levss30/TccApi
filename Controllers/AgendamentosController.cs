using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TccApi.Data;
using TccApi.Models;
using TccApi.Utils;

namespace TccApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AgendamentosController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Agendamento a = await _context.Agendamentos
                .Include(user => user.Usuario)
                .Include(v => v.Estabelecimentos)
                .FirstOrDefaultAsync(eBusca => eBusca.Id == id);

                return Ok(a);
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
                List<Agendamento> lista = await _context.Agendamentos
                .Include(e => e.Estabelecimentos)
                .Include(a => a.Usuario)
                .ToListAsync();

                return Ok(lista);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private int ObterUsuarioId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Agendamento novoAgendamento)
        {
            try
            {
                if (novoAgendamento.Local_ag == null)
                {
                    throw new System.Exception("Os campos não podem estar vazio");
                }

                novoAgendamento.Usuario = _context.Usuarios
                .FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());

                await _context.Agendamentos.AddAsync(novoAgendamento);
                await _context.SaveChangesAsync();

                return Ok(novoAgendamento.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Agendamento novoAgendamento)
        {
            try
            {
                if (novoAgendamento.Local_ag == null)
                {
                    throw new System.Exception("O nome não pode estar vazio");
                }

                novoAgendamento.Usuario = _context.Usuarios.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());

                _context.Agendamentos.Update(novoAgendamento);
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
                Agendamento aRemover = await _context.Agendamentos.FirstOrDefaultAsync(p => p.Id == id);

                _context.Agendamentos.Remove(aRemover);
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