-- Stored Procedure Check Product Statuses IsOfferable,IsSold,IsDeleted situtaion
CREATE PROC SP_CheckProductStatuses(@productId INT)
AS
BEGIN
	DECLARE @IsOfferable bit
	DECLARE @IsSold bit
	DECLARE @IsDeleted bit
	
	SELECT  @IsDeleted = IsDeleted, @IsOfferable = IsOfferable, @IsSold = IsSold
		FROM ProductCatalogDb.dbo.Products WHERE Id = @productId;
	IF(@IsOfferable = 0)
		BEGIN
			;THROW 51000, 'Product is not offerable. Something went wrong',1;
		END
	IF(@IsDeleted = 1)
		BEGIN
			;THROW 51000, 'The product has been deleted. So can not offer this product',1;
		END
	IF(@IsSold = 1)
	BEGIN
		;THROW 51000, 'The product has been sold. You can try to offer sooner next time. :D',1;
	END
END
