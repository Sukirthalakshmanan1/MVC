--delete student
CREATE PROCEDURE [dbo].sp_Deletestudent
	@p_id int
	
AS
	Delete from student
	where student_id=@p_id;
RETURN 0
--find student
Alter PROCEDURE [dbo].sp_Findstudent
	@p_stuid int,@p_stuclass int output,
	  @p_name varchar(20) output

	

AS
	SELECT
	@p_name=student_name ,@p_stuclass=student_class
	from student	where student_id=@p_stuid;

RETURN 0


--find class
create PROCEDURE [dbo].sp_FindClass1
	@p_stuid int,@p_stuclass int output

AS
	SELECT @p_stuclass=class_strength
	from Class1	where Room_no=@p_stuid;

RETURN 0

--update student table

Alter PROCEDURE [dbo].[Updatestudent]

      @p_stuid int,
	  @p_stuname varchar(20),
	  @p_stuclass int

AS

BEGIN

    

      UPDATE  student SET student_name = @p_stuname,
	  student_class=@p_stuclass
	

      WHERE student_id=@p_stuid

END


--update class
Create PROCEDURE [dbo].[UpdatesClass1]

      @p_stuid int,
	  
	  @p_stuclass int

AS

BEGIN

    

      UPDATE  Class1 SET 
	  class_strength=@p_stuclass
	

      WHERE Room_no=@p_stuid

END


CREATE PROCEDURE [dbo].sp_Delete
	@p_id int
	
AS
	Delete from Class1
	where Room_no=@p_id;
RETURN 0

