REM   ===============================================
REM   SQL*Plus script constraints.sql
REM   geeft een overzicht van de constraints + status
REM   Leerboek Oracle SQL, Lex de Haan
REM   derde editie, Academic Service 2004
REM   ===============================================

col   constraint_name format a15
col   table_name      format a15
col   type            format a6
break on table_name   page

select   table_name
,        constraint_name
,        case constraint_type
              when 'P' then 'PRIKEY'
              when 'U' then 'UNIQUE'
              when 'C' then ' CHECK'
              when 'R' then 'FORKEY'
                       else ' OTHER'
         end  as type
,        status
from     user_constraints
order by table_name
,        type;

clear breaks
