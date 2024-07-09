--Question 1

CREATE TABLE Book
(
Book_ID VARCHAR2(100) NOT NULL,
Title VARCHAR2(100) NOT NULL,
Price NUMBER(5,2) NOT NULL,
Instock INT NOT NULL,
CONSTRAINT PK_Book PRIMARY KEY(Book_ID)
);


CREATE TABLE Author
(
Author_ID INT NOT NULL,
Firstname VARCHAR2(100) NOT NULL,
Surname VARCHAR2(100) NOT NULL,
Contact VARCHAR2(100) NOT NULL,
CONSTRAINT PK_Author PRIMARY KEY(Author_ID)
);

CREATE TABLE ORDERS
(
Order_ID VARCHAR2(100) NOT NULL,
Order_Date DATE NOT NULL,
Qty VARCHAR2(100) NOT NULL,
Book_ID VARCHAR2(100) NOT NULL,
Author_id INT NOT NULL,
CONSTRAINT PK_ORDERS PRIMARY KEY (Order_ID),
    CONSTRAINT FK_Book_orders FOREIGN KEY (Book_ID) REFERENCES Book(Book_ID),
    CONSTRAINT FK_Author_orders FOREIGN KEY(Author_ID) REFERENCES Author(Author_ID)
);


SELECT (a.firstname|| ' '|| a.surname) as AUTHOR_NAME ,b.title as TITLE ,Order_Date as ORDERDATE
FROM Orders o
INNER JOIN book b ON o.book_id = b.book_id
INNER JOIN author a ON o.author_id = a.author_id
order by b.title
;

select b.title ,b.price, (b.price*0.14) as VAT ,(b.price + b.price*0.14) as TOTAL_PRICE
FROM book b
INNER JOIN orders o ON b.book_id = o.book_id
where o.qty = 5;


SET SERVEROUTPUT ON;
DECLARE 
    v_Aname author.firstname%type;
    v_Asurname author.surname%type;
    v_Title book.title%type;
    CURSOR c2
    is
select a.firstname, a.surname ,b.title
FROM orders o
INNER JOIN book b ON o.book_id = b.book_id
INNER JOIN author a ON o.author_id = a.author_id
where a.contact like '011%';
BEGIN
OPEN c2;
loop
fetch c2 into  v_Aname, v_Asurname, v_Title;
exit when c2%notfound;

dbms_output.put_line('AUTHOR: '|| v_Aname ||' '|| v_Asurname);
dbms_output.put_line('TITLE: ' ||v_Title);
dbms_output.put_line('------------------------------------');

end loop;
close c2;
end;

--question%
SET SERVEROUTPUT ON;
DECLARE 
    v_Aname author.firstname%type;
    v_Asurname author.surname%type;
    v_Total INT;
    CURSOR c2
    is
select a.firstname, a.surname ,sum(o.qty)
FROM  author a 
INNER JOIN orders o ON a.author_id = o.author_id
Group by a.firstname, a.surname
ORDER BY a.firstname;
BEGIN
OPEN c2;
loop
fetch c2 into  v_Aname, v_Asurname, v_Total;
exit when c2%notfound;

dbms_output.put_line('Book sales for '|| v_Aname ||' '|| v_Asurname|| ' are '|| v_Total);

dbms_output.put_line('------------------------------------');

end loop;
close c2;
end;

