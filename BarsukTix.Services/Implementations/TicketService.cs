using BarsukTix.Data.Entities;
using BarsukTix.Services.DTO;
using Microsoft.EntityFrameworkCore;
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
        public TicketViewModel PostTicket(Dictionary<string,string> formdata, string userId)
        {
            var data = formdata.Select(x => (Guid.Parse(x.Key), int.Parse(x.Value.ToString()))).ToDictionary();

            var db = GetDB();

            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                var categories = GetAllCategories(db);
                var ticket = db.Tickets.SingleOrDefault(t => t.UserId == userId);

                if (ticket == null)
                {
                    ticket = new Ticket
                    {
                        RowId = Guid.NewGuid(),
                        UserId = userId,
                    };
                    db.Tickets.Add(ticket);
                }

                var oldTicketCategories = db.TicketCategories.Where(x => x.TicketRowId == ticket.RowId).ToArray();
                var newTicketCategories = data.Select(x => new TicketCategory{CategoryRowId = x.Key, Quantity = x.Value }).ToArray();
                var totalQuantity = newTicketCategories.Sum(x => x.Quantity);
                if (totalQuantity > 0) 
                {
                    foreach (var newTicketCategory in newTicketCategories)
                    {
                        var oldTicketCategory = oldTicketCategories.SingleOrDefault(x => x.CategoryRowId == newTicketCategory.CategoryRowId);
                        if (oldTicketCategory == null)
                        {
                            newTicketCategory.RowId = Guid.NewGuid();
                            newTicketCategory.TicketRowId = ticket.RowId;
                            db.TicketCategories.Add(newTicketCategory);
                        }
                        else
                        {
                            oldTicketCategory.Quantity = newTicketCategory.Quantity;
                        }
                    }

                    var delTicketCategories = oldTicketCategories.Where(x => !newTicketCategories.Any(z => z.CategoryRowId == x.CategoryRowId)).ToList();
                    delTicketCategories.ForEach(x => db.TicketCategories.Remove(x));

                    ticket.TotalAmount = newTicketCategories.Sum(x => x.Quantity * GetCategoryPrice(x.CategoryRowId, categories));

                    db.SaveChanges();
                    dbContextTransaction.Commit();

                    var result = GetTicketViewModel(userId);
                    return result;
                }
                else
                {
                    var result = GetTicketViewModel(userId);
                    result.TicketCategories.ForEach(x => x.Quantity = newTicketCategories?.SingleOrDefault(z => z.CategoryRowId == x.CategoryRowId)?.Quantity ?? 0);
                    result.ErrorText = "The total must be greater than zero";
                    return result;
                }
            }
        }

        public TicketViewModel GetTicketViewModel(string userId)
        {
            var db  = GetDB();
            var row = db.Tickets.Include(x => x.TicketCategories).ThenInclude(x => x.TicketAttendees).SingleOrDefault(t => t.UserId == userId);

            var result = new TicketViewModel
            {
                Ticket = row,
                TicketCategories = row?.TicketCategories?.ToList() ?? new List<TicketCategory>(),
                TicketAttendees = row?.TicketCategories?.SelectMany(x => x.TicketAttendees).ToList() ?? new List<TicketAttendee>(),
                Categories = GetAllCategories(db),
                Festival = GetFestival(db),
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

        private Festival GetFestival(BarsukTixDB db)
        {
            var row = db.Festivals.FirstOrDefault();
            return row ?? new Festival { FestivalFullName = "-", FestivalName = "-" };
        }

        private Category[] GetAllCategories(BarsukTixDB db)
        {
            return db.Categories.OrderBy(x => x.SequenceNumber).ToArray();
        }

        private decimal GetCategoryPrice(Guid categoryRowId, Category[] categories)
        {
            var price = categories.SingleOrDefault(x => x.RowId == categoryRowId)?.Price ?? 0M;
            return price;
        }

 

        BarsukTixDB GetDB()
        {
            var db = new BarsukTixDB();
            return db;
        }

    }
}
