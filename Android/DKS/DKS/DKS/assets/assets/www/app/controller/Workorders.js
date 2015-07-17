Ext.define("DksApp.controller.Workorders", {
    extend: "Ext.app.Controller",
    number:-1,
    config: {
        //Based on this ref, the framework generates a getter function that we can use to work with the
        //reference if we need to. Ref-derived getter functions are named following a simple format,
        //consisting of the word get and the capitalized name of the ref in question.
        refs: {
            mainlistView: "mainlistview",
            optionsView: "optionsview",
            detailsView: "detailsview",
            newView: "newview"
        },
        control: {
            mainlistView: {
                // The commands fired by the main list container.
                viewConfigScreenCmd: "onViewConfigScreenCmd",
                viewWorkorderDetailsCmd: "onViewWorkorderDetailsCmd",
                AddWorkordersCmd: "onAddWorkordersCmd",
                SynchronizeWorkordersCmd:  "onSynchronizeWorkordersCmd",
                DeleteWorkordersCmd: "onDeleteWorkordersCmd",
                viewDetails: "activateDetailsView",
                viewNewViewCmd: "onViewNewViewCmd",
                UploadCmd: "onUploadCmd"
            }
        }      
    },
    
    // Transitions
    slideLeftTransition: { type: 'slide', direction: 'left' },
    slideRightTransition: { type: 'slide', direction: 'right' },    
    
    //Functions
    activateOptionView: function () {
        Ext.Viewport.animateActiveItem(this.getOptionsView(), this.slideLeftTransition);
    },
    activateDetailsView: function () {
        Ext.Viewport.animateActiveItem(this.getDetailsView(), this.slideLeftTransition);
    }, 
    activateNewView: function () {
        Ext.Viewport.animateActiveItem(this.getNewView(), this.slideLeftTransition);
        
    }, 
    // Commands
    onViewConfigScreenCmd: function () {
        this.getApplication().getController('Options').bindData();
        this.activateOptionView();        
    },
    onViewWorkorderDetailsCmd: function (list, record, target, index, evt, options) {
    	//console.log("onViewConfigScreenCmd");
        this.number = record.data.wo_number;
        //console.log('workorder '+this.number);
        this.getApplication().getController('Details').bindData(record.data);        
    },
    onViewNewViewCmd: function () {

    	this.activateNewView();       
    },
    onRefreshWorkordersCmd : function(){
        LoadWorkorders();    
    },

    onDeleteWorkordersCmd : function(){
    	var store = Ext.getStore('Workorders');
        var index = store.find(this.number);
        if (index!==false){
          mdl = store.getAt(index);	
          if (mdl.get('wo_status')==2){
        	  alert('Verslag is gereed , kan niet worden verwijderd');
          } else
          { 	  
            store.removeat(index);
            DeleteWorkorder(this.number);
          }
        }  
    },
	newModelItem : function(){
		return {wo_number:null,wo_status:1,wo_remark:'',wo_weekNo:10,WO_SMALLDESC:'',wo_debtorName:'',wo_contactperson:'nieuw'};
	},
    onAddWorkordersCmd : function(){
    	var me = this;
    	var mdl = Ext.create('DksApp.model.Workorder',this.newModelItem());
        AddWorkorder(me,mdl,this.onAfterWorkorder);   
    },
    onAfterWorkorder : function(sender,mdl){
    	Details = sender.getApplication().getController('Details');
    	Details.bindData(mdl.data);  
    },
    onSynchronizeWorkordersCmd : function(){
        Download(LoadWorkorders);         
    },
    onUploadCmd : function(){
    	//Download(LoadWorkorders);
    	if (Ext.device.Connection.isOnline()==true){	
          Upload(this.onSynchronizeWorkordersCmd);
    	} else
    	{
    		Ext.device.Notification.show({
    		    title: 'Geen netwerk verbinding',
    		    message: 'Er is geen verbinding met het newerk. Maak een netwerkverbinding voordat u de gegevens gaat synchroniseren.'
    		    });
    	}	
           },           
    //Events
    launch: function () {
       
        this.callParent();
        
        //LoadConfigs();        
        LoadWorkorders();
    },
    loadStores: function() {
    	//console.log('Load stores');
    },
    init: function () {

        this.callParent();
        this.loadStores();
        //console.log("init");
    }
});