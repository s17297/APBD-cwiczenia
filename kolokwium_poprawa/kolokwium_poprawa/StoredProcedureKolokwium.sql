  
CREATE PROCEDURE UpdateEndTime @IdAction INT, @EndTime DATETIME  
AS  
BEGIN  
   
 DECLARE @End DATETIME, @Price DECIMAL(5,2);  
	select @End = "Action".EndTime from "Action" where idaction = @IdAction;
 
 SET XACT_ABORT ON;  
 BEGIN TRAN;  
   
if @End is null
	begin
	if (select StartTime from "Action" where IdAction = @IdAction) < @EndTime
		begin
		update "Action" 
		set EndTime = @EndTime
		where IdAction = @IdAction
		end
	else
		begin
		RAISERROR('Data wczesniejsza niz data rozpoczecia ', 18, 0);
		end
	end
else
begin
RAISERROR('Data juz podana ', 18, 0);
 end
 COMMIT;  
END;