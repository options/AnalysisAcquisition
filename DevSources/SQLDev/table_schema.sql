CREATE TABLE TBS_HTMLTEST
(
  NM_PRO         VARCHAR(2000) NOT NULL,
  NO_PRO         VARCHAR(200),
  CD_COUNTRY     VARCHAR(50),
  DS_PRO_STATUS  VARCHAR(50),
  DS_PTMOA       VARCHAR(50),
  DS_SOFA        VARCHAR(max),
  DT_REG_FST     SMALLDATETIME DEFAULT(GETDATE()),
  FG_DEL         VARCHAR(5),
  ID_ATTACH      VARCHAR(500),
  CONSTRAINT PK_TBS_HTMLTEST PRIMARY KEY CLUSTERED (NO_PRO)
)
GO

INSERT INTO TBS_HTMLTEST(NM_PRO
               ,NO_PRO
               ,CD_COUNTRY
               ,DS_PRO_STATUS
               ,DS_PTMOA
               ,DS_SOFA
               ,DT_REG_FST
               ,FG_DEL
               ,ID_ATTACH
            )
            VALUES
            (
                'Sustainable Highlands Highway Investment Program'
               ,'48444-002'
               ,'598'
               ,'Approved'
               ,'Loan'
               ,'Loan 3539-IND: Odisha Skills Development Project Ordinary capital resources:US$ 102.00million'
               ,GETDATE()
               ,'N'
               ,NULL
            );


INSERT INTO TBS_HTMLTEST(NM_PRO, NO_PRO, CD_COUNTRY, DS_PRO_STATUS, DS_PTMOA, DS_SOFA, FG_DEL, ID_ATTACH)
VALUES('Karnataka State Highways Improvement Ill Project', '42513-014', '598', 'Proposed', 'Loan', 'Ordinary capital resources	US$ 350.00 million',  'N', NULL),
		('State-Level Support for National Flagship Urban Programs', '49107-003', '598', 'Proposed', 'Loan', 'Ordinary capital resources	US$ 500.00 million',  'N', NULL),
		('Dhaka Metro Project', '49258-003', '599', 'Proposed', 'Loan', 'Ordinary capital resources	US$ 1,000.00 million',  'N', NULL)


SELECT * FROM TBS_HTMLTEST;
