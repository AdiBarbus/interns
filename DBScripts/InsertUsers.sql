Insert Into Users(FirstName,LastName,Email,Password,ConfirmPassword,Phone,University,Role_ID)
Values('Ion','Deorde','ion@yahoo.com','test','test',1234,'UBB',1),
	  ('Softvision',null,'softvision@gmail.com','test','test',5533,null,2),
	  ('admin',null,'admin@admin','admin','admin',null,null,3);

select * from Users

select Users.FirstName, Users.Email, Addresses.City
from Users
inner join Addresses On Users.ID = Addresses.UserID

