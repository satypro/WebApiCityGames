IF NOT EXISTS (SELECT * FROM [User] where Username = 'bhogg')
 INSERT INTO [dbo].[User]([Firstname], [Lastname],[Username])
             VALUES(N'Boss',N'Hogg',N'bhogg')

IF NOT EXISTS (SELECT * FROM [User] where Username = 'jbob')
 INSERT INTO [dbo].[User]([Firstname], [Lastname],[Username])
             VALUES(N'Jim',N'Bob',N'jbob')

IF NOT EXISTS (SELECT * FROM [User] where Username = 'jdoe')
 INSERT INTO [dbo].[User]([Firstname], [Lastname],[Username])
             VALUES(N'John',N'Doe',N'jdoe')


IF NOT EXISTS(SELECT * FROM dbo.Task where Subject = 'Test Task')
BEGIN
  select top 1 @statusId = StatusId from Status order by StatusId;
  select top 1 @userId = UserId from [User] order by UserId;

  INSERT INTO dbo.Task(Subject,StartDate,StatusId,CreatedDate, CreatedUserId)
              VALUES('Test Task',GETDATE(),@statusId,GETDATE(),@userId);

  set @taskId = SCOPE_IDENTITY();

  INSERT INTO [dbo].[TaskUser]([taskId],[UserId])
              VALUES(@taskId,@userId)
END