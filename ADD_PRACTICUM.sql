--Question1--

CREATE TABLE instructors (
    ins_ID INT PRIMARY KEY,
    ins_fname VARCHAR(50),
    ins_sname VARCHAR(50),
    ins_contact VARCHAR(20),
    ins_level INT
);

CREATE TABLE customers (
    cust_id VARCHAR(10) PRIMARY KEY,
    cust_fname VARCHAR(50),
    cust_sname VARCHAR(50),
    cust_address VARCHAR(50),
    cust_contact VARCHAR(20)
);

CREATE TABLE dives (
    dive_id INT PRIMARY KEY,
    dive_name VARCHAR(50),
    dive_duration VARCHAR(50),
    dive_location VARCHAR(100),
    dive_exp_level INT,
    dive_cost INT
);

CREATE TABLE dive_events (
    dive_event_id VARCHAR(10) PRIMARY KEY,
    dive_date DATE,
    dive_participants INT,
    ins_ID INT,
    cust_id VARCHAR(10),
    dive_ID INT,
    FOREIGN KEY (ins_ID) REFERENCES instructors(ins_ID),
    FOREIGN KEY (cust_id) REFERENCES customers(cust_id),
    FOREIGN KEY (dive_ID) REFERENCES dives(dive_id)
);


INSERT INTO instructors (ins_ID, ins_fname, ins_sname, ins_contact, ins_level) VALUES (101, 'James', 'Willis', '0843569851', 7);

INSERT INTO instructors (ins_ID, ins_fname, ins_sname, ins_contact, ins_level) VALUES (102, 'Sam', 'Wait', '0763698521', 2);

INSERT INTO instructors (ins_ID, ins_fname, ins_sname, ins_contact, ins_level) VALUES (103, 'Sally', 'Gumede', '0786598521', 8);

INSERT INTO instructors (ins_ID, ins_fname, ins_sname, ins_contact, ins_level) VALUES (104, 'Bob', 'Du Preez', '0796369857', 3);

INSERT INTO instructors (ins_ID, ins_fname, ins_sname, ins_contact, ins_level) VALUES (105, 'Simon', 'Jones', '0826598741', 9);



INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C115', 'Heinrich', 'Willis', '3 Main Road', '0821253659');

INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C116', 'David', 'Watson', '13 Cape Road', '0769658547');

INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C117', 'Waldo', 'Smith', '3 Mountain Road', '0863256574');

INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C118', 'Alex', 'Hanson', '8 Circle Road', '0762356587');

INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C119', 'Kuhle', 'Bitterhout', '15 Main Road', '0821235258');

INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C120', 'Thando', 'Zolani', '88 Summer Road', '0847541254');

INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C121', 'Philip', 'Jackson', '3 Long Road', '0745556658');

INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C122', 'Sarah', 'Jones', '7 Sea Road', '0814745745');

INSERT INTO customers (cust_id, cust_fname, cust_sname, cust_address, cust_contact) VALUES ('C123', 'Catherine', 'Howard', '31 Lake Side Road', '0822232521');


INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (550, 'Shark Dive', '3 hours', 'Shark Point', 8, 500);

INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (551, 'Coral Dive', '1 hour', 'Break Point', 7, 300);

INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (552, 'Wave Crescent', '2 hours', 'Ship Wreck Ally', 3, 800);

INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (553, 'Underwater Exploration', '1 hour', 'Coral Ally', 2, 250);

INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (554, 'Underwater Adventure', '3 hours', 'Sandy Beach', 3, 750);

INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (555, 'Deep Blue Ocean', '30 minutes', 'Lazy Waves', 2, 120);

INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (556, 'Rough Seas', '1 hour', 'Pipe', 9, 700);

INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (557, 'White Water', '2 hours', 'Drifts', 5, 200);

INSERT INTO dives (dive_id, dive_name, dive_duration, dive_location, dive_exp_level, dive_cost) VALUES (558, 'Current Adventure', '2 hours', 'Rock Lands', 3, 150);


INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_101', TO_DATE('2017-07-15', 'YYYY-MM-DD'), 5, 103, 'C115', 558);

INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_102', TO_DATE('2017-07-16', 'YYYY-MM-DD'), 7, 102, 'C117', 555);

INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_103', TO_DATE('2017-07-18', 'YYYY-MM-DD'), 8, 104, 'C118', 552);

INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_104', TO_DATE('2017-07-19', 'YYYY-MM-DD'), 3, 101, 'C119', 551);

INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_105', TO_DATE('2017-07-21', 'YYYY-MM-DD'), 5, 104, 'C121', 558);

INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_106', TO_DATE('2017-07-22', 'YYYY-MM-DD'), 8, 105, 'C120', 556);

INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_107', TO_DATE('2017-07-25', 'YYYY-MM-DD'), 10, 105, 'C115', 554);

INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_108', TO_DATE('2017-07-27', 'YYYY-MM-DD'), 5, 101, 'C122', 552);

INSERT INTO dive_events (dive_event_id, dive_date, dive_participants, ins_ID, cust_id, dive_ID) VALUES ('de_109', TO_DATE('2017-07-28', 'YYYY-MM-DD'), 3, 102, 'C123', 553);



--Question3--

Select (i.ins_fname ||','|| i.ins_sname) AS INSTRUCTOR, (c.cust_fname ||','|| c.cust_sname) AS CUSTOMER , d.dive_location AS DIVE_LOCATION ,a.dive_participants AS DIVE_PARTICIPANTS
FROM dive_events a
inner join  instructors i on a.ins_id = i.ins_id
inner join customers c on a.cust_id = c.cust_id
inner join dives d on a.dive_id = d.dive_id
where a.dive_participants between 8 and 10;

--question4--

SET SERVEROUTPUT ON;

DECLARE
    v_dive_name dives.dive_name%TYPE;
    v_dive_date dive_events.dive_date%TYPE;
    v_participants dive_events.dive_participants%TYPE;
BEGIN
    -- Cursor to fetch dive events with 10 or more participants
    FOR c_dive_events IN (
        SELECT d.dive_name, de.dive_date, de.dive_participants
        FROM dives d
        JOIN dive_events de ON d.dive_id = de.dive_ID
        WHERE de.dive_participants >= 10
    )
    LOOP
        -- Fetching values into variables
        v_dive_name := c_dive_events.dive_name;
        v_dive_date := TO_CHAR(c_dive_events.dive_date, 'DD/MON/YY');
        v_participants := c_dive_events.dive_participants;
        
        -- Output the results
        DBMS_OUTPUT.PUT_LINE('DIVE NAME:'|| v_dive_name );
        DBMS_OUTPUT.PUT_LINE('DIVE DATE:' || v_dive_date);
        DBMS_OUTPUT.PUT_LINE('PARTICIPANTS: ' || v_participants);
        DBMS_OUTPUT.PUT_LINE('-----------------------------------');
    END LOOP;
END;

--Question5--

SET SERVEROUTPUT ON;

DECLARE
    CURSOR c_dive_events IS
        SELECT cu.cust_fname || ', ' || cu.cust_sname AS customer_name,
               d.dive_name,
               de.dive_participants,
               d.dive_cost
          FROM dive_events de
          JOIN customers cu
            ON de.cust_id = cu.cust_id
          JOIN dives d
            ON de.dive_ID = d.dive_id
         WHERE d.dive_cost > 500;
         
    v_customer_name VARCHAR2(100);
    v_dive_name dives.dive_name%TYPE;
    v_participants dive_events.dive_participants%TYPE;
    v_status VARCHAR2(100);
    
    v_instructors_required INT;
BEGIN
    FOR rec IN c_dive_events LOOP
        v_customer_name := rec.customer_name;
        v_dive_name := rec.dive_name;
        v_participants := rec.dive_participants;
       
        IF v_participants <= 4 THEN
            v_instructors_required := 1;
        ELSIF v_participants <= 7 THEN
            v_instructors_required := 2;
        ELSE
            v_instructors_required := 3;
        END IF;
        v_status := v_instructors_required || ' instructors required.';
        
        
        DBMS_OUTPUT.PUT_LINE('CUSTOMER: ' || v_customer_name);
        DBMS_OUTPUT.PUT_LINE('DIVE NAME: ' || v_dive_name);
        DBMS_OUTPUT.PUT_LINE('PARTICIPANTS: ' || v_participants);
        DBMS_OUTPUT.PUT_LINE('STATUS: ' || v_status);
        DBMS_OUTPUT.PUT_LINE('------------------------');
    END LOOP;
END;
/


