GO
CREATE TABLE UserAccount(
	id int IDENTITY(1,1) PRIMARY KEY,
	UserName varchar(100) not null,
	Password varchar(100) not null,
	SoDienThoai char(10) null,
	Email varchar(50) UNIQUE,
	Status bit
)


GO
CREATE TABLE Role(
	id int IDENTITY(1,1) PRIMARY KEY,
	RoleName varchar(100) not null,
	Description nvarchar(200)
)

GO
CREATE TABLE UserInRole(
	idAccount int,
	idRole int,
	Status bit
	CONSTRAINT PK_IdRole_IdAccount PRIMARY KEY (idAccount, idRole) 
)

GO
CREATE TABLE Product(
	idProduct varchar(10) PRIMARY KEY,
	idCategory varchar(10),
	Name nvarchar(100) not null,
	Unicost decimal,
	Amount int,
	Image varchar(200),
	Description nvarchar(200),
	Status bit
)
GO
INSERT INTO Product(idProduct, idCategory, Name, Unicost, Amount, Author, Publisher, Year)
VALUES ('SH01','TT', N'Sherlock Holmes Tập 1',10000,10,'Conan Doyle',N'Kim đồng',2010),
		('SH02','TT',N'Sherlock Holmes Tập 2',12000,20,'Conan Doyle',N'Kim đồng',2010),
		('SH03','TT',N'Sherlock Holmes Tập 3',14000,30,'Conan Doyle',N'Kim đồng',2010),
		('SH04','VH', N'Chí phèo',10000,10,'Nam Cao',N'Kim đồng',2010),
		('SH05','VH',N'Nhật ký trong tù',9000,20,N'Hồ Chí Minh',N'Kim đồng',2010),
		('SH06','GD',N'Trí tuệ Do Thái',14000,30,'Eran Katz',N'Kim đồng',2010),
		('SH07','GD', N'Đời ngắn đừng ngủ dài',10000,10,'Robin Sharma',N'Kim đồng',2010),
		('SH08','NN',N'Ngôi trường mọi khi',12000,20,N'Nguyễn Nhật Ánh',N'Kim đồng',2010),
		('SH09','GD',N'Nhà giả kim',14000,30,'Paulo',N'Kim đồng',2010)

GO
CREATE TABLE Category(
	idCategory varchar(10) PRIMARY KEY,
	Name nvarchar(100) not null,
	Description nvarchar(200)
)

GO
INSERT INTO Category(idCategory,Name)
VALUES ('TT',N'Trinh thám'),
		('VH',N'Văn học'),
		('NN',N'Ngụ ngôn'),
		('KT',N'Kinh tế'),
		('GD',N'Giáo dục')


GO
ALTER TABLE Product
	ADD CONSTRAINT FK_IDCATEGORY_PRODUCT FOREIGN KEY (idCategory) REFERENCES Category(idCategory)

GO
ALTER TABLE UserInRole
	ADD CONSTRAINT FK_IDROLE_ROLE FOREIGN KEY (idRole) REFERENCES Role(id),
		CONSTRAINT FK_IDACCOUNT_USERACCOUNT FOREIGN KEY (idAccount) REFERENCES UserAccount(id)

GO
ALTER TABLE UserAccount
	ADD CONSTRAINT CHECK_EMAIL CHECK ( Email LIKE '[A-Za-z0-9]%@gmail.com' OR Email LIKE '[A-Za-z0-9]%@ute.udn.vn'),
		CONSTRAINT CHECK_SODIENTHOAI CHECK ( SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' )
		


