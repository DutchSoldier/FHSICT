Ext.define("DksApp.view.Nocore_Afspraak",{   
	extend:"Ext.Panel",
	alias: "widget.nocore_afspraak",
	requires:['DksApp.store.MaxId'],
	setupDone: false,
	number:-1,
	config:{
	   layout:'vbox',	
	   store:null,
	   delstore:null,
	   index:-1,
	   padding:0,
	   scrollable: {
		    direction: 'vertical',
		    directionLock: true
		},
	   listeners : {storeDeletedItems  : function(store) {this.storeDeletedItems(store); },
		   	        afterCreateElement : function(store) {this.afterCreateElement();},
		   			maxElementNbr : function(store) {this.maxElementNbr(store);}
		   		   }	                
    },
	constructor: function(config)
	{ 
	  this.callParent([config]);
	  //console.log(' config : ',this.config);
	  this.maxidstore = Ext.getStore("MaxId");//Ext.create('BezoekverslagenApp.store.MaxId');
	},
	
	applyStore: function(newStore,oldStore){  
    	//console.log('apply store');
   	  if (newStore != null){

   		this.store = newStore;  
   		/*this.createDelStore();*/
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
    	
	createSelector:function(aname,aindex){
    	return {xtype:'button',width:'4%',name:aname,pressedCls: 'customPressedCls',text:'x',listeners:{tap:function(item,e,eOpts){console.log(item.getName());}}};
    },    
	createDesc:function(aname,avalue,aheight){
		return Ext.create('Ext.field.TextArea',
				{ minWidth:'60%',name:aname,id:aname,value:avalue,labelWidth:'0%',maxRows:1});
	},
	createWho:function(aname,avalue){
		return Ext.create('Ext.field.Text',{width : '20%',name:aname,id:aname,value:avalue,labelWidth:'0%'});
	},
	createDate:function(aname,avalue){
		var dt = Ext.create('Ext.field.DatePicker',{dateFormat:'d-m-Y',name:aname,id:aname, width: '20%',labelWidth:'0%'});
		dt.setValue(avalue);
		return dt;
	},
	setCuritem:function(item){
		//console.log('set curitem '+item.getParent().index);
		this.activeIndex = item.getParent().index;
	},
	
	createItem:function(i,mdl){
	  var me = this;
	  
      var s = mdl.get('the_remark');
	  var lineCnt = (s.split("\n").length);
	  if (lineCnt==0) {lineCnt=1;} 
	  lineCnt = (lineCnt*24)+23;
      lineCnt = lineCnt.toString()+'px';
      //console.log('who'+i.toString());
      var whom = mdl.get('the_who');
	  var who = me.createWho('who'+i.toString(),whom);
	  var afd = mdl.get('the_date');
	  var afspraakdate = me.createDate('afspdate'+i.toString(),afd);
	  //afspraakdate.on('focus',this.setCuritem);
      var desc = me.createDesc('taakdesc'+i.toString(),s,lineCnt);
      //var sel = me.createSelector('sel'+i.toString(),i);
	  var newitem = Ext.create('Ext.form.FieldSet',{id:'afspraak'+i.toString(),layout:'hbox',height: '100',items:[desc,who,afspraakdate],model:mdl});	
	  //console.log('newitem '+i.toString()+' '+newitem);
      me.insert(me.items.length,newitem);	
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
		return {the_id:maxnbr,the_inquerynbr:this.inquerynbr,thd_who:'',the_remark:'',the_inqueryanswer:this.groupid,the_document_id:this.number,the_date:null};
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
		var mdl = Ext.create('DksApp.model.TaskElement',this.newModelItem(maxmdl.get('maxid')));
		
		mdl.set('the_id',maxmdl.get('maxid'));
		mdl.set('the_date',new Date());
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
	    var afspraak = Ext.getCmp('afspraak'+i.toString());//me.store.getAt(i);
	    console.log('edit state '+afspraak.model.get('the_editstate').toString()+' '+afspraak.model.get('the_id').toString());
	    
	    var index = me.store.find('the_id',afspraak.model.get('the_id'));
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
	  var cnt = me.items.length;
	  var i;
	  for(i=0;i<cnt;i++){
		 me.removeAt(0);
	  }		  
	},
	// 
	storeItem : function(i){
		var me = this;
		//console.log('who'+i.toString());
		//var mdl = me.store.getAt(i);
		var afspraak = Ext.getCmp('afspraak'+i.toString());
		var whom = Ext.getCmp('who'+i.toString()).getValue();
		var afsdate = Ext.getCmp('afspdate'+i.toString()).getValue();
		//console.log('datum '+afsdate);
		var taakdesc = Ext.getCmp('taakdesc'+i.toString()).getValue();
		//console.log('afspraak '+afspraak.model.get('the_id').toString()+' who '+whom+' taak '+taakdesc);
		var index = me.store.find('the_id',afspraak.model.get('the_id'));
		//console.log('store index '+index);
		if ((index!==false)||(index!=-1)){
		  console.log('record found');
		  var mdl = me.store.getAt(index);
		  mdl.set('the_who',whom);
		  mdl.set('the_remark',taakdesc);
		  mdl.set('the_date',afsdate);
		  mdl.set('the_editstate',3);
		  mdl.setDirty();
		}
		//var mdl = afspraak.model;
		//me.store.insert(0,[mdl]);
	},
	
	storeData : function(callfrom,eventname){
		var me = this;
		//var cnt = me.store.removeAll;
		//console.log('store data store count'+cnt.toString());
		//me.callfrom = callfrom;
		//me.eventName = eventname;
		var i;
		var cnt = me.items.length;
		for(i=0;i<cnt;i++){
		  	
		  //console.log('index : '+i.toString()+' the_id : '+mdl.get('the_id').toString());
	      me.storeItem(i);
	      //console.log('Out of routine '+mdl.get('the_id').toString+' who '+whom+' taak '+taakdesc);
	      
		}	
		StoreInQuery(me.number,me.store,callfrom,eventname);
	},
	
	storeDeletedItems : function(){
		me = this;
		//console.log('storeDeletedItems '+me.delstore.getCount().toString()+' '+me.callfrom+' '+me.eventName);
		StoreInQuery(me.number,me.delstore,me.callfrom,me.eventName);
	}
	
});