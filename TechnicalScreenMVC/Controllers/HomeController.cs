using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechnicalScreenMVC.Models;
using TechnicalScreenMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace TechnicalScreenMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var purchaseDetails = await _context.PurchaseDetailViewModels
            .FromSqlRaw("EXEC GetPurchaseDetails")
            .ToListAsync();
        return View(purchaseDetails);
    }

    public async Task<IActionResult> AddItem(PurchaseDetailUpdateModel newItem)
    {
        if (ModelState.IsValid)
        {
            newItem.LastModifiedDateTime = DateTime.Now;

            _context.PurchaseDetailUpdateModels.Add(newItem);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> EditItem(PurchaseDetailUpdateModel updatedItem)
    {
        if (ModelState.IsValid)
        {
            var existingItem = await _context.PurchaseDetailUpdateModels
                .FirstOrDefaultAsync(p => p.PurchaseDetailItemAutoId == updatedItem.PurchaseDetailItemAutoId);

            if (existingItem != null)
            {
                existingItem.PurchaseOrderNumber = updatedItem.PurchaseOrderNumber;
                existingItem.ItemNumber = updatedItem.ItemNumber;
                existingItem.ItemName = updatedItem.ItemName;
                existingItem.ItemDescription = updatedItem.ItemDescription;
                existingItem.PurchasePrice = updatedItem.PurchasePrice;
                existingItem.PurchaseQuantity = updatedItem.PurchaseQuantity;
                existingItem.LastModifiedByUser = updatedItem.LastModifiedByUser;
                existingItem.LastModifiedDateTime = DateTime.Now;

                await _context.SaveChangesAsync();
            }
        }

        return RedirectToAction(nameof(Index));
    }

}
