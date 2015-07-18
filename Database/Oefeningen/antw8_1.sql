/* Hoofdstuk 8 oefening 1     *************************************/


create or replace package pck_pz 
as
   procedure bepaal_comm_perc
      ( p_ratio in number 
      );
   procedure ontsla_med
      ( p_mnr in medewerkers.mnr%type 
      );
   procedure ontsla_med 
      ( p_naam in medewerkers.naam%type 
      );
   procedure neem_med_aan
      ( p_naam     in medewerkers.naam%type
      , p_voorl    in medewerkers.voorl%type
      , p_gbdatum  in medewerkers.gbdatum%type
      , p_maandsal in medewerkers.maandsal%type
      , p_afd      in medewerkers.afd%type
      , p_functie  in medewerkers.functie%type  default null
      , p_chef     in medewerkers.chef%type     default null
      );

end pck_pz;
/

create or replace package body pck_pz 
as
   g_commissieratio number;

   procedure bepaal_comm_perc
      ( p_ratio in number 
      )
   is
      v_maxratio number;
   begin
      select max( comm/maandsal ) 
      into v_maxratio 
      from medewerkers;
      if p_ratio <= v_maxratio 
      then
         g_commissieratio := p_ratio;
      else
         raise_application_error( -20000 , 'Waarde van initiele commissieratio (' 
                                 || to_char( p_ratio ) || ') overschrijdt maximum (' 
                                 || to_char( v_maxratio ) || ')' ) ;
      end if;
    
   end bepaal_comm_perc;

   function afdeling_van
      (p_mnr in number
      )
      return number
   is
      v_anr number;
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

   procedure ontsla_med
      ( p_naam in medewerkers.naam%type )
   is
      v_mnr medewerkers.mnr%type;
   begin
      select mnr
      into v_mnr
      from medewerkers
      where naam = p_naam;
      ontsla_med( v_mnr);
   exception
      when no_data_found then
         raise_application_error( -20000, 'Medewerker bestaat niet: ' || p_naam);
      when too_many_rows then
         raise_application_error( -20000, 'Naam medewerker niet uniek: ' || p_naam
                                          ||'. Gebruik mnr' );
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
           when 'VERKOPER' then p_maandsal * g_commissieratio
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


begin
   select avg( comm/maandsal ) 
   into g_commissieratio
   from medewerkers;
exception
   when zero_divide then
      raise_application_error( -20000, 'Kan commissieratio niet uitrekenen: maandsal = 0');
end pck_pz;
/


