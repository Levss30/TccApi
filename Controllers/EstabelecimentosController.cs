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
    public class EstabelecimentosController : ControllerBase
    {
        private readonly DataContext _context;
        private IConfiguration _configuration;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public EstabelecimentosController(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
                Estabelecimento a = await _context.Estabelecimentos
                .Include(user => user.Usuario)
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
                List<Estabelecimento> lista = await _context.Estabelecimentos
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

        private async Task<bool> EstabelecimentoExistente(string email)
        {
            if (await _context.Estabelecimentos.AnyAsync(x => x.Email.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }


        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<ActionResult> RegistrarUsuario(Estabelecimento est)
        {
            try
            {
                if (await EstabelecimentoExistente(est.Email))
                    throw new System.Exception("Email já cadastrado");

                Criptografia.CriarSenhaHash(est.Senha, out byte[] hash, out byte[] salt);
                est.Senha = string.Empty;
                est.Senha_hash = hash;
                est.Senha_salt = salt;
                await _context.Estabelecimentos.AddAsync(est);
                await _context.SaveChangesAsync();

                return Ok(est.Email);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Estabelecimento novoEstabelecimento)
        {
            try
            {
                if (novoEstabelecimento.Cnpj == null)
                {
                    throw new System.Exception("O nome não pode estar vazio");
                }

                novoEstabelecimento.Usuario = _context.Usuarios
                .FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());

                await _context.Estabelecimentos.AddAsync(novoEstabelecimento);
                await _context.SaveChangesAsync();

                return Ok(novoEstabelecimento.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Estabelecimento novoEstabelecimento)
        {
            try
            {
                if (novoEstabelecimento.Cnpj == null)
                {
                    throw new System.Exception("O nome não pode estar vazio");
                }

                novoEstabelecimento.Usuario = _context.Usuarios.FirstOrDefault(uBusca => uBusca.Id == ObterUsuarioId());

                _context.Estabelecimentos.Update(novoEstabelecimento);
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
                Estabelecimento eRemover = await _context.Estabelecimentos.FirstOrDefaultAsync(e => e.Id == id);

                _context.Estabelecimentos.Remove(eRemover);
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
