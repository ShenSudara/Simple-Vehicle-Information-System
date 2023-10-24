CREATE TABLE vehicle_tbl (
	reg_no VARCHAR(10), 
	model_name VARCHAR(50) NOT NULL,
	no_of_seat INT NOT NULL
	CONSTRAINT PK_VEHICLE_REG_NO PRIMARY KEY(reg_no)
);

CREATE TABLE vehicle_color_tbl(
	reg_no VARCHAR(10),
	color_code VARCHAR(8),
	CONSTRAINT PK_VEHICLE_COLOR_CODE PRIMARY KEY(reg_no, color_code),
	CONSTRAINT FK_VEHICLE_COLOR FOREIGN KEY(reg_no) REFERENCES vehicle_tbl(reg_no)
);

SELECT V.reg_no, V.model_name, V.no_of_seat, COUNT(VC.color_code) as no_of_color
FROM vehicle_tbl V 
INNER JOIN  vehicle_color_tbl VC 
ON V.reg_no = VC.reg_no
GROUP BY V.reg_no, V.model_name, V.no_of_seat
ORDER BY V.model_name, V.reg_no asc;