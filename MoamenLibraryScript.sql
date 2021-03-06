USE [master]
GO
/****** Object:  Database [LibrarySystem]    Script Date: 9/29/2020 2:41:33 PM ******/
CREATE DATABASE [LibrarySystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibrarySystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LibrarySystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibrarySystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\LibrarySystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibrarySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibrarySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibrarySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibrarySystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibrarySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibrarySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibrarySystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LibrarySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibrarySystem] SET  MULTI_USER 
GO
ALTER DATABASE [LibrarySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibrarySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibrarySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibrarySystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibrarySystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [LibrarySystem]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 9/29/2020 2:41:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 9/29/2020 2:41:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[NumberOfCopies] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/29/2020 2:41:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserBook]    Script Date: 9/29/2020 2:41:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBook](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[NumberOfBorrowings] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserBook] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202009281529483_Init', N'Repositories.Migrations.Configuration', 0x1F8B0800000000000400ED5ADD6EDB3614BE1FB077107439A49193DE6C81DD22759AC1581307715AEC2E60A4638728456A2495D918F664BBD823ED1576A83F4BA464CB49EA14451120B0499E5F7EE790FAE4FFFEF977F8761933EF01A4A2828FFCA3C381EF010F4544F962E4A77AFEEA67FFED9B1F7F18BE8FE2A5F7A95CF7DAAC4349AE46FEBDD6C94910A8F01E62A20E631A4AA1C45C1F86220E482482E3C1E097E0E8280054E1A32ECF1B5EA75CD318B22FF8752C7808894E09BB101130558CE3CC2CD3EA5D921854424218F9D7900845B5901494EF9D324AD08719B0B9EF11CE85261A3D3CF9A860A6A5E08B59820384DDAC12C07573C214149E9FAC97F70D62706C8208D682A5AA30555AC43B2A3C7A5D6425B0C51F955BBFCA1AE6ED3DE657AF4CD459EE46FE3B213EFB9E6DE864CCA45934F233014CE961F5C1481C78E5D7836AF31123E6EFC01BA74CA712461C522D093BF0AED23B46C3DF6075233E031FF194B1BA53E816CE350670E84A8A04A45E5DC3BC707572E67B41532EB0052BB19A4C1EC884EBD7C7BE7789C6C91D836ACF6B41CF103DF02B709044437445B406895B368920CB9A63DDB275433583D21CA20C4BC5F72EC8F203F085BEC7221A60719CD32544E548E1C2474EB1B25048CB145A5CDC6CF6328DEF404EE7639164D0DF1CAEA5EB923CD04516BDA5150B459A9D4685D7C0B215EA9E2679496518B8AD2D399722BE16ACC0D37AE6762652199AA488D6E91B2217A09B5E0D8335483742B754B31B7C4BA9EF106EB16512B3DDDE661D26C14FD55162FA9D9052FC8985F46CB8CE01F314489798ED807489F85D0AADD5A152E56DBE62ED4F63C2A9B0E6EC930B6CF7E2FA5E586D80C6FF7B381A1ED9CE7B42CD467E3B10FB40ED542911D2CC0DCBC1DC856654EF79E46D847E9ED67A24985D441A4D105B687EE4FFE4A4AA4B69156453A9ADF0C8B74139E567C04083771AE657BD31512189DC4DC29C44CD11C431480324C2F0CAABB03228D72EE8290F6942D826B72DA19EB5629CAAD4DB336790003730DFB4077DEC9607836BBB3261256A5B5E86410D489BF165B5F72E2C745D5FD6606843D7B382A1D3990E64F683FBA320D69E8D3D60AC3DF23E86CB1BCC1E4096B73694D12801B270A03CFCCC382C75CBF989711547A82AFABA0D00A37706BA1612F6ED75276D20D1696B4DE15AE37714ACD1D34349970247B8962DD78DE284A9AD693D82ECCDDB7602540E37027630B0ADE75B6A1C150D28E0B21E81DBD74A37F24D9DA94F6FAA39BD3DEE8E96D2277F1B822F8FF9AA16D6444D90333525A31374503AC30B9224E69EBF962C46BC59CEEF8C5FCD76A73FE25C4710AA1616A4F2B6B284773CB2006B164DA3A7E7542A7D4634B923E6DE358E6267995DF91D35555AAB17B7BB6165A595ABCDE75CA24E74E53DC0ED8B85D43986139BAE9ADD5E2DA0B86219AF4618912D17E5B16069CCBB9B7BB774418BD4151443FD75D81C475D993DE76A1D06563E9CB3C1C9B773483737AFD7D66EAAE99EDB5B75E8DDB7B85BF4CB6C7379F0D635741DC6DD5ACA3B625D4BD7BD713B5CEAF4411B64EAF35F156C9E089947C2655F50C91F861B1B928DEC790B9C53CB5E5259AF4E2FEB941A1627C6F6B713CE11922FF13D4CCD038DCCF1315B290DF1A1597038FB838D19C578D70B2E08A773503AE749FCE3C1D1B1F59AE3EB79E5102815B11EEF1DF64EF45093D1AD54CE8E646583F7E70F4486F744BAF4CEB3D0FA59001B35ED4E9F7F1BBBD0A4AE3313CE93D7049FFF9623FFAF4CE4C49BFC7E9B4B1D7853892576E20DBCBF9FC877F7359C4B3DC9703749FECC28F9461052E7601F59A65F82CFDC2FD5E83E02EF9350EAB89C7C318EF29BE2255F8A867C09A0F4DEBC7D02E5C5B9459788D8CE1C761287F90D74E447770277366F793B518A1B19C536ED3BF18D9D746397E61720221DE2AC17E7D84AB77D7D54A3C32CEE25B81DA844F7E10B0BAEF603322C7645176B15E6E7641CC246A9556B267C2ECA8AB73C2A9758D7890BD024C23A3C959ACE49A8713A04A5B257BB9F084BCDBB00BCA045133E4D75926A0C19E23BD678556C3AC726FB195FDAF479384DB2B7B7CF1102BA49310498F277296551E5F779CBCDA743856949C51DCDECA53677B5C5AAD27429784F4545FAAA4E7A0371C250999AF2197980C7F886F0FB000B12AECA67E86E25DB37A299F6E119250B496255E858CBE357C470142FDFFC0FD2CCEE5047290000, N'6.4.4')
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [Title], [NumberOfCopies]) VALUES (1, N'C#', 3)
INSERT [dbo].[Book] ([ID], [Title], [NumberOfCopies]) VALUES (5, N'ASP.Net MVC', 2)
INSERT [dbo].[Book] ([ID], [Title], [NumberOfCopies]) VALUES (7, N'JavaScript', 1)
INSERT [dbo].[Book] ([ID], [Title], [NumberOfCopies]) VALUES (8, N'C++', 4)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Name]) VALUES (1, N'Moamen')
INSERT [dbo].[User] ([ID], [Name]) VALUES (2, N'Khaled')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserBook] ON 

INSERT [dbo].[UserBook] ([ID], [BookID], [UserID], [NumberOfBorrowings]) VALUES (1, 1, 1, 1)
INSERT [dbo].[UserBook] ([ID], [BookID], [UserID], [NumberOfBorrowings]) VALUES (3, 5, 2, 0)
INSERT [dbo].[UserBook] ([ID], [BookID], [UserID], [NumberOfBorrowings]) VALUES (4, 8, 1, 2)
INSERT [dbo].[UserBook] ([ID], [BookID], [UserID], [NumberOfBorrowings]) VALUES (5, 1, 1, 2)
INSERT [dbo].[UserBook] ([ID], [BookID], [UserID], [NumberOfBorrowings]) VALUES (6, 8, 1, 1)
INSERT [dbo].[UserBook] ([ID], [BookID], [UserID], [NumberOfBorrowings]) VALUES (7, 8, 1, 3)
INSERT [dbo].[UserBook] ([ID], [BookID], [UserID], [NumberOfBorrowings]) VALUES (8, 5, 1, 1)
SET IDENTITY_INSERT [dbo].[UserBook] OFF
/****** Object:  Index [IX_BookID]    Script Date: 9/29/2020 2:41:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookID] ON [dbo].[UserBook]
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserID]    Script Date: 9/29/2020 2:41:34 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserID] ON [dbo].[UserBook]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserBook]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserBook_dbo.Book_BookID] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserBook] CHECK CONSTRAINT [FK_dbo.UserBook_dbo.Book_BookID]
GO
ALTER TABLE [dbo].[UserBook]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserBook_dbo.User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserBook] CHECK CONSTRAINT [FK_dbo.UserBook_dbo.User_UserID]
GO
USE [master]
GO
ALTER DATABASE [LibrarySystem] SET  READ_WRITE 
GO
