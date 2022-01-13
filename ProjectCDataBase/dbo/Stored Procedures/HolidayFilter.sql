
CREATE PROCEDURE HolidayFilter 
	-- Add the parameters for the stored procedure here
	@Category nvarchar(50),
	@Location nvarchar(50),
	@TempRating nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.Holiday 
	where Category like '%' + @Category + '%' and Location like '%' + @Location + '%' and TempRating like '%' + @TempRating+ '%'
END