using System;
using System.Collections.Generic;

namespace BarsukTix.Data.EntitiesYYY;

public partial class Category
{
    public Guid RowId { get; set; }

    public int SequenceNumber { get; set; }

    public string CategoryName { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<TicketCategory> TicketCategories { get; set; } = new List<TicketCategory>();
}
