/* Hoofdstuk 4 oefening 9     *************************************/

declare

   type type_coll_number
   is table of number;

   tab_chef            type_coll_number;
   tab_hoofd           type_coll_number;
   tab_docent          type_coll_number;
   tab_chef_niet_hoofd type_coll_number;  
   tab_chef_docent     type_coll_number; 
 
begin
   select chef
   bulk collect into tab_chef
   from medewerkers;
   
   select hoofd
   bulk collect into tab_hoofd
   from afdelingen;
 
   select docent
   bulk collect into tab_docent
   from uitvoeringen;
   
   tab_chef_niet_hoofd := tab_chef multiset except tab_hoofd;
   tab_chef_niet_hoofd := set ( tab_chef_niet_hoofd );
   tab_chef_docent := tab_chef multiset intersect tab_docent;
 
  
   
   dbms_output.put_line('Niet-hoofden:');     
   if not tab_chef_niet_hoofd is empty
   then 
      for i in 1 .. tab_chef_niet_hoofd.count
      loop
          dbms_output.put_line(tab_chef_niet_hoofd(i));
      end loop;
   end if;


   dbms_output.put_line('Chefs die docent zijn:');     
   if not tab_chef_docent is empty
   then 
      loop
         dbms_output.put_line(tab_chef_docent(i));
      end loop;
   end if;

end;
/


