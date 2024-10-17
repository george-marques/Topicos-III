using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Crud.Models
{
    public class Carro
    {
        [Key]
        [Column("id_carro")]
        public int Id { get; set; } // Primary Key

        [DisplayName("Modelo:")]
        [Required(ErrorMessage = "Digite o modelo.")]
        [Column("modelo")]
        public string Modelo { get; set; }

        [DisplayName("Data de Fabricação:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Digite a data de fabricação.")]
        [Column("data_fabricacao")]
        public DateTime DataFabricacao { get; set; }
        
        [DisplayName("Ano do Modelo:")]
        [Required(ErrorMessage = "Digite o ano do modelo.")]
        [Column("ano_modelo")]
        public int AnoModelo { get; set; }

        [DisplayName("Consumo:")]
        [Required(ErrorMessage = "Digite o consumo.")]
        [Column("consumo")]
        public double Consumo { get; set; }

        [DisplayName("Quantidade de portas:")]
        [Required(ErrorMessage = "Digite a quantidade de portas.")]
        [Column("qtd_portas")]
        public int QuantidadePortas { get; set; }

        [DisplayName("Quantidade de passageiros:")]
        [Required(ErrorMessage = "Digite a quantidade de passageiros.")]
        [Column("qtd_passageiros")]
        public int QuantidadePassageiros { get; set; }

        [DisplayName("Categoria:")]
        [Required(ErrorMessage = "Digite a categoria.")]
        [Column("categoria")]
        public string Categoria { get; set; } 
    }
}