/* Hoofdstuk 5 oefening 5     *************************************/

declare
   procedure drop_tabel
      ( p_tabel in varchar2
      , p_cascade_mode in varchar2 default 'NO_CASCADE'
      ) 
   is
      v_error varchar2( 255 );
      v_cascade varchar2( 30 );
      e_onbekende_parameter exception;
   begin
      if upper( p_cascade_mode ) = 'CASCADE' 
      then
         v_cascade := ' cascade constraints';
      elsif upper( p_cascade_mode ) = 'NO_CASCADE' then
         null;
      else
         raise e_onbekende_parameter;
      end if;

      execute immediate  'drop table ' || p_tabel || v_cascade ;

  exception

     when e_onbekende_parameter then
        raise_application_error( -20000 ,
           'Onbekende waarde voor parameter P_CASCADE_MODE: ' || p_cascade_mode );
  end drop_tabel; 
begin
   drop_tabel(p_tabel => 'schalen');
   drop_tabel(p_tabel => 'medewerkers');
end;
/
