using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDDSample.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "A marca é necessária")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "O modelo é necessário")]
        //[MinLength(1)]
        //[MaxLength(100)]
        //[DisplayName("Idade")]
        //public string Modelo { get; set; }

        //[Required(ErrorMessage = "A Versão é necessária")]
        //[MinLength(1)]
        //[MaxLength(100)]
        //[DisplayName("Versao")]
        //public string Versao { get; set; }

        [Required(ErrorMessage = "A Idade é necessária")]
        [DisplayName("Idade")]
        public int Idade { get; set; }

        //[Required(ErrorMessage = "A Quilometragem é necessária")]
        //[DisplayName("Quilometragem")]
        //public int Quilometragem { get; set; }

        //[Required(ErrorMessage = "A Observação é necessária")]
        //[DisplayName("Observacao")]
        //public string Observacao { get; set; }
    }
}
