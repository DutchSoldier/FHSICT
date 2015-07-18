/* Aanvulscript voor oefening 3 bij Hoofdstuk 
 *
 * Vul zelf de definities van de procedures en functie aan
 *
 ********************************************************/


create sequence seq_medewerkers_mnr start with 8000
/

declare
   v_afd afdelingen.anr%type;

   function afdeling_van
   /* Vul aan */
   end afdeling_van;

   procedure ontsla_med
   /* Vul aan */
   end ontsla_med;

   procedure neem_med_aan
   /* Vul aan */
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

