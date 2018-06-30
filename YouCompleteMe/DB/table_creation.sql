create table users (
	userID int identity(1,1), 
	username varchar(25) not null unique, 
	fName varchar(25), 
	lName varchar(25), 
	email varchar(60) not null unique, 
	phone varchar(10), 
	enc_password varchar(255) not null,
	primary key(userID)
);
create table tasks (
	task_owner int, 
	taskID int identity(1,1), 
	title varchar(255) not null, 
	createdDate datetime not null, 
	currentDate datetime not null, 
	deadline datetime, 
	task_priority int, 
	completed bit not null default 0,
	primary key(task_owner, taskID)
);
create table subtask (
	taskID int not null, 
	subtaskID int identity(1,1), 
	st_Description varchar(500) not null, 
	st_CreatedDate datetime not null, 
	st_CompleteDate datetime, 
	st_Deadline datetime, 
	st_Priority int,
	primary key(taskID, subtaskID)
);
create table note (
	taskID int not null, 
	subtaskID int, 
	noteID int identity(1,1),
	note_message varchar(1000) not null,
	primary key(taskID, noteID)
);

drop table activities;

create table activities (
	taskID int not null,
	seconds int not null,
	primary key (taskID)
);