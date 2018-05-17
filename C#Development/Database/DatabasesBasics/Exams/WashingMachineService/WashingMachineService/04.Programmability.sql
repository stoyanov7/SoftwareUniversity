-- 17. Cost of Order
CREATE FUNCTION udf_GetCost
(
	 @jobId INT
)
RETURNS DECIMAL(6, 2)
AS
	 BEGIN
	 	 RETURN
	 	 (
	 		  SELECT ISNULL(SUM(p.Price), 0)
	           FROM Parts AS p
	                JOIN OrderParts AS op ON op.PartId = p.PartId
	                JOIN Orders AS o ON o.OrderId = op.OrderId
	 		  WHERE o.JobId = @jobId
	 	 )
	 END
GO

-- 18. Place Order
CREATE PROCEDURE usp_PlaceOrder
(
	 @jobId INT, 
	 @partSerialNumber VARCHAR(50),
	 @quantity INT
) 
AS
	 BEGIN
		  -- Params validation
		  IF(@quantity <= 0)
		  BEGIN;
			   THROW 50012, 'Part quantity must be more than zero!', 1
		  END

		  DECLARE @innerJobId INT =
		  (
			   SELECT j.JobId  
			   FROM Jobs AS j
			   WHERE j.JobId = @jobId
		  )

		  IF(@innerJobId IS NULL)
		  BEGIN;
			   THROW 50013, 'Job not found!', 1;
		  END

		  DECLARE @jobStatus VARCHAR = 
		  (
			   SELECT j.[Status]
			   FROM Jobs AS j
			   WHERE j.JobId = @jobId
		  )

		  IF(@jobStatus = 'Finished')
		  BEGIN;
			   THROW 50011, 'This job is not active!', 1;
		  END

		  DECLARE @serialNumber VARCHAR = 
		  (
			   SELECT p.SerialNumber
			   FROM Parts AS p
			   WHERE SerialNumber = @partSerialNumber
		  )

		  IF(@serialNumber IS NULL)
          BEGIN;
                 THROW 50014, 'Part not found!', 1;
		  END;

		  -- Create Order if not exists
		  IF(
			   (
			       SELECT JobId
			       FROM Orders
			       WHERE JobId = @jobId
			             AND IssueDate IS NULL
			   ) IS NULL)
			   BEGIN
                 INSERT INTO Orders(JobId, IssueDate, Delivered)
                 VALUES
                 (@jobId, NULL, 0);
			   END

		   -- Add part to order if not exists
		   DECLARE @orderId INT=
		   (
		       SELECT TOP (1) o.OrderId
		       FROM Orders AS o
		       WHERE o.JobId = @jobId AND
			         o.IssueDate IS NULL
		   )

		   DECLARE @partId INT=
		   (
		       SELECT p.PartId
		       FROM Parts AS p
		       WHERE p.SerialNumber = @partSerialNumber
		   )

           IF(
           (
               SELECT PartId
               FROM OrderParts
               WHERE PartId = @partId
                     AND OrderId = @orderId
           ) IS NULL)
             BEGIN
                 INSERT INTO OrderParts(OrderId, PartId, Quantity)
                 VALUES
                 (@orderId, @partId, @quantity);
		  END
		  -- Part exists in the order - Add quantity
             ELSE
             BEGIN
                 UPDATE OrderParts
                 SET Quantity += @quantity
                 WHERE PartId = @partId AND
					   OrderId = @orderId
			 END
	 END
	 GO
-- 19.	Detect Delivery
CREATE TRIGGER te_UpdateStockQuantityUponDeliveryArrival ON Orders
AFTER UPDATE
AS
     BEGIN
         IF(
           (
               SELECT Delivered
               FROM deleted
           ) = 0
           AND
           (
               SELECT Delivered
               FROM inserted
           ) = 1)
             BEGIN
			 -- Extract order data
                 WITH cte_OrderDataFromOrderParts(OrderId,
                                                  PartId,
                                                  Quantity)
                      AS (
                      SELECT OrderId,
                             PartId,
                             SUM(Quantity) AS Quantity
                      FROM OrderParts
                      WHERE OrderId =
                      (
                          SELECT OrderId
                          FROM inserted
                      )
                      GROUP BY OrderId,
                               PartId)

				  -- Update StockQty
                      UPDATE Parts
                      SET StockQty+=cte.Quantity
                      FROM cte_OrderDataFromOrderParts AS cte
                      WHERE Parts.PartId = cte.PartId;
         END
	 END

-- 20.	Vendor Preference
WITH cte_JoinedGroupedTables
     AS (
     SELECT m.MechanicId,
            v.VendorId,
            SUM(op.Quantity) AS PartsForMechanicByVendor
     FROM Mechanics AS m
          JOIN jobs AS j ON j.MechanicId = m.MechanicId
          JOIN Orders AS o ON o.JobId = j.JobId
          JOIN OrderParts AS op ON op.OrderId = o.OrderId
          JOIN Parts AS p ON p.PartId = op.PartId
          JOIN Vendors AS v ON v.VendorId = p.VendorId
     GROUP BY m.MechanicId,
              v.VendorId
	 )

     SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
            v.Name AS Vendor,
            cte.PartsForMechanicByVendor AS Parts,
            CONCAT(FLOOR(cte.PartsForMechanicByVendor * 1.0 /
			(
			    SELECT SUM(PartsForMechanicByVendor)
			    FROM cte_JoinedGroupedTables
			    WHERE MechanicId = m.MechanicId
			) * 100), '%') AS Preference
     FROM cte_JoinedGroupedTables AS cte
          JOIN Mechanics AS m ON m.MechanicId = cte.MechanicId
          JOIN Vendors AS v ON v.VendorId = cte.VendorId
     ORDER BY Mechanic,
              Parts DESC,
			  Vendor