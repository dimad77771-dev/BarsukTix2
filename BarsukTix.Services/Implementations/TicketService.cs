using BarsukTix.Data.Entities;
using BarsukTix.Services.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsukTix.Services.Implementations
{
	public class TicketService
	{
        public TicketViewModel GetTicketViewModel(string userId)
        {
            var db  = GetDB();
            var row = db.Tickets.SingleOrDefault(t => t.UserId == userId);

            var result = new TicketViewModel
            {
                Ticket = row,
                Categories = db.Categories.OrderBy(x => x.SequenceNumber).ToArray(),
            };

            return result;
        }

        public bool PaymentProcessing(PaymentProcessingData data, string userId)
		{
            var db = GetDB();

            var amount = (decimal?)null;
            if (!string.IsNullOrEmpty(data.amount))
            {
                if (decimal.TryParse(data.amount.Replace(",","."), NumberStyles.Number, CultureInfo.InvariantCulture, out var amount2))
                {
                    amount = amount2;
                }
            }

            var responseDateTime = (DateTime?)null;
            var result1 = DateTime.TryParseExact(data.time ?? "", new[] { "HH:mm:ss" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out var responseTime);
            var result2 = DateTime.TryParseExact(data.date ?? "", new[] { "yyyy-MM-dd" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out var responseDate);
            if (result1 && result2)
            {
                responseDateTime = responseDate.Date.Add(responseTime.TimeOfDay);
            }

            var paymentProcessing = new PaymentProcessing
            {
                RowId = Guid.NewGuid(),
                UserId = userId,
                ProcessingDateTime = DateTime.Now,
                Response = data.response,
                ResponseMessage = data.responseMessage,
                NoticeMessage = data.noticeMessage,
                ResponseDateTime = responseDateTime,
                ResponseType = data.type,
                Amount = amount,
                CardHolderName = data.cardHolderName,
                CardNumber = data.cardNumber,
                CardExpiry = data.cardExpiry,
                CardToken = data.cardToken,
                CardType = data.cardType,
                TransactionId = data.transactionId,
                AvsResponse = data.avsResponse,
                CvvResponse = data.cvvResponse,
                ApprovalCode = data.approvalCode,
                OrderNumber = data.orderNumber,
                CustomerCode = data.customerCode,
                Currency = data.currency,
                XmlHash = data.xmlHash,
            };

            db.PaymentProcessings.Add(paymentProcessing);
            db.SaveChanges();

			return true;
		}



        BarsukTixDB GetDB()
        {
            var db = new BarsukTixDB();
            return db;
        }

    }
}
