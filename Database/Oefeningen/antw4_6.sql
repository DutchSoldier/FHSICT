/* Hoofdstuk 4 oefening 6     *************************************/

declare
   type type_coll_varchar
   is varray (4) of varchar2(15);
   t_telefoon type_coll_varchar := type_coll_varchar();
begin
   t_telefoon.extend(4);
   t_telefoon(1) := '06-1234567';
   t_telefoon(2) := '06-7654321';
   t_telefoon(3) := '0345-65411';
   t_telefoon(4) := '06-1134567';

   for i in 1 .. 4
   loop
      dbms_output.put_line(t_telefoon(i));
   end loop;

   -- De volgende regel mag niet:
   -- t_telefoon(5) := '06-1134567';
   -- Levert een fout op: ORA-06532: Subscript outside of limit

end;
/


-- Alternatief: 

declare
   type type_coll_varchar
   is varray (4) of varchar2(15);
   t_telefoon type_coll_varchar := type_coll_varchar('06-1234567'
                                    , '06-7654321', '0345-65411'
                                    , '06-1134567');
begin
   for i in 1 .. 4
   loop
      dbms_output.put_line(t_telefoon(i));
   end loop;

end;
/
