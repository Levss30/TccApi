using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TccApi.Models.Enuns;

namespace TccApi.Models
{
    public class Estabelecimento
    {
        public long Id { get; set; }

        public string Cnpj { get; set; }

        public string Email { get; set; }

        public string Nome_est { get; set; }

        public string Endereco { get; set; }

        public int Telefone { get; set; }

        public string CEP { get; set; }

        public int Complemento { get; set; }

        [NotMapped]
        public string Senha { get; set;}

        [NotMapped]
        public string Token { get; set; }

        public byte[]? Senha_hash { get; set; }

        public byte[]? Senha_salt { get; set; }

        public int Numero_est { get; set; }
        public long UsuarioId { get; set; }
        public List<Agendamento> Agendamentos { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}