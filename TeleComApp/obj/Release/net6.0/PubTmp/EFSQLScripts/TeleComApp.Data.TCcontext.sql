IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135006_Initial_DB')
BEGIN
    CREATE TABLE [PhoneNumbers] (
        [PhoneNumberId] int NOT NULL IDENTITY,
        [Number] int NOT NULL,
        [PlanId] int NOT NULL,
        CONSTRAINT [PK_PhoneNumbers] PRIMARY KEY ([PhoneNumberId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135006_Initial_DB')
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135006_Initial_DB')
BEGIN
    CREATE TABLE [Plans] (
        [PlanId] int NOT NULL IDENTITY,
        [Type] int NOT NULL,
        [PhoneLines] int NOT NULL,
        [NumberLines] int NOT NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_Plans] PRIMARY KEY ([PlanId]),
        CONSTRAINT [FK_Plans_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135006_Initial_DB')
BEGIN
    CREATE TABLE [Devices] (
        [DeviceId] int NOT NULL IDENTITY,
        [Model] nvarchar(max) NOT NULL,
        [PhoneNumber] int NOT NULL,
        [IsActive] bit NOT NULL,
        [UserId] int NOT NULL,
        [PlanId] int NULL,
        CONSTRAINT [PK_Devices] PRIMARY KEY ([DeviceId]),
        CONSTRAINT [FK_Devices_Plans_PlanId] FOREIGN KEY ([PlanId]) REFERENCES [Plans] ([PlanId]),
        CONSTRAINT [FK_Devices_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135006_Initial_DB')
BEGIN
    CREATE INDEX [IX_Devices_PlanId] ON [Devices] ([PlanId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135006_Initial_DB')
BEGIN
    CREATE INDEX [IX_Devices_UserId] ON [Devices] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135006_Initial_DB')
BEGIN
    CREATE INDEX [IX_Plans_UserId] ON [Plans] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135006_Initial_DB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220831135006_Initial_DB', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135429_Computed_prop_NumLines')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Plans]') AND [c].[name] = N'NumberLines');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Plans] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Plans] DROP COLUMN [NumberLines];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135429_Computed_prop_NumLines')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220831135429_Computed_prop_NumLines', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135950_Computed_Prop_IsActive')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Devices]') AND [c].[name] = N'IsActive');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Devices] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Devices] DROP COLUMN [IsActive];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220831135950_Computed_Prop_IsActive')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220831135950_Computed_Prop_IsActive', N'6.0.8');
END;
GO

COMMIT;
GO

