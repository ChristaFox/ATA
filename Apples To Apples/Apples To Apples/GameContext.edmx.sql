
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/28/2014 21:08:19
-- Generated from EDMX file: C:\Users\Christa\Documents\GitHub\ATA\Apples To Apples\Apples To Apples\GameContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ApplesToApplesDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PlayerInfo_inherits_GameInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameInfoes_PlayerInfo] DROP CONSTRAINT [FK_PlayerInfo_inherits_GameInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoundInfo_inherits_GameInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameInfoes_RoundInfo] DROP CONSTRAINT [FK_RoundInfo_inherits_GameInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UseDeck_inherits_GameInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameInfoes_UseDeck] DROP CONSTRAINT [FK_UseDeck_inherits_GameInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[GameInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameInfoes];
GO
IF OBJECT_ID(N'[dbo].[GreenDeckOfCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GreenDeckOfCards];
GO
IF OBJECT_ID(N'[dbo].[GameInfoes_PlayerInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameInfoes_PlayerInfo];
GO
IF OBJECT_ID(N'[dbo].[RedDeckOfCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RedDeckOfCards];
GO
IF OBJECT_ID(N'[dbo].[GameInfoes_RoundInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameInfoes_RoundInfo];
GO
IF OBJECT_ID(N'[dbo].[GameInfoes_UseDeck]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameInfoes_UseDeck];
GO
IF OBJECT_ID(N'[dbo].[UserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLogins];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GameInfoes'
CREATE TABLE [dbo].[GameInfoes] (
    [GameID] int IDENTITY(1,1) NOT NULL,
    [NumberOfPlayers] int  NOT NULL
);
GO

-- Creating table 'GreenDeckOfCards'
CREATE TABLE [dbo].[GreenDeckOfCards] (
    [GreenIndex] int  NOT NULL,
    [adj] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'GameInfoes_PlayerInfo'
CREATE TABLE [dbo].[GameInfoes_PlayerInfo] (
    [PlayerNumber] int IDENTITY(1,1) NOT NULL,
    [AwesomePoints] nchar(10)  NOT NULL,
    [Choice] nchar(10)  NOT NULL,
    [GameID] int  NOT NULL
);
GO

-- Creating table 'RedDeckOfCards'
CREATE TABLE [dbo].[RedDeckOfCards] (
    [RedIndex] int  NOT NULL,
    [noun] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'GameInfoes_RoundInfo'
CREATE TABLE [dbo].[GameInfoes_RoundInfo] (
    [Round] int IDENTITY(1,1) NOT NULL,
    [JudgeNumber] int  NOT NULL,
    [AdjectiveCard] nchar(10)  NULL,
    [GameID] int  NOT NULL
);
GO

-- Creating table 'GameInfoes_UseDeck'
CREATE TABLE [dbo].[GameInfoes_UseDeck] (
    [GreenCard] nvarchar(50)  NULL,
    [RedCard] nvarchar(50)  NULL,
    [GameID] int  NOT NULL
);
GO

-- Creating table 'UserLogins'
CREATE TABLE [dbo].[UserLogins] (
    [ProvidedID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [email] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GameID] in table 'GameInfoes'
ALTER TABLE [dbo].[GameInfoes]
ADD CONSTRAINT [PK_GameInfoes]
    PRIMARY KEY CLUSTERED ([GameID] ASC);
GO

-- Creating primary key on [GreenIndex] in table 'GreenDeckOfCards'
ALTER TABLE [dbo].[GreenDeckOfCards]
ADD CONSTRAINT [PK_GreenDeckOfCards]
    PRIMARY KEY CLUSTERED ([GreenIndex] ASC);
GO

-- Creating primary key on [GameID] in table 'GameInfoes_PlayerInfo'
ALTER TABLE [dbo].[GameInfoes_PlayerInfo]
ADD CONSTRAINT [PK_GameInfoes_PlayerInfo]
    PRIMARY KEY CLUSTERED ([GameID] ASC);
GO

-- Creating primary key on [RedIndex] in table 'RedDeckOfCards'
ALTER TABLE [dbo].[RedDeckOfCards]
ADD CONSTRAINT [PK_RedDeckOfCards]
    PRIMARY KEY CLUSTERED ([RedIndex] ASC);
GO

-- Creating primary key on [GameID] in table 'GameInfoes_RoundInfo'
ALTER TABLE [dbo].[GameInfoes_RoundInfo]
ADD CONSTRAINT [PK_GameInfoes_RoundInfo]
    PRIMARY KEY CLUSTERED ([GameID] ASC);
GO

-- Creating primary key on [GameID] in table 'GameInfoes_UseDeck'
ALTER TABLE [dbo].[GameInfoes_UseDeck]
ADD CONSTRAINT [PK_GameInfoes_UseDeck]
    PRIMARY KEY CLUSTERED ([GameID] ASC);
GO

-- Creating primary key on [UserName] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [PK_UserLogins]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GameID] in table 'GameInfoes_PlayerInfo'
ALTER TABLE [dbo].[GameInfoes_PlayerInfo]
ADD CONSTRAINT [FK_PlayerInfo_inherits_GameInfo]
    FOREIGN KEY ([GameID])
    REFERENCES [dbo].[GameInfoes]
        ([GameID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GameID] in table 'GameInfoes_RoundInfo'
ALTER TABLE [dbo].[GameInfoes_RoundInfo]
ADD CONSTRAINT [FK_RoundInfo_inherits_GameInfo]
    FOREIGN KEY ([GameID])
    REFERENCES [dbo].[GameInfoes]
        ([GameID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GameID] in table 'GameInfoes_UseDeck'
ALTER TABLE [dbo].[GameInfoes_UseDeck]
ADD CONSTRAINT [FK_UseDeck_inherits_GameInfo]
    FOREIGN KEY ([GameID])
    REFERENCES [dbo].[GameInfoes]
        ([GameID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------