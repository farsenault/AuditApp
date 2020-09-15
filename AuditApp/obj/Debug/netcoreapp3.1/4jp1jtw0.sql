IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AuditEvents] (
    [Id] bigint NOT NULL IDENTITY,
    [Application] nvarchar(max) NULL,
    [Tenant] nvarchar(max) NULL,
    [User] nvarchar(max) NULL,
    [Type] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [HappenedOn] datetime2 NOT NULL,
    [JSON] nvarchar(max) NULL,
    CONSTRAINT [PK_AuditEvents] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200914201918_init', N'3.1.8');

GO

