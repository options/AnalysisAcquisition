CREATE TABLE HTMLTEST.TBS_HTMLTEST
(
  NM_PRO         VARCHAR2(2000 BYTE)            NOT NULL,
  NO_PRO         VARCHAR2(200 BYTE),
  CD_COUNTRY     VARCHAR2(50 BYTE),
  DS_PRO_STATUS  VARCHAR2(50 BYTE),
  DS_PTMOA       VARCHAR2(50 BYTE),
  DS_SOFA        CLOB,
  DT_REG_FST     DATE,
  FG_DEL         VARCHAR2(5 BYTE),
  ID_ATTACH      VARCHAR2(500 BYTE)
)
TABLESPACE TS_BASE_WEB2
PCTUSED    40
PCTFREE    10
INITRANS   1
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            FREELISTS        1
            FREELIST GROUPS  1
            BUFFER_POOL      DEFAULT
           )
LOGGING 
NOCOMPRESS 
LOB (DS_SOFA) STORE AS 
      ( TABLESPACE  TS_BASE_WEB2 
        ENABLE      STORAGE IN ROW
        CHUNK       8192
        RETENTION
        NOCACHE
        INDEX       (
          TABLESPACE TS_BASE_WEB2
          STORAGE    (
                      INITIAL          64K
                      NEXT             1
                      MINEXTENTS       1
                      MAXEXTENTS       UNLIMITED
                      PCTINCREASE      0
                      FREELISTS        1
                      FREELIST GROUPS  1
                      BUFFER_POOL      DEFAULT
                     ))
        STORAGE    (
                    INITIAL          64K
                    NEXT             1M
                    MINEXTENTS       1
                    MAXEXTENTS       UNLIMITED
                    PCTINCREASE      0
                    FREELISTS        1
                    FREELIST GROUPS  1
                    BUFFER_POOL      DEFAULT
                   )
      )
NOCACHE
NOPARALLEL
MONITORING;
 
 
CREATE UNIQUE INDEX HTMLTEST.TBS_HTMLTEST_PK ON HTMLTEST.TBS_HTMLTEST
(NO_PRO)
LOGGING
TABLESPACE TS_BASE_WEB2
PCTFREE    10
INITRANS   2
MAXTRANS   255
STORAGE    (
            INITIAL          64K
            NEXT             1M
            MINEXTENTS       1
            MAXEXTENTS       UNLIMITED
            PCTINCREASE      0
            FREELISTS        1
            FREELIST GROUPS  1
            BUFFER_POOL      DEFAULT
           )
NOPARALLEL;
 
 
ALTER TABLE HTMLTEST.TBS_HTMLTEST ADD (
  CONSTRAINT TBS_HTMLTEST_PK
 PRIMARY KEY
 (NO_PRO)
    USING INDEX 
    TABLESPACE TS_BASE_WEB2
    PCTFREE    10
    INITRANS   2
    MAXTRANS   255
    STORAGE    (
                INITIAL          64K
                NEXT             1M
                MINEXTENTS       1
                MAXEXTENTS       UNLIMITED
                PCTINCREASE      0
                FREELISTS        1
                FREELIST GROUPS  1
               ));


INSERT INTO TBS_HTMLTEST
            (
               NM_PRO
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
                #{NM_PRO}
               ,#{NO_PRO}
               ,#{CD_COUNTRY}
               ,#{DS_PRO_STATUS}
               ,#{DS_PTMOA}
               ,#{DS_SOFA}
               ,SYSDATE
               ,'N'
               ,#{ID_ATTACH}
            )


INSERT INTO TBS_HTMLTEST
            (
               NM_PRO
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
               ,¡®Loan 3539-IND: Odisha Skills Development Project
Ordinary capital resources:US$ 102.00million¡¯


               ,SYSDATE
               ,'N'
               ,NULL
            )
