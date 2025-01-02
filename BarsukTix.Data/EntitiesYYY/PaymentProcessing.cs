using System;
using System.Collections.Generic;

namespace BarsukTix.Data.EntitiesYYY;

public partial class PaymentProcessing
{
    public Guid RowId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime? ProcessingDateTime { get; set; }

    public string? Response { get; set; }

    public string? ResponseMessage { get; set; }

    public string? NoticeMessage { get; set; }

    public DateTime? ResponseDateTime { get; set; }

    public string? ResponseType { get; set; }

    public decimal? Amount { get; set; }

    public string? CardHolderName { get; set; }

    public string? CardNumber { get; set; }

    public string? CardExpiry { get; set; }

    public string? CardToken { get; set; }

    public string? CardType { get; set; }

    public string? TransactionId { get; set; }

    public string? AvsResponse { get; set; }

    public string? CvvResponse { get; set; }

    public string? ApprovalCode { get; set; }

    public string? OrderNumber { get; set; }

    public string? CustomerCode { get; set; }

    public string? Currency { get; set; }

    public string? XmlHash { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
