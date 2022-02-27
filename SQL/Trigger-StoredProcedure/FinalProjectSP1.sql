
-- Stored Procedure for Special Category Price CategoryName => Seafood
CREATE PROC SP_CheckSpeciallyPricedCategory(@productId INT,@offerPrice float)
AS
BEGIN
	DECLARE @categoryId INT;
	DECLARE @price float;
	DECLARE @categoryName  NVARCHAR(100);
	DECLARE @priceShouldBe float;

	SELECT @categoryId = CategoryId,@price= Price FROM ProductCatalogDb.dbo.Products WHERE Id = @productId;

	SELECT @categoryName = CategoryName FROM ProductCatalogDb.dbo.Categories WHERE Id = @categoryId;

	IF(@categoryName = 'Seafood')
	BEGIN
		SET @priceShouldBe = @price + @price * 0.2;
		IF(@offerPrice < @priceShouldBe)
		BEGIN
			;THROW 51000, 'Products with Category Seafood can be offered percent 20 more than the Product price.',1;
		END
	END
END
