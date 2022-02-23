using System;
using CadViagem.Controllers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadViagem.Models
{
    public class DriverViewModel
    {
        [Key()]
        public Guid Id { get; set; }
        public virtual ICollection<TripViewModel> Trips { get; set; }

        [Display(Name = "Nome: *")]
        [StringLength(25, ErrorMessage = "O nome deve ter no máximo 25 caracteres.")]
        [Required(ErrorMessage = "Nome é Obrigatório")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome: *")]
        [StringLength(25, ErrorMessage = "O nome deve ter no máximo 25 caracteres.")]
        [Required(ErrorMessage = "Sobrenome é Obrigatório")]
        public string LastName { get; set; }

        #region  Endereço
        [Display(Name = "CEP:")]
        [Required(ErrorMessage = "O Cep é Obrigatório")]
        public string Cep { get; set; }

        [Display(Name = "Rua:")]
        [Required(ErrorMessage = "Rua é Obrigatório")]
        public string StreetName { get; set; }

        [Display(Name = "Numero:")]
        [Required(ErrorMessage = "O Numero é Obrigatório")]
        public string StreetNumber { get; set; }

        [Display(Name = "Complemento:")]
        public string StreetComplement { get; set; }

        [Display(Name = "UF:")]
        [Required(ErrorMessage = "A Uf é Obrigatória")]
        public string Uf { get; set; }
        
        [Display(Name = "Municipio:")]
        [Required(ErrorMessage = "O Municipio é Obrigatório")]
        public string Municipio { get; set; }

        [Display(Name = "Bairro:")]
        [Required(ErrorMessage = "O Bairro é Obrigatório")]
        public string District { get; set; }
        #endregion

        [Display(Name = "Caminhão")]
        [Required(ErrorMessage = "O Caminhão é Obrigatório")]

        public string Truck { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "A marca do caminhão é Obrigatório")]

        public string Marck { get; set; }

        [Display(Name = "Eixo")]
        [Required(ErrorMessage = "O eixo do caminhão é Obrigatório")]

        public string Axis { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "O modelo do caminhão é Obrigatório")]

        public string Model { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "A placa do caminhão é Obrigatório")]

        public string Plaque { get; set; }

    }
}