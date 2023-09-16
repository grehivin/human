-- database setup script
-- this will define all objects and their relations to setup an online training for human rights lms in spanish for the 
-- Asociación Jovenes por los Derechos Humanos Costa Rica
-- created by: Grehivin Vargas - grehivin.vargas@uamcr.net, grehivin@gmail.com

-- begin: database creation
create database hre; -- hre = human rights education
go

use hre; -- hre = human rights education
go
-- end: database creation

-- begin: trainig tables
create schema lms;
go

create table lms.courses (
	id int identity (100000, 1) not null primary key,
	course varchar (255) not null,
	descr text not null,
	enabled bit)
go

create table lms.topics (
	id int identity (100000, 1) not null primary key,
	courseID int,
	topic varchar (255) not null,
	enabled bit)
go

alter table lms.topics
	with check
	add constraint fk_topics_courses
	foreign key (courseID)
	references lms.courses (id)
	on delete no action
	on update no action
go

alter table lms.topics
	check constraint fk_topics_courses
go

create table lms.contents (
	id int identity (100000, 1) not null primary key,
	topicID int,
	contentType varchar(3) not null, -- types of content: t - text, yt - youtube video, l - link, q - question
	content text not null,
	enabled bit)
go

alter table lms.contents
	with check
	add constraint fk_contents_topics
	foreign key (topicID)
	references lms.topics (id)
	on delete no action
	on update no action
go

alter table lms.contents
	check constraint fk_contents_topics
go

create table lms.options (
	id int identity (100000, 1) not null primary key,
	contentID int,
	descr varchar (255) not null,
	enabled bit,
	valid bit)
go

alter table lms.options
	with check
	add constraint fk_options_contents
	foreign key (contentID)
	references lms.contents (id)
	on delete no action
	on update no action
go

alter table lms.options
	check constraint fk_options_contents
go

create table lms.userCourses (
	id int identity (100000, 1) not null primary key,
	userID int,
	courseID int,
	completed bit,
	approved bit)
go

alter table lms.userCourses
	with check
	add constraint fk_userCourses_courses
	foreign key (courseID)
	references lms.courses (id)
	on delete no action
	on update no action
go

alter table lms.userCourses
	check constraint fk_userCourses_courses
go

create table lms.userContents (
	id int identity (100000, 1) not null primary key,
	userID int,
	contentID int,
	completed bit)
go

alter table lms.userContents
	with check
	add constraint fk_userContents_contents
	foreign key (contentID)
	references lms.contents (id)
	on delete no action
	on update no action
go

alter table lms.userContents
	check constraint fk_userContents_contents
go

create table lms.userResponses (
	id int identity (100000, 1) not null primary key,
	userID int,
	contentID int,
	optionID int)
go

alter table lms.userResponses
	with check
	add constraint fk_userResponses_contents
	foreign key (contentID)
	references lms.contents (id)
	on delete no action
	on update no action
go

alter table lms.userResponses
	check constraint fk_userResponses_contents
go

alter table lms.userResponses
	with check
	add constraint fk_userResponses_options
	foreign key (optionID)
	references lms.options (id)
	on delete no action
	on update no action
go

alter table lms.userResponses
	check constraint fk_userResponses_options
go
-- end: training tables

-- begin: access control tables
create schema security;
go

create table security.users (
	id int identity (100000, 1) not null primary key,
	name varchar (50) not null,
	lastName varchar (50) not null,
	email varchar (50) not null,
	userName varchar (50) not null,
	password varchar (255) not null,
	enabled bit)
go

alter table lms.userCourses
	with check
	add constraint fk_userCourses_users
	foreign key (userID)
	references security.users (id)
	on delete no action
	on update no action
go

alter table lms.userCourses
	check constraint fk_userCourses_users
go

alter table lms.userContents
	with check
	add constraint fk_userContents_users
	foreign key (userID)
	references security.users (id)
	on delete no action
	on update no action
go

alter table lms.userContents
	check constraint fk_userContents_users
go

alter table lms.userResponses
	with check
	add constraint fk_userResponses_users
	foreign key (userID)
	references security.users (id)
	on delete no action
	on update no action
go

alter table lms.userResponses
	check constraint fk_userResponses_users
go

create table security.roles (
	id int identity (100000, 1) not null primary key,
	role varchar (255) not null,
	enabled bit)
go

create table security.userRoles (
	id int identity(100000, 1) not null primary key,
	userID int,
	roleID int)
go

alter table security.userRoles
	with check
	add constraint fk_userRoles_roles
	foreign key (roleID)
	references security.roles (id)
	on delete no action
	on update no action
go

alter table security.userRoles
	check constraint fk_userRoles_roles
go

alter table security.userRoles
	with check
	add constraint fk_userRoles_users
	foreign key (userID)
	references security.users (id)
	on delete no action
	on update no action
go

alter table security.userRoles
	check constraint fk_userRoles_users
go

insert into security.users (
	name,
	lastName,
	email,
	username,
	password,
	enabled)
values
	('Asociación',
	'Jóvenes por los Derechos Humanos CR',
	'tbd@domain.com',
	'admin',
	'Der3CH05huM4n0$',
	1)
go

insert into security.roles (
	role,
	enabled)
values 
	('Administrador',
	1),
	('Estudiante',
	1)
go

insert into security.userRoles (
	userId,
	roleId)
values (
	100000,
	100000)
go
-- end: access control tables

-- begin: stored procedures
create procedure security.GetRolesForUser
	@uid int
as
begin
	select id, userID, roleID from security.userRoles where userID = @uid;
end;
-- end: stored procedures

-- dev area, commands to be used by developer to make changes or corrections
--alter table lms.persons add userID int;
--insert into security.roles (role, enabled) values ('Estudiante',1)
--delete from security.roles where id = 100002
--select * from security.roles
go