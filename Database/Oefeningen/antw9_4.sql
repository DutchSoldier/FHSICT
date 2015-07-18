/* Hoofdstuk 9 oefening 4 ***********
 *
 *  Voor deze opgave is het nodig om een package (een specificatie en een body)
 *  te maken en drie triggers die een aantal procedures uit het package aanroepen.
 *************************************/

create or replace package pck_chefconstr
as
   procedure init ;
   procedure save 
      (p_mnr  in medewerkers.mnr%type 
      ,p_chef in medewerkers.chef%type 
      ,p_afd  in medewerkers.afd%type 
      ) ;
   procedure check_constr ;
end pck_chefconstr ;
/


create or replace package body pck_chefconstr
as
   e_geen_directeur exception ;
   e_directeurs     exception ;

   type type_rec_med is record
      ( mnr    medewerkers.mnr%type
      , chef   medewerkers.chef%type 
      , afd    medewerkers.afd%type ) ;
 
   type type_tab_med
      is table of type_rec_med
      index by binary_integer;
   
   t_med type_tab_med;
   g_index pls_integer := 0 ;

   procedure init 
   is
   begin
      t_med.delete ;
      g_index := 0 ;
   end init ;

   procedure save 
      (p_mnr  in medewerkers.mnr%type 
      ,p_chef in medewerkers.chef%type 
      ,p_afd  in medewerkers.afd%type 
      ) 
   is
   begin
      g_index := g_index + 1 ;
      t_med(g_index).mnr  := p_mnr ;
      t_med(g_index).chef := p_chef ;
      t_med(g_index).afd := p_afd ;
   end save ;

   procedure check_constr
   is
      v_pres medewerkers.mnr%type ;
      v_afd  medewerkers.afd%type ;
   begin

      begin
         select med.mnr
         into   v_pres
         from   medewerkers med
         where  med.chef is null ;
      exception
         when no_data_found then
            raise e_geen_directeur ;
         when too_many_rows then
            raise e_directeurs ;
      end ;

      for i in 1 .. t_med.count 
      loop
         if t_med(i).chef <> v_pres 
         then 
            select med.afd
            into   v_afd
            from   medewerkers med
            where  med.mnr = t_med(i).chef ;

            if v_afd <> t_med(i).afd
            then
               raise_application_error ( -20000, 'Medewerker ' || to_char (t_med(i).mnr) 
                                    || ' (afdeling ' || to_char(t_med(i).afd)
                                    || ') moet op zelfde afdeling als zijn chef werken ('
                                    || to_char(t_med(i).chef) || ' afdeling '
                                    || to_char(v_afd) || ')' ) ;    
            end if ; 
         end if ;
      end loop ;
   exception
      when e_directeurs then
         raise_application_error ( -20000, 'Meer dan 1 directeur.') ;
     when e_geen_directeur then
         raise_application_error ( -20000, 'Geen directeur aanwezig.') ;

   end check_constr ;
end pck_chefconstr ;
/

create or replace trigger med_bsiu
   before insert or update of chef, afd 
   on medewerkers
begin
   pck_chefconstr.init ;
end med_bsiu;
/

create or replace trigger med_ariu
   after insert or update of chef, afd 
   on medewerkers
   for each row
begin
   pck_chefconstr.save (:new.mnr, :new.chef, :new.afd) ;
end med_ariu;
/

create or replace trigger med_asiu
   after insert or update of chef, afd 
   on medewerkers
begin
   pck_chefconstr.check_constr ;
end med_asiu ;
/

