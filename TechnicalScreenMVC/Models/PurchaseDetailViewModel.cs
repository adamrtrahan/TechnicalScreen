using System.ComponentModel.DataAnnotations;

namespace TechnicalScreenMVC.Models;

public partial class PurchaseDetailViewModel
{
    [Key]
    public long PurchaseDetailItemAutoId { get; set; }

    public string PurchaseOrderNumber { get; set; } = null!;
    
    public long LineNumber { get; set; }

    public int ItemNumber { get; set; }

    public string ItemName { get; set; } = null!;

    public string? ItemDescription { get; set; }

    public decimal PurchasePrice { get; set; }

    public int PurchaseQuantity { get; set; }

    public string LastModifiedByUser { get; set; } = null!;

    public DateTime LastModifiedDateTime { get; set; }
}
