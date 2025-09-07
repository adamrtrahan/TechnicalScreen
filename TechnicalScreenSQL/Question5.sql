/*
	The PurchaseDetailItem table also seems to have duplicate records, 
	can you write a query to identify the duplicates inserted that have the same purchase order number, 
	item number, purchase price and quantity that are the same? Provide the query below: 
*/

SELECT detailItem.PurchaseDetailItemAutoId
	,detailItem.PurchaseOrderNumber
	,detailItem.ItemNumber
	,detailItem.PurchasePrice
	,detailItem.PurchaseQuantity
	,duplicate.DuplicatesCount
FROM PurchaseDetailItem AS detailItem
JOIN (
	SELECT PurchaseOrderNumber
		,ItemNumber
		,PurchasePrice
		,PurchaseQuantity
		,COUNT(*) as DuplicatesCount
	FROM PurchaseDetailItem
	GROUP BY PurchaseOrderNumber
		,ItemNumber
		,PurchasePrice
		,PurchaseQuantity
	HAVING COUNT(*) > 1
) AS duplicate ON 
	detailItem.PurchaseOrderNumber = duplicate.PurchaseOrderNumber
	AND detailItem.ItemNumber = duplicate.ItemNumber
	AND detailItem.PurchasePrice = duplicate.PurchasePrice
	AND detailItem.PurchaseQuantity = duplicate.PurchaseQuantity
ORDER BY PurchaseOrderNumber
	,ItemNumber
	,PurchasePrice
	,PurchaseQuantity;
