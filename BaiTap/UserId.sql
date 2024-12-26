CREATE DATABASE USERID_DB
USE USERID_DB

CREATE TABLE Users
(
	UserId int IDENTITY(1,1) NOT NULL,
	Username nvarchar(40),
	Password nvarchar(64),
	Email nvarchar(50),
)
--khóa chính--
ALTER TABLE Users ADD CONSTRAINT PK_Users PRIMARY KEY (UserId)

--khóa ngoại--
ALTER TABLE Users ADD CONSTRAINT UQ_Username UNIQUE (Username)
ALTER TABLE Users ADD CONSTRAINT UQ_Enail UNIQUE (Email)

--thêm cột tên và ngày sinh--
ALTER TABLE Users ADD HOTEN varchar(40)
ALTER TABLE Users ADD NGAYSINH nvarchar(20)
ALTER TABLE Users ALTER COLUMN NGAYSINH nvarchar(20)

SET DATEFORMAT dmy
