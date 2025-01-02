using System;
using System.Collections.Generic;

namespace BarsukTix.Data.Entities;

public partial class TicketCategory
{
    public Guid RowId { get; set; }

    public Guid TicketRowId { get; set; }

    public Guid CategoryRowId { get; set; }

    public int Quantity { get; set; }

    public virtual Category CategoryRow { get; set; } = null!;

    public virtual ICollection<TicketAttendee> TicketAttendees { get; set; } = new List<TicketAttendee>();

    public virtual Ticket TicketRow { get; set; } = null!;
}
