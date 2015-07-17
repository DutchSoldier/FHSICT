var mainlistGroupField;
var configs = new Array();
var mainListTpl; //loaded in localizations.js because it needs translations loaded 

//var groupFields = {
//        WEEK : {value: 0, name: "Week number", code: "week"}, 
//        DEBTOR: {value: 1, name: "Debtor", code: "debtor"}
//      };

function LoadConfigs(){
    
    //console.log("Loading configurations ...");
   
    var arr = ["select * from configurations"];
   
    dbPlugin.loadData(
          arr, 
          
          function(res) {
             
              //console.log("-------> configurari");
              for (i = 0; i <= res.recordCount-1; i++)
              {
                  configs[res.rows[i].conf_key] = res.rows[i].conf_value
                  //console.log("conf_key = " + res.rows[i].conf_key);
                  //console.log("conf_value = " + res.rows[i].conf_value);                  
              }
              
              //console.log("<-------  end configurari");
              
              LoadTranslations();
          },
          
          function(e) {
               console.log("Error while running statement!");
               alert("Error while running statement!"+e);
          }
  );  
}

function SaveConfig(key, value){
    configs[key]=value;
    var arr = ["update configurations set conf_value = ? where conf_key = ?", value, key];
    
    dbPlugin.executeSql(
            arr, 
            
            function(res) {
            },
            
            function(e) {
            }
    );
}

function GetSortField(index) {
    
    if (index == 0) return "wo_weekNo";
    else return "wo_debtorName";
}

