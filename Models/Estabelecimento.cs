using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TccApi.Models.Enuns;

namespace TccApi.Models
{
    public class Estabelecimento
    {
        public long Id { get; set; }

        public string Cnpj { get; set; }

        public string Nome_est { get; set; }

        public string Endereco { get; set; }

        public int CEP { get; set; }

        public int Complemento { get; set; }

        public int Numero_est { get; set; }

        public long UsuarioId { get; set; }

        public TipoClasseUsuario TipoUsuario { get; set; }

        public List<Agendamento> Agendamentos { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}