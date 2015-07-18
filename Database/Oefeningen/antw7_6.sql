/* Hoofdstuk 7 oefening 6     *************************************/

select table_name
from user_tables tab
where not exists 
  ( select 1
    from user_dependencies dep
    where tab.table_name = dep.referenced_name)
/

