/* Hoofdstuk 9 oefening 2     *************************************/

create or replace trigger biur_med
   before insert or update
   on medewerkers
   for each row
begin
   if :new.gbdatum is not null
   and months_between( sysdate , :new.gbdatum)/12 < 18
   then
      raise_application_error( -20000 , 'Medewerker jonger dan 18 jaar' );
   end if;
   :new.functie := upper( :new.functie );
   :new.naam := upper( :new.naam );
   if :new.functie = 'MANAGER'
   and :old.functie not in ( 'MANAGER' , 'DIRECTEUR' )
   then
      :new.maandsal := :old.maandsal * 1.1;
   end if;
end biur_med;
/


