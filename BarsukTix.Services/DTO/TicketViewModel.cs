using BarsukTix.Common;
using BarsukTix.Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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

        public decimal GetTotalAmount() => Ticket?.TotalAmount ?? 0;

		public string? HelcimToken => BarsukTixSettings.HelcimToken;
		public string? HelcimSecretKey => BarsukTixSettings.HelcimSecretKey;

		public string GetAmountHash()
        {
            var data = HelcimSecretKey + GetTotalAmount().ToString("0.00", CultureInfo.InvariantCulture);
			using (var sha256Hash = SHA256.Create())
            {
				var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

				var builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				var result = builder.ToString();
				return result;
			}
		}
	}
}
