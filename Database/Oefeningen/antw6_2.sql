/* Hoofdstuk 6 oefening 2     *************************************/

declare
   cursor c_med 
   is
      select *
      from medewerkers
      order by gbdatum;

   type type_coll_med
   is table of c_med%rowtype;

   t_med   type_coll_med;
   v_index pls_integer;
begin
   open c_med;
   fetch c_med bulk collect into t_med;
   close c_med;
   
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

