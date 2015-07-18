REM =========================================
REM SQL*Plus script describe.sql
REM geeft een overzicht van de casus tabellen
REM Leerboek Oracle SQL, Lex de Haan
REM derde editie, Academic Service 2004
REM =========================================

store set sqlplus_settings replace

set numwidth   6
set pagesize   99
set linesize   80
set sqlprompt  " "

prompt
prompt Overzicht casustabellen Leerboek Oracle SQL
prompt ===========================================

set echo on

describe MEDEWERKERS
describe AFDELINGEN
describe SCHALEN
describe CURSUSSEN
describe UITVOERINGEN
describe INSCHRIJVINGEN
describe HISTORIE

set echo off

@sqlplus_settings
