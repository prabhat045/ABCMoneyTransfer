using ABCMoneyTransfer.DTOs;
using ABCMoneyTransfer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ABCMoneyTransfer.Controllers
{
    [Authorize]
    public class TransferController : Controller
    {
        private readonly TransactionService _transactionService;
        private readonly IExchangeRateService _exchangeRateService;

        public TransferController(TransactionService transactionService, IExchangeRateService exchangeRateService)
        {
            _transactionService = transactionService;
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var rate = await _exchangeRateService.GetExchangeRateAsync();
            var model = new TransferViewModel
            {
                ExchangeRate = rate
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var partyDto = new PartyDTO(model);
            var paymentDto = new PaymentDetailDTO(model);
            var dto = new TransferRequestDTO(partyDto, paymentDto);
            
            await _transactionService.ProcessTransferAsync(userId, dto);
            TempData["TransferSuccess"] = "Transfer completed successfully.";
            return RedirectToAction("Create", "Transfer");
        }
    }
}
