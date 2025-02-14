using ABCMoneyTransfer.Infrastructure;
using ABCMoneyTransfer.DTOs;
using AutoMapper;
using System.Threading.Tasks;
using ABCMoneyTransfer.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ABCMoneyTransfer.Services
{
    public class TransactionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public TransactionService(ApplicationDbContext context, IMapper mapper,  UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task ProcessTransferAsync(string userId, TransferRequestDTO model)
        {
            Sender sender = await GetSenderInformation(userId).ConfigureAwait(false);
            var receiver = _mapper.Map<Receiver>(model.Receiver);
            var paymentDetail = _mapper.Map<PaymentDetail>(model.PaymentDetail);

            var transaction = new Transaction(sender, receiver, paymentDetail, userId);
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        private async Task<Sender> GetSenderInformation(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var sender = new Sender()
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Address = user.Address,
                Country = user.Country
            };
            return sender;
        }

        public async Task<List<TransactionDTO>> GenerateReportAsync(string userId, TransactionReportFilterDTO filter)
        {
            DateTime start = filter.StartDate?.Date ?? DateTime.MinValue;
            DateTime end = filter.EndDate?.Date ?? DateTime.MaxValue;
            start = start.Date;
            if (end < DateTime.MaxValue.Date)
                end = end.Date.AddDays(1).AddTicks(-1);

            var query = _context.Transactions
                .Where(t => t.senderUserId == userId);

            query = query.Where(t => t.CreatedAt >= start && t.CreatedAt <= end);

            int pageNumber = filter.PageNumber < 1 ? 1 : filter.PageNumber;
            int pageSize = filter.PageSize < 1 ? 10 : filter.PageSize;

            query = query.OrderByDescending(t => t.CreatedAt);

            var transactions = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<List<TransactionDTO>>(transactions);
        }
    }
}
