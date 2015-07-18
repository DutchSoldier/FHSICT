REM ========================================
REM SQL*Plus script inhoud.sql
REM genereert overzicht inhoud casustabellen
REM Leerboek Oracle SQL, Lex de Haan
REM derde editie, Academic Service 2004
REM ========================================

store set sqlplus_settings replace

set pagesize  999
set linesize  80
set feedback  off
set numwidth  6
set trimspool on

col begindatum format A10
col type       format A4
col cursus     format A6
col afd        format 999
col anr        format 999
col mnr        format 9999
col chef       format 9999
col type       format A4
col begindatum format A10
col cursus     format A6

spool casusinhoud.txt

prompt
prompt   MEDEWERKERS:
select   *
from     medewerkers
order by mnr
/
prompt
prompt   AFDELINGEN:
select   *
from     afdelingen
order by anr
/
prompt
prompt   SCHALEN:
select   *
from     schalen
order by snr
/
prompt
prompt   CURSUSSEN:
select   *
from     cursussen
order by type
/
prompt
prompt   UITVOERINGEN:
select   *
from     uitvoeringen
order by begindatum
/
prompt
prompt   INSCHRIJVINGEN:
select   *
from     inschrijvingen
order by cursist
,        begindatum
/
prompt
prompt   HISTORIE:
select   *
from     historie
order by mnr
,        begindatum
/
spool off

@sqlplus_settings
