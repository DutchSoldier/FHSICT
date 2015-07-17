Ext.define("DksApp.controller.Ruimtes", {
    extend: "Ext.app.Controller",
    number: -1, 
    documentid: -1,
    ruimte: -1,
    config: {
        refs: {
            mainlistView: "mainlistview",
            detailsView: "detailsview",
            algemeenTabPanel: 'detailstab_algemeen',
            infoTabPanel: 'detailstab_info',
            ruimtesView: 'ruimtesview',
            newView: "newview"
        },
        control: {
            detailsView: {
                backToListCmd: "onBackToListCmd"
            }
        },
    listeners: {
           dataLoaded : function(store) {this.dataLoaded(store); },
           dataLoaded1 : function(store) {this.dataLoaded1(store); },
           dataLoaded2 : function(store) {this.dataLoaded2(store); },
           dataStored : function(store) {this.dataStored(store); }
        } 
    },
    
    // Transitions
    slideLeftTransition: { type: 'slide', direction: 'left' },
    slideRightTransition: { type: 'slide', direction: 'right' },  
    
    storeData: function(gereed){
    	//.log(this.model);
    	var ruimtes = Ext.getCmp('pnlRuimtes');    	
    	if (gereed){
    	   //console.log('Gereed');	
     	   this.model.set('rm_gecontroleerd',2);    	   
     	   ruimtes.setGecontroleerd(this.model.get('rm_id'),2);
    	} else
     	{
    		this.model.set('rm_gecontroleerd',1);
    		ruimtes.setGecontroleerd(this.model.get('rm_id'),1);   	
     	}	
    	var pnlElementen = Ext.getCmp('pnlElemRuimte');
    	pnlElementen.number = this.model.get('rm_document_id');
    	
    	//console.log('plnElementen number '+pnlElementen.number);
    	pnlElementen.storeData(this,"dataStored");
    },    
    dataStored: function(store){
    	//console.log('Ruimtes dataStored');
    	//console.log(this.model);
    	
    	var pnlElementen = Ext.getCmp('pnlElemRuimte');
    	var ruimtes = Ext.getCmp('pnlRuimtes'); 
    	var roomidx = this.model.get('rm_id');
    	ruimtes.calcScore(this.model.get('rm_id'),pnlElementen);
    	Ext.Viewport.setActiveItem(this.getDetailsView());
    	ruimtes.storeDataOneRoom(roomidx);
    },
    dataStored1: function(store){
    	Ext.Viewport.setActiveItem(this.getDetailsView());
    },	    
    //Events
    launch: function () {
        
        this.callParent();
    },
    
    init: function () {
        
        this.callParent();
    },
    
    loadData: function(ruimte) {
      var me = this;
      
      me.model = ruimte;
      //var nm = Ext.getCmp('rm_naam');
     // nm.setValue(ruimte.get('rm_naam'));
      
      //var nm = Ext.getCmp('rm_ruimtekind');
      var st = Ext.getStore('Ruimtesoort');
      var num = st.find('rs_id',ruimte.get('rm_ruimtekind'));
      var record = st.getAt(num);
      //nm.setValue(record.get('rs_naam'));
      var rmnaam = ruimte.get('rm_naam'); 
      if (rmnaam.length>15){
    	  rmnaam = rmnaam.slice(0,15);
      }
      
      var rsnaam = record.get('rs_naam');
      if (rsnaam.length>15){
    	  rsnaam = rsnaam.slice(0,15);
      }
      this.getRuimtesView().setTitle('Ruimte : '+rmnaam+' Soort : '+rsnaam);
      
      me.number = ruimte.get('rm_id');
      me.documentid = ruimte.get('rm_document_id');
      LoadRuimteElementen("Elementen",ruimte.get('rm_ruimtekind'),me.number,"dataLoaded1",me);      
    },
    dataLoaded1: function (store) {
      var me = this;	
      //console.log('Dataloaded3 scoredefs');
      
      var pnlElementen = Ext.getCmp('pnlElemRuimte');
      var stElementen = Ext.getStore("Elementen");
      
      for(var i=0;i<stElementen.getCount();i++){
    	  var mdl = stElementen.getAt(i);
    	  mdl.set('the_ruimte',me.model.get('rm_id'));
    	  mdl.set('the_document_id',me.model.get('the_document_id'));
      }
      
      pnlElementen.number = me.model.get('rm_id');
  	  if (stElementen !== null){
  		//console.log('Elmenten count '+stElementen.getCount());
  		pnlElementen.setStore(stElementen);
  	  }	  
  	  Ext.Viewport.setActiveItem(this.getRuimtesView());
  	  //var pnlElementen = Ext.getCmp('pnlElementen');
	  //pnlElementen.storeData(null,null);
    } 
});