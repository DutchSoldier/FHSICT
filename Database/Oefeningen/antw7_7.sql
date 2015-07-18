/* Hoofdstuk 7 oefening 7     
 *
 * Voor de eerste controle moet u eerst het script UTLDTREE.sql uitvoeren.
 * Daarna voert u de procedure deptree_fill als volgt uit:
 **********************************************************/

execute deptree_fill( 'TABLE' , user , 'MEDEWERKERS' )

-- Daarna vindt u de afhankelijkheden terug in de view deptree of ideptree:

select * from deptree;
select * from ideptree;

-- Voor de tweede controle roept u opnieuw de procedure deptree_fill aan en
-- wel als volgt:

execute deptree_fill( 'TABLE' , user , 'INSCHRIJVINGEN' )

-- Daarna raadpleegt u deptree of ideptree.

select * from deptree;
select * from ideptree;

