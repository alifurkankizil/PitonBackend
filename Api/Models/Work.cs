using Api.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Work
    {
        public Guid WorkId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public CompleteState CompleteState { get; set; } = CompleteState.New;
    }
}
