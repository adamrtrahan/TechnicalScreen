/*
Extract name and age values from a JSON column CustomerData in table Customers.
*/

SELECT CustomerID
  ,JSON_VALUE(CustomerData, '$.name') AS [Name]
  ,JSON_VALUE(CustomerData, '$.age') AS Age
FROM Customers