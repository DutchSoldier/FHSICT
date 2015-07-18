/* Hoofdstuk 4 oefening 4 ******************************************/

declare

   type type_coll_med
   is table of medewerkers%rowtype;

   t_med  type_coll_med;
   v_opgemaakt number := 0 ;
   v_grens number     := 1500;

begin
   select *
   bulk collect into t_med
   from   medewerkers
   order by maandsal
   for update;
   
   if t_med.count > 0
   then
      for i in 1 .. t_med.count
      loop
         exit when v_opgemaakt + ( t_med(i).maandsal * 0.1 ) > v_grens;

         update medewerkers
         set    maandsal = maandsal * 1.10
         where  mnr = t_med(i).mnr;

         v_opgemaakt := v_opgemaakt + ( t_med(i).maandsal * 0.1 );
      end loop;

   end if;
  dbms_output.put_line ( 'Opgemaakt: ' || to_char( v_opgemaakt ));
  commit;
end;
/


