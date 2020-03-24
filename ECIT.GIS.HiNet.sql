--系统表
CREATE TABLE System(
	Id UUID PRIMARY KEY NOT NULL,
   	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
    Name VARCHAR(128),
    Remark VARCHAR(1024),
	Disable BOOLEAN NOT NULL DEFAULT FALSE,
    IsDelete BOOLEAN NOT NULL DEFAULT FALSE,
    Code VARCHAR(256)
);
--系统配置
CREATE TABLE SystemConfig(
	Id UUID PRIMARY KEY NOT NULL,
   	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
	CreateUserId UUID,
    LastUpdateUserId UUID,
    SystemId UUID NOT NULL,
    ConfigType INT NOT NULL,
    ConfigData  TEXT
);
--系统模块关系表
CREATE TABLE SystemModule(
	Id UUID PRIMARY KEY NOT NULL,
	SystemId UUID NOT NULL,
	ModuleId UUID NOT NULL,
	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
	Remark Varchar(100)
);

CREATE INDEX SystemModule_SystemId_Index ON SystemModule(SystemId);
CREATE INDEX SystemModule_ParentId_Index ON SystemModule(ModuleId);

--模块列表
CREATE TABLE Module(
	Id UUID PRIMARY KEY NOT NULL,
   	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
    Name VARCHAR(128),
    Remark VARCHAR(1024),
    Disable BOOLEAN NOT NULL DEFAULT FALSE,
    IsDelete BOOLEAN NOT NULL DEFAULT FALSE,
    ModuleType INT NOT NULL,
    Url VARCHAR(256),
    OrderNo serial NOT NULL,
    ParentId UUID,
    XPath VARCHAR(1024) DEFAULT ''
);
CREATE INDEX Module_ParentId_Index ON Module(ParentId);




--组织表
CREATE TABLE Organization(
	Id UUID PRIMARY KEY NOT NULL,
   	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
    Name VARCHAR(128),
	SystemId UUID NOT NULL,
    Remark VARCHAR(1024),
    Disable BOOLEAN NOT NULL DEFAULT FALSE,
    IsDelete BOOLEAN NOT NULL DEFAULT FALSE
);

--部门表
CREATE TABLE Department(
	Id UUID PRIMARY KEY NOT NULL,
   	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
    Name VARCHAR(128),
    Remark VARCHAR(1024),
    Disable BOOLEAN NOT NULL DEFAULT FALSE,
    IsDelete BOOLEAN NOT NULL DEFAULT FALSE,
    OrganizationId UUID NOT NULL,
    ParentId UUID,
    XPath VARCHAR(1024) DEFAULT ''
)
    WITH (
  OIDS=FALSE
);
CREATE INDEX Department_OrganizationId_Index ON Department(OrganizationId);
CREATE INDEX Department_ParentId_Index ON Department(ParentId);

---角色表
CREATE TABLE Role(
	Id UUID PRIMARY KEY NOT NULL,
   	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
    Name VARCHAR(128),
    Remark VARCHAR(1024),
    Disable BOOLEAN NOT NULL DEFAULT FALSE,
    OrganizationId UUID NOT NULL
);
CREATE INDEX Role_OrganizationId_Index ON Role(OrganizationId);

--角色模块(权限)
CREATE TABLE RolePermission(
	Id UUID PRIMARY KEY NOT NULL,
   	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
    RoleId UUID NOT NULL,
    ModuleId UUID NOT NULL
);

CREATE INDEX RolePermission_RoleId_Index ON RolePermission(RoleId);
CREATE INDEX RolePermission_ModuleId_Index ON RolePermission(ModuleId);

---用户表
CREATE TABLE UserAccount(
	Id UUID PRIMARY KEY NOT NULL,
   	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
    Name VARCHAR(128),
    Remark VARCHAR(1024),
    Disable BOOLEAN NOT NULL DEFAULT FALSE,
    IsDelete BOOLEAN NOT NULL DEFAULT FALSE,
    Account VARCHAR(128) NOT NULL,
    Code VARCHAR(128),
    Password VARCHAR(128) NOT NULL,
    OrganizationId UUID NOT NULL,
    DepartmentId UUID NOT NULL,
    UserType INT NOT NULL,
    Sex INT NOT NULL,
    Description VARCHAR(1024),
    WebToken VARCHAR(128),
    MobileToken VARCHAR(128),
    LoginFaultCount INT NOT NULL DEFAULT 0,
	LsFirstLogin Boolean NOT NULL DEFAULT FALSE
);

CREATE INDEX UserAccount_Account_Index ON UserAccount(Account);
CREATE INDEX UserAccount_Code_Index ON UserAccount(Code);
CREATE INDEX UserAccount_Password_Index ON UserAccount(Password);
CREATE INDEX UserAccount_OrganizationId_Index ON UserAccount(OrganizationId);
CREATE INDEX UserAccount_DepartmentId_Index ON UserAccount(DepartmentId);

--用户角色表
CREATE TABLE UserRole(
	Id UUID PRIMARY KEY NOT NULL,
	CreateTime TIMESTAMP WITHOUT TIME ZONE,
	LastUpdateTime TIMESTAMP WITHOUT TIME ZONE,
    CreateUserId UUID,
    LastUpdateUserId UUID,
    UserId UUID NOT NULL,
    RoleId UUID NOT NULL
);
CREATE INDEX UserRole_UserId_Index ON UserRole(UserId);
CREATE INDEX UserRole_RoleId_Index ON UserRole(RoleId);




CREATE extension IF NOT EXISTS "uuid-ossp";
-- 添加管理员
INSERT INTO useraccount(Id,CreateTime,CreateUserId,Name,Account,Code,Password,OrganizationId,DepartmentId,UserType,Sex,LoginFaultCount,LsFirstLogin)
VALUES('bfbfa658-16aa-4064-b5a5-aa8d00929262',now(),'00000000-0000-0000-0000-000000000000','admin','sAdmin','admin','0192023A7BBD73250516F069DF18B500','00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000000',0,0,0,false);
-- 添加铁路人员安全防护系统
INSERT INTO System(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code) 
VALUES('e540a81d-bbc3-4767-8517-aa8b00fba169', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '铁路安全人员防护系统', '', 'f', 'f', 'RailwayProtectionSystem');
-- 添加权限
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('713b7229-08d3-4a97-9798-aa8b01021874', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '安全预警', '', 'f', 'f', 'RailwayProtectionSystem.SecurityWarning.Warning', 1, '/security.html', 't', 1, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '98647335-b54f-424f-8a39-aa8b01018704', '98647335-b54f-424f-8a39-aa8b01018704');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('98647335-b54f-424f-8a39-aa8b01018704', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '安全预警', '', 'f', 'f', 'RailwayProtectionSystem.SecurityWarning', 0, NULL, 't', 1, 'e540a81d-bbc3-4767-8517-aa8b00fba169', NULL, '');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('d20fe696-a3e2-4b75-89d5-aa8b00fd958a', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '工作范围', '', 'f', 'f', 'RailwayProtectionSystem.Permission.WorkRange', 1, '{pms}/workRange.html', 'f', 5, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '2aad23d1-9d98-4502-b946-aa8b00fc2703', '2aad23d1-9d98-4502-b946-aa8b00fc2703');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('717302ba-f41e-4615-9ea8-aa8b00fd7ab2', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '角色管理', '', 'f', 'f', 'RailwayProtectionSystem.Permission.RoleManage', 1, '{pms}/system.html#/systemRole/e540a81d-bbc3-4767-8517-aa8b00fba169/true/%20', 'f', 4, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '2aad23d1-9d98-4502-b946-aa8b00fc2703', '2aad23d1-9d98-4502-b946-aa8b00fc2703');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('4d367862-fcd4-47a8-b25c-aa8b00fd5a3d', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '车辆管理', '', 'f', 'f', 'RailwayProtectionSystem.Permission.UserManage', 1, '{pms}/user.html?userType=2&userTypeAction=Replace&userTypeName=车辆&hideRole=true&extendInfo=限速', 'f', 3, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '2aad23d1-9d98-4502-b946-aa8b00fc2703', '2aad23d1-9d98-4502-b946-aa8b00fc2703');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('af7524d3-e8bb-4ac5-b81f-aa8b00fd3cb8', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '用户管理', '', 'f', 'f', 'RailwayProtectionSystem.Permission.UserOperate', 1, '/user.html', 'f', 2, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '2aad23d1-9d98-4502-b946-aa8b00fc2703', '2aad23d1-9d98-4502-b946-aa8b00fc2703');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('983eb7ad-05f5-4c12-9380-aa8b00fd18f2', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '部门管理', '', 'f', 'f', 'RailwayProtectionSystem.Permission.DepartmentManage', 1, '{pms}/department.html', 'f', 1, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '2aad23d1-9d98-4502-b946-aa8b00fc2703', '2aad23d1-9d98-4502-b946-aa8b00fc2703');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('35378ca8-5742-4784-a1a5-aa8b00fceca6', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '白名单管理', '', 'f', 'f', 'RailwayProtectionSystem.WhiteList.WhiteListManage', 1, '/whiteList.html', 'f', 5, 'e540a81d-bbc3-4767-8517-aa8b00fba169', 'a508c5cb-b079-4471-895b-aa8b00fc1797', 'a508c5cb-b079-4471-895b-aa8b00fc1797');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('d6643e88-68bf-4e20-be02-aa8b00fcdc91', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '考核统计', '', 'f', 'f', 'RailwayProtectionSystem.Inspect.Statistics', 1, '/inspectionRecords.html', 'f', 5, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '00531343-24d1-436c-bfed-aa8b00fc0546', '00531343-24d1-436c-bfed-aa8b00fc0546');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('bb5a4db8-ade0-487b-854b-aa8b00fcc424', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '考核配置', '', 'f', 'f', 'RailwayProtectionSystem.Inspect.Configure', 1, '/examine.html', 'f', 4, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '00531343-24d1-436c-bfed-aa8b00fc0546', '00531343-24d1-436c-bfed-aa8b00fc0546');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('b27bb3b6-3446-4886-b2a9-aa8b00fcb33a', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '设备注册', '', 'f', 'f', 'RailwayProtectionSystem.MobileDevice.DeviceRegister', 1, '/deviceSignUp.html', 'f', 3, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '425b04e0-e773-495d-bcb9-aa8b00fbf6cf', '425b04e0-e773-495d-bcb9-aa8b00fbf6cf');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('97d868e8-4662-47f4-b29d-aa8b00fca87c', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '设备管理', '', 'f', 'f', 'RailwayProtectionSystem.MobileDevice.DeviceManage', 1, '/device.html', 'f', 2, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '425b04e0-e773-495d-bcb9-aa8b00fbf6cf', '425b04e0-e773-495d-bcb9-aa8b00fbf6cf');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('03738a82-dbba-41ea-8c74-aa8b00fc8f3a', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', 'Cors管理', '', 'f', 'f', 'RailwayProtectionSystem.Assets.CorsManage', 1, '/cors.html', 'f', 3, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '35415ab7-a813-4acd-94b7-aa8b00fbde14', '35415ab7-a813-4acd-94b7-aa8b00fbde14');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('f224377f-5c9e-4ce5-80d4-aa8b00fc7cce', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '杆塔管理', '', 'f', 'f', 'RailwayProtectionSystem.Assets.TowerManage', 1, '/tower.html', 'f', 2, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '35415ab7-a813-4acd-94b7-aa8b00fbde14', '35415ab7-a813-4acd-94b7-aa8b00fbde14');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('ed9df2d1-a9fe-4613-8350-aa8b00fc4333', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '站场管理', '', 'f', 'f', 'RailwayProtectionSystem.Assets.StationManage', 1, '/stations.html', 'f', 1, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '35415ab7-a813-4acd-94b7-aa8b00fbde14', '35415ab7-a813-4acd-94b7-aa8b00fbde14');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('2aad23d1-9d98-4502-b946-aa8b00fc2703', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '权限配置', '', 'f', 'f', 'RailwayProtectionSystem.Permission', 0, NULL, 'f', 8, 'e540a81d-bbc3-4767-8517-aa8b00fba169', NULL, '');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('a508c5cb-b079-4471-895b-aa8b00fc1797', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '白名单', '', 'f', 'f', 'RailwayProtectionSystem.WhiteList', 0, NULL, 'f', 7, 'e540a81d-bbc3-4767-8517-aa8b00fba169', NULL, '');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('00531343-24d1-436c-bfed-aa8b00fc0546', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '干部考核', '', 'f', 'f', 'RailwayProtectionSystem.Inspect', 0, NULL, 'f', 5, 'e540a81d-bbc3-4767-8517-aa8b00fba169', NULL, '');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('425b04e0-e773-495d-bcb9-aa8b00fbf6cf', now(), 'bfbfa658-16aa-4064-b5a5-aa8d00929262', '移动设备', '', 'f', 'f', 'RailwayProtectionSystem.MobileDevice', 0, NULL, 'f', 6, 'e540a81d-bbc3-4767-8517-aa8b00fba169', NULL, '');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('35415ab7-a813-4acd-94b7-aa8b00fbde14', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '资产管理', '', 'f', 'f', 'RailwayProtectionSystem.Assets', 0, NULL, 'f', 3, 'e540a81d-bbc3-4767-8517-aa8b00fba169', NULL, '');

--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('c3b2d931-6088-481d-8dfb-aab7011b0cab', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '职教模块', '', 'f', 'f', 'RailwayProtectionSystem.VocationalEducation', 0, NULL, 'f', 4, 'e540a81d-bbc3-4767-8517-aa8b00fba169', NULL, '');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('77ab59a2-b533-48f7-a2d8-aab7011b2950', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '职教模块', '', 'f', 'f', 'RailwayProtectionSystem.VocationalEducation.VocationalEducationMenu', 1, '/vocationalEducation.html', 'f', 1, 'e540a81d-bbc3-4767-8517-aa8b00fba169', 'c3b2d931-6088-481d-8dfb-aab7011b0cab', 'c3b2d931-6088-481d-8dfb-aab7011b0cab');

--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('4b7dd9ba-ff70-4c79-a728-aab7011a2c26', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '工务巡检', '', 'f', 'f', 'RailwayProtectionSystem.WorkInspection', 0, NULL, 'f', 2, 'e540a81d-bbc3-4767-8517-aa8b00fba169', NULL, '');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('23a81b2a-b64e-4213-b58d-aab7011aefaa', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '作业单位', '', 'f', 'f', 'RailwayProtectionSystem.WorkInspection.OperationalUnit', 1, '/operationalUnit.html', 'f', 1, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('a7bf5149-a20e-489c-a2fe-aab7011a6d2c', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '作业标准库', '', 'f', 'f', 'RailwayProtectionSystem.WorkInspection.OperationalStandardLibrary', 1, '/operationalStandardLib.html', 'f', 2, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('c91ea3ad-e3c7-4b2e-b499-aab7011a95fa', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '巡检设备', '', 'f', 'f', 'RailwayProtectionSystem.WorkInspection.DeviceManagement', 1, '/deviceManagement.html', 'f', 3, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('79e6e967-c3b3-4010-8c2d-aab7011abe20', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '巡检记录', '', 'f', 'f', 'RailwayProtectionSystem.WorkInspection.DeviceRecords', 1, '/deviceRecords.html', 'f', 4, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26');
--INSERT INTO SystemPermission(Id, CreateTime, CreateUserId, Name, Remark, Disable, IsDelete, Code, PermissionType, Url, IsPublic, OrderNo, SystemId, ParentId, XPath) 
--VALUES ('3d3ce1db-1272-425c-98ed-aab7011ad756', now(),'bfbfa658-16aa-4064-b5a5-aa8d00929262', '巡检监控', '', 'f', 'f', 'RailwayProtectionSystem.WorkInspection.DeviceRealPosition', 1, '/deviceRealPosition.html', 'f', 5, 'e540a81d-bbc3-4767-8517-aa8b00fba169', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26', '4b7dd9ba-ff70-4c79-a728-aab7011a2c26');
