USE [master]
GO
/****** Object:  Database [RealEstate]    Script Date: 31.01.2022 11:14:16 ******/
CREATE DATABASE [RealEstate]
GO

USE [RealEstate]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 31.01.2022 11:14:16 ******/
SET ANSI_NULLS ON
CREATE TABLE [dbo].[Address](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TownID] [int] NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressCity]    Script Date: 31.01.2022 11:14:16 ******/
SET ANSI_NULLS ON
CREATE TABLE [dbo].[AddressCity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_AddressCity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressCountry]    Script Date: 31.01.2022 11:14:16 ******/
SET ANSI_NULLS ON
CREATE TABLE [dbo].[AddressCountry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_AddressCountry] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressTown]    Script Date: 31.01.2022 11:14:16 ******/
SET ANSI_NULLS ON
CREATE TABLE [dbo].[AddressTown](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CityID] [int] NOT NULL,
 CONSTRAINT [PK_AddressTown] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 31.01.2022 11:14:16 ******/
SET ANSI_NULLS ON
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Level] [smallint] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 31.01.2022 11:14:16 ******/
SET ANSI_NULLS ON
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[ProfilePicUrl] [nvarchar](max) NULL,
	[AddressID] [int] NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_AddressTown] FOREIGN KEY([TownID])
REFERENCES [dbo].[AddressTown] ([ID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_AddressTown]
GO
ALTER TABLE [dbo].[AddressCity]  WITH CHECK ADD  CONSTRAINT [FK_AddressCity_AddressCountry] FOREIGN KEY([CountryID])
REFERENCES [dbo].[AddressCountry] ([ID])
GO
ALTER TABLE [dbo].[AddressCity] CHECK CONSTRAINT [FK_AddressCity_AddressCountry]
GO
ALTER TABLE [dbo].[AddressTown]  WITH CHECK ADD  CONSTRAINT [FK_AddressTown_AddressCity] FOREIGN KEY([CityID])
REFERENCES [dbo].[AddressCity] ([ID])
GO
ALTER TABLE [dbo].[AddressTown] CHECK CONSTRAINT [FK_AddressTown_AddressCity]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Address] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Address]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
