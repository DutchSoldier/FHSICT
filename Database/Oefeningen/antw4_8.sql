/* Hoofdstuk 4 oefening 8     *************************************/

declare
   type type_coll_number
   is table of number;
   t_mnrs type_coll_number;
begin
   select m.mnr
   bulk collect into t_mnrs
   from medewerkers m
   where m.functie = 'MANAGER';

  forall i in t_mnrs.first .. t_mnrs.last   
  update medewerkers 
  set maandsal = 1.1 * maandsal
  where chef = t_mnrs(i);


  for i in t_mnrs.first .. t_mnrs.last 
  loop
     dbms_output.put_line(
          'Aantal updates: '  || sql%bulk_rowcount(i)
       || ' bij medewerker '  || t_mnrs(i)
       );
  end loop;
end;
/
