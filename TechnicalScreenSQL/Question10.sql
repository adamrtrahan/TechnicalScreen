/*
    Given an Orders table, with columns: CustomerId, OrderDate and Amount, 
    calculate the running total of sales per customer.  
    Results will include CustomerId, OrderDate, Amount, RunningTotal
*/

SELECT  CustomerId
      ,OrderDate
      ,Amount
      ,SUM(Amount) OVER(PARTITION BY CustomerId ORDER BY OrderDate) as RunningTotal
  FROM Orders
  Order by CustomerId, OrderDate