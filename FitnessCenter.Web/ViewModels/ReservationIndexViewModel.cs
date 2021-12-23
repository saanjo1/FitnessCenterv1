using FitnessCenter.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationIndexViewModel
    {
        public class Row
        {
            public DateTime DateTimeFrom { get; set; }
            public DateTime DateTimeTo { get; set; }
            public int ReservationId { get; set; }
            public string User { get; set; }
            public string Coach { get; set; }
            public string FitnessRoom { get; set; }
            public bool IsConfirmed { get; set; }
        }


        public List<Row> Rows { get; set; }
    }
}
