using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadViagem.Models
{
    public class TripViewModel
    {
        [Key()]
        public Guid TripId { get; set; }

        [ForeignKey("Driver")]
        [Required(ErrorMessage = "Motorista é Obrigatório")]
        public Guid DriverId { get; set; }

        [Display(Name = "Motorista:")]
        public virtual DriverViewModel Driver { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm}")]
        [Display(Name = "Data e Hora de Viagem:")]
        [Required(ErrorMessage = "Data é Obrigatório")]
        public DateTime Date { get; set; }

        [Display(Name = "Local de entrada:")]
        [Required(ErrorMessage = "Local de entrada é Obrigatório")]
        public string LocaleEntry { get; set; }

        [Display(Name = "Local de saída:")]
        [Required(ErrorMessage = "Local de saída é Obrigatório")]
        public string LocaleExit { get; set; }

        [Display(Name = "KM:")]
        [Required(ErrorMessage = "KM é Obrigatório")]
        public int KM { get; set; }

        [NotMapped]
        public SelectList Drivers { get; set; }

        public Dictionary<string, string> validate()
        {
            var erros = new Dictionary<string, string>();
            if (Date > DateTime.Now)
            {
                erros.Add("Date", "Não é possivel gravar com datas futuras.");
            }
            if (Date == DateTime.MinValue)
            {
                erros.Add("Date", "Selecione uma data para cadastrar a viagem.");
            }
            if (KM <= 0)
            {
                erros.Add("KM", "A KM da viagem deve ser maior que 0.");
            }
            return erros;
        }
    }
}