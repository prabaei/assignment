drop table tblProjectStaff
alter table tblProjectStaff drop constraint Pk_tblProjectStaff 
alter table tblProjectStaff drop constraint Fk_tblProjectStaff_tblProject 
alter table tblProjectStaff drop constraint Fk_tblProjectStaff_tblEmployeeMaster

create table tblProjectStaff
(
projectId int identity(1,1),
empId int not null,
createdOn datetime not null default getdate(),
modifiedOn datetime not null,
active bit default 1
) on assignmentMaster
alter table tblProjectStaff add constraint Pk_tblProjectStaff primary key (projectId,empId)
alter table tblProjectStaff add constraint Fk_tblProjectStaff_tblProject foreign key (projectId) references tblProject(projectId)
alter table tblProjectStaff add constraint Fk_tblProjectStaff_tblEmployeeMaster foreign key (empId) references tblEmployeeMaster(empId)


drop table tblProject

alter table tblProject drop constraint Pk_tblProject 
alter table tblProject drop constraint Fk_tblProject_tblEmployeeMaster 

create table tblProject
(
projectId int identity(1,1),
projectTitle nvarchar(80) not null,
assignee int not null,
projectStatus int not null,
progress decimal(18,2) not null,
createdOn datetime not null default getdate()
,modifiedOn datetime not null
,active bit default 1
) on assignmentMaster


alter table tblProject add constraint Pk_tblProject primary key (projectId)
alter table tblProject add constraint Fk_tblProject_tblEmployeeMaster foreign key (assignee) references tblEmployeeMaster(empId)



drop table tblEmployeeMaster

alter table tblEmployeeMaster drop constraint Pk_tblEmployeeMaster


create table tblEmployeeMaster
(
empId int identity(1,1),
name nvarchar(80) not null,
mobile nvarchar(80) not null,
employeeRole int not null,
createdOn datetime not null default getdate(),
modifiedOn datetime not null
,active bit default 1
) on assignmentMaster

alter table tblEmployeeMaster add constraint Pk_tblEmployeeMaster primary key (empId)


create table tblempRole
(
id int not null,
employeeRole nvarchar(30) not null
)
alter table tblempRole add constraint Pk_tblempRole primary key (id)





