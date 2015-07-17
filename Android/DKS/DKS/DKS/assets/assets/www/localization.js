var localeStrings = new Array();

//Loads all translations in memory
function LoadTranslations() {
    
    //console.log("Load 'english' - '" + configs["language"] + "' translations  ... ");
    
    var languageFld = 'loc_' + configs["language"];
    var sqlStr = "select loc_english, " + languageFld + " from localization";
        
    dbPlugin.loadData(
        [sqlStr], 
          
        function(res) {
            //var jsnStr = JSON.stringify(res.rows);
            //console.log("**** query result as json obj: " + jsnStr);    
            var i;
            //console.log("-------> localizations");
            for (i = 0; i <= res.recordCount-1; i++)
            {
                //console.log("loc_engligh = " + res.rows[i]["loc_english"]);
                //console.log("loc_dutch = " + res.rows[i][languageFld]);
                localeStrings[res.rows[i]["loc_english"]] = res.rows[i][languageFld];
            }   
            //console.log("<-------  end localizations");
                  
            //if the grouping is set to weekNo, the list will not contain again this information
            configs["mainlistGroupField"]=0;
            if (configs["mainlistGroupField"] == 0){ 
            	 mainListTpl = "<table>"+
                 "<tr>"+
                   "<td width=\'350px\'><div class=\"list-item-title\">"+GetLocaleString("Projectnr")+": {wo_projectNumber}</div></td>" +
                   "<td width=\'150px\'><div class=\"list-item-title\">{wo_startDate:date(\"d-m-Y\")}</div></td>"+
                 "</tr>"+  
                 "<tr>"+
                   "<td width=\'350px\'><div class=\"list-item-narrative\">"+GetLocaleString("Project")+": {wo_projectName}</div></td>"+
                   "<td width=\'150px\'><div class=\"list-item-title\">{wo_finishDate:date(\"d-m-Y\")}</div></td>"+
                 "</tr>"+
                 "<tr>"+
                   "<td width=\'350px\'><div class=\"list-item-narrative\">{aw_street} {aw_houseNumber} {aw_city}</div></td>"+ 
                   "<td width=\'150px\'><div class=\"list-item-title\">{ds_description}</div></td>"+
                 "</tr>"+
             "</table>";
            }
            else {
            	mainListTpl = "<table>"+
                "<tr>"+
                  "<td width=\'350px\'><div class=\"list-item-title\">"+GetLocaleString("Projectnr")+": {wo_projectNumber}</div></td>" +
                  "<td width=\'150px\'><div class=\"list-item-title\">{wo_startDate:date(\"d-m-Y\")}</div></td>"+
                "</tr>"+  
                "<tr>"+
                  "<td width=\'350px\'><div class=\"list-item-narrative\">"+GetLocaleString("Project")+": {wo_projectName}</div></td>"+
                  "<td width=\'150px\'><div class=\"list-item-title\">{wo_finishDate:date(\"d-m-Y\")}</div></td>"+
                "</tr>"+
                "<tr>"+
                  "<td width=\'350px\'><div class=\"list-item-narrative\">{aw_street} {aw_houseNumber} {aw_city}</div></td>"+ 
                  "<td width=\'150px\'><div class=\"list-item-title\">{ds_description}</div></td>"+
                "</tr>"+
            "</table>";
            }
        },
        
        function(e) {
            console.log("Error while running statement!");
            alert("Error while running statement!"+e);                
        }
    )
}

//get the localized string
function GetLocaleString(engStr){
    var result = localeStrings[engStr];

    //if the localized string is not loaded, will just return the original string
    if(result == undefined || result == "") {
        result = engStr;
    }
    
    return result;
}

//load one specific string directly from db
function TranslateFromEng(str) {
    
    var languageFld;
    //console.log("TranslateFromEng ... " + configs["language"]);
    
    if (configs["language"] == 'english') return str;
    else
        if (configs["language"] == 'dutch') languageFld = 'loc_dutch';
    
    var sqlStr = "select " + languageFld + " from localization where loc_english = ?";
    var arr = [sqlStr, str];
    
    dbPlugin.loadData(
            arr, 
            
            function(res) {
                //var jsnStr = JSON.stringify(res.rows);
                //console.log("**** query result as json obj: " + jsnStr);    
                var i;
                //console.log("-------> localizations");
                for (i = 0; i <= res.recordCount-1; i++)
                {
                    //console.log("loc_dutch2 = " + res.rows[i][languageFld]);
                    localeStrings[str] = res.rows[i][languageFld];
                    
                }   
                //console.log("<-------  end localizations");                
            },
            
            function(e) {
                console.log("Error while running statement!");
                alert("Error while running statement!"+e);                
            }
    );
}