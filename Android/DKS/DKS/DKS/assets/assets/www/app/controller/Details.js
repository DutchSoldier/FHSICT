Ext.define("DksApp.controller.Details", {
    extend: "Ext.app.Controller",
    workorder: null,
    state: -1,
    //http://stackoverflow.com/questions/10679175/sencha-touch-2-set-label-in-controller
    config: {
        refs: {
            mainlistView: "mainlistview",
            detailsView: "detailsview",
            infoTabPanel: 'detailstab_info'
        },
        control: {
            detailsView: {
                backToListCmd: "onBackToListCmd"
            },
        }
    },
    
    // Transitions
    slideLeftTransition: { type: 'slide', direction: 'left' },
    slideRightTransition: { type: 'slide', direction: 'right' },  
    
    // Commands
    onBackToListCmd: function () {
      //  console.log("Details onBackToListCmd");
        this.state = 1;
        this.dataStored();
    },
    
    //Events
    launch: function () {

        this.callParent();
    },
    
    init: function () {
        
        this.callParent();
    },
    
    bindData: function(selectedWorkorder) {
    	var me = this;
    	me.workorder = selectedWorkorder;
        var detailsToolbar = Ext.getCmp('detailsViewToolbar');
        detailsToolbar.setTitle(GetLocaleString("Verslag"));        
        me.state = 1;       
        me.dataLoaded();
        //this.getInfoTabPanel().setHtml(woDetails);
    },
    dataLoaded: function() {
    	var me = this;
    	//console.log("details dataLoaded "+me.state);
    	switch (me.state) {
    	  case 1 : { me.state = 2; me.getApplication().getController('Algemeen').loadData(me.workorder); }; break; 
    	  case 2 : { me.state = 3; me.getApplication().getController('Info').loadData(me.workorder); }; break;
    	  case 3 : { me.state = 1; me.getApplication().getController('Workorders').activateDetailsView(); }; break;
        }
    	
    },
    dataStored: function() {
        var me = this;
        //console.log("details dataStored "+me.state);
        switch(me.state) {
        case 1 : { me.state = 2; me.getApplication().getController('Algemeen').storeData();}; break;
        case 2 : { me.state = 3; me.getApplication().getController('Info').storeData();}; break;
        case 3 : { me.state = 1; LoadWorkorders(); Ext.Viewport.animateActiveItem(this.getMainlistView(), this.slideRightTransition); }; break;
        }
    }
});