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

create table lms.persons (
	id int identity (100000, 1) not null primary key,
	name varchar (50) not null,
	lastname varchar (50) not null,
	email varchar (50) not null,
	userID int)
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
	on delete set null
	on update cascade
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
	on delete set null
	on update cascade
go

alter table lms.contents
	check constraint fk_contents_topics
go

create table lms.contentOptions (
	id int identity (100000, 1) not null primary key,
	contentID int,
	descr varchar (255) not null,
	enabled bit,
	valid bit)
go

alter table lms.contentOptions
	with check
	add constraint fk_contentOptions_contents
	foreign key (contentID)
	references lms.contents (id)
	on delete set null
	on update cascade
go

alter table lms.contentOptions
	check constraint fk_contentOptions_contents
go

create table lms.coursesByPerson (
	id int identity (100000, 1) not null primary key,
	personID int,
	courseID int,
	completed bit,
	approved bit)
go

alter table lms.coursesByPerson
	with check
	add constraint fk_coursesByPerson_persons
	foreign key (personID)
	references lms.persons (id)
	on delete set null
	on update cascade
go

alter table lms.coursesByPerson
	check constraint fk_coursesByPerson_persons
go

alter table lms.coursesByPerson
	with check
	add constraint fk_coursesByPerson_courses
	foreign key (courseID)
	references lms.courses (id)
	on delete set null
	on update cascade
go

alter table lms.coursesByPerson
	check constraint fk_coursesByPerson_courses
go
-- end: training tables

-- begin: access control tables
create schema security;
go

create table security.users (
	id int identity (100000, 1) not null primary key,
	personID int,
	username varchar (50) not null,
	password varchar (255) not null,
	enabled bit)
go

alter table security.users
	with check
	add constraint fk_users_persons
	foreign key (personID)
	references lms.persons (id)
	on delete no action
	on update no action
go

alter table security.users
	check constraint fk_users_persons
go

alter table lms.persons
	with check
	add constraint fk_persons_users
	foreign key (userID)
	references security.users (id)
	on delete no action
	on update no action
go

alter table lms.persons
	check constraint fk_persons_users
go

create table security.roles (
	id int identity (100000, 1) not null primary key,
	role varchar (255) not null,
	enabled bit)
go

create table security.rolesAssignedToUsers (
	id int identity(100000, 1) not null primary key,
	userID int,
	roleID int)
go

alter table security.rolesAssignedToUsers
	with check
	add constraint fk_rolesAssignedToUsers_roles
	foreign key (roleID)
	references security.roles (id)
	on delete set null
	on update cascade
go

alter table security.rolesAssignedToUsers
	check constraint fk_rolesAssignedToUsers_roles
go

alter table security.rolesAssignedToUsers
	with check
	add constraint fk_rolesAssignedToUsers_users
	foreign key (userID)
	references security.users (id)
	on delete set null
	on update cascade
go

alter table security.rolesAssignedToUsers
	check constraint fk_rolesAssignedToUsers_users
go

insert into security.users (
	username,
	password,
	enabled)
values (
	'admin',
	'Der3CH05huM4n0$',
	1)
go

insert into security.roles (
	role,
	enabled)
values (
	'Administrador',
	1)
go

insert into security.rolesAssignedToUsers (
	userId,
	roleId)
values (
	100000,
	100000)
go
-- end: access control tables

-- dev area, commands to be used by developer to make changes or corrections
--alter table lms.persons add userID int;
go