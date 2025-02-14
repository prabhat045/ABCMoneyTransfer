using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using ABCMoneyTransfer.Services;
using ABCMoneyTransfer.DTOs;

namespace ABCMoneyTransfer.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly TransactionService _transactionService;

        public TransactionsController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> Report( TransactionReportFilterDTO filter, bool showReport = false)
        {
            if (!showReport)
            {
                return View(Enumerable.Empty<TransactionDTO>());
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var reportData = await _transactionService.GenerateReportAsync(userId, filter);
            return View(reportData);
        }
    }
}
