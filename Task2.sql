--Задание 2

--клиенты
drop table if exists #Clients;
create table #Clients
(
  Id bigint Identity(1,1), -- Id клиента
  ClientName nvarchar(200) -- Наименование клиента
)

--контакты клиентов
drop table if exists #ClientContacts;
create table #ClientContacts
(
  Id bigint Identity(1,1), -- Id контакта
  ClientId bigint, -- Id клиента
  ContactType nvarchar(255), -- тип контакта
  ContactValue nvarchar(255) --  значение контакта
)

insert into #Clients values ('Петров'),('Петров1'),('Петров2'),('Петров3'),('Петров5')
insert into #ClientContacts values (1,'телефон','88005553535'),(2,'почта','sdfsf'),(3,'телефон','88005553536'),(4,'телефон','88005553537'),(5,'почта','ыуаы'),(5,'голубь','вова'),(5,'голубь','паша')

--Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов

select c.ClientName, cc.ClientId, COUNT(cc.ContactValue)
from #Clients c
inner join #ClientContacts cc on c.Id = cc.ClientId
group by ClientId,ClientName

--или 
select c.ClientName,cc.CountContacts
from #Clients c
inner join 
(select ClientId, COUNT(ContactValue) as CountContacts from #ClientContacts group by ClientId )cc on c.Id = cc.ClientId

--Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов

select c.ClientName
from #Clients c
inner join 
(select ClientId, COUNT(ContactValue) as CountContacts from  #ClientContacts group by ClientId )cc on c.Id = cc.ClientId
where cc.CountContacts > 2

--или
select c.ClientName
from #ClientContacts cc
inner join #Clients c on c.Id = cc.ClientId
group by cc.ClientId,c.ClientName
having COUNT(cc.ContactValue) >2