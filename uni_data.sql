CREATE TABLE UniversityModel.dbo."__EFMigrationsHistory" (
	MigrationId nvarchar(150) NOT NULL,
	ProductVersion nvarchar(32) NOT NULL,
	PRIMARY KEY (MigrationId)
);
CREATE TABLE UniversityModel.dbo.CourseDepartment (
	CoursesId uniqueidentifier NOT NULL,
	DepartmentsId uniqueidentifier NOT NULL,
	PRIMARY KEY (CoursesId,DepartmentsId)
);
CREATE TABLE UniversityModel.dbo.Courses (
	Id uniqueidentifier NOT NULL,
	Name nvarchar(max),
	PRIMARY KEY (Id)
);
CREATE TABLE UniversityModel.dbo.CourseStudent (
	CoursesId uniqueidentifier NOT NULL,
	StudentsId uniqueidentifier NOT NULL,
	PRIMARY KEY (CoursesId,StudentsId)
);
CREATE TABLE UniversityModel.dbo.Departments (
	Id uniqueidentifier NOT NULL,
	Name nvarchar(max),
	PRIMARY KEY (Id)
);
CREATE TABLE UniversityModel.dbo.Students (
	Id uniqueidentifier NOT NULL,
	FirstName nvarchar(max),
	LastName nvarchar(max),
	DepartmentId uniqueidentifier,
	PRIMARY KEY (Id)
);
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220419180525_Initial-Migration', N'5.0.16');
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220419184012_Add-Students-To-Course', N'5.0.16');
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220419184104_Add-Students-To-Course-2', N'5.0.16');
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220424194128_Attempt-Debugging-Lol', N'5.0.16');
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220424195139_Attempt-Debugging-Lol-2', N'5.0.16');
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220425075946_Add-DepartmendId-To-Student', N'5.0.16');
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220425081401_Remove-DeptId-From-Student', N'5.0.16');
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220425083605_Idk-Anymore', N'5.0.16');
INSERT INTO UniversityModel.dbo."__EFMigrationsHistory"(MigrationId, ProductVersion) VALUES (N'20220426060242_Remove-CourseDepartments-Entity', N'5.0.16');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('985C4CAA-719F-4EF7-8C83-8F4EF7452AB1', '9E83B2BF-8313-44B7-AD8E-0D940B456AE0');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('9DAF876B-E351-4875-9524-8FFB3A203378', '9E83B2BF-8313-44B7-AD8E-0D940B456AE0');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('2DDCBE73-F898-446A-B6DF-CD61BE8FE5CA', '9E83B2BF-8313-44B7-AD8E-0D940B456AE0');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('9424A983-88FE-4F99-98AB-F57092EEC11E', '9E83B2BF-8313-44B7-AD8E-0D940B456AE0');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('DC4E4DB6-06C8-4B40-BC27-19A2624CD27E', '331DE260-D11C-4579-9C60-56CD78DB27BF');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('9424A983-88FE-4F99-98AB-F57092EEC11E', '331DE260-D11C-4579-9C60-56CD78DB27BF');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('F2CA127B-F3D4-4C42-B2B3-53915A344A51', 'D04353F1-7880-4B96-BB22-7A4CE6B97313');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('3A881CAA-BC65-4DAA-BD25-AC1BB176F18D', 'D04353F1-7880-4B96-BB22-7A4CE6B97313');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('53210795-F00C-405A-8F12-F8A05D386CF3', 'E0C97342-3A05-4407-9CBC-A976DBA9DEA3');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('F2CA127B-F3D4-4C42-B2B3-53915A344A51', '02EF7157-E672-44C1-A8FB-FB4F415BA28B');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('9DAF876B-E351-4875-9524-8FFB3A203378', '02EF7157-E672-44C1-A8FB-FB4F415BA28B');
INSERT INTO UniversityModel.dbo.CourseDepartment(CoursesId, DepartmentsId) VALUES ('53210795-F00C-405A-8F12-F8A05D386CF3', '02EF7157-E672-44C1-A8FB-FB4F415BA28B');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('DC4E4DB6-06C8-4B40-BC27-19A2624CD27E', 'Latin grammar');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('F2CA127B-F3D4-4C42-B2B3-53915A344A51', 'Modern German literature');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('906C8521-CBCF-480F-BA62-8C4458D7C0AB', 'French 2/3');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('985C4CAA-719F-4EF7-8C83-8F4EF7452AB1', 'Icelandic 2/3');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('9DAF876B-E351-4875-9524-8FFB3A203378', 'Norwegian 3/4');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('21370C82-E53F-4D5C-AA50-A3F1F10CAC77', 'Latvian 1/1');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('3A881CAA-BC65-4DAA-BD25-AC1BB176F18D', 'German phonology');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('2DDCBE73-F898-446A-B6DF-CD61BE8FE5CA', 'Estonian 3/4');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('D99C19C8-D14E-4B56-A656-D55ED1DEEC52', 'Icelandic 1/3');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('9424A983-88FE-4F99-98AB-F57092EEC11E', 'Ancient Greek 1/3');
INSERT INTO UniversityModel.dbo.Courses(Id, Name) VALUES ('53210795-F00C-405A-8F12-F8A05D386CF3', 'Estonian 2/4');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('F2CA127B-F3D4-4C42-B2B3-53915A344A51', '28A6E906-FF0F-4C37-B8F7-207BBABD4E35');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('2DDCBE73-F898-446A-B6DF-CD61BE8FE5CA', '28A6E906-FF0F-4C37-B8F7-207BBABD4E35');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('DC4E4DB6-06C8-4B40-BC27-19A2624CD27E', '69349C55-9CA1-419E-B0F4-6CCA44B9AB5D');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('21370C82-E53F-4D5C-AA50-A3F1F10CAC77', '69349C55-9CA1-419E-B0F4-6CCA44B9AB5D');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('2DDCBE73-F898-446A-B6DF-CD61BE8FE5CA', '69349C55-9CA1-419E-B0F4-6CCA44B9AB5D');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('53210795-F00C-405A-8F12-F8A05D386CF3', '69349C55-9CA1-419E-B0F4-6CCA44B9AB5D');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('3A881CAA-BC65-4DAA-BD25-AC1BB176F18D', 'C3D75113-9616-41B3-8F8A-9058C057BD19');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('DC4E4DB6-06C8-4B40-BC27-19A2624CD27E', '18478A4D-B44E-48D7-A03E-CB2D1D43F8B3');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('F2CA127B-F3D4-4C42-B2B3-53915A344A51', '18478A4D-B44E-48D7-A03E-CB2D1D43F8B3');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('21370C82-E53F-4D5C-AA50-A3F1F10CAC77', '18478A4D-B44E-48D7-A03E-CB2D1D43F8B3');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('906C8521-CBCF-480F-BA62-8C4458D7C0AB', 'D2DB8FD7-0809-425F-BFE6-DDA061475BC4');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('21370C82-E53F-4D5C-AA50-A3F1F10CAC77', 'D2DB8FD7-0809-425F-BFE6-DDA061475BC4');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('906C8521-CBCF-480F-BA62-8C4458D7C0AB', '386A1494-009F-46E5-9EC6-F73E1C21073F');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('9DAF876B-E351-4875-9524-8FFB3A203378', '386A1494-009F-46E5-9EC6-F73E1C21073F');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('2DDCBE73-F898-446A-B6DF-CD61BE8FE5CA', '386A1494-009F-46E5-9EC6-F73E1C21073F');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('9424A983-88FE-4F99-98AB-F57092EEC11E', '386A1494-009F-46E5-9EC6-F73E1C21073F');
INSERT INTO UniversityModel.dbo.CourseStudent(CoursesId, StudentsId) VALUES ('53210795-F00C-405A-8F12-F8A05D386CF3', '386A1494-009F-46E5-9EC6-F73E1C21073F');
INSERT INTO UniversityModel.dbo.Departments(Id, Name) VALUES ('9E83B2BF-8313-44B7-AD8E-0D940B456AE0', 'Scandinavian studies');
INSERT INTO UniversityModel.dbo.Departments(Id, Name) VALUES ('331DE260-D11C-4579-9C60-56CD78DB27BF', 'Classical philology');
INSERT INTO UniversityModel.dbo.Departments(Id, Name) VALUES ('D04353F1-7880-4B96-BB22-7A4CE6B97313', 'German philology');
INSERT INTO UniversityModel.dbo.Departments(Id, Name) VALUES ('E0C97342-3A05-4407-9CBC-A976DBA9DEA3', 'French philology');
INSERT INTO UniversityModel.dbo.Departments(Id, Name) VALUES ('02EF7157-E672-44C1-A8FB-FB4F415BA28B', 'Institute for Foreign Languages');
INSERT INTO UniversityModel.dbo.Students(Id, FirstName, LastName, DepartmentId) VALUES ('28A6E906-FF0F-4C37-B8F7-207BBABD4E35', 'Edith', 'Piaf', '331DE260-D11C-4579-9C60-56CD78DB27BF');
INSERT INTO UniversityModel.dbo.Students(Id, FirstName, LastName, DepartmentId) VALUES ('69349C55-9CA1-419E-B0F4-6CCA44B9AB5D', 'Petr', 'Cech', '9E83B2BF-8313-44B7-AD8E-0D940B456AE0');
INSERT INTO UniversityModel.dbo.Students(Id, FirstName, LastName, DepartmentId) VALUES ('AF5778A7-FC47-43F9-8BF1-764C9FD99C2E', 'Snorri', 'Sturlusson', '9E83B2BF-8313-44B7-AD8E-0D940B456AE0');
INSERT INTO UniversityModel.dbo.Students(Id, FirstName, LastName, DepartmentId) VALUES ('C3D75113-9616-41B3-8F8A-9058C057BD19', 'Steven', 'Seagal', 'D04353F1-7880-4B96-BB22-7A4CE6B97313');
INSERT INTO UniversityModel.dbo.Students(Id, FirstName, LastName, DepartmentId) VALUES ('18478A4D-B44E-48D7-A03E-CB2D1D43F8B3', 'Halldor', 'Laxness', 'D04353F1-7880-4B96-BB22-7A4CE6B97313');
INSERT INTO UniversityModel.dbo.Students(Id, FirstName, LastName, DepartmentId) VALUES ('D2DB8FD7-0809-425F-BFE6-DDA061475BC4', 'Dave', 'Stieb', '02EF7157-E672-44C1-A8FB-FB4F415BA28B');
INSERT INTO UniversityModel.dbo.Students(Id, FirstName, LastName, DepartmentId) VALUES ('386A1494-009F-46E5-9EC6-F73E1C21073F', 'Sylvester', 'Stallone', 'E0C97342-3A05-4407-9CBC-A976DBA9DEA3');
ALTER TABLE UniversityModel.dbo.CourseDepartment
	ADD FOREIGN KEY (CoursesId) 
	REFERENCES dbo.Courses (Id);

ALTER TABLE UniversityModel.dbo.CourseDepartment
	ADD FOREIGN KEY (DepartmentsId) 
	REFERENCES dbo.Departments (Id);


ALTER TABLE UniversityModel.dbo.CourseStudent
	ADD FOREIGN KEY (CoursesId) 
	REFERENCES dbo.Courses (Id);

ALTER TABLE UniversityModel.dbo.CourseStudent
	ADD FOREIGN KEY (StudentsId) 
	REFERENCES dbo.Students (Id);


ALTER TABLE UniversityModel.dbo.Students
	ADD FOREIGN KEY (DepartmentId) 
	REFERENCES dbo.Departments (Id);


