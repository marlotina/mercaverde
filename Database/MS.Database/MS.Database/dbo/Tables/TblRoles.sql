CREATE TABLE [dbo].[TblRoles]
(
	[IdRole] INT IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR(50) NOT NULL,
    [RoleDescription] NVARCHAR(150) NOT NULL, 
    CONSTRAINT [PK_TblRoles] PRIMARY KEY ([IdRole]),
)
