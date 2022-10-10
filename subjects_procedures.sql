CREATE PROCEDURE [dbo].[Updatesubjects]

      @p_subid int,
	  @p_subname varchar(20)

AS

BEGIN

    

      UPDATE  subjects SET subjects_name = @p_subname
	

      WHERE subjects_id=@p_subid

END


CREATE PROCEDURE [dbo].sp_Deletesubjects
	@p_id int
	
AS
	Delete from subjects
	where subjects_id=@p_id;
RETURN 0

Alter PROCEDURE [dbo].sp_Findsubject
	@p_subid int,
	  @p_name varchar(50) output

	

AS
	SELECT
	@p_name=subjects_name 
	from subjects	where subjects_id=@p_subid;

RETURN 0