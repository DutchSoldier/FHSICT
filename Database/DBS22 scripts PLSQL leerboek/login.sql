REM ===================================
REM SQL*Plus script login.sql
REM Leerboek Oracle SQL, Lex de Haan
REM derde editie, Academic Service 2004
REM ===================================

col mnr        format 9999
col naam       format A15
col chef       format 9999
col afd        format 999

col anr        format 99
col locatie    format A10
col hoofd      format 9999

col snr        format 99

col type       format A4

col cursus     format A6
col begindatum format A10

set numwidth   6
set pagesize   25
set linesize   100

-- alter session set nls_language=dutch;

set pause '[Return...] '

-- accept antwoord   prompt "pause (on/off)? "
-- set    pause      &antwoord
-- undef  antwoord
