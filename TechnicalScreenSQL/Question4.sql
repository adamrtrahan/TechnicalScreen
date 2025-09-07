/*
	The table PurchaseDetailItem has records that were inconsistently inserted for two different Purchase Order numbers, 
	can you write a quick query to create a line number column per item per purchase order 
	number? Provide the query below, Expected results pictured below:
*/
SELECT PurchaseDetailItemAutoId
      ,PurchaseOrderNumber
	  ,ROW_NUMBER() OVER (PARTITION BY PurchaseOrderNumber, ItemNumber ORDER BY purchaseDetailItemAutoId) AS LineNumber
      ,ItemNumber
      ,ItemName
      ,ItemDescription
      ,PurchasePrice
      ,PurchaseQuantity
      ,LastModifiedByUser
      ,LastModifiedDateTime
  FROM PurchaseDetailItem