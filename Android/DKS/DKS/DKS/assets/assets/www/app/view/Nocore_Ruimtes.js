Ext.define("DksApp.view.Nocore_Ruimtes",{   
	extend:"Ext.Panel",
	alias: "widget.nocore_ruimtes",
	requires:['DksApp.store.MaxId'],
	setupDone: false,
	number:-1,
	documentid:-1,
	uniqueid:0,
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
	  //(' config : ',this.config);
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
    delButton:function( me, e, eOpts ){
    	//console.log('delete ruimte '+me.name+' '+me.ruimteid);
    	me.ruimtes.removeItem(me.ruimteid);
    },
    openRuimte:function( me, e, eOpts){
    	//console.log('Open ruimte '+me.name+' '+me.ruimteid);
    	//console.log(DksApp);
    	var detailView = me.up('detailsview');
    	//console.log(detailView);
    	var ruimtecontroller = _myAppGlobal.getController('Ruimtes');
   
    	var recordnr = me.ruimtes.getRuimteIdx(me.ruimteid);
    	me.ruimtes.storeItem(recordnr);
    	//console.log('current record '+recordnr);
    	var record = me.ruimtes.getAt(recordnr);
    	ruimtecontroller.loadData(record.model);
    },
    createDelButton:function(aname,avalue,ruid,delindex){
    	var btn = Ext.create('Ext.Button',{name:aname,text:avalue,width:'8%',ruimteid:ruid,delidx:delindex});
    	btn.addListener({'tap':this.delButton});
    	return btn;
    },
    createRuimteButton:function(aname,avalue,ruid){
    	var btn = Ext.create('Ext.Button',{name:aname,text:avalue,width:'15%',ruimteid:ruid});
        btn.addListener({'tap':this.openRuimte});
        return btn;
    },	
	createNaam:function(aname,avalue){
		return Ext.create('Ext.field.Text',
				{ name:aname,value:avalue,labelWidth:'0%',width:'30%'});
	},
	createRuimtegroep:function(aname,avalue){
		var grp = Ext.create('Ext.field.Select',
				{ name:aname,labelWidth:'0%',store:'Ruimtesoort',displayField:'rs_naam',valueField:'rs_id',width:'30%'});
		grp.setValue(avalue);
		return grp;
	},
	createGecontroleerd:function(aname,avalue){
		var con = Ext.create('Ext.field.Select',
				{ name:aname,labelWidth:'0%',store:'NeeJa',displayField:'dtext',valueField:'value',width:'15%'});
			con.setValue(avalue);
			con.disabled = true;
		return con;
	},
	setCuritem:function(item){
		//console.log('set curitem '+item.getParent().index);
		this.activeIndex = item.getParent().index;
	},
	
	createItem:function(i,mdl){
	  var me = this;
      me.uniqueid++;
      var ruimtenameid = 'ruimte'+me.uniqueid.toString();
      var naam = mdl.get('rm_naam');
	  var armnaam = me.createNaam('rmnaam'+me.uniqueid.toString(),naam);
	  var kind = mdl.get('rm_ruimtekind');
	  var ruimteid = mdl.get('rm_id');
	  //console.log('ruimtekind '+kind);
	  var armgroep = me.createRuimtegroep('rmgroep'+me.uniqueid.toString(),kind);
	  var con = mdl.get('rm_gecontroleerd');
	  var armcon = me.createGecontroleerd('rmcon'+me.uniqueid.toString(),con);
      var delbutton = me.createDelButton('rmdel'+me.uniqueid.toString(),'X',ruimtenameid);
      var controlebutton = me.createRuimteButton('rmruimte'+me.uniqueid.toString(),'Vul in',ruimtenameid);
	  var newitem = Ext.create('Ext.Panel',{name:ruimtenameid,layout:'hbox',height: '45px',
		              items:[delbutton,armnaam,armgroep,armcon,controlebutton],model:mdl,rmnaam:armnaam,rmgroep:armgroep,rmcon:armcon});	
      delbutton.ruimtes = this;
      controlebutton.ruimtes = this;
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
		return {rm_naam:'',rm_ruimtekind:108,rm_document_id:this.number,rm_gecontroleerd:1};
	},
		
	addItem : function(){
	  var me = this;
	  //data.js CreateElement
	  CreateRuimte(this.number,null,me,"afterCreateElement");  
	},
	
	afterCreateElement : function(){
		//console.log('after create element');
		//data.js GetMaxElementNbr
		GetMaxElementNbr(this,"maxElementNbr","tbl_ruimtes","rm_id");
	},	
	maxElementNbr : function(store){
		me = this;
		//console.log('max element '+this.maxidstore.getCount());
		var maxmdl = this.maxidstore.getAt(0);
		//console.log(' maxmdl '+maxmdl.get('maxid'));
		var mdl = Ext.create('DksApp.model.Ruimtes',this.newModelItem(maxmdl.get('maxid')));
		
		mdl.set('rm_id',maxmdl.get('maxid'));
		mdl.set('rm_editstate',3);
		me.store.add(mdl);

		me.createItem(me.items.length,mdl);
	    index = me.items.length-1;
	},
	getRuimteIdx: function(aname){
		var me = this;
		var idx = -1;
		for(var i=0;i<me.items.length;i++){		  
			  if (me.getAt(i).name==aname){
			    idx = i;  			    
			  } 	  
		  }
		return idx;
	},
	getRuimteIdxByRoomIdx: function(roomidx){
		var me = this;
		var idx = -1;
		for(var i=0;i<me.items.length;i++){		  
			  if (me.getAt(i).model.get('rm_id')==roomidx){
			    idx = i;  			    
			  } 	  
		  }
		return idx;
	},
	setGecontroleerd:function(ruimtenr,val){
		var me = this;
	   	for(var i=0;i<me.items.length;i++)
	   	{
	   		var pnl = me.getAt(i);
	   		if (pnl.model.get('rm_id')==ruimtenr){
	   			var con = pnl.getAt(3).setValue(val);	   			
	   		}
	   	}	
	},
	allChecked:function(){
		var me = this;
		var checked = true;
	   	for(var i=0;i<me.items.length;i++)
	   	{
	   		if (me.getAt(i).getAt(3).getValue()!=2){
	   			checked = false;
	   		}	   			
	   	}
	   	return checked;
	},
	calcScore:function(ruimtenr,elementen){
		me = this;
		var vuil=0;
		var methode=0;
		var periodiek=0;
		var aantalelem=elementen.items.length;
		for(var i=0;i<aantalelem;i++)
	   	{
	   		var mdl = elementen.getAt(i).model;
	   		meting = mdl.get('the_inqueryanswer');
	   		switch (meting){ 
	   		  case 1:methode++;break;
	   		  case 2:vuil++;break;
	   		  case 3:periodiek++;break;
	   		}
	   	}
		
	   	for(var i=0;i<me.items.length;i++)
	   	{
	   		var pnl = me.getAt(i);
	   		if (pnl.model.get('rm_id')==ruimtenr){	   			
	   			
	   			pnl.model.set('rm_methode',methode);
	   			pnl.model.set('rm_vuil',vuil);
	   			pnl.model.set('rm_periodiek',periodiek);
	   			//console.log('aantal elementen '+aantalelem);
	   			pnl.model.set('rm_aantelem',aantalelem);
	   		}
	   	}	
	},
	removeItem : function(aname){
	  //console.log('remove ruimte '+aname);	
	  var me = this;
	  
	  var delidx = -1;
	  for(var i=0;i<me.items.length;i++){		  
		  if (me.getAt(i).name==aname){
		    delidx = i;  
		    //console.log('found at '+delidx);
		  }		  
	  }
	  
	  if ((delidx>=0)&&(delidx<me.items.length)){
			
	    try{
	      var ruimte = me.getAt(delidx);//me.store.getAt(i);
	      //console.log('edit state '+ruimte.model.get('rm_editstate').toString()+' '+ruimte.model.get('rm_id').toString());
	    
	      var index = me.store.find('rm_id',ruimte.model.get('rm_id'));
		  if (index!==false){
		    //console.log('record found');
			me.store.removeAt(index);
		    DeleteRuimte(ruimte.model.get('rm_id'),ruimte.model.get('rm_document_id'));				    
		  }
	     }
	     catch(e){
		    alert(e.message+ ' Index '+delidx.toString()+' '+ruimte.model);
	     }

	     me.removeAt(delidx) 
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
        var ruimte = me.getAt(i);

		var rmnaam = ruimte.rmnaam.getValue();
		var rmgroep = ruimte.rmgroep.getValue();
		var rmcon = ruimte.rmcon.getValue();

		//console.log('ruimte '+ruimte.model.get('rm_id').toString()+' naam '+rmnaam+' groep '+rmgroep);
		var index = me.store.find('rm_id',ruimte.model.get('rm_id'));
		//console.log('store index '+index);
		if ((index!==false)||(index!=-1)){
		  //console.log('record found');
		  var mdl = me.store.getAt(index);
		  mdl.set('rm_naam',rmnaam);
		  mdl.set('rm_ruimtekind',rmgroep);
		  mdl.set('rm_gecontroleerd',rmcon);
		  mdl.set('rm_editstate',3);
		  mdl.setDirty();
		}
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
		StoreRuimte(me.store,callfrom,eventname);
	},	
	storeDataOneRoom : function(roomidx){
		var me = this;
		var i = me.getRuimteIdxByRoomIdx(roomidx);
	    me.storeItem(i);
		StoreRuimte(me.store,null,null);
	}	
});