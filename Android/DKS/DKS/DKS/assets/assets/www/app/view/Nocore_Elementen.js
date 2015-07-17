Ext.define("DksApp.view.Nocore_Elementen",{   
	extend:"Ext.Panel",
	alias: "widget.nocore_elementen",
	requires:['DksApp.store.MaxId','DksApp.view.Nocore_SegButton'],
	setupDone: false,
	number:-1,
	groupid:-1,
	ruimteid:-1,
	config:{
	   layout:'vbox',
	  
	   store:null,
	   delstore:null,
	   index:-1,
	   listeners : {storeDeletedItems  : function(store) {this.storeDeletedItems(store); },
		   	        afterCreateElement : function(store) {this.afterCreateElement();},
		   			maxElementNbr : function(store) {this.maxElementNbr(store);}
		   		   }   
    },
	constructor: function(config)
	{ 
	  this.callParent([config]);
	  //console.log(' config : ',this.config);
	  this.maxidstore = Ext.getStore("MaxId");
	},
	
	applyStore: function(newStore,oldStore){  
    	//console.log('apply store');
   	  if (newStore != null){
   		this.store = newStore;  
   		this.setupControl(newStore);
   	  }
    },
    
    updateStore: function(newStore,oldStore){
    	//console.log('update store');
      if (newStore!=oldStore){
    	  if (oldStore!==null){
    		  removeitems();
    	  }
    	  if (newStore!==null){
    		  this.store = newStore;
    		  this.setupControl(newStore);
    	  }
      }	
    },
       
    createQuestion:function(aname,atext){
    	return Ext.create('Ext.field.Text',{labelWrap:true,value:'',labelWidth:'100%',label:atext,readOnly:true, width:'50%',cls: 'color: white; background-color: grey;'});
    },    
	createRemark:function(aname,avalue,aheight){
		var txt = Ext.create('Ext.field.TextArea',
				{ width : '100%',name:aname,id:aname,value:avalue,labelWidth:'0%',maxRows:1});
		return Ext.create('Ext.Panel',{style:'padding:0px',bodyStyle:'padding:0px',items:[txt],width:'32%'});		
	},
	createAnswers:function(aname,i,mdl){
		var buttons = Ext.create('DksApp.view.Nocore_SegButton',{style: 'padding:0px',bodyStyle: 'padding:0px',width : '50%',name:mdl.get('thd_control')+i.toString(),id:mdl.get('thd_control')+i.toString()});
		buttons.setupControl(mdl.get('iq_store_name'),mdl.get('iq_displayField'),mdl.get('thd_control')+i.toString(),null);
		buttons.setState(mdl.get('ia_index'),mdl.get('the_inqueryanswer'),mdl.get('the_empty'),mdl.get('the_editstate'));
		return buttons;
	},
	createReason:function(aname,i,mdl){
		var buttons = Ext.create('DksApp.view.Nocore_SegButton',{width : '68%',name:aname,id:aname,allowMultiple:true,pressedCls: 'PressedBlueCls',});
		var iqs = Ext.getStore("InQuery");
		//console.log(' inquery recordcount '+iqs.getCount());
		var reasonidx = iqs.find('iq_id',mdl.get('thd_reason_type'));
		var mdlreason = iqs.getAt(reasonidx);
		//console.log('mdlreason');
		//console.log(mdlreason);
		buttons.setupControl(mdlreason.get('iq_store_name'),mdlreason.get('iq_displayField'),'reason'+i.toString(),null);
		buttons.setStateMultiple(mdl.get('the_reasonanswer'),mdl.get('the_empty'),mdl.get('the_editstate'));
		return buttons;
	},
	
	setCuritem:function(item){
		//console.log('set curitem '+item.getParent().index);
		this.activeIndex = item.getParent().index;
	},
	
	createItem:function(i,mdl){
	  var me = this;
	  
      //console.log('elem ruimtenr '+mdl.get('the_ruimte'));
      //console.log('question'+i.toString());
      var questDesc = mdl.get('thd_inquery_text');
	  var question = me.createQuestion('quest'+i.toString(),questDesc);

	  var answers = me.createAnswers('answer'+i.toString(),i,mdl);
	  var remarkval = mdl.get('the_remark');
	  if (me.useRemark){
	    var remark = me.createRemark('remark'+i.toString(),mdl.get('the_remark'),1);
	  }
	
	  var reasontype = mdl.get('thd_reason_type');
	  //console.log(mdl);
	  //console.log('reasontype'+reasontype);
	  var reason;
	  if (reasontype>0){
	    reason = me.createReason('reason'+i.toString(),i,mdl);
	    me.useReason = true;
	  } else
	  {
		me.useReason = false;
	  }	  

	  var l1 = Ext.create('Ext.Panel',{name:'quest_p1'+i.toString(),id:'quest_p1'+me.name+i.toString(),layout:'hbox',height: '45px',items:[question,answers]});	
	  
	  if (me.useRemark){
	    if (reason!==undefined){
	  	  var l2 = Ext.create('Ext.Panel',{name:'quest_p2'+i.toString(),id:'quest_p2'+me.name+i.toString(),layout:'hbox',height: '45px',items:[remark,reason]});
	    } else
	    {
		  var l2 = Ext.create('Ext.Panel',{name:'quest_p2'+i.toString(),id:'quest_p2'+me.name+i.toString(),layout:'hbox',height: '45px',items:[remark]}); 	    
	    }	  
	    //console.log('l2 made');
	    var elempan = Ext.create('Ext.Panel',{id:'elem'+me.name+i.toString(),layout:'vbox',height: '90px',items:[l1,l2],model:mdl});	
	  } else
	  {
		  if (reason!==undefined){
		  	  var l2 = Ext.create('Ext.Panel',{name:'quest_p2'+i.toString(),id:'quest_p2'+me.name+i.toString(),layout:'hbox',height: '45px',items:[reason]});
		  	  var elempan = Ext.create('Ext.Panel',{id:'elem'+me.name+i.toString(),layout:'vbox',height: '90px',items:[l1,l2],model:mdl});
		  } else
	      {
			  var elempan = Ext.create('Ext.Panel',{id:'elem'+me.name+i.toString(),layout:'vbox',height: '45px',items:[l1],model:mdl});
	      }		  
	  }	  
	  me.insert(me.items.length,elempan);	
	},
	
	
	setupControl : function(aStr){
	   var me=this;
	   //if (me.setupDone!=true){
	     
	     // remove all fieldsets
	     me.clear(); 
	     var i;
	     var cnt = me.store.getCount();
	     for(i=0;i<cnt;i++){  	       	 
	       var mdl = me.store.getAt(i);
	       //console.log('storecount '+cnt.toString()+'index '+i.toString()+' '+mdl.get('the_id').toString());
	       me.createItem(i,mdl);
	     } 
	     me.index = 0;
	   //}	   
	   //me.setupDone = true;
	},
	// this must be implemented as delegate when refactored as general class
	newModelItem : function(maxnbr){
		return {the_id:maxnbr,the_inquerynbr:this.inquerynbr,thd_who:'',the_remark:'',the_inqueryanswer:-1,thd_group_id:this.groupid,the_document_id:this.number};
	},
		
	addItem : function(){
	  var me = this;
	  //data.js CreateElement
	  CreateElement(this.number,null,me,"afterCreateElement",this.inquerynbr,this.groupid);  
	},
	
	afterCreateElement : function(){
		//console.log('after create element');
		//data.js GetMaxElementNbr
		GetMaxElementNbr(this,"maxElementNbr","tbl_dks_elementen","the_id");
	},
	
	maxElementNbr : function(store){
		me = this;
		//console.log('max element '+this.maxidstore.getCount());
		var maxmdl = this.maxidstore.getAt(0);
		//console.log(' maxmdl '+maxmdl.get('maxid'));
		var mdl = Ext.create('DksApp.model.InQueryElement',this.newModelItem(maxmdl.get('maxid')));
		
		mdl.set('the_id',maxmdl.get('maxid'));
		mdl.set('the_editstate',3);
		me.store.add(mdl);

		me.createItem(me.items.length,mdl);
	    index = me.items.length-1;
	},
	
	removeItem : function(){
	  var me = this;
	  if (this.activeIndex!==undefined){
		var i = this.activeIndex;  
	  } else
	  {	  
	    var i = me.items.length-1;
	  }
	  try{
	    var element = Ext.getCmp('elem'+i.toString());//me.store.getAt(i);
	    //console.log('edit state '+element.model.get('the_editstate').toString()+' '+element.model.get('the_id').toString());
	    
	    var index = me.store.find('the_id',element.model.get('the_id'));
		if (index!==false){
		  //console.log('record found');
		  var mdl = me.store.getAt(index);
		  		
	      switch (mdl.get('the_editstate')){
	        case 1 : mdl.set('the_editstate',5);
	       		   //me.delstore.add(mdl); // record only available in local database not at remote server
	      		   break;
	        case 3: mdl.set('the_editstate',5);
	      		   //me.delstore.add(mdl); 	    		 
	    		   break;
	      }
	      mdl.setDirty();
		}
	  }
	  catch(e){
		  alert(e.message+ ' Index '+i.toString()+' '+afspraak.model);
	  }
	  //me.store.removeAt(i);
	  me.removeAt(i);
	  
	  if (me.activeIndex > me.items.length-1){
	    me.activeIndex = me.items.length-1;
	  }
	  //console.log('after delete aantal store items '+me.store.getCount()+' ');
	},
	// remove all visual items store is not touched 
	clear : function(){
	  var me = this;
  
	  while (me.items.length>0){
		  me.removeAt(me.items.length-1);
	  }
	},
	// 
	storeItem : function(i){
		var me = this;
		//console.log('who'+i.toString());
		//var mdl = me.store.getAt(i);
		var element = Ext.getCmp('elem'+me.name+i.toString());
		var mdl = element.model;
		var index = me.store.find('the_id',mdl.get('the_id'));
		var inquerynbr = mdl.get('thd_id');
		var elementstate = 0;
		//console.log('store index '+index.toString()+' inqery nbr '+inquerynbr.toString());
		//console.log(mdl);
		
		if (me.useRemark){
		  var remark = Ext.getCmp('remark'+i.toString());
		  if (remark.getValue()!=mdl.get('the_remark')){
		    mdl.set('the_remark',remark.getValue());
		    elementstate = 1;
		  }
		}
		//console.log('the answernbr '+mdl.get('thd_answer_type')+' '+mdl.get('the_inquerynbr'));
		
		if (me.useReason) {
		  var reason = Ext.getCmp('reason'+i.toString());
		  if (reason!==undefined){
	        var reasonstate = reason.getStateMultiple();
	        if (reasonstate!=mdl.get('the_reasonanswer'))
	        {	  
		      mdl.set('the_reasonanswer',reasonstate);
		      //console.log('the reasonanswer '+mdl.get('the_reasonanswer'));
		      mdl.set('the_reasonnbr',mdl.get('thd_reason_type'));
		      elementstate = 1;
	        }  
		    //console.log('the reasonnbr '+mdl.get('thd_reason_type')+' '+mdl.get('the_reasonnbr'));
	      }
		}
		
		var answer = Ext.getCmp(mdl.get('thd_control')+i.toString());
		var val = answer.getState();
		if ((mdl.get('the_inqueryanswer')!=val)||(answer.indexSet!=answer.indexGet)) {
			elementstate = 1;
		}
		//console.log('the_ruimte '+mdl.get('the_ruimte'));
				
		if (elementstate==1){
            if (val==-1){ // button not set
              if (mdl.get("the_empty")=='1'){ // value is set back to empty remove existing records
                  mdl.set("the_inqueryanswer",0);
                  mdl.set("the_editstate",4);
                  mdl.set("the_inquerynbr",inquerynbr);
                  //console.log('delete existing value '+val);
                } else
                {  // no existing value do nothing
                  mdl.set("the_inqueryanswer",0);
                  mdl.set("the_editstate",1);
                  mdl.set("the_inquerynbr",inquerynbr);
                  //console.log('non existing value not changed '+val);
                }
             } else
             { if(mdl.get("the_empty")=='1'){// existing value update the value in the table
                  mdl.set("the_inqueryanswer",val);
                  mdl.set("the_editstate",3);
                  mdl.set("the_inquerynbr",inquerynbr);
                  //console.log('value changed '+val);
                } else
                {  // new record create insert in the table
                  mdl.set("the_inqueryanswer",val);
                  mdl.set("the_editstate",2);
                  mdl.set("the_inquerynbr",inquerynbr);
                  //console.log('value created '+val);
               }
             }
             //console.log("Storedata scoredefs : "+cnt+" number "+nbr); 
             mdl.set("the_document_id",me.number);
             mdl.setDirty();
           } 	   
	},
	
	storeData : function(callfrom,eventname){
		var me = this;
		var i;
		var cnt = me.items.length;
		for(i=0;i<cnt;i++){		  	
		  //console.log('store at index : '+i.toString());
	      me.storeItem(i);	      
		}	
		StoreInQuery(me.number,me.store,callfrom,eventname);
	}
});