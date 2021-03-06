USE [assignment]
GO
/****** Object:  Table [dbo].[tblEmployeeMaster]    Script Date: 2019-12-24 5:34:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployeeMaster](
	[empId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](80) NOT NULL,
	[mobile] [nvarchar](80) NOT NULL,
	[employeeRole] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[active] [bit] NULL,
 CONSTRAINT [Pk_tblEmployeeMaster] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [assignmentMaster]
) ON [assignmentMaster]
GO
/****** Object:  Table [dbo].[tblempRole]    Script Date: 2019-12-24 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblempRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employeeRole] [nvarchar](30) NOT NULL,
 CONSTRAINT [Pk_tblempRole] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProject]    Script Date: 2019-12-24 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProject](
	[projectId] [int] IDENTITY(1,1) NOT NULL,
	[projectTitle] [nvarchar](80) NOT NULL,
	[assignee] [int] NOT NULL,
	[projectStatus] [int] NOT NULL,
	[progress] [decimal](18, 2) NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[active] [bit] NULL,
 CONSTRAINT [Pk_tblProject] PRIMARY KEY CLUSTERED 
(
	[projectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [assignmentMaster]
) ON [assignmentMaster]
GO
/****** Object:  Table [dbo].[tblProjectStaff]    Script Date: 2019-12-24 5:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProjectStaff](
	[projectId] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NOT NULL,
	[active] [bit] NULL,
 CONSTRAINT [Pk_tblProjectStaff] PRIMARY KEY CLUSTERED 
(
	[projectId] ASC,
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [assignmentMaster]
) ON [assignmentMaster]
GO
ALTER TABLE [dbo].[tblEmployeeMaster] ADD  DEFAULT (getdate()) FOR [createdOn]
GO
ALTER TABLE [dbo].[tblEmployeeMaster] ADD  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[tblProject] ADD  DEFAULT (getdate()) FOR [createdOn]
GO
ALTER TABLE [dbo].[tblProject] ADD  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[tblProjectStaff] ADD  DEFAULT (getdate()) FOR [createdOn]
GO
ALTER TABLE [dbo].[tblProjectStaff] ADD  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[tblEmployeeMaster]  WITH CHECK ADD  CONSTRAINT [Fk_tblEmployeeMaster_tblempRole] FOREIGN KEY([employeeRole])
REFERENCES [dbo].[tblempRole] ([id])
GO
ALTER TABLE [dbo].[tblEmployeeMaster] CHECK CONSTRAINT [Fk_tblEmployeeMaster_tblempRole]
GO
ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [Fk_tblProject_tblEmployeeMaster] FOREIGN KEY([assignee])
REFERENCES [dbo].[tblEmployeeMaster] ([empId])
GO
ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [Fk_tblProject_tblEmployeeMaster]
GO
ALTER TABLE [dbo].[tblProjectStaff]  WITH CHECK ADD  CONSTRAINT [Fk_tblProjectStaff_tblEmployeeMaster] FOREIGN KEY([empId])
REFERENCES [dbo].[tblEmployeeMaster] ([empId])
GO
ALTER TABLE [dbo].[tblProjectStaff] CHECK CONSTRAINT [Fk_tblProjectStaff_tblEmployeeMaster]
GO
ALTER TABLE [dbo].[tblProjectStaff]  WITH CHECK ADD  CONSTRAINT [Fk_tblProjectStaff_tblProject] FOREIGN KEY([projectId])
REFERENCES [dbo].[tblProject] ([projectId])
GO
ALTER TABLE [dbo].[tblProjectStaff] CHECK CONSTRAINT [Fk_tblProjectStaff_tblProject]
GO
