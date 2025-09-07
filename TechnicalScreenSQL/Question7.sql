/*
    Given a table Employees with columns: EmployeeID, Name, ManagerID.
    •	Write a recursive CTE to display the hierarchy starting from the top-level manager.
    •	Include EmployeeID, Name, ManagerID, ManagerName, and Level (depth in the hierarchy).
*/

WITH Hierarchy AS (
    SELECT
       EmployeeID
      ,[Name]
      ,ManagerID
      ,CAST(NULL AS VARCHAR(100)) as ManagerName
      ,0 AS [Level]
    FROM Employees
    WHERE ManagerID IS NULL
    UNION ALL
    SELECT
       e.EmployeeID
      ,e.[Name]
      ,e.ManagerID
      ,h.[Name] as ManagerName
      ,h.[Level] + 1 AS [Level]
    FROM Employees AS e
    INNER JOIN Hierarchy AS h ON e.ManagerID = h.EmployeeID
)

SELECT EmployeeId
    ,[Name]
    ,ManagerID
    ,ManagerName
    ,[Level]
FROM Hierarchy
ORDER BY [Level], EmployeeID
OPTION (MAXRECURSION 5); -- don't want to loop forever if managers reference each other