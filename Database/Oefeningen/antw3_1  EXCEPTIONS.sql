/* Hoofdstuk 3 oefening 1 ******************************************/

declare 
   v_naam     medewerkers.naam%type;
   v_mnr      medewerkers.mnr%type;
   v_maandsal medewerkers.maandsal%type;
begin
   v_naam := 'VERMEULEN';
   select mnr
   ,      maandsal
   into   v_mnr
   ,      v_maandsal
   from   medewerkers
   where  naam = v_naam;

   dbms_output.put_line( 'Naam medewerker: ' || v_naam );
   dbms_output.put_line( 'Nummer:          ' || to_char( v_mnr ));
   dbms_output.put_line( 'Maandsalaris:    ' || v_maandsal );   

exception
   when no_data_found then
      raise_application_error( -20000, 'Onbekende werknemer ' || v_naam ); 
   when too_many_rows then
      raise_application_error( -20000, 'Meer dan 1 werknemer met de naam ' || v_naam );
end ;
/


