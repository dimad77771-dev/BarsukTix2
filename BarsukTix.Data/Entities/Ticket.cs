using System;
using System.Collections.Generic;

namespace BarsukTix.Data.Entities;

public partial class Ticket
{
    public Guid RowId { get; set; }

    public string UserId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? RepeatEmail { get; set; }

    public string? MobilePhone { get; set; }

    public string? ZipCode { get; set; }

    public string? AddressLine { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public virtual ICollection<TicketCategory> TicketCategories { get; set; } = new List<TicketCategory>();

    public virtual AspNetUser User { get; set; } = null!;
}
