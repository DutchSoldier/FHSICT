Ext.define("DksApp.controller.Info", {
    extend: "Ext.app.Controller",
    number: -1,
    config: {
        refs: {
            mainlistView: "mainlistview",
            detailsView: "detailsview",            
            infoTabPanel: "detailstab_info",
            tabsView:"detailstabs",
            algemeenTabPanel: 'detailstab_algemeen'
        },
        control: {
            detailsView: {
                backToListCmd: "onBackToListCmd",
            }
        },
    listeners: {
           dataLoaded  : function(store) {this.dataLoaded(store); },
           dataLoaded1 : function(store) {this.dataLoaded1(store); },
           dataStored  : function(store) {this.dataStored(store); },         
           nextimage : function(object) {this.nextimage(object);},
           finishedLoading : function(object) {this.finishedLoading(object);},
           stateToggle  : function(container,button, pressed) {this.stateToggle(container, button, pressed);}
        }    
    },
    
    // Transitions
    slideLeftTransition: { type: 'slide', direction: 'left' },
    slideRightTransition: { type: 'slide', direction: 'right' },  
    
    // Commands
    onBackToListCmd: function () {
    	//console.log("back handelingen");
    	//this.getApplication().getController('Details').dataStored();
    },
    storeData: function(store){
       //console.log("Info datastored");	
        var me = this;   	
        workorderStore = Ext.getStore("Workorders");
        mdl = workorderStore.findRecord("wo_number", me.number);
        
        var elemStore = Ext.getStore("Info");
        var cnt = elemStore.getCount();
        //console.log('info status count '+cnt.toString());
        
        for(var i=0;i<cnt;i++){          
			var val=11;
			mdl1 = elemStore.getAt(i);
			elname = mdl1.get('thd_control'); 
			var cmp = Ext.getCmp(elname);
			val = cmp.getState();
			if (val==0){val=0;};
			if (val==1){val=2;};
            //console.log("waarde status = "+i.toString()+" "+elname+' '+val);
            mdl.set("wo_status",val);
          } 
        
        var remarks = this.getInfoTabPanel().getValues().wo_remarks;
        var finishdate = this.getInfoTabPanel().getValues().wo_finishDate;
        var contactperson = this.getAlgemeenTabPanel().getValues().wo_contactperson;
        
        mdl.set("wo_remarks",remarks);
        
        mdl.set("wo_finishDate",finishdate);   
        mdl.set("wo_contactperson",contactperson);
         
	    me.saveControllerImage(me);    
    },	
    saveControllerImage: function(me){	 	
    	var canvas = document.getElementById('signcanvascontroller_cv');
    	var canparent = Ext.getCmp('signcanvascontroller');
        if (canparent.changed){
    	  window.canvasplugin(canparent,canvas,me.getImageController);
        } else
        {
           me.saveCustomerImage(me);  	
        }	
    },
    getImageController: function(val){
    	var me = _myAppGlobal.getController('Info'); 
    	workorderStore = Ext.getStore("Workorders");
        mdl = workorderStore.findRecord("wo_number", me.number);
    	mdl.set("wo_signature",val.data);
    	me.saveCustomerImage(me);
    },	
    saveCustomerImage: function(me){	
    	var canvas = document.getElementById('signcanvasklant_cv');
    	var canparent = Ext.getCmp('signcanvasklant');
        if (canparent.changed){
    	  window.canvasplugin(canparent,canvas,me.getImageCustomer);
        } else
        {
           me.saveDks(me);  	
        }	
    },
    getImageCustomer: function(val){
    	var me = _myAppGlobal.getController('Info'); 
    	workorderStore = Ext.getStore("Workorders");
        mdl = workorderStore.findRecord("wo_number", me.number);
        console.log(val.data);
    	mdl.set("wo_signklant",val.data);
    	me.saveDks(me);
    },	
    saveDks: function(me){
    	mdl.setDirty();   
    	StoreWorkorders(me.number,"Workorders",me,"dataStored");
    },
    dataStored: function(store){
    	var me = _myAppGlobal.getController('Info'); 
    	this.getApplication().getController('Details').dataStored();   	
    },
    
    //Events
    launch: function () {
        
        this.callParent();
    },
    
    init: function () {
        
        this.callParent();
    },
    checkAllRooms: function(){
        var setReady = false;        
    	var ruimtes = Ext.getCmp('pnlRuimtes');
        if (ruimtes.allChecked()!=true){
        	Ext.device.Notification.show({
        	    title: 'Bevestging',
        	    message: 'Niet alle ruimtes zijn gecontroleerd. Weet u zeker dat deze controle gereed is? Niet gecontroleerde ruimtes worden niet doorgestuurd!',
        	    buttons: ["Nee", "Ja"],

        	    callback: function(button) {
        	        if (button=="Ja"){
        	        	//var cmp = Ext.getCmp('status'); 
                   	    //cmp.setState(1,1,1,2);  
        	        	ready = Ext.getCmp('txtReadyDate');
        	        	ready.setValue(new Date());
        	        } else
        	        {   
        	        	var cmp = Ext.getCmp('status'); 
                   	    cmp.setState(0,0,1,2);  
        	        	ready = Ext.getCmp('txtReadyDate');
        	        	ready.setValue(null);
        	        }	
        	    }
        	});
        } else
        {
        	ready = Ext.getCmp('txtReadyDate');
        	ready.setValue(new Date());
        	setReady = true;
        }	
        return setReady;
    },
    stateToggle: function(container,button, pressed){   
    	  var infoController = _myAppGlobal.getController('Info');        
          ready = Ext.getCmp('txtReadyDate');
          switch (button.config.id){
                case 'status02':
                 if (pressed) {
                   infoController.checkAllRooms();   
                 } else 
                 { ready.setValue(null);
                 };
              break;
              default:ready.setValue(null);                                   
           }
        	
    },    
    
    loadData: function(selectedWorkorder) {
      me = this; 	
     // console.log('Loaddata Handelingen');
     // console.log(selectedWorkorder.wo_number);
      me.number = selectedWorkorder.wo_number;
      dataimg = selectedWorkorder.wo_signature;
      dataimgklant = selectedWorkorder.wo_signklant;
      
      Ext.getCmp('signcanvascontroller').setTopview(this.getTabsView());
      Ext.getCmp('signcanvasklant').setTopview(this.getInfoTabPanel());
      this.getInfoTabPanel().setValues(selectedWorkorder); 

      LoadDocStateQuery("Info",selectedWorkorder.wo_number,"dataLoaded",this);   
    },
       
    dataLoaded: function (store){
       	var storex = Ext.getStore("Info"); 
        var cnt = storex.getCount();
     //   console.log('Handelingen '+cnt);

        for(var j=0;j<cnt;j++){     
          mdl = storex.getAt(j);         
  	      cmp = Ext.getCmp(mdl.get('thd_control'));
  	    //  console.log(j+" "+cmp.name);
  	    //  console.log(j+" "+cmp.name+' '+mdl.get('thd_control'));
	      if (mdl.get('thd_control')=='status'){
	    	cmp.setupControl(mdl.get('iq_store_name'),mdl.get('iq_displayField'),mdl.get('thd_control')+j.toString(),this.stateToggle);  
	    	cmp.setState(mdl.get('ia_index'),mdl.get('the_inqueryanswer'),1,2);
	      }          
  	    }
    	 
    	var sign = Ext.getCmp('signcanvascontroller'); 
    	sign.setupControl();     
        sign.loadCanvas(dataimg,"nextimage",this);              
       },       
   nextimage: function(object){
	   var signkl = Ext.getCmp('signcanvasklant');
       signkl.setupControl();     
       signkl.loadCanvas(dataimgklant,"finishedLoading",object); 
       
   }  ,
   finishedLoading: function(object){
	   object.getApplication().getController('Details').dataLoaded();
   }
   
    
});