var dbPlugin;


//function used to initialize all the plugins used by phonegap
//called from index.html, onDeviceReady event
function InitializePlugins() {
    
    dbPlugin = new DataAccessPlugin(
                        ["dks.sqlite3", true],
                        
                        function(res) {
                           // console.log("InitializePlugins - DataAccessPlugin successfully loaded!");
                            LoadConfigs();
                            //LoadTranslations();
                        },
                       
                        function(e) {
                            alert(e);
                        }
    );
}


//generic method for loading data into a store
//not to be called directly!
function LoadData(statement, store, delegate) {
	//console.log(statement);
    dbPlugin.loadData(
               statement, 
               function(res) {
                    //var jsnStr = JSON.stringify(res.rows);
                    //console.log("**** query result as json obj: " + jsnStr);                                 
                    
                                   
                    var workorderStore = Ext.getStore(store);
                    if (workorderStore!=null) {
                      workorderStore.setData(res.rows); 
                      //console.log('loadData :'+workorderStore.getCount()+' geladen');
                      if ((delegate!==undefined)&&(delegate!==null)){
                      	//console.log(delegate);  
                      	if (delegate instanceof Array){
                            var fd = delegate.pop();
                            if (fd!==undefined){
                      	      fd(delegate);
                            }
                      	} else
                      	{
                      		if (typeof(delegate) == "function"){
                      			delegate();
                      		}
                      	}	
                        }
                    } else
                    {
                      console.log('loadData: store not definied or problems with definition');
                    } 
               },
               
               function(e) {
                    console.log("Error while running statement!");
                    alert("Error while running statement!"+e);
               }
    );    
}     

//generic method for loading data into a store
//not to be called directly!
function LoadDataEvent(statement, store, event, object) {
	//console.log(statement);
    dbPlugin.loadData(
               statement, 
               function(res) {
                    //var jsnStr = JSON.stringify(res.rows);
                    //console.log("**** query result as json obj: " + jsnStr);                                                                                     
                    var workorderStore = Ext.getStore(store);
                    if (workorderStore) {
                      workorderStore.setData(res.rows); 
                //      console.log('loadData :'+workorderStore.getCount()+' geladen');
                    } else
                    {
                      console.log('loadData: store not definied or problems with definition');
                    } 
                    object.fireEvent(event, object, store);
               },
               
               function(e) {
                    console.log("Error while running statement!");
                    alert("Error while running statement!"+e);
               }
    );    
}   

//generic method for loading data into a store
//not to be called directly!
function StoreDataEvent(statement, store, event, object) {
    
    dbPlugin.executeSql(
               statement, 
               function(res) {
                    //var jsnStr = JSON.stringify(res.rows);
                    //console.log("**** query result as json obj: " + jsnStr);                                 
                  object.fireEvent(event, object, store);
               },
               
               function(e) {
                    console.log("Error while running statement!");
                    alert("Error while running statement!"+e);
               }
    );
}    

function StoreBatchDataEvent(statement, storename, event, object) {
    
    dbPlugin.execBatch(
               statement, 
               function(res) {
                 //   var jsnStr = JSON.stringify(res.rows);
                 // console.log("**** batch query ");
                 // console.log(object);
                 // console.log(storename);
            	   if (object!==null){
                      object.fireEvent(event, object, storename);
            	   }
               },
               
               function(e) {
                    console.log("Error while running statement!");
                    alert("Error while running statement!"+e);
               }
    );
}     

function InsertRecord(statement, store, tablename, columnname ,mdl,delegate,sender) {
	  dbPlugin.executeSql(
	             statement, 
	             function(res) {
	                 var sqlString = "select max("+columnname+") maxid from "+tablename;
	            	 arr=[sqlString];
	            	 dbPlugin.loadData(
	        	             arr, 
	        	             function(res) {
	        	            	 var aStore = Ext.getStore("MaxId");
	        	                    if (aStore) {
	        	                      aStore.setData(res.rows);
	        	                      var insertStore = Ext.getStore(store);
	        	                      var mdlmaxid = aStore.getAt(0);
	        	                      mdl.set(columnname,mdlmaxid.get('maxid'));
	        	                      insertStore.add(mdl);
	        	                      /* console.log(delegate); */
	        	                      if ((delegate!==null)||(delegate!==undefined)){
	        	                        delegate(sender,mdl);
	        	                      }
	        	                    }
	        	             },
	        	             function(e) {
	        	                  console.log("Error while retrieving maxid!");
	        	                  alert("Error while retrieving max on table "+tablename+" "+e);
	        	             }
	        	  ); 
	             },
	             
	             function(e) {
	                  console.log("Error while inserting record!");
	                  alert("Error while inserting record!"+e);
	             }
	  );
	}    


function Download(delegatefunction){
	var arr = [
               {"contactpers":{"acknowledge":false,"lastsyncevent":false}},
               {"address":{"acknowledge":false,"lastsyncevent":false}},
               {"contactpers_comunication":{"acknowledge":false,"lastsyncevent":false}},
               {"tbl_ruimtesoort":{"acknowledge":false,"lastsyncevent":true,"syncpname":"rs_update","synccol":{"col1":"rs_id"}}},
               {"tbl_dks_definition":{"acknowledge":false,"lastsyncevent":true,"syncpname":"thd_update","synccol":{"col1":"thd_id"}}},
               {"dks":{"acknowledge":true,"ackcolumn":"WO_NUMBER","lastsyncevent":false}}];        
       dbPlugin.SynchronizeDB(
           arr, 
           function(res) {          
        	   var delarr = [];
               delarr.push(delegatefunction);
               LoadRuimteSoorten(delarr);                             
           },     
           function(e) {
                //console.log("Error loading workorders "+e);
                alert("Error during download "+e);
           }
      );
}

function Upload(delegatefunction){ 
	
	var syncdata = [ 
	{"dks_ready": 
	  { "query":"select wo_number as wsq_workorder_id,wo_signature as wsq_signature,wo_remarks as wsq_remark,wo_status as wsq_state," +
	  		"wo_finishDate as wsq_datetime_ready,wo_contactperson as wsq_contactperson,wo_signklant as wsq_signklant from dks where wo_status=2",
		"table":"tbl_workorder_sendque",
		"primarykey":"wsq_workorder_id",
		"mapping":"[{wsq_workorder_id:INTEGER},{wsq_signature:TEXT},{wsq_remark:TEXT},{wsq_state:INTEGER},{wsq_datetime_ready:DATE},{wsq_contactperson:TEXT},{wsq_signklant:TEXT}]",
		"acknowledge":"wsq_workorder_id",
		"autoid":"gn_workorder_sendque",
		"delstatements":"[{dks:WO_NUMBER},{address:aw_workorder_id},{contactpers:ctp_workorder_id},{contactPers_comunication:cpc_workorder_id},{tbl_ruimtes:rm_document_id},{tbl_dks_elementen:the_document_id}]",
	  }
	}
	,
    {"ruimtes":
      { "query":"select tbl_ruimtes.* from tbl_ruimtes inner join dks on (rm_document_id=wo_number) where wo_status=2 and rm_gecontroleerd=2",
		"table":"tbl_ruimtes",
		"primarykey":"rm_id",
		"acknowledge":"rm_id",
		"delstatements":"[{tbl_ruimtes:rm_id}]",
		"autoid":"gn_ruimtes",
		"recstate":"C",
		"ismaster":"true"
	  }	
    },
    {"elementen":
      { "query":"select tbl_dks_elementen.* from tbl_dks_elementen inner join dks on (the_document_id=wo_number) " +
    	   "left join tbl_ruimtes on (rm_id=the_ruimte) where wo_status=2 and ((the_ruimte=0) or ((the_ruimte>0) and (rm_gecontroleerd=2)))",
		"table":"tbl_dks_elementen",
		"primarykey":"the_id",
		"master":"tbl_ruimtes",
		"foreignkey":"the_ruimte=rm_id",
		"delfkey":"true",
		"acknowledge":"the_id",
		"delstatements":"[{tbl_dks_elementen:the_id}]",
		"autoid":"gn_dks_elementen",
		"recstate":"C"
	  }	
    }
	//,
    //{"mks_inuitvoering":
    //  { "query":"select wo_number as wsq_workorder_id,wo_signature as wsq_signature,wo_remarks as wsq_remark,wo_status as wsq_state," +
    //  		"wo_finishDate as wsq_datetime_ready,wo_contactperson as wsq_contactperson from maandkwaliteit where wo_status=1",
	//	"table":"tbl_workorder_sendque",
	//	"primarykey":"wsq_workorder_id",
	//	"autoid":"gn_workorder_sendque",
	//	"mapping":"[{wsq_workorder_id:INTEGER},{wsq_signature:TEXT},{wsq_remark:TEXT},{wsq_state:INTEGER},{wsq_datetime_ready:DATE},{wsq_contactperson:TEXT}]"	  }	
    //}
	];        
	
	dbPlugin.Upload(
            syncdata, 
            
            function(res) { 

              if (delegatefunction!=null){	

                 delegatefunction();         
              }
            },     
             function(e) {
             //console.log(e);
             alert("Error during upload "+e);
            }
         );  
	
}

function LoadWorkorders() {
    sqlString = "select dks.*,descriptions.ds_description,aw_street,aw_houseNumber,aw_city from dks "+
                "left join address on wo_number=aw_workorder_id "+
                "left join descriptions on (wo_status=ds_value) and (ds_group='WOSTAT') order by wo_weekNo desc,wo_number";
    var arr = [sqlString];
  //  console.log("load workorders "+[sqlString][0]);
    LoadData(arr, "Workorders");      
}

function AddWorkorder(object,mdl,delegate) {  
    var arr = ["insert into dks (wo_status) values (1) "];        
    InsertRecord(arr,"Workorders","dks","wo_number",mdl,delegate,object);
}

function DeleteWorkorder(number){
	sqlString = "Delete from dks where wo_number="+number.toString();
}

function StoreWorkorders(docid,storename,object,eventname) {
	  //console.log('Store workorder : '+docid);
	  store = Ext.getStore(storename);
	  mdl = store.findRecord("wo_number",docid);
	  mdl.getData();
	  nbr = mdl.get('id');
	  if (nbr==-1){
	     s='';
	         }else
	         {
	  var sqlString = "update dks set wo_debtorName = ?,WO_SMALLDESC = ?,wo_status = ?,wo_remarks=?,wo_signature = ?,wo_signklant = ?,wo_finishDate = ?,wo_contactperson = ? where wo_number= ?";
	  var arr = [sqlString,mdl.get('wo_debtorName'),mdl.get('WO_SMALLDESC'),mdl.get('wo_status'),mdl.get('wo_remarks'),mdl.get('wo_signature'),mdl.get('wo_signklant'),mdl.get("wo_finishDate"),mdl.get('wo_contactperson'),mdl.get('wo_number')];
	  
	  //console.log('stored workorder '+arr);
		 
	  StoreDataEvent(arr,"Workorders",eventname,object);
	         }
}

function LoadStartupStores(delegate){
	LoadData(['select * from Relaties order by Naam'],'Relaties',delegate);
}

function LoadContactPers(workorderId,object) {
   //console.log(workorderId);
    var sqlString = "select " +
                    "  contactpers.* " +
                    "from contactpers " +
                     "where ctp_workorder_id = ?";
    
    var arr = [sqlString, workorderId];

    LoadDataEvent(arr,"ContactPers","dataLoaded2",object);   
   //  console.log("End ContactPers : "+workorderId); 
}

function LoadAddress(workorderId,object) {
   //console.log("data,js : Address : "+workorderId);
    var sqlString = "select " +
                    "  address.* " +
                    "from address " +
                     "where aw_workorder_id = ?";
    
    var arr = [sqlString, workorderId];

    LoadDataEvent(arr,"Address","dataLoaded",object);
//    console.log("End Address : "+workorderId);      
}

function LoadCommunication(workorderId,object) {
   //console.log(workorderId);
    //console.log("Start Communication : "+workorderId); 
    var sqlString = "select " +
                    "  contactpers_Comunication.* " +
                    "from contactpers_Comunication " +
                     "where cpc_workorder_id = ?";
    
    var arr = [sqlString, workorderId]; 
    
    LoadDataEvent(arr, "Communication","dataLoaded1",object); 
   //console.log("End Communication : "+workorderId); 
}

function LoadDebiteur(eventname,object){
	aStore = Ext.getStore("Relaties");
	if (aStore.getCount()==0){
	  var sqlString = "select * from Relaties where kind=1 order by Naam";
      var arr = [sqlString];
      LoadDataEvent(arr,"Relaties",eventname,object); 
	} else
	{
	  object.fireEvent(eventname, object, aStore);	
	}	
}

function LoadInQueryDef(delegate){
	var sqlString = "select * from tbl_inquery order by iq_id";
	var arr = [sqlString];
	LoadData(arr,'InQuery',delegate);
}

function CreateStores(){
	//console.log('Create stores');
	iq = Ext.getStore('InQuery');
	for (var i=0;i<iq.getCount();i++){
		var mdl = iq.getAt(i);
		var modelname = "DksApp.model."+mdl.get('iq_model');
		var storename = 'DksApp.store.'+mdl.get('iq_store_name');
		//console.log('create store '+storename);
		var store = Ext.define(storename,{extend:"Ext.data.Store",			
			config: {
		        model: modelname,
		        storeId: mdl.get('iq_store_name'),
		        sorters: [{ property: 'index', direction: 'ASC'}]
		    }
		
		});		
	}
	//console.log('exit Create stores');
}

function LoadStores(idx,max,delegate){
	//console.log('Load stores '+idx.toString());
	var iq = Ext.getStore('InQuery');
	var mdl = iq.getAt(idx);
    //console.log(mdl);
	if (mdl!==undefined){
      if ((mdl.get('iq_model_name')!==null)|| (mdl.get('iq_model_name')!=='')){		
	  modelstack.push(mdl);	
	  arr = ['select * from tbl_inquery_answers where ia_inquery_group='+mdl.get('iq_id').toString()];
	  //console.log(arr[0]);
	  dbPlugin.loadData(
              arr, 
              function(res) {
            	   var mdlpop = modelstack.pop();
            	   var storeName = mdlpop.get('iq_store_name');
            	   //console.log(storeName);
                   var aStore = Ext.getStore(storeName.toString());
                   if (aStore) {
                	   
                	 //console.log(res);  
                	 newrows = [];
                	 for(var j=0;j<res.rows.length;j++)
                	 {   //console.log(mdlpop);
                	     data = res.rows[j];
                	     //console.log(data);
                	     //,dtext:data.mdlpop.get('iq_valueField');
                	     text = mdlpop.get('iq_valueField');
                	     //console.log(text);
                	     if (text!==null){
                		   mdlnew = {index:data.ia_index,value:data.ia_value,dtext:data[text],visible:data.ia_visible};
                	     } else
                	     {
                	       mdlnew = {index:data.ia_index,value:data.ia_value,dtext:'',visible:data.ia_visible};	 
                	     }	 
                		 newrows[j] = mdlnew;
                	 }	 
                	 aStore.setData(newrows); 
                                          
                     //console.log('loadData :'+mdlpop.get('iq_store_name').toString()+' '+aStore.getCount()+' geladen '+idx.toString()+' '+max.toString());
                     //console.log(aStore);
                   } else
                   {
                     console.log('loadData: '+mdlpop.get('iq_store_name').toString()+' store not definied or problems with definition');
                   } 
                   idx++;
                   if (idx<max){                	   
                     LoadStores(idx,max);
	               } else
	               {
	            	   if (typeof(delegate) == "function"){
                 			delegate();
                 		}
	               }	   
                    
              },
              
              function(e) {
            	   var mdlpop = modelstack.pop();
                   //console.log("Error loading enumstore "+mdlpop.get('iq_store_name').toString());
                   alert("Error while running statement! "+mdlpop.get('iq_store_name').toString()+' '+e);
              }
	  		);   
      }
	} 
	//delegate();
}

function LoadInQuery(storename,groupId,workorderId,eventname,object) {
   //console.log('Load inquery : '+groupId+' workorder '+workorderId);
   var sqlString = "select tbl_dks_definition.*,tbl_inquery.*,tbl_dks_elementen.*,tbl_inquery_answers.ia_index from tbl_dks_definition "+
                   "inner join tbl_inquery on (thd_answer_type=iq_id) and (thd_group_id= "+groupId.toString()+")  "+
                   "left join tbl_dks_elementen on (the_inquerynbr=thd_id) and (thd_group_id="+groupId.toString()+")  "+
                   "and (the_document_id="+workorderId.toString()+")"+
                   "left join tbl_inquery_answers on (the_inqueryanswer=ia_value) and (ia_inquery_group=thd_answer_type) order by thd_id";
   //console.log('Load inquery : '+sqlString);
   var arr = [sqlString];
   LoadDataEvent(arr,storename,eventname,object);               
}

function LoadRuimteElementen(storename,groupId,ruimteId,eventname,object){
//console.log('Load inquery : '+groupId+' workorder '+workorderId);
var sqlString = "select tbl_dks_definition.*,tbl_inquery.*,tbl_dks_elementen.*,tbl_inquery_answers.ia_index from tbl_dks_definition "+
				"inner join tbl_ruimtesoort on (thd_group_id=rs_id) and (thd_group_id= "+groupId.toString()+")  "+
				"inner join tbl_inquery on (thd_answer_type=iq_id) " +
				"left join tbl_dks_elementen on (the_inquerynbr=thd_id) and (thd_group_id="+groupId.toString()+")  and (the_ruimte="+ruimteId.toString()+") "+
				"left join tbl_inquery_answers on (the_inqueryanswer=ia_value) and (ia_inquery_group=thd_answer_type)  "+
				"order by thd_id ";
	var arr = [sqlString];
	//console.log('Load ruimteelementen : '+sqlString);
    LoadDataEvent(arr,storename,eventname,object);               
}

function LoadInQueryExists(storename,groupId,workorderId,eventname,object) {
	   //console.log('Load inquery : '+groupId+' workorder '+workorderId);
	   var sqlString = "select tbl_dks_definition.*,tbl_inquery.*,tbl_dks_elementen.*,tbl_inquery_answers.ia_index from tbl_dks_definition "+
	                   "inner join tbl_inquery on (thd_answer_type=iq_id) and (thd_group_id="+groupId.toString()+")  "+
	                   "inner join tbl_dks_elementen on (the_inquerynbr=thd_id) and (thd_group_id="+groupId.toString()+")  and (the_editstate in (1,3))"+
	                   "and (the_document_id="+workorderId.toString()+")"+
	                   "left join tbl_inquery_answers on (the_inqueryanswer=ia_value) and (ia_inquery_group=thd_answer_type) order by the_id ";
	   //console.log('Load inquery : '+sqlString);
	   var arr = [sqlString];
	   LoadDataEvent(arr,storename,eventname,object);               
	}

function CreateElement(docid,stored,object,eventname,inquerynbr,answernbr){
	var sqlInsString = "insert into tbl_dks_elementen (the_document_id,the_inquerynbr,the_editstate,the_empty,the_remark,the_inqueryanswer) values (?,?,1,1,'',?)";
	arr=[sqlInsString,docid,inquerynbr,answernbr];
	  //console.log(batch);
	StoreDataEvent(arr,stored,eventname,object);
}

function GetMaxElementNbr(object,eventname,tablename,columnname){
	var sqlString = "select max("+columnname+") maxid from "+tablename;
	arr=[sqlString];
	//console.log(arr[0]);
	LoadDataEvent(arr,"MaxId",eventname,object); 
}

function StoreInQuery(docid,stored,object,eventname){
  //logMessage = log;	
  //console.log('Store inquery ruimte : ');
  var sqlInsString = "insert into tbl_dks_elementen (the_reasonanswer,the_reasonnbr,the_inqueryanswer,the_inquerynbr,the_document_id,the_editstate,the_remark,the_who,the_date,the_ruimte,the_empty) values (?,?,?,?,?,?,?,?,?,?,1)";
  var sqlUpdateString = "update tbl_dks_elementen set the_editstate=?,the_reasonanswer=?,the_inqueryanswer=?,the_remark=?,the_who=?,the_date=?,the_ruimte=? where the_id=?";
  var sqlDelString = "update tbl_dks_elementen set the_editstate=4 where the_id=? ";
  var sqldelLocal = "delete from tbl_dks_elementen where the_id=? ";
  var cnt = stored.getCount();
  var batch = [];
  var batchid = 0;
  //console.log('Count '+cnt);  
  for (var i=0;i<cnt;i++){
    var mdl = stored.getAt(i);
    if (mdl.dirty){
      //console.log('Store inquery ruimte : '+mdl.get('the_ruimte'));
      var arr = [];
      //console.log('item : '+i+mdl.get("thd_control")+' '+mdl.get("the_editstate")+' '+mdl.get("the_inqueryanswer"));
      switch (mdl.get("the_editstate")) {
        case 2: arr=[sqlInsString,mdl.get("the_reasonanswer"),mdl.get('the_reasonnbr'),mdl.get("the_inqueryanswer"),mdl.get("the_inquerynbr"),docid,1,mdl.get('the_remark'),mdl.get('the_who'),mdl.get('the_date'),mdl.get('the_ruimte')];break;
        case 3: arr=[sqlUpdateString,3,mdl.get("the_reasonanswer"),mdl.get("the_inqueryanswer"),mdl.get('the_remark'),mdl.get('the_who'),mdl.get('the_date'),mdl.get('the_ruimte'),mdl.get("the_id")];break;
        case 4: arr=[sqlDelString,mdl.get("the_id")];break;  
        case 5: arr=[sqldelLocal,mdl.get("the_id")];break;
        default: arr=null;break;
      }
      if (arr) {
         batch[batchid]=arr;
         batchid++;
       //console.log('batchid '+batchid+' query : '+arr);
       } else
       { 
         //console.log('nothing to store');     
       }
       arr=null;
    }
  }
  //console.log(batch);
  StoreBatchDataEvent(batch,stored.getStoreId(),eventname,object);
}

function LoadDocStateQuery(storename,workorderId,eventname,object){
	// console.log('Load inquery : '+groupId+' workorder '+workorderId);
	var sqlString = "select tbl_dks_definition.*,tbl_inquery.*,dks.wo_status as the_inqueryanswer,tbl_inquery_answers.ia_index from tbl_dks_definition "+
                    "inner join tbl_inquery on (thd_answer_type=iq_id) and (thd_group_id=5)  and (iq_id=5) "+
                    "inner join dks on (wo_number="+workorderId.toString()+")"+
	                "left join tbl_inquery_answers on (wo_status=ia_value) and (ia_inquery_group=thd_answer_type) order by thd_id";
	   //console.log('Load docstate : '+sqlString);
	   var arr = [sqlString];
	   LoadDataEvent(arr,storename,eventname,object);              
}

function StoreDocStateQuery(docid,stored,object){
	//console.log("Store doc state");

	
}

function LoadRuimteSoorten(delegate){
	//console.log('Load ruimte soort');
	LoadData(['Select * from tbl_ruimtesoort order by rs_id'],'Ruimtesoort',delegate);
}

function LoadRuimtes(docid,event,object){
	LoadDataEvent(['Select * from tbl_ruimtes where rm_document_id=?',docid],'Ruimtes',event,object);
}

function LoadRuimtesInventarisatie(docid,event,object){
	LoadDataEvent(['Select * from tbl_inventarisatie where rm_project=?',docid],'Ruimtes',event,object);
}

function CreateRuimte(docid,stored,object,eventname){
	var sqlInsString = "insert into tbl_ruimtes (rm_naam,rm_ruimtekind,rm_gecontroleerd,rm_document_id) values ('',108,1,?);";
	arr=[sqlInsString,docid];
	  //console.log(batch);
	StoreDataEvent(arr,stored,eventname,object);
}

function CreateRuimtes(docid,event,object){
	var s = "insert into tbl_ruimtes (rm_naam,rm_ruimtekind,rm_gecontroleerd,rm_document_id) values (?,?,1,?);";
	var st = Ext.getStore('Ruimtesoort');
	var statement;
	for(var i=0;i<st.getCount();i++){
	  var mdl = st.getAt(i);	 
	  statement = [s,mdl.get('rs_naam'),mdl.get('rs_id'),docid];
	  if (i==st.getCount()-1){
	    dbPlugin.executeSql(statement, 
	    		function(res) {
	    	        var controller = _myAppGlobal.getController("Algemeen");
	    	        LoadRuimtes(docid,"loadRuimtes",controller);
                    },
	    		function(e)	{console.log('Fout bij aanmaken ruimtes');}	
	    		);
	  } else
      {
	    dbPlugin.executeSql(statement,null,null);		  
      }		  
	}
}

function DeleteRuimte(ruimteid,docid){
	var s = "Delete from tbl_ruimtes where rm_id=?";
	var statement = [s,ruimteid];
	dbPlugin.executeSql(statement,null,null);
	var s = "Delete from tbl_dks_elementen where the_ruimte=? and the_document_id=?";
	var statement = [s,ruimteid,docid];
	dbPlugin.executeSql(statement,null,null);	
}

function StoreRuimte(stored,object,eventname){
	  //logMessage = log;	
	  //console.log('Store inquery : ');
	  var sqlInsString = "insert into tbl_ruimtes (rm_naam,rm_ruimtekind,rm_gecontroleerd,rm_document_id,rm_editstate) values (?,?,?,?,1)";
	  var sqlUpdateString = "update tbl_ruimtes set rm_naam=?,rm_ruimtekind=?,rm_gecontroleerd=?,rm_editstate=?,rm_aantelem=?,rm_methode=?,rm_vuil=?,rm_periodiek=? where rm_id=?";
	  var sqlDelString = "update tbl_ruimtes set rm_editstate=4 where rm_id=? ";
	  var sqldelLocal = "delete from tbl_ruimtes where rm_id=? ";
	  var cnt = stored.getCount();
	  var batch = [];
	  var batchid = 0;
	  //console.log('Count '+cnt);  
	  for (var i=0;i<cnt;i++){
	    var mdl = stored.getAt(i);
	    if (mdl.dirty){
	      var arr = [];
	      //console.log('item : '+i+mdl.get("thd_control")+' '+mdl.get("the_editstate")+' '+mdl.get("the_inqueryanswer"));
	      switch (mdl.get("rm_editstate")) {
	        case 2: arr=[sqlInsString,mdl.get("rm_naam"),mdl.get('rm_ruimtekind'),mdl.get("rm_gecontroleerd"),mdl.get("rm_document_id")];break;
	        case 3: arr=[sqlUpdateString,mdl.get("rm_naam"),mdl.get("rm_ruimtekind"),mdl.get('rm_gecontroleerd'),3,mdl.get('rm_aantelem'),mdl.get('rm_methode'),mdl.get('rm_vuil'),mdl.get('rm_periodiek'),mdl.get("rm_id")];break;
	        case 4: arr=[sqlDelString,mdl.get("rm_id")];break;  
	        case 5: arr=[sqldelLocal,mdl.get("rm_id")];break;
	        default: arr=null;break;
	      }
	      if (arr) {
	         batch[batchid]=arr;
	         batchid++;
	       //console.log('batchid '+batchid+' query : '+arr);
	      } 
	      arr=null;
	    }
	  }
	  //console.log(batch);
	  StoreBatchDataEvent(batch,stored.getStoreId(),eventname,object);
	}

function CreateRuimteElementen(docid,ruimteid,event,object){
	
}

function DeleteWorkorders() {
   //console.log('data.js : delete workorder');
   var statement = ["delete from maandkwaliteit"];        
   dbPlugin.executeSql(statement,null,null);
   statement = ["delete from contactpers where ctp_workorder_id>=0"];
   dbPlugin.executeSql(statement,null,null);
   statement = ["delete from contactpers_comunication where cpc_workorder_id>=0"];
   dbPlugin.executeSql(statement,null,null);
   statement = ["delete from address where aw_workorder_id>=0"];
   dbPlugin.executeSql(statement,null,null);      
   statement = ["delete from tbl_dks_elementen where the_document_id>=0"];
   dbPlugin.executeSql(statement,null,null);   
}

function ShowToast(message) {
    
    dbPlugin.displayToast(
            
            message, 
            
            function(res) {
            },
            
            function(e) {
            }
    );
}

function objToString (obj) {
    var str = '';
    for (var p in obj) {
        if (obj.hasOwnProperty(p)) {
            str += p + '::' + obj[p] + '\n';
        }
    }
    return str;
}

function GetStoreCount(storeName){
    
    var storeObj = Ext.getStore(storeName);    
    return storeObj.getCount();
}

