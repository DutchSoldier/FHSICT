Ext.define("DksApp.controller.Algemeen", {
    extend: "Ext.app.Controller",
    number: -1,    
    config: {
        refs: {
            mainlistView: "mainlistview",
            detailsView: "detailsview",
            newView: "newview",
            algemeenTabPanel: 'detailstab_algemeen'
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
           loadRuimtes : function(store) {this.loadRuimtes(store); },
           dataStored : function(store) {this.dataStored(store); },
           dataStored1 : function(store) {this.dataStored1(store); }
        } 
    },
    
    // Transitions
    slideLeftTransition: { type: 'slide', direction: 'left' },
    slideRightTransition: { type: 'slide', direction: 'right' },  
    
    // Commands
    onBackToListCmd: function () {
    	//console.log('back scoredefs');
    	//this.getApplication().getController('Details').dataStored();
    },
    
    storeData: function(){
    	var pnlElementen = Ext.getCmp('pnlElementen');
    	pnlElementen.storeData(this,"dataStored");
    },    
    dataStored: function(store){
    	var pnlRuimtes = Ext.getCmp('pnlRuimtes');
    	pnlRuimtes.storeData(this,"dataStored1");
    },
    dataStored1: function(store){
    	this.getApplication().getController('Details').dataStored();
    },
    
    //Events
    launch: function () {
        
        this.callParent();
    },
    
    init: function () {
        
        this.callParent();
    },
    
    loadData: function(selectedWorkorder) {
      var me = this;
      //console.log('ScoreDefsRadio.loadData '+selectedWorkorder.wo_number);
      me.getAlgemeenTabPanel().setValues(selectedWorkorder); 
      me.number = selectedWorkorder.wo_number;
      LoadInQuery("Algemeen",1,me.number,"dataLoaded1",me);      
    },
    dataLoaded1: function (store) {
      var me = this;	
      //console.log('Dataloaded3 scoredefs');
      
      var pnlElementen = Ext.getCmp('pnlElementen');
      var stElementen = Ext.getStore("Algemeen");
      pnlElementen.number = this.number;
  	  if (stElementen !== null){
  		//console.log('Elmenten count '+stElementen.getCount());
  		pnlElementen.setStore(stElementen);
  	  }
  	  LoadRuimtes(me.number,"dataLoaded2",me);  
    } ,
    dataLoaded2: function (store) {
        var me = this;	
        //console.log('Dataloaded4 Glas');
        var stRuimtes = Ext.getStore("Ruimtes");
        //console.log('Aantal ruimtes gedefinieerd : '+stRuimtes.getCount());
        if (stRuimtes.getCount() == 0){
        	CreateRuimtes(me.number,"loadRuimtes",me);
        } else
        {
        	this.loadRuimtes();
        }	
  	  },
  	loadRuimtes: function(){
  		var pnlRuimtes = Ext.getCmp('pnlRuimtes');
        var stRuimtes = Ext.getStore("Ruimtes");        
        pnlRuimtes.number = this.number;
    	if (stRuimtes !== null){
    	  //console.log('Ruimtes count '+stRuimtes.getCount());
    	  pnlRuimtes.setStore(stRuimtes);
    	}
    	this.getApplication().getController('Details').dataLoaded();
  	}  
});