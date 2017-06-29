CREATE TABLE TB_PROJECTS
(
	SEQ INT IDENTITY(1,1),
	ProjectID AS (CONVERT(NVARCHAR(20), SEQ) + '_' + ProjectName) PERSISTED NOT NULL,
	ProjectName NVARCHAR(250) NOT NULL,
	ProjectNumber NVARCHAR(50) NOT NULL,
	Country NVARCHAR(50) NOT NULL,
	ProjectStatus NVARCHAR(20) NOT NULL,
	ProjectType NVARCHAR(50) NOT NULL,
	SourceofFunding NVARCHAR(250) NOT NULL,
	Amount Money,
	CONSTRAINT PK_TB_PROJECTS PRIMARY KEY CLUSTERED (ProjectID)
)
GO

INSERT INTO TB_PROJECTS(ProjectName, ProjectNumber, Country, ProjectStatus, ProjectType, SourceofFunding, Amount) VALUES('Karnataka State Highways Improvement Ill Project', '42513-014', 'India', 'Proposed', 'Loan', 'Ordinary capital resources', 350.00);
INSERT INTO TB_PROJECTS(ProjectName, ProjectNumber, Country, ProjectStatus, ProjectType, SourceofFunding, Amount) VALUES('State-Level Support for National Flagship Urban Programs', '49107-003', 'India', 'Proposed', 'Loan', 'Ordinary capital resources', 500.00);
INSERT INTO TB_PROJECTS(ProjectName, ProjectNumber, Country, ProjectStatus, ProjectType, SourceofFunding, Amount) VALUES('Dhaka Metro Project', '49258-003', 'Bangladesh', 'Proposed', 'Loan', 'Ordinary capital resources', 1000.00);