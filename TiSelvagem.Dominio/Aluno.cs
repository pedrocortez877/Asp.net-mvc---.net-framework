using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiSelvagem.Dominio
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome do aluno")]
        public string Nome { get; set; }

        [DisplayName("Mãe")]
        [Required(ErrorMessage = "Preencha o nome da mãe")]
        public string Mae { get; set; }

        [DisplayName("Data de nascimento")]
        [Required(ErrorMessage = "Preencha a data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
    }
}
