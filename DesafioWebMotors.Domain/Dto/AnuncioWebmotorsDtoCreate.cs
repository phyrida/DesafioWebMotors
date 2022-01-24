using DesafioWebMotors.Domain.DataAnnotationValidation;
using System.ComponentModel.DataAnnotations;

namespace DesafioWebMotors.Domain.Dto
{
    public class AnuncioWebmotorsDtoCreate
    {
        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        [MaxLength(45, ErrorMessage = "A quantidade máxima de caracteres permitidos para o campo Marca é de {1}")]
        public string Marca { get; set; }


        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        [MaxLength(45, ErrorMessage = "A quantidade máxima de caracteres permitidos para o campo Modelo é de {1}")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Versao é obrigatório")]
        [MaxLength(45, ErrorMessage = "A quantidade máxima de caracteres permitidos para o campo Versao é de {1}")]
        public string Versao { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        [NumberMinValueAttribute(1900, ErrorMessage = "O valor mínimo para o campo Ano deve ser maior que {1}")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Quilometragem é obrigatório")]
        [NumberMinValueAttribute(-1, ErrorMessage = "O valor mínimo para o campo Quilometragem deve ser maior que {1}")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "O campo Observacao é obrigatório")]
        [MaxLength(45, ErrorMessage = "A quantidade máxima de caracteres permitidos para o campo Observacao é de {1}")]
        public string Observacao { get; set; }
    }
}
