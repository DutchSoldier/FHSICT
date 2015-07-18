/* Hoofdstuk 5 oefening 3 ******************************************/


create sequence seq_medewerkers_mnr start with 8000
/

declare
   v_afd afdelingen.anr%type;

   function afdeling_van
      (p_mnr in medewerkers.mnr%type)
   return number
   is
      v_anr afdelingen.anr%type;
   begin
      select afd
      into v_anr
      from medewerkers
      where p_mnr = mnr;
      return v_anr;
   exception
      when no_data_found then
         return null;
   end afdeling_van;

   procedure ontsla_med
      ( p_mnr in medewerkers.mnr%type )
   is
      v_err varchar2( 200 );
      e_geen_delete exception;
      e_fk_found exception;
      pragma exception_init( e_fk_found , -2292 );
   begin
      delete from inschrijvingen
      where cursist = p_mnr;
      update uitvoeringen
      set docent = null
      where docent = p_mnr;
      delete from medewerkers
      where mnr = p_mnr;
      if sql%notfound 
      then
         raise e_geen_delete ;
      end if;
   exception
      when e_fk_found then
         v_err := dbms_utility.format_error_stack();
         if v_err like '%.A_HOOFD_FK%' 
         then
            raise_application_error( -20000 
                                    , 'Medewerker niet verwijderd: is afdelingshoofd');
         elsif v_err like '%.M_CHEF_FK%' 
         then
            raise_application_error( -20000 
                                   , 'Medewerker niet verwijderd: heeft nog ondergeschikten');
         end if;
      when e_geen_delete then
         raise_application_error( -20000, 'Geen medewerker verwijderd');
   end ontsla_med;

   procedure neem_med_aan
      ( p_naam     in medewerkers.naam%type
      , p_voorl    in medewerkers.voorl%type
      , p_gbdatum  in medewerkers.gbdatum%type
      , p_maandsal in medewerkers.maandsal%type
      , p_afd      in medewerkers.afd%type
      , p_functie  in medewerkers.functie%type default null
      , p_chef     in medewerkers.chef%type default null
      )
   is
      v_afd_chef number;
      v_functie medewerkers.functie%type := upper( p_functie );
      e_geen_18 exception;
      e_geen_chef exception;
      e_geen_chef_afd exception;

   begin
      if months_between( sysdate , p_gbdatum )/12 < 18 
      then
         raise e_geen_18;
      end if;
      if p_chef is not null 
      then
         begin
            v_afd_chef := afdeling_van( p_chef );
         exception
            when no_data_found then
               raise e_geen_chef;
         end;
         if v_afd_chef <> p_afd
         then
            raise e_geen_chef_afd;
         end if;
      end if;
      insert into medewerkers
      ( mnr
      , naam
      , voorl
      , functie
      , chef
      , gbdatum
      , maandsal 
      , comm 
      , afd
      )
      values
      ( seq_medewerkers_mnr.nextval
      , upper ( p_naam )
      , upper ( p_voorl )
      , v_functie
      , p_chef
      , p_gbdatum
      , p_maandsal
      , case v_functie
           when 'VERKOPER' then p_maandsal * .1
           else  null 
        end
      , p_afd
      ) ;
   exception
      when e_geen_chef then
         raise_application_error( -20000 , 'Ongeldig chefnummer: '
                                           || to_char( p_chef ));
      when e_geen_chef_afd then
         raise_application_error( -20000 , 'Chef niet op zelfde ' 
                                          || 'afdeling als medewerker' );
      when e_geen_18 then
         raise_application_error( -20000 
                                , 'Medewerker nog geen 18 jaar' );
   end neem_med_aan ;

BEGIN
   ontsla_med( p_mnr => 7900 );
   v_afd := afdeling_van( p_mnr =>  7369 );
   dbms_output.put_line( v_afd );

   neem_med_aan
      ( p_naam     => 'vermeulen' 
      , p_voorl    => 't'
      , p_gbdatum  => to_date('15-02-1961', 'dd-mm-yyyy')
      , p_maandsal => 2000
      , p_afd      => 10
     );

  neem_med_aan
      ( p_naam     => 'derks' 
      , p_voorl    => 'm'
      , p_gbdatum  => to_date('05-08-1961', 'dd-mm-yyyy')
      , p_maandsal => 2500
      , p_afd      => 30
      , p_functie  => 'verkoper'
      , p_chef     => 7698 
     );

  neem_med_aan
      ( p_naam     => 'martens' 
      , p_voorl    => 'i'
      , p_gbdatum  => to_date('11-07-1976', 'dd-mm-yyyy')
      , p_maandsal => 2100
      , p_afd      => 20
      , p_functie  => 'TRAINER'
     );

  neem_med_aan
      ( p_naam     => 'punter' 
      , p_voorl    => 'w'
      , p_gbdatum  => to_date('11-09-1980', 'dd-mm-yyyy')
      , p_maandsal => 2600
      , p_afd      => 30
      , p_functie  => 'verkoper'
      , p_chef     => 7782 
     );

END;
/

