/* Hoofdstuk 2 oefening 2 ******************************************/

declare
   v_naam     varchar2(20) default 'Theo Vermeulen';
   v_vandaag  date default sysdate;
   v_gebdatum date default to_date( '15-02-1961', 'dd-mm-yyyy' );
   v_dagen    number;
   v_maanden  number;
   v_jaren    number; 
begin
   v_dagen   := v_vandaag - v_gebdatum;
   v_maanden := months_between( v_vandaag , v_gebdatum);
   v_jaren   := trunc( v_maanden/12 );
   dbms_output.put_line( v_naam 
      || ', geboren op ' || to_char( v_gebdatum ) 
      || ' heeft op '    || to_char( v_vandaag ) 
      || ' de leeftijd van '
      ||  to_char( v_dagen )   || ' dagen, '      
      ||  to_char( v_maanden ) || ' maanden en ' 
      ||  to_char( v_jaren )   || ' jaren' ); 
end;

/

