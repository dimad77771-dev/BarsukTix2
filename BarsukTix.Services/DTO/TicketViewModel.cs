using BarsukTix.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsukTix.Services.DTO
{
    public class TicketViewModel
    {
        public Ticket? Ticket { get; set; }
        public required List<TicketCategory> TicketCategories { get; set; }
        public required Category[] Categories { get; set; }
        public string? ErrorText { get; set; }
    }
}
