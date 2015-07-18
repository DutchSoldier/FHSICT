/* Hoofdstuk 4 oefening 2 ******************************************/

declare
   type type_coll_med
   is table of medewerkers%rowtype;

   t_med   type_coll_med;
   v_index pls_integer;
begin
   select *
   bulk collect into t_med
   from   medewerkers 
   order by gbdatum;
   
   v_index := t_med.first;
   while v_index is not null
   loop
      dbms_output.put_line( t_med(v_index).naam 
                           || ' ' || to_char( t_med(v_index).gbdatum ) );
      exit when v_index >= 4;
      v_index := t_med.next(v_index);
  end loop;
end;
/


