/* Hoofdstuk 3 oefening 2 ******************************************/

BEGIN
   update afdelingen
   set    naam = 'VERKOOP'
   where  naam = 'PERSONEELSZAKEN';
EXCEPTION
   when dup_val_on_index then
      raise_application_error( -20000, 'Afdelingsnaam komt al voor');
END;
/




DECLARE
   e_afdeling_bestaat_niet exception;
   pragma exception_init( e_afdeling_bestaat_niet , -2291);
BEGIN
   update medewerkers
   set    afd = 50
   where  naam = 'DE KONING';
EXCEPTION
   when e_afdeling_bestaat_niet then
      raise_application_error( -20000, 'Afdelingsnummer bestaat niet');
END;
/