/* Hoofdstuk 4 oefening 7     *************************************/

create table mkopie 
as 
select * from medewerkers where 1=2
/


declare
  type type_coll_med 
  is table of medewerkers%rowtype;
  tab_mdw type_coll_med; 
begin
   select *
   bulk collect into tab_mdw
   from medewerkers 
   order by naam;

   forall i in tab_mdw.first .. tab_mdw.last
   insert into mkopie
   values tab_mdw(i);
   
end;  
/
