

--TRIGGER
ALTER Trigger TR_UPDATEOFFER
On ProductCatalogDb.dbo.OFFERS 
INSTEAD OF INSERT
	AS
	BEGIN
		DECLARE @Id INT;
		DECLARE @offeredPrice float;
		SELECT @Id = ProductId, @offeredPrice = OfferedPrice FROM INSERTED;
		EXEC SP_CheckSpeciallyPricedCategory @productId = @Id, @offerPrice =  @offeredPrice
		EXEC SP_CheckProductStatuses @productId = @Id
		INSERT INTO Offers 
		SELECT PercentRate,IsApproved,IsSold,OfferedPrice,UserId,ProductId,CreatedDate,IsDeleted  FROM INSERTED
	END