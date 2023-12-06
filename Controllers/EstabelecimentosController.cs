using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
                Estabelecimento e = await _context.Estabelecimentos
                .Include(est => est.Usuario)
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

        private int ObterEstabelecimentoId()
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
        public async Task<ActionResult> RegistrarEstablecimento(Estabelecimento user)
        {
            try
            {
                if (await EstabelecimentoExistente(user.Email))
                    throw new System.Exception("Estabelecimento já cadastrado");

                Criptografia.CriarSenhaHash(user.Senha, out byte[] hash, out byte[] salt);
                user.Senha = string.Empty;
                user.Senha_hash = hash;
                user.Senha_salt = salt;
                await _context.Estabelecimentos.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
catch (System.Exception ex)
    {
        // Adicione estas linhas para exibir detalhes da exceção interna
        if (ex.InnerException != null)
        {
            return BadRequest($"Erro: {ex.Message}, Detalhes: {ex.InnerException.Message}");
        }
        else
        {
            return BadRequest(ex.Message);
        }
    }
        }

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarEstabelecimento(Estabelecimento credenciais)
        {
            try
            {
                Estabelecimento estabelecimento = await _context.Estabelecimentos
                   .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(credenciais.Email.ToLower()));

                if (estabelecimento == null)
                {
                    throw new System.Exception("Estabelecimento não encontrado.");
                }
                else if (!Criptografia
                .VerificarSenhaHash(credenciais.Senha, estabelecimento.Senha_hash, estabelecimento.Senha_salt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    estabelecimento.Senha_hash = null;
                    estabelecimento.Senha_salt = null;
                    estabelecimento.Token = CriarToken(estabelecimento);
                    return Ok(estabelecimento);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

                private string CriarToken(Estabelecimento est)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, est.Id.ToString()),
                new Claim(ClaimTypes.Name, est.Email)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("ConfiguracaoToken:Chave").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Estabelecimento novoEstabelecimento)
        {
            try
            {
                if (novoEstabelecimento.Cnpj == null)
                {
                    throw new System.Exception("O cnpj não pode estar vazio");
                }

                novoEstabelecimento.Usuario = _context.Usuarios
                .FirstOrDefault(uBusca => uBusca.Id == ObterEstabelecimentoId());

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

                novoEstabelecimento.Usuario = _context.Usuarios.FirstOrDefault(uBusca => uBusca.Id == ObterEstabelecimentoId());

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
