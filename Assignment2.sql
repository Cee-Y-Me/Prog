
CREATE TABLE CUSTOMER (
    CUSTOMER_ID NUMBER PRIMARY KEY,
    FIRST_NAME VARCHAR2(50),
    SURNAME VARCHAR2(50),
    ADDRESS VARCHAR2(100),
    CONTACT_NUMBER VARCHAR2(20),
    EMAIL VARCHAR2(100)
);

-- Populate CUSTOMER table
INSERT INTO CUSTOMER (CUSTOMER_ID, FIRST_NAME, SURNAME, ADDRESS, CONTACT_NUMBER, EMAIL)
VALUES (11011, 'Jack', 'Smith', '18 Water Rd', '0877277521', 'jsmith@isat.com');

INSERT INTO CUSTOMER (CUSTOMER_ID, FIRST_NAME, SURNAME, ADDRESS, CONTACT_NUMBER, EMAIL)
VALUES (11012, 'Pat', 'Hendricks', '22 Water Rd', '0863257857', 'ph@mcom.co.za');

INSERT INTO CUSTOMER (CUSTOMER_ID, FIRST_NAME, SURNAME, ADDRESS, CONTACT_NUMBER, EMAIL)
VALUES (11013, 'Andre', 'Clark', '101 Summer Lane', '0834567891', 'aclark@mcom.co.za');

INSERT INTO CUSTOMER (CUSTOMER_ID, FIRST_NAME, SURNAME, ADDRESS, CONTACT_NUMBER, EMAIL)
VALUES (11014, 'Kevin', 'Jones', '55 Mountain way', '0612547895', 'kj@isat.co.za');

INSERT INTO CUSTOMER (CUSTOMER_ID, FIRST_NAME, SURNAME, ADDRESS, CONTACT_NUMBER, EMAIL)
VALUES (11015, 'Lucy', 'Williams', '5 Main rd', '0827238521', 'lw@mcal.co.za');


-- Create EMPLOYEE table
CREATE TABLE EMPLOYEE (
    EMPLOYEE_ID VARCHAR2(10) PRIMARY KEY,
    FIRST_NAME VARCHAR2(50),
    SURNAME VARCHAR2(50),
    CONTACT_NUMBER VARCHAR2(10),
    ADDRESS VARCHAR2(100),
    EMAIL VARCHAR2(100)
);

-- Populate EMPLOYEE table
INSERT INTO EMPLOYEE (EMPLOYEE_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, ADDRESS, EMAIL)
VALUES ('emp101', 'Jeff', 'Davis', '0877277521', '10 main road', 'jand@isat.com');

INSERT INTO EMPLOYEE (EMPLOYEE_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, ADDRESS, EMAIL)
VALUES ('emp102', 'Kevin', 'Marks', '0837377522', '18 water road', 'km@isat.com');

INSERT INTO EMPLOYEE (EMPLOYEE_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, ADDRESS, EMAIL)
VALUES ('emp103', 'Adanya', 'Andrews', '0817117523', '21 circle lane', 'aa@isat.com');

INSERT INTO EMPLOYEE (EMPLOYEE_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, ADDRESS, EMAIL)
VALUES ('emp104', 'Adebayo', 'Dryer', '0797215244', '1 sea road', 'arver@isat.com');

INSERT INTO EMPLOYEE (EMPLOYEE_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, ADDRESS, EMAIL)
VALUES ('emp105', 'Xolani', 'Samson', '0827122255', '12 main road', 'xosam@isat.com');


-- Create DONATOR table
CREATE TABLE DONATOR (
    DONATOR_ID NUMBER PRIMARY KEY,
    FIRST_NAME VARCHAR2(50),
    SURNAME VARCHAR2(50),
    CONTACT_NUMBER VARCHAR2(20),
    EMAIL VARCHAR2(100)
);

-- Populate DONATOR table
INSERT INTO DONATOR (DONATOR_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, EMAIL)
VALUES (20111, 'Jeff', 'Watson', '0827172250', 'jwatson@ymail.com');

INSERT INTO DONATOR (DONATOR_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, EMAIL)
VALUES (20112, 'Stephen', 'Jones', '0837865670', 'joness@ymail.com');

INSERT INTO DONATOR (DONATOR_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, EMAIL)
VALUES (20113, 'James', 'Joe', '0878978650', 'jj@isat.com');

INSERT INTO DONATOR (DONATOR_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, EMAIL)
VALUES (20114, 'Kelly', 'Ross', '0826575650', 'Kross@gsat.com');

INSERT INTO DONATOR (DONATOR_ID, FIRST_NAME, SURNAME, CONTACT_NUMBER, EMAIL)
VALUES (20115, 'Abraham', 'Clark', '0797656430', 'aclark@ymall.com');


-- Create DONATION table
CREATE TABLE DONATION (
    DONATION_ID NUMBER PRIMARY KEY,
    DONATOR_ID NUMBER,
    DONATION_DESCRIPTION VARCHAR2(100),
    PRICE INT,
    DONATION_DATE DATE,
    CONSTRAINT fk_donator_id FOREIGN KEY (DONATOR_ID) REFERENCES DONATOR(DONATOR_ID)
);

-- Populate DONATION table
INSERT INTO DONATION (DONATION_ID, DONATOR_ID, DONATION_DESCRIPTION, PRICE, DONATION_DATE)
VALUES (7111, 20111, 'KIC Fridge',  599, TO_DATE('2024-05-01', 'YYYY-MM-DD'));

INSERT INTO DONATION (DONATION_ID, DONATOR_ID, DONATION_DESCRIPTION, PRICE, DONATION_DATE)
VALUES (7112, 20112, 'Samsung 42 inch LCD', 1299, TO_DATE('2024-05-03', 'YYYY-MM-DD'));

INSERT INTO DONATION (DONATION_ID, DONATOR_ID, DONATION_DESCRIPTION, PRICE, DONATION_DATE)
VALUES (7113, 20113, 'Sharp Microwave', 1599, TO_DATE('2024-05-03', 'YYYY-MM-DD'));

INSERT INTO DONATION (DONATION_ID, DONATOR_ID, DONATION_DESCRIPTION, PRICE, DONATION_DATE)
VALUES (7114, 20115, '6 Seat Dining room table', 799, TO_DATE('2024-05-05', 'YYYY-MM-DD'));

INSERT INTO DONATION (DONATION_ID, DONATOR_ID, DONATION_DESCRIPTION, PRICE, DONATION_DATE)
VALUES (7115, 20114, 'Lazyboy Sofa', 1199, TO_DATE('2024-05-07', 'YYYY-MM-DD'));

INSERT INTO DONATION (DONATION_ID, DONATOR_ID, DONATION_DESCRIPTION, PRICE, DONATION_DATE)
VALUES (7116, 20113, 'JVC Surround Sound System', 179, TO_DATE('2024-05-09', 'YYYY-MM-DD'));


-- Create DELIVERY table
CREATE TABLE DELIVERY (
    DELIVERY_ID NUMBER PRIMARY KEY,
    DELIVERY_NOTES VARCHAR2(100),
    DISPATCH_DATE DATE,
    DELIVERY_DATE DATE
);

-- Populate DELIVERY table
INSERT INTO DELIVERY (DELIVERY_ID, DELIVERY_NOTES, DISPATCH_DATE, DELIVERY_DATE)
VALUES (511, 'Double packaging requested', TO_DATE('2024-05-10', 'YYYY-MM-DD'), TO_DATE('2024-05-15', 'YYYY-MM-DD'));

INSERT INTO DELIVERY (DELIVERY_ID, DELIVERY_NOTES, DISPATCH_DATE, DELIVERY_DATE)
VALUES (512, 'Delivery to work address', TO_DATE('2024-05-12', 'YYYY-MM-DD'), TO_DATE('2024-05-15', 'YYYY-MM-DD'));

INSERT INTO DELIVERY (DELIVERY_ID, DELIVERY_NOTES, DISPATCH_DATE, DELIVERY_DATE)
VALUES (513, 'Signature required', TO_DATE('2024-05-12', 'YYYY-MM-DD'), TO_DATE('2024-05-17', 'YYYY-MM-DD'));

INSERT INTO DELIVERY (DELIVERY_ID, DELIVERY_NOTES, DISPATCH_DATE, DELIVERY_DATE)
VALUES (514, 'No notes', TO_DATE('2024-05-12', 'YYYY-MM-DD'), TO_DATE('2024-05-15', 'YYYY-MM-DD'));

INSERT INTO DELIVERY (DELIVERY_ID, DELIVERY_NOTES, DISPATCH_DATE, DELIVERY_DATE)
VALUES (515, 'Birthday present wrapping required', TO_DATE('2024-05-18', 'YYYY-MM-DD'), TO_DATE('2024-05-19', 'YYYY-MM-DD'));

INSERT INTO DELIVERY (DELIVERY_ID, DELIVERY_NOTES, DISPATCH_DATE, DELIVERY_DATE)
VALUES (516, 'Delivery to work address', TO_DATE('2024-05-20', 'YYYY-MM-DD'), TO_DATE('2024-05-25', 'YYYY-MM-DD'));


-- Create RETURNS table
CREATE TABLE RETURNS (
    RETURN_ID VARCHAR2(10) PRIMARY KEY,
    RETURN_DATE DATE,
    REASON VARCHAR2(100),
    CUSTOMER_ID NUMBER,
    DONATION_ID NUMBER,
    EMPLOYEE_ID VARCHAR2(10),
    CONSTRAINT fk_customer_id FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMER(CUSTOMER_ID),
    CONSTRAINT fk_donation_id FOREIGN KEY (DONATION_ID) REFERENCES DONATION(DONATION_ID),
    CONSTRAINT fk_employee_id FOREIGN KEY (EMPLOYEE_ID) REFERENCES EMPLOYEE(EMPLOYEE_ID)
);

-- Populate RETURNS table
INSERT INTO RETURNS (RETURN_ID, RETURN_DATE, REASON, CUSTOMER_ID, DONATION_ID, EMPLOYEE_ID)
VALUES ('ret001', TO_DATE('2024-05-25', 'YYYY-MM-DD'), 'Customer not satisfied with product', 11011, 7116, 'emp101');

INSERT INTO RETURNS (RETURN_ID, RETURN_DATE, REASON, CUSTOMER_ID, DONATION_ID, EMPLOYEE_ID)
VALUES ('ret002', TO_DATE('2024-05-25', 'YYYY-MM-DD'), 'Product had broken section', 11013, 7114, 'emp103');


-- Create INVOICE table
CREATE TABLE INVOICE (
    INVOICE_NUM NUMBER PRIMARY KEY,
    CUSTOMER_ID NUMBER,
    INVOICE_DATE DATE,
    EMPLOYEE_ID VARCHAR2(10),
    DONATION_ID NUMBER,
    DELIVERY_ID NUMBER,
    CONSTRAINT fk_customer_id_invoice FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMER(CUSTOMER_ID),
    CONSTRAINT fk_employee_id_invoice FOREIGN KEY (EMPLOYEE_ID) REFERENCES EMPLOYEE(EMPLOYEE_ID),
    CONSTRAINT fk_donation_id_invoice FOREIGN KEY (DONATION_ID) REFERENCES DONATION(DONATION_ID),
    CONSTRAINT fk_delivery_id_invoice FOREIGN KEY (DELIVERY_ID) REFERENCES DELIVERY(DELIVERY_ID)
);

-- Populate INVOICE table
INSERT INTO INVOICE (INVOICE_NUM, CUSTOMER_ID, INVOICE_DATE, EMPLOYEE_ID, DONATION_ID, DELIVERY_ID)
VALUES (8111, 11011, TO_DATE('2024-05-15', 'YYYY-MM-DD'), 'emp103', 7111, 511);

INSERT INTO INVOICE (INVOICE_NUM, CUSTOMER_ID, INVOICE_DATE, EMPLOYEE_ID, DONATION_ID, DELIVERY_ID)
VALUES (8112, 11013, TO_DATE('2024-05-15', 'YYYY-MM-DD'), 'emp101', 7114, 512);

INSERT INTO INVOICE (INVOICE_NUM, CUSTOMER_ID, INVOICE_DATE, EMPLOYEE_ID, DONATION_ID, DELIVERY_ID)
VALUES (8113, 11012, TO_DATE('2024-05-17', 'YYYY-MM-DD'), 'emp101', 7112, 513);

INSERT INTO INVOICE (INVOICE_NUM, CUSTOMER_ID, INVOICE_DATE, EMPLOYEE_ID, DONATION_ID, DELIVERY_ID)
VALUES (8114, 11015, TO_DATE('2024-05-17', 'YYYY-MM-DD'), 'emp102', 7113, 514);

INSERT INTO INVOICE (INVOICE_NUM, CUSTOMER_ID, INVOICE_DATE, EMPLOYEE_ID, DONATION_ID, DELIVERY_ID)
VALUES (8115, 11011, TO_DATE('2024-05-17', 'YYYY-MM-DD'), 'emp102', 7115, 515);

INSERT INTO INVOICE (INVOICE_NUM, CUSTOMER_ID, INVOICE_DATE, EMPLOYEE_ID, DONATION_ID, DELIVERY_ID)
VALUES (6116, 11015, TO_DATE('2024-05-18', 'YYYY-MM-DD'), 'emp103', 7116, 516);