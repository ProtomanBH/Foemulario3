using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foemulario3.Shared
{
    public class Usuario
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; }

        [Range(18, 120, ErrorMessage = "A idade deve ser maior que 18")]
        public int Idade { get; set; }

    }
}