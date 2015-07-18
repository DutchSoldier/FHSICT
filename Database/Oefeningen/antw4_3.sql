/* Hoofdstuk 4 oefening 3 ******************************************/

declare

   type type_rec_med 
    is record 
    ( naam     medewerkers.naam%type
    , functie  medewerkers.functie%type
    , maandsal medewerkers.maandsal%type
    , cumsal   number);

  type type_coll_medrec
    is table of type_rec_med;
   
  t_med    type_coll_medrec;
  v_cumsal number := 0;

begin
   select naam
   ,      functie
   ,      maandsal
   ,      null
   bulk collect into t_med 
   from   medewerkers
   order by naam;

   if t_med.count > 0
   then
      for i in 1 .. t_med.count
      loop
         v_cumsal := v_cumsal + t_med(i).maandsal;
         t_med(i).cumsal := v_cumsal;
         dbms_output.put_line(t_med( i ).naam || ' ' || t_med( i ).functie 
                || ' ' || t_med( i ).maandsal || ' ' || t_med( i ).cumsal );
      end loop;
   end if;
end;
/


