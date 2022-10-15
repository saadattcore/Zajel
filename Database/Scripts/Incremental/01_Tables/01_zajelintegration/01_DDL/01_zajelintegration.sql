Create table ZAJELINTEGRATION
(
  id                    NCHAR(32) not null,
  system_key            NCHAR(32) not null,
  application_id        NVARCHAR2(1000) not null,
  contactno             NVARCHAR2(50),
  landlineno            NVARCHAR2(50),
  sponsorname           NVARCHAR2(1000),
  area                  NVARCHAR2(1000),
  address               NVARCHAR2(1000),
  pobox                 NVARCHAR2(50),
  odrstatus             NVARCHAR2(2),
  deliverymode          NUMBER(38) default 0,
  applicationtype       NVARCHAR2(1000),
  fileno                NVARCHAR2(1000),
  producttype           NUMBER(38) default 0,
  airwaybillid          NVARCHAR2(50),
  responsecurrentstatus NVARCHAR2(50),
  responsedescription   NVARCHAR2(1000),
  responseresult        NVARCHAR2(50)
)
;