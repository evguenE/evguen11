--delete from Table_test where OrderValue in(select OrderValue from Table_test group by OrderValue having count(OrderValue)>1)
--DELETE FROM Test WHERE Id NOT IN (SELECT MIN(Id) FROM Test GROUP BY str,message)
--SELECT MIN(OrderID) FROM Table_test GROUP BY OrderValue,message

--select distinct(cus.Id), cusp.Value as FirstName, cus.name as Name,cusi.Value as Phone from Customer cus join Customerinfo cusi on cus.Id = cusi.Id  join Customerinfo cusp on cus.Id = cusp.Id where cusi.Field = 'Phone' or cusp.Field = 'FirstName' 

--select distinct(cus.Id), cus.name as Name,cusp.Value  from Customer cus join Customerinfo cusi on cus.Id = cusi.Id  join Customerinfo cusp on cus.Id = cusp.Id 

--select id, Value from Customerinfo where Field = 'FirstName' and EXISTS(select id, Value from Customerinfo where Field = 'Phone')
--select id, Value from Customerinfo where Field = 'Phone'


--select cus.Id,cus.Value,cusi.Value from Customerinfo cus left join(select id, Value from Customerinfo where Field = 'Phone') cusi on cus.Id = cusi.Id where cus.Field = 'FirstName'  

select cu.Id,cus.Value as FirstName,cu.name as Name,ISNULL(cusi.Value,'') as Phone from Customer cu join  Customerinfo cus on cu.Id = cus.Id  left join(select id, Value from Customerinfo where Field = 'Phone') cusi on cus.Id = cusi.Id where cus.Field = 'FirstName'  



--UNION all
--select cus.Id, cusi.Value, cus.name as Name from Customer cus join Customerinfo cusi on cus.Id = cusi.Id  where cusi.Field = 'Phone'
--INSERT INTO Test2 (Id, FirstName,Name)select cus.Id, cusi.Value, cus.name as Name from Customer cus join  Customerinfo cusi on cus.Id = cusi.Id  where cusi.Field = 'FirstName'
