/* Hoofdstuk 3 oefening 3 ******************************************/
declare

   v_mnr         medewerkers.mnr%type ;
   v_err         varchar2( 250 );
   e_geen_delete exception;
   e_fk_found    exception;
   pragma exception_init( e_fk_found , -2292 );

begin
   v_mnr := &medewerkersnummer;

   delete from inschrijvingen
   where cursist = v_mnr;

   update uitvoeringen
   set docent = null 
   where docent = v_mnr;

   delete from medewerkers
   where mnr = v_mnr;

   if sql%notfound then
      raise e_geen_delete ;
   end if;

   dbms_output.put_line( 'Medewerker verwijderd');
exception
   when e_fk_found then
      v_err := dbms_utility.format_error_stack();
      if v_err like '%.A_HOOFD_FK%' 
      then
         raise_application_error( -20000 , 'Medewerker niet verwijderd: is afdelingshoofd');
      elsif v_err like '%.M_CHEF_FK%' 
      then
         raise_application_error( -20000 , 'Medewerker niet verwijderd: heeft nog ondergeschikten');
      end if;
   when e_geen_delete then
      raise_application_error( -20000, 'Geen medewerker verwijderd');
end;
/


