REM ==================================================
REM SQL*Plus script indexen.sql
REM geeft overzicht van de indexen op de casustabellen
REM Leerboek Oracle SQL, Lex de Haan
REM derde editie, Academic Service 2004
REM ==================================================

col tabelnaam format a15
col indexnaam format a15
col uniciteit format a9
col kolomnaam format a15

set linesize 80

break  on tabelnaam skip 1 -
       on indexnaam -
       on uniciteit -
       on status

select   i.table_name    as tabelnaam
,        i.index_name    as indexnaam
,        i.uniqueness    as uniciteit
,        i.status
,        ic.column_name  as kolomnaam
from     user_indexes i
,        user_ind_columns ic
where    i.table_name = ic.table_name
and      i.index_name = ic.index_name
and      i.table_name in ('MEDEWERKERS','AFDELINGEN','SCHALEN'
                         ,'CURSUSSEN','UITVOERINGEN'
                         ,'INSCHRIJVINGEN','HISTORIE')
order by tabelnaam
,        indexnaam
,        uniciteit
,        ic.column_position
/

clear breaks
