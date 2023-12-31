USE master
GO
DROP DATABASE IF EXISTS [digital_examinations]
GO
CREATE DATABASE [digital_examinations]
GO
USE [digital_examinations]
GO
CREATE TABLE [dbo].[answers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[answerText] [varchar](800) NULL,
	[isCorrect] [bit] NULL,
	[questionId] [int] NULL,
 CONSTRAINT [PK__answers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[exams]    Script Date: 09/09/2023 06:33:02 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exams](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](500) NULL,
 CONSTRAINT [PK_exams] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[questions]    Script Date: 09/09/2023 06:33:02 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[questions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[questionText] [varchar](500) NULL,
	[questionType] [int] NULL,
	[score] [int] NULL,
	[examId] [int] NULL,
 CONSTRAINT [PK__question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student_exam_answers]    Script Date: 09/09/2023 06:33:02 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student_exam_answers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentExamId] [int] NULL,
	[asnwerId] [int] NULL,
	[answerText] [varchar](800) NULL,
	[score] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student_exams]    Script Date: 09/09/2023 06:33:02 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student_exams](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[examId] [int] NULL,
	[studentId] [int] NULL,
	[score] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[students]    Script Date: 09/09/2023 06:33:02 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](500) NULL,
 CONSTRAINT [PK_students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[answers]  WITH CHECK ADD  CONSTRAINT [FK_answers_questions] FOREIGN KEY([questionId])
REFERENCES [dbo].[questions] ([id])
GO
ALTER TABLE [dbo].[answers] CHECK CONSTRAINT [FK_answers_questions]
GO
ALTER TABLE [dbo].[questions]  WITH CHECK ADD  CONSTRAINT [FK_questions_exams] FOREIGN KEY([examId])
REFERENCES [dbo].[exams] ([id])
GO
ALTER TABLE [dbo].[questions] CHECK CONSTRAINT [FK_questions_exams]
GO
ALTER TABLE [dbo].[student_exam_answers]  WITH CHECK ADD  CONSTRAINT [FK_student_exam_answers_answers] FOREIGN KEY([asnwerId])
REFERENCES [dbo].[answers] ([id])
GO
ALTER TABLE [dbo].[student_exam_answers] CHECK CONSTRAINT [FK_student_exam_answers_answers]
GO
ALTER TABLE [dbo].[student_exam_answers]  WITH CHECK ADD  CONSTRAINT [FK_student_exam_answers_student_exams] FOREIGN KEY([studentExamId])
REFERENCES [dbo].[student_exams] ([id])
GO
ALTER TABLE [dbo].[student_exam_answers] CHECK CONSTRAINT [FK_student_exam_answers_student_exams]
GO
ALTER TABLE [dbo].[student_exams]  WITH CHECK ADD  CONSTRAINT [FK_student_exams_exams] FOREIGN KEY([examId])
REFERENCES [dbo].[exams] ([id])
GO
ALTER TABLE [dbo].[student_exams] CHECK CONSTRAINT [FK_student_exams_exams]
GO
ALTER TABLE [dbo].[student_exams]  WITH CHECK ADD  CONSTRAINT [FK_student_exams_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([id])
GO
ALTER TABLE [dbo].[student_exams] CHECK CONSTRAINT [FK_student_exams_students]
GO
