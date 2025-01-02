using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsukTix.Services.DTO
{
	public class PaymentProcessingData
	{
		public string? response { get; set; }
		public string? responseMessage { get; set; }
		public string? noticeMessage { get; set; }
		public string? date { get; set; }
		public string? time { get; set; }
		public string? type { get; set; }
		public string? amount { get; set; }
		public string? cardHolderName { get; set; }
		public string? cardNumber { get; set; }
		public string? cardExpiry { get; set; }
		public string? cardToken { get; set; }
		public string? cardType { get; set; }
		public string? transactionId { get; set; }
		public string? avsResponse { get; set; }
		public string? cvvResponse { get; set; }
		public string? approvalCode { get; set; }
		public string? orderNumber { get; set; }
		public string? customerCode { get; set; }
		public string? currency { get; set; }
		public string? xmlHash { get; set; }
	}
}
