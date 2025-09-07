/*
Find gaps in sequential data.  Given an Invoices table, identify missing invoice numbers (InvoiceNumber) in the Invoices table.
*/

SELECT s.value AS MissingInvoiceNumber
FROM GENERATE_SERIES(
	(SELECT MIN(InvoiceNumber) FROM Invoices), 
	(SELECT MAX(InvoiceNumber) FROM Invoices),
	1) AS s
LEFT JOIN Invoices i ON s.value = i.InvoiceNumber
WHERE i.InvoiceNumber IS NULL;