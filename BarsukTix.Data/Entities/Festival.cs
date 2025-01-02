using System;
using System.Collections.Generic;

namespace BarsukTix.Data.Entities;

public partial class Festival
{
    public Guid RowId { get; set; }

    public string? FestivalName { get; set; }

    public string? FestivalFullName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinishDate { get; set; }
}
