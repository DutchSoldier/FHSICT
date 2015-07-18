/* Hoofdstuk 2 oefening 4  ******************************************/

declare
   v_vandaag    date default sysdate;
   v_gebdatum   date default to_date( '15-02-1961', 'dd-mm-yyyy');
   v_leeftijd   number;
   v_aant_wkend pls_integer default 0;
begin

   v_leeftijd := floor( months_between( v_vandaag , v_gebdatum)/12);

   for v_teller in 1 .. v_leeftijd loop
      v_gebdatum := add_months( v_gebdatum , 12 );
      if to_char( v_gebdatum , 'd' ) in ( '6' , '7' )
      then
        v_aant_wkend := v_aant_wkend + 1;
      end if;
   end loop;

   dbms_output.put_line( 'Het aantal is weekenden is ' || to_char( v_aant_wkend ));

end;
/

