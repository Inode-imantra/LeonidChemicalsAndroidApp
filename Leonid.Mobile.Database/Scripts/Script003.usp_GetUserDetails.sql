--- ===============================================================================
-- Author:		<Abhijith>
-- Create date: <01-16-2017>
-- Description:	Getting the User details based on username and password.
-- ================================================================================


IF OBJECT_ID(N'usp_GetUserDetails', N'P') IS NOT NULL
BEGIN
     DROP PROCEDURE  usp_GetUserDetails
END
GO

CREATE PROCEDURE usp_GetUserDetails
(
	 @userName VARCHAR(250)
	 ,@password VARCHAR(250)
)
AS
BEGIN
	 SELECT 
	  UserId
	  ,Name 
	  ,Email
	  ,RoleId
	 FROM tUsers 
     WHERE
         UserName = @userName AND Password = @password
END
GO


