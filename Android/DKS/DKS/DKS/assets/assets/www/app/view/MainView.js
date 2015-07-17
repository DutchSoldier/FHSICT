Ext.define("DksApp.view.MainView", {
    extend: "Ext.Container",
    requires:["Ext.*"],
    alias: "widget.mainlistview",  
    
    config: {
    	scrollable:false,
        layout: {
            type: 'fit'
        },        
        items: [
            {
                xtype: "toolbar",
                docked: "top",
                id: "toolbar",
                title: GetLocaleString("NOCORE DKS"), 
                //title: GetLocaleString("MKS"), 
                height: '70px',
                defaults: {
                    iconMask: true,
                    ui: "plain"
                },            
                items: [{
                    xtype: "button",
                    iconCls: "delete",
                    id: "btnDelete",
                    height:'60px',
                    width:'60px',
                    hidden:true
               },{
                    xtype: "spacer"
                },{
                    xtype: "button",
                    iconCls: "add",
                    id: "btnAddItem",
                    height:'60px',
                    width:'60px',
                    hidden:false
                },{
                    xtype: "button",
                    iconCls: "refresh",
                    id: "btnRefresh",
                    height:'60px',
                    width:'60px'
                },{
                    xtype: "button",
                    iconCls: "settings",
                    id: "btnConfig" ,
                    height:'60px',
                    width:'60px'                
                },{
                    xtype: "button",
                    iconCls: "download",
                    id: "btnDownload",
                    height:'60px',
                    width:'60px'
                }]
            },
            {
                xtype: "list",
                store: "Workorders",
                id: "workordersList",
                loadingText: "Controle laden...", //Todo translation
                emptyText: "<div class=\"notes-list-empty-text\">Geen controles gevonden!</div>", //Todo translation
                onItemDisclosure: true,
                grouped: true,
                itemTpl: mainListTpl
            },{
                xtype: "button",
                text: "next",
                id: "btnNext",
                height:'60px',
                dock: "bottom",
                width:'60px'
            }
        ],
        listeners: [
            {
                delegate: "#btnDelete",
                event: "tap",
                fn: "onDeleteButtonTap"
            },{
                delegate: "#btnAddItem",
                event: "tap",
                fn: "onAddButtonTap"
            },{
                delegate: "#btnNext",
                event: "tap",
                fn: "onNextButtonTap"
            },{
                delegate: "#btnRefresh",
                event: "tap",
                fn: "onRefreshButtonTap"
            },{
                delegate: "#btnConfig",
                event: "tap",
                fn: "onConfigButtonTap"
            },
            {
                delegate: "#workordersList",
                event: "disclose",
                fn: "onWorkordersListDisclose"
            },
            {
                delegate: "#workordersList",
                event: "itemswipe",
                fn: "onWorkordersItemSwipe"
            },
            {
                delegate: "#workordersList",
                event: "tap",
                fn: "onWorkordersItemTap"
            },
            {
                delegate: "#btnDownload",
                event: "tap",
                fn: "onDownloadButtonTap"
            }
        ]
    },
    onConfigButtonTap: function () {
        this.fireEvent("viewConfigScreenCmd", this);
    },
    onWorkordersListDisclose: function (list, record, target, index, evt, options) {
        //var jsonText2 = JSON.stringify(record.data);
        //console.log(jsonText2);
        this.fireEvent('viewWorkorderDetailsCmd', this, record);
    },
    onWorkordersItemSwipe: function( list, index, target, record, e, eOpts ){
    	// console.log("itemswipe");
    	this.fireEvent('viewWorkorderDetailsCmd', this, record);
    },
    onWorkordersItemDoubleTap: function( list, index, target, record, e, eOpts ){
    	// console.log("itemswipe");
    	this.fireEvent('viewWorkorderDetailsCmd', this, record);
    },
    onWorkordersItemTap: function( list, index, target, record, e, eOpts ){
    	// console.log("itemtap");
    	this.getApplication().getController('Workorders').number = record.data.wo_number;
    },
    onAddButtonTap: function () {
       // this.fireEvent("UpLoadCmd",this); 
       // console.log("AddWorkordersCmd");
	   this.fireEvent("AddWorkordersCmd",this);     
    },
    onNextButtonTap: function () {
    	this.fireEvent("viewNewViewCmd", this);    
     },
    onDownloadButtonTap: function () {
       // this.fireEvent("UpLoadCmd",this); 
       // console.log("Uploadcmd");
	   this.fireEvent("UploadCmd",this);     
    },
    onDeleteButtonTap: function () {
		this.fireEvent("DeleteWorkordersCmd",this);        
    }  
});