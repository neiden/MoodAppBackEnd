DROP TABLE COMMENTS; 
DROP TABLE POSTS; 
DROP TABLE MOODS; 
DROP TABLE FRIENDS; 
DROP TABLE PLAYLISTS; 
DROP TABLE LOGINS;
DROP TABLE USERS; 

CREATE TABLE USERS(
    User_Id INT PRIMARY KEY, 
    F_Name VARCHAR(100) NOT NULL,
    L_Name VARCHAR(100) NOT NULL, 
    Phone_Number VARCHAR(10), 
    Zipcode VARCHAR(10) NOT NULL, 
    Birthdate DATE NOT NULL, 
); 

CREATE TABLE LOGINS(
    Username VARCHAR(50) PRIMARY KEY, 
    P_hash_salt VARCHAR(100), 
    Pwd VARCHAR(50) NOT NULL, 
    U_Id int FOREIGN KEY REFERENCES USERS(User_ID),
    Email VARCHAR(319) NOT NULL
);

CREATE TABLE FRIENDS(
    Friend_Id INT PRIMARY KEY IDENTITY(1, 1), 
    Source_Id INT FOREIGN KEY REFERENCES USERS(User_ID),
    Target_Id INT FOREIGN KEY REFERENCES USERS(User_ID),
);

CREATE TABLE MOODS(
    Id INT PRIMARY KEY IDENTITY(1, 1), 
    U_Id INT FOREIGN KEY REFERENCES USERS(User_ID),
    mDate DATETIME DEFAULT GETDATE(),
    Category VARCHAR(50) NOT NULL, 
    Score DECIMAL (2,2) NOT NULL,
);

CREATE TABLE PLAYLISTS(
    Playlist_ID INT PRIMARY KEY IDENTITY(1, 1), 
    U_Id INT FOREIGN KEY REFERENCES USERS(User_ID),
    Link_Text VARCHAR(250), 
    P_Name VARCHAR(50)
);

CREATE TABLE POSTS(
    Post_Id INT PRIMARY KEY IDENTITY(1, 1), 
    U_Id INT FOREIGN KEY REFERENCES USERS(User_ID),
    Likes INT, 
    Content VARCHAR(150) NOT NULL, 
    Comment_Date DATETIME DEFAULT GETDATE()
);

CREATE TABLE COMMENTS(
    Comment_Id INT PRIMARY KEY IDENTITY(1, 1), 
    P_Id INT FOREIGN KEY REFERENCES POSTS(Post_ID), 
    Likes INT, 
    Content VARCHAR(150) NOT NULL, 
    Comment_Date DATETIME DEFAULT GETDATE()
);

SELECT * FROM USERS;
SELECT * FROM LOGINS;
SELECT Source_Id, Count(Target_Id) as NumberofFriends FROM FRIENDS GROUP BY Source_Id;
SELECT * FROM POSTS; 
SELECT * FROM COMMENTS; 
SELECT * FROM MOODS;

Delete from Logins where Username = 'VelmaJinkies1';
Delete from Users where User_Id = 11;

