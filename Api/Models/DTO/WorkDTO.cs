using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.DTO
{
    public class WorkDTO
    {
        [Required(ErrorMessage ="Başlık bilgisi giriniz!")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Açıklama giriniz!")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Tarih giriniz!")]
        public DateTime? Date { get; set; }
    }
}
