create table Categories(
id int identity(1,1) primary key,
categoryName nvarchar(50)
)

create table Products(
id int identity(1,1) primary key,
productName nvarchar(50),
price decimal,
picture  varbinary(max),
categoryId int,
FOREIGN KEY (categoryId) REFERENCES Categories(id)
)