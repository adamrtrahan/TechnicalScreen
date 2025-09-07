CREATE OR ALTER PROCEDURE GetPurchaseDetails
AS
BEGIN
	/* 
	 Create a stored procedure that lists out all the purchase detail records with the line number field from question #4. 
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

END;