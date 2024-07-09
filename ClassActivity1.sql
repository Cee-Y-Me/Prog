select * from product;
select * from sales;
select * from supplier;

SELECT Product_Name,count(s.product_id) as max_sales
FROM product p
INNER JOIN sales s ON p.product_id = s.product_id
Group By p.product_Name
order by count(s.product_id) desc 
FETCH FIRST 1 ROWS ONLY
;

SET SERVEROUTPUT ON;

DECLARE 
    v_Pname Product.Product_Name%type;
    v_Spname Supplier.Supplier_Name%type;
    v_Sdate Sales.Sales_date%type;

CURSOR c1
is
SELECT p.Product_Name, s.supplier_name , s.sales_date
FROM product p
INNER JOIN sales s ON p.product_id = s.product_id
inner join supplier sp on s.supplier_id = sp.supplier_id
where s.sales_id = 3;
BEGIN
OPEN c1;
loop
fetch c1 into  v_Pname, v_Spname,v_Sdate;
exit when c1%notfound;

dbms_output.put_line('Product Name'||v_Pname);
dbms_output.put_line('Supplier Name'||v_Spname);
dbms_output.put_line('Sales Date'||v_Sdate);
end loop;
close c1;
end;



DECLARE 
    v_Pname Product.Product_Name%type;
    v_Price Product.Product_Price%type;
    CURSOR c2
    is
select p.product_name , p.product_price*1.1
FROM product p
INNER JOIN sales s ON p.product_id = s.product_id
inner join supplier sp on s.supplier_id = sp.supplier_id
where sp.supplier_name = 'Coffee Incoporated';
BEGIN
OPEN c2;
loop
fetch c2 into  v_Pname, v_Price;
exit when c1%notfound;

dbms_output.put_line(v_Pname ||'Price: R'||v_Price);
dbms_output.put_line('------------------------------------');

end loop;
close c2;
end;


Create or replace view Product_sales
as
SELECT Product_Name,count(s.product_id) as max_sales
FROM product p
INNER JOIN sales s ON p.product_id = s.product_id
Group By p.product_Name,s.sales_date
having s.sales_date between '1 july 2017' and '28 August 2017'
;