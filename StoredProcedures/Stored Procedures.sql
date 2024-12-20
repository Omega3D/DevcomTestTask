USE [devcom]
GO
/****** Object:  StoredProcedure [dbo].[spCreateAnnouncement]    Script Date: 19.12.2024 22:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateAnnouncement]
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Status NVARCHAR(50),
    @Category NVARCHAR(100),
    @SubCategory NVARCHAR(100)
AS
BEGIN
    INSERT INTO Announcements (Title, Description, CreatedDate, Status, Category, SubCategory)
    VALUES (@Title, @Description, GETDATE(), @Status, @Category, @SubCategory);
END;
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAnnouncement]    Script Date: 19.12.2024 22:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteAnnouncement]
    @Id INT
AS
BEGIN
    DELETE FROM Announcements WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetAllAnnouncements]    Script Date: 19.12.2024 22:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllAnnouncements]
AS
BEGIN
    SELECT * FROM Announcements;
END;
GO
/****** Object:  StoredProcedure [dbo].[spGetAnnouncementById]    Script Date: 19.12.2024 22:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAnnouncementById]
    @Id INT
AS
BEGIN
    SELECT * FROM Announcements WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAnnouncement]    Script Date: 19.12.2024 22:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateAnnouncement]
    @Id INT,
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Status NVARCHAR(50),
    @Category NVARCHAR(100),
    @SubCategory NVARCHAR(100)
AS
BEGIN
    UPDATE Announcements
    SET Title = @Title,
        Description = @Description,
        Status = @Status,
        Category = @Category,
        SubCategory = @SubCategory
    WHERE Id = @Id;
END;
GO
