Create Procedure dbo.spPrizes_Insert
	@PlaceNumber int, 
	@PlaceName nvarchar(50),
	@PrizeAmt money,
	@PrizePercent float,
	@id int = 0 output
As
Begin
	Set NoCount On;
	
	Insert into dbo.Prizes (PlaceNumber, PlaceName, PrizeAmt, PrizePercent)
	Values (@PlaceNumber, @PlaceName, @PrizeAmt, @PrizePercent);

	Select @id = SCOPE_IDENTITY();
End

Go