create or replace
PROCEDURE dropAllTables
IS
  cursor ix is
    select *
      from user_TABLES;
begin
 for x in ix loop
   execute immediate('drop table ' || x.table_name || ' CASCADE CONSTRAINTS');
 end loop;
end;