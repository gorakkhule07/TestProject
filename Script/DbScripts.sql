CREATE TABLE `contact` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `PhoneNumber` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
);


DELIMITER $$
CREATE  PROCEDURE `SP_Contacts_D_ById_contact`(
IN iId int
)
BEGIN
update contact set Status="InActive" where Id= iId;
END$$
DELIMITER ;

DELIMITER $$
CREATE  PROCEDURE `SP_Contacts_I_contact`(
IN iEmail Varchar(45),
IN iFirstName Varchar(45),
IN iLastName Varchar(45),
IN iPhoneNumber Varchar(45),
IN iStatus Varchar(45)
)
BEGIN

insert into contact(
FirstName,
LastName,
PhoneNumber,
Status,
Email
)
values(
iFirstName,
iLastName,
iPhoneNumber,
iStatus,
iEmail
);

END$$
DELIMITER ;

DELIMITER $$
CREATE  PROCEDURE `SP_Contacts_G_ById_contact`(
IN iId int
)
BEGIN
select * from contact where Id = iId;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE `SP_Contacts_G_ALL_contact`()
BEGIN
select * from contact;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE `SP_Contacts_G_Email_count`(
IN iId int,
IN iEmail varchar(45)
)
BEGIN

if iId = 0
then
	select count(*) from contact where lower(Email)= lower(iEmail);
else
   select count(*) from contact where lower(Email)= lower(iEmail) and Id != iId;
end if;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE `SP_Contacts_U_contact`(
IN iId int,
IN iEmail Varchar(45),
IN iFirstName Varchar(45),
IN iLastName Varchar(45),
IN iPhoneNumber Varchar(45),
IN iStatus Varchar(45)
)
BEGIN
UPDATE  contact SET
FirstName=iFirstName,
LastName=iLastName,
PhoneNumber=iPhoneNumber,
Status=iStatus,
Email=iEmail where Id=iId;

END$$
DELIMITER ;



