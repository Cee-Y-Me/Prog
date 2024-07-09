CREATE TABLE KAYAKS (
    kayak_id INT PRIMARY KEY,
    kayak_type VARCHAR(50),
    kayak_model VARCHAR(50),
    manufacturer VARCHAR(50)
);

CREATE TABLE CUSTOMER (
    cust_id VARCHAR2(4) PRIMARY KEY,
    cust_fname VARCHAR2(50),
    cust_sname VARCHAR2(50),
    cust_address VARCHAR2(100),
    cust_contact VARCHAR2(50)
);

CREATE TABLE UPGRADES (
    upgrade_id INT PRIMARY KEY,
    upgrade_work VARCHAR(100),
    upgrade_date VARCHAR2(50),
    upgrade_hrs DECIMAL(5,2)
);

CREATE TABLE KAYAK_UPGRADES (
    kayak_upgrade_num INT PRIMARY KEY,
    kayak_upgrade_date VARCHAR2(20),
    kayak_upgrade_amt DECIMAL(10,2),
    kayak_id INT,
    cust_id VARCHAR2(4),
    upgrade_id INT,
    FOREIGN KEY (kayak_id) REFERENCES KAYAKS(kayak_id),
    FOREIGN KEY (cust_id) REFERENCES CUSTOMER(cust_id),
    FOREIGN KEY (upgrade_id) REFERENCES UPGRADES(upgrade_id)
);


INSERT INTO KAYAKS (kayak_id, kayak_type, kayak_model, manufacturer) VALUES (12345, 'Single Seater', 'K100', 'FeelFree');
INSERT INTO KAYAKS (kayak_id, kayak_type, kayak_model, manufacturer) VALUES (54321, 'Tandem Seater', 'J55','Roamer');
INSERT INTO KAYAKS (kayak_id, kayak_type, kayak_model, manufacturer) VALUES (78945, 'Fishing Kayak', 'H9000', 'Wavesport');
INSERT INTO KAYAKS (kayak_id, kayak_type, kayak_model, manufacturer) VALUES (98754, 'Hobie Kayak', 'A450', 'Gemini');
INSERT INTO KAYAKS (kayak_id, kayak_type, kayak_model, manufacturer) VALUES (55311, 'Canadian Style', 'L920', 'Surge');


INSERT INTO CUSTOMER (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C115', 'Jeff', 'Willis', '3 Main Road', '0821253659');
INSERT INTO CUSTOMER (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C116', 'Andre', 'Watson', '13 Cape Road', '0769658547');
INSERT INTO CUSTOMER (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C117', 'Wallis', 'Smith', '3 Mountain Road', '0863256574');
INSERT INTO CUSTOMER (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C118', 'Alex', 'Hanson', '8 Circle Road', '0762356587');
INSERT INTO CUSTOMER (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C119', 'Bob', 'Bitterhout', '15 Main Road', '0821235258');
INSERT INTO CUSTOMER (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C120', 'Thando', 'Zolani', '88 Summer Road', '0847541254');
INSERT INTO CUSTOMER (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C121', 'Philip', 'Jackson', '3 Long Road', '0745556658');
INSERT INTO CUSTOMER (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C122', 'Sarah', 'Jones', '7 Sea Road', '0814745745');



INSERT INTO UPGRADES (upgrade_id, upgrade_work, upgrade_date, upgrade_hrs) VALUES (1, 'Sonar Device', '2022-07-15', 5);
INSERT INTO UPGRADES (upgrade_id, upgrade_work, upgrade_date, upgrade_hrs) VALUES (2, 'Padded Seats', '2022-07-18', 3);
INSERT INTO UPGRADES (upgrade_id, upgrade_work, upgrade_date, upgrade_hrs) VALUES (3, 'GoPro Camera Mount', '2022-07-19', 10);


INSERT INTO KAYAK_UPGRADES (kayak_upgrade_num, kayak_upgrade_date, kayak_upgrade_amt, kayak_id, cust_id, upgrade_id) VALUES (101, '2019-07-27', 75, 98754, 'C121', 3);
INSERT INTO KAYAK_UPGRADES (kayak_upgrade_num, kayak_upgrade_date, kayak_upgrade_amt, kayak_id, cust_id, upgrade_id) VALUES (102, '2019-07-20', 30, 12345, 'C120', 2);
INSERT INTO KAYAK_UPGRADES (kayak_upgrade_num, kayak_upgrade_date, kayak_upgrade_amt, kayak_id, cust_id, upgrade_id) VALUES (103, '2019-07-23', 75, 55311, 'C119', 1);
INSERT INTO KAYAK_UPGRADES (kayak_upgrade_num, kayak_upgrade_date, kayak_upgrade_amt, kayak_id, cust_id, upgrade_id) VALUES (104, '2019-07-17', 50, 54321, 'C117', 1);
INSERT INTO KAYAK_UPGRADES (kayak_upgrade_num, kayak_upgrade_date, kayak_upgrade_amt, kayak_id, cust_id, upgrade_id) VALUES (105, '2019-07-19', 30, 12345, 'C122', 2);



select * from kayaks;
select * from customer;
select * from kayak_upgrades;
select * from upgrades;


CREATE USER Tshepo IDENTIFIED BY tmphoabc2023;
GRANT SELECT ANY TABLE TO Tshepo;

-- Create user Mya with password and grant INSERT ANY TABLE privilege
CREATE USER Mya IDENTIFIED BY mrobertabc2023;
GRANT INSERT ANY TABLE TO Mya;


Select KAYAK_ID, CUST_ID , b.UPGRADE_HRS,KAYAK_UPGRADE_AMT,(b.UPGRADE_HRS*KAYAK_UPGRADE_AMT) AS TOTAL
FROM KAYAK_UPGRADES a
INNER JOIN UPGRADES b on a.upgrade_id = b.upgrade_id;

Select (C.CUST_FNAME ||' '|| C.CUST_SNAME) AS CUSTOMER, k.KAYAK_TYPE , B.UPGRADE_HRS,UPGRADE_WORK,KAYAK_UPGRADE_AMT
FROM KAYAK_UPGRADES a
inner join  UPGRADES b on a.UPGRADE_ID = b.UPGRADE_ID
inner join CUSTOMER c on a.CUST_ID = c.CUST_ID
inner join KAYAKS k on a.kayak_id = k.kayak_id;

DECLARE 
    v_CName customer.CUST_ID%type;
    v_UPWORK UPGRADES.UPGRADE_WORK%type;
    v_UPAMT KAYAK_UPGRADES.KAYAK_UPGRADE_AMT%type;
    CURSOR c2
    is
select o.CUST_ID, b.UPGRADE_WORK ,o.KAYAK_UPGRADE_AMT
FROM KAYAK_UPGRADES o
inner join  UPGRADES b on o.UPGRADE_ID = b.UPGRADE_ID
where o.KAYAK_UPGRADE_AMT > 50;
BEGIN
OPEN c2;
loop
fetch c2 into  v_CName, v_UPWORK, v_UPAMT;
exit when c2%notfound;
dbms_output.put_line('------------------------------------');
dbms_output.put_line('CUSTOMER ID: '|| v_cname);
dbms_output.put_line('UPGRADE WORK: ' ||v_UPWORK);
dbms_output.put_line('UPGRADE AMOUNT: ' ||'R '||v_UPAMT);
dbms_output.put_line('------------------------------------');

end loop;
close c2;
end;



SET SERVEROUTPUT ON;
DECLARE 
    v_CFname customer.CUST_fname%type;
    v_CSname customer.CUST_sname%type;
    v_Ktype KAYAKS.KAYAK_TYPE%type;
    v_UPwrk UPGRADES.UPGRADE_WORK%type;
    v_UPdate UPGRADES.UPGRADE_DATE%type;
    v_KUAMT KAYAK_UPGRADES.KAYAK_UPGRADE_AMT%type;
    CURSOR c2
    is
select c.cust_fname,c.cust_sname,k.kayak_type,b.upgrade_work,b.upgrade_date ,o.KAYAK_UPGRADE_AMT
FROM KAYAK_UPGRADES o
inner join  customer c on o.cust_id = c.cust_id
inner join  UPGRADES b on o.UPGRADE_ID = b.UPGRADE_ID
inner join  KAYAKS k on o.kayak_id = k.kayak_id
where o.cust_id = 'C121';
BEGIN
OPEN c2;
loop
fetch c2 into   v_CFname, v_CSname, v_Ktype,v_UPwrk,v_UPdate,v_KUAMT;
exit when c2%notfound;
dbms_output.put_line('------------------------------------');
dbms_output.put_line('CUSTOMER : '|| v_CFname || ' '||v_CSname);
dbms_output.put_line('KAYAK TYPE: ' ||v_Ktype);
dbms_output.put_line('UPGRADE WORK: ' ||'R '||v_UPwrk);
dbms_output.put_line('UPGRADE DATE: ' ||v_UPdate);
dbms_output.put_line('UPGRADE AMT: ' ||'R '||v_KUAMT);
dbms_output.put_line('DISCOUNT AMT: ' ||'R '||(v_KUAMT * 0.1));
dbms_output.put_line('------------------------------------');
end loop;
close c2;
end;

CREATE VIEW vwCustUpgrades AS
SELECT (c.cust_fname ||','||c.cust_sname) as customer, ku.kayak_type, u.upgrade_work, c.cust_contact
FROM KAYAK_UPGRADES k
INNER JOIN KAYAKS ku ON k.kayak_id = ku.kayak_id
INNER JOIN UPGRADES u ON k.upgrade_id = u.upgrade_id
INNER JOIN CUSTOMER c ON k.cust_id = c.cust_id
where c.cust_address like '%Summer%';


