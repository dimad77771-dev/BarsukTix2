using System;
using System.Collections.Generic;

namespace BarsukTix.Data.Entities;

public partial class TicketAttendee
{
    public Guid RowId { get; set; }

    public Guid TicketCategoryRowId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool IsAgree { get; set; }

    public virtual TicketCategory TicketCategoryRow { get; set; } = null!;
}
