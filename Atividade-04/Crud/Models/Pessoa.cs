using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Crud.Models
{
    public class Pessoa
    {
        [Key]
        [Column("id_pessoa")]
        public int Id { get; set; } // Primary Key

        [DisplayName("Primeiro Nome:")]
        [Required(ErrorMessage = "Digite o primeiro nome.")]
        [Column("primeiro_nome")]
        public string PrimeiroNome { get; set; }

        [DisplayName("Sobrenome:")]
        [Required(ErrorMessage = "Digite o nome do paciente.")]
        [Column("sobrenome")]
        public string Sobrenome { get; set; }

        [DisplayName("Apelido:")]
        [Column("apelido")]
        public string Apelido { get; set; }

        [DisplayName("Data de Nascimento:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Digite a data de nascimento.")]
        [Column("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Nome do pai:")]
        [Required(ErrorMessage = "Digite o nome do pai.")]
        [Column("pai")]
        public string NomePai { get; set; }

        [DisplayName("Nome da mãe:")]
        [Required(ErrorMessage = "Digite o nome da mãe.")]
        [Column("mae")]
        public string NomeMae { get; set; }
    }
}