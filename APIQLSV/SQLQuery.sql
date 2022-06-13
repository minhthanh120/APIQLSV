CREATE DATABASE APIQLSV
GO
/*
 

use master
*/
USE APIQLSV
GO

CREATE TABLE SINHVIEN
(
    MASV INT PRIMARY KEY IDENTITY(1, 1),
    TENSV NVARCHAR(50),
    LOP NVARCHAR(10),
    KHOA NVARCHAR(10),
    NGAYSINH DATE,
    GIOITINH BIT,
)
GO

CREATE TABLE MONHOC
(
    MAMH INT PRIMARY KEY IDENTITY(1,1),
    TENMH NVARCHAR(50),
    SOTIET INT,
    CONSTRAINT kt_sotiet CHECK(SOTIET <7)
)
GO

CREATE TABLE SinhvienMonhoc
(
    MASV INT FOREIGN KEY REFERENCES SINHVIEN(MASV),
    MAMH INT FOREIGN KEY REFERENCES MONHOC(MAMH),
    PRIMARY KEY(MASV, MAMH),
    DIEMTP FLOAT,
    DIEMQT FLOAT,
    CONSTRAINT kt_diemtp CHECK(DIEMTP<=10 AND DIEMTP>=0),
    CONSTRAINT kt_diemqt CHECK(DIEMQT<=10 AND DIEMQT>=0)
)
GO

-- Insert rows into table 'MONHOC'
INSERT INTO MONHOC
    ( -- columns to insert data into
    [TENMH], [SOTIET]
    )
VALUES
    ( -- first row: values for the columns in the list above
        N'Giải tích', 4
),
    ( -- second row: values for the columns in the list above
        N'Hình họa', 2
),
    (
        N'Vật lý đại cương', 4
),
    (
        N'Xử lý ngôn ngữ tự nhiên', 3
        ),
    (
        N'Xử lý hình ảnh', 3
        )
-- add more rows here
GO

-- Insert rows into table 'SINHVIEN'
INSERT INTO SINHVIEN
    ( -- columns to insert data into
    [TENSV], [GIOITINH], [NGAYSINH], [LOP], [KHOA]
    )
VALUES
    ( -- first row: values for the columns in the list above
        N'Nguyễn Văn A', 1, '1998-09-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Do Thị B', 0, '1999-08-02', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Ly Văn C', 1, '2000-07-03', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Hà Thị D', 0, '2001-06-04', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Tăng Văn E', 1, '2000-05-05', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Nguyễn Thị F', 0, '1999-04-06', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Hồ Văn G', 1, '1998-03-07', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Nguyễn Thị H', 0, '1997-02-08', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Cao Văn I', 1, '1996-01-09', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Lê Thị J', 0, '1995-01-10', N'K17', N'2021'
)
-- add more rows here
GO


-- Insert rows into table 'TableName'
INSERT INTO SinhvienMonhoc
    ( -- columns to insert data into
    [MASV], [MAMH]
    )
VALUES
    ( -- first row: values for the columns in the list above
        1, 71
),
    ( -- second row: values for the columns in the list above
        1, 72
),
    (
        1, 73
),
    (1, 74),
	(1,65),
	(1,64),
	(1,66),
	(1,67),
	(1,69),
	(1,70),
	(1,79),
    (2, 71),
    (2, 73),
    (6, 73),
    (6, 64),
    (4, 64),
    (4, 65),
    (7, 65)
-- add more rows here
GO




--TRIGGER xóa điểm khi xóa sinh viên
CREATE OR ALTER TRIGGER TR_XOADIEM_DML ON SINHVIEN INSTEAD OF DELETE
AS
DECLARE @MA INT
BEGIN
    SELECT @MA=MASV
    FROM deleted
    DELETE SinhvienMonhoc WHERE MASV=@MA
    DELETE SINHVIEN WHERE MASV=@MA
END
GO

--Xóa điểm của môn học khi xóa môn học
create or alter trigger TR_XOAMON_DML ON MONHOC INSTEAD OF DELETE
as
begin
    Declare @Id int
    SELECT @Id = MONHOC.MAMH
    FROM MONHOC JOIN deleted on MONHOC.MAMH= deleted.MAMH
    IF (@Id is not null)
begin
        DELETE SinhvienMonhoc FROM SinhvienMonhoc JOIN deleted on SinhvienMonhoc.MAMH=deleted.MAMH
        DELETE MONHOC FROM MONHOC JOIN deleted on MONHOC.MAMH=deleted.MAMH
    end
end


INSERT INTO MONHOC
    ( -- columns to insert data into
    [TENMH], [SOTIET]
    )
VALUES
    ( -- first row: values for the columns in the list above
        N'Cơ sở dữ liệu', 4
),
    ( -- second row: values for the columns in the list above
        N'Thực tập công nghiệp', 2
),
    (
        N'Thực tập CNTT', 4
),
    (
        N'Phương pháp thiết kế', 3
        ),
    (
        N'Cấu trúc máy tính', 3
        )

		
INSERT INTO MONHOC
    ( -- columns to insert data into
    [TENMH], [SOTIET]
    )
VALUES
    ( -- first row: values for the columns in the list above
        N'Phân tích hệ thống', 4
),
    ( -- second row: values for the columns in the list above
        N'Lập trình Java', 2
),
    (
        N'Sức bền vật liệu', 4
),
    (
        N'Hóa chất 1', 3
        ),
    (
        N'Hóa chất 2', 3
        )
		select * from sinhvien
		select * from SinhvienMonhoc
		select * from monhoc