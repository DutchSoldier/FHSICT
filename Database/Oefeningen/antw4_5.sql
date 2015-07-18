/* Hoofdstuk 4 oefening 5     *************************************/

declare

   type type_coll_med
   is table of medewerkers%rowtype;
   t_med type_coll_med;

   v_teller pls_integer:= 0;
   v_totsal number := 0;
   v_maxsal constant number := 55000;
   v_opslag constant number := 0.1;

begin
   select *
   bulk collect into t_med
   from medewerkers
   order by gbdatum desc
   for update;

   if t_med.count = 0
   then 
      rollback;
      -- met het return-statement kunnen we een PL/SQL-blok
      -- direct verlaten.
      return;
   end if;

   select sum(maandsal)
   into v_totsal
   from medewerkers;
   
   <<buitenloop>>
   while v_totsal <= v_maxsal 
   loop
      for i in 1 ..t_med.count 
      loop
         exit buitenloop when (v_totsal + ( t_med(i).maandsal * v_opslag )) > v_maxsal;
         update medewerkers
         set maandsal = maandsal * (1 + v_opslag)
         where mnr = t_med(i).mnr;
         t_med(i).maandsal := t_med(i).maandsal *(1+ v_opslag);

         v_teller := v_teller + 1;
         v_totsal := v_totsal + (t_med(i).maandsal * v_opslag);
      end loop;
   end loop buitenloop;

   dbms_output.put_line( to_char( v_teller ) ||
                         '-maal een rij ge-update' );
   dbms_output.put_line( to_char( v_totsal ) ||
                         ' is het salaristotaal' ); 
   commit;
end;
/