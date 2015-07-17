Ext.require(['Ext.device.Connection','Ext.device.Notification','Ext.device.Camera']);

Ext.application({
    name: "DksApp",
    appProperty: 'Current',
    models: ["Workorder", "IdVal","ContactPers","Address","Communication","InQueryElement","TaskElement","MaxId","Relaties","InQuery","Ruimtes","Ruimtesoort"],
    stores: ["Workorders","InfoData","IdVal","InQuery1","Info","ContactPers","Address","Communication","MaxId","Relaties","InQuery","Elementen",
             "SMG","JaNee","DocState","Afspraken","DKS","Algemeen","Ruimtes","Ruimtesoort","NeeJa"],
    controllers: ["Options", "Details", "Workorders", "Algemeen","Info","Ruimtes"],   
    views: ["OptionsView", "NewView", "DetailsView", "DetailsTabs", "DetailsTab_Algemeen","DetailsTab_Info","RuimtesView","Signature","Nocore_SegButton","Nocore_Afspraak","Nocore_Elementen","Nocore_Ruimtes","MainView"],

    tabletStartupscreen : 'resources\loading\ancora.png',

    launch: function () {
    	_myAppGlobal = this;
    	
    	document.addEventListener("backbutton", this.backKeyDown, true); 
        
        LoadInQueryDef(this.afterLoadInQueryDef);             
    },    
    afterLoadInQueryDef: function(){
    	//CreateStores();
    	modelstack=[];
    	LoadStores(0,6);
    	LoadRuimteSoorten(null);
    	
    	var mainView = {
                xtype: "mainlistview"
            };
            var optionsView = {
                xtype: "optionsview"
            };
            var detailsView = {
                xtype: "detailsview"
            };
            var detailsTabs = {
                xtype: "detailstabs"
            };
            var ruimtesView = {
                xtype: "ruimtesview"
            };
            var newView = {
                xtype: "newview"
            };

            Ext.Viewport.add([mainView, optionsView, detailsView
                              ,ruimtesView, newView
                              ]);   
    	
    },
    backKeyDown: function(){
    	//console.log(Ext.vi);
    }
});

