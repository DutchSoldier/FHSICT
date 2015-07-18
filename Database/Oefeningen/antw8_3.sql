/* Hoofdstuk 8 oefening 3     *************************************/

declare
   t_namen  dbms_utility.lname_array;
   v_namen  varchar2(2000);  
   v_aantal binary_integer; 
begin

   select naam
   bulk collect into t_namen
   from afdelingen;

   dbms_utility.table_to_comma
      ( tab    => t_namen
      , tablen => v_aantal
      , list   => v_namen); 

   dbms_output.put_line(v_namen);
end;
/
