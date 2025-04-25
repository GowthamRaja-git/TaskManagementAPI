use tempdb

select * from information_schema.tables

SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tasks'


select * from Users
select * from TaskItems
select * from TaskComments

INSERT INTO Users (Username, Password, Role)
VALUES
('gowtham', 'gowtham345', 1);
('admin', 'admin123', 0),  -- Admin (Role = 0)
('user', 'user123', 1);     -- User (Role = 1)

INSERT INTO TaskItems (Title, Description, AssignedToUserId)
VALUES
('Sample Task', 'This is a sample task', 1);  -- Assigned to Admin (Id = 1)


INSERT INTO TaskComments (Comment, TaskItemId, UserId)
VALUES
('This is a comment on the task.', 1, 1);  -- Comment on TaskId 1, by UserId 1 (Admin)






--User Table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    Password NVARCHAR(255) NOT NULL, -- Adjust size as needed
    Role INT NOT NULL
);




--Task Table
CREATE TABLE TaskItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500) NULL, -- Description can be optional
    AssignedToUserId INT NOT NULL,
    FOREIGN KEY (AssignedToUserId) REFERENCES Users(Id) -- Foreign key to the Users table
);





--TaskComments Table
CREATE TABLE TaskComments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Comment NVARCHAR(1000) NOT NULL,
    TaskItemId INT NOT NULL,
    UserId INT NOT NULL,
    CONSTRAINT FK_TaskComments_TaskItem FOREIGN KEY (TaskItemId) REFERENCES TaskItems(Id),
    CONSTRAINT FK_TaskComments_User FOREIGN KEY (UserId) REFERENCES Users(Id)
);








--A sample SQL query to Get all tasks assigned to a user :

SELECT *
FROM TaskItems
WHERE AssignedToUserId = 3;


--A sample SQL query to Get all comments on a task :

SELECT TC.Id, U.Username, TC.Comment
FROM TaskComments TC
JOIN Users U ON TC.UserID = U.Id
WHERE TC.id = 1

