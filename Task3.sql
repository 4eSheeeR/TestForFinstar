--Задание 3
drop table if exists #Dates;
create table #Dates -- клиенты
(
  Id bigint,
  Dt date
);

insert into #Dates
values(1,'20210101'),(1,'20210110'),(1,'20210130'),(2,'20210115'),(2,'20210130');

select*
from #Dates;

with nextDate as (
  select Id, Dt ,lead(Dt) over (partition by Id order by Id) nextDate
  from #Dates 
    )

select *
from nextDate nd
where nd.nextDate is not null