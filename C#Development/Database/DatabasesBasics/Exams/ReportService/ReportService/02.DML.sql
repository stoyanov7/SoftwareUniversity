INSERT INTO Employees(FirstName, LastName, Gender, Birthdate, DepartmentId)
VALUES
('Marlo', 'O�Malley', 'M', '09/21/1958', 1),
('Niki', 'Stanaghan', 'F', '11/26/1969', 4),
('Ayrton', 'Senna', 'M', '03/21/1960', 9),
('Ronnie', 'Peterson', 'M', '02/14/1944', 9),
('Giovanna', 'Amati', 'F', '07/20/1959', 5);

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1, 1, '04/13/2017', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '09/05/2015', '12/06/2015', 'Charity trail running', 3, 5),
(14, 2, '09/07/2015', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', 1, 1);

UPDATE Reports
SET StatusId = 2
WHERE StatusId = 1 AND CategoryId = 4

DELETE Reports
WHERE StatusId = 4