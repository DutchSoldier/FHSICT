REM ======================================
REM SQL*Plus script creschema.sql:
REM maakt het schema voor de casustabellen
REM Leerboek Oracle SQL, Lex de Haan
REM derde editie, Academic Service 2004
REM ======================================

set trimspool on
spool creschema.txt

-- connect / as sysdba

prompt Drop bestaande schema ...
drop user boek cascade;

prompt Maak nieuw schema ...
create user boek
-- default tablespace users
-- temporary tablespace temp
identified by boek;

prompt Geef de benodigde systeemprivileges ...
grant create session, alter session,
      unlimited tablespace,
      create table, create view,
      create materialized view,
      create procedure,
      create sequence,
      create synonym,
      create trigger,
      create type
to    boek;

grant execute on dbms_lock to boek;

prompt Ga naar het nieuwe schema ...
connect boek/boek
set feedback off

prompt Maak de casustabellen ...
@@crecase

prompt Vul de casustabellen ...
@@vulcase

prompt Einde procedure.

spool off
set feedback on
