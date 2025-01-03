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
        public required Category[] Categories { get; set; }
        public required Festival Festival { get; set; }

        public Ticket? Ticket { get; set; }
        public required List<TicketCategory> TicketCategories { get; set; }
        public required List<TicketAttendee> TicketAttendees { get; set; }

        public string? ErrorText { get; set; }
        public bool HasError => !string.IsNullOrEmpty(ErrorText);

        public TicketCategory? GetTicketCategory(Guid categoryRowId) => TicketCategories?.SingleOrDefault(x => x.CategoryRowId == categoryRowId);
    }
}
