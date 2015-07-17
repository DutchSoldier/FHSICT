Ext.define("DksApp.view.OptionsView", {
    extend: "Ext.form.Panel",
    alias: "widget.optionsview",
    
    config: {
    	scrollable:false,
        items: [
                {
                    xtype: "toolbar",
                    docked: "top",
                    title: GetLocaleString("Options"),
                    items: []
                },{
                    xtype: "toolbar",
                    ui: 'light',
                    docked: "bottom",
                    items: [
                    {
                        xtype: "button",
                        text: GetLocaleString("Back"),
                        ui: "back",
                        id: "btnCancelOpt"
                    },{
                        xtype: "button",
                        text: GetLocaleString("Run query"),
                        id: "btnQuery"
                    },{
                        xtype: "button",
                        text: GetLocaleString("Load Data"),
                        id: "btnLoadData"
                    },{
                        xtype: "spacer"
                    },{
                        xtype: "button",
                        text: GetLocaleString("Restart app"),
                        ui: "confirm",
                        id: "btnRestartApp",
                        hidden: true
                    } ]
                },{
                    xtype: 'selectfield',
                    id: 'groupBySelector',
                    name: 'groupBySelector',
                    label: GetLocaleString("Group by:"),
                    labelWidth: '35%',
                    valueField: 'groupByField',
                    displayField: 'groupByFieldDesc',
                    store: {
                        data: [
                            { groupByField: 'week', groupByFieldDesc: GetLocaleString("Week number")},
                            { groupByField: 'debtor', groupByFieldDesc: GetLocaleString("Debtor")}
                        ]
                    }                    
                },{
                    xtype: 'selectfield',
                    id: 'sortSelector',
                    name: 'sortSelector',
                    label: GetLocaleString("Sort by:"),
                    labelWidth: '35%',
                    valueField: 'sortByField',
                    displayField: 'sortByFieldDesc',
                    store: {
                        data: [
                            { sortByField: 'week', sortByFieldDesc: GetLocaleString("Week number")},
                            { sortByField: 'debtor', sortByFieldDesc: GetLocaleString("Debtor")}                      
                        ]
                    }                    
                },{
                    xtype: 'selectfield',
                    id: 'languageSelector',
                    name: 'languageSelector',
                    label: GetLocaleString("Language:"),
                    labelWidth: '35%',
                    valueField: 'languageField',
                    displayField: 'languageFieldDesc',
                    store: {
                        data: [
                            { languageField: 'english', languageFieldDesc: 'English'},
                            { languageField: 'dutch', languageFieldDesc: 'Dutch'}
                        ]
                    }
                },{
                    xtype: 'checkboxfield',
                    id: 'displayPlannedHours',
                    name : 'displayPlannedHours',
                    label: GetLocaleString("Display planned hours:"),
                    labelWrap: 'true',
                    labelWidth: '80%'
                },
                {  xtype: 'textfield',
                    id: 'accountid',
                    name: 'accountid',
                    label: GetLocaleString("Account ID")
                },
                {  xtype: 'textfield',
                    id: 'mobiledeviceid',
                    name: 'mobiledeviceid',
                    label: GetLocaleString("Device ID")
                },
                {  xtype: 'textfield',
                    id: 'host',
                    name: 'host',
                    label: GetLocaleString("host")
                },
                {  xtype: 'textfield',
                    id: 'port',
                    name: 'port',
                    label: GetLocaleString("port")
                },
                {
                    xtype: 'textfield',
                    id: 'sqlcommand',
                    name: 'sqlcommand',
                    label: GetLocaleString("Query")
                }
        ],
        listeners: [{
                delegate: "#groupBySelector",
                event: "change",
                fn: "onGroupBySelectorChange"
            },{
                delegate: "#sortSelector",
                event: "change",
                fn: "onSortSelectorChange"                    
            },{
                delegate: "#languageSelector",
                event: "change",
                fn: "onLanguageSelectorChange"
            },{
                delegate: "#host",
                event: "change",
                fn: "onHostFieldChanged"
            },{
                delegate: "#port",
                event: "change",
                fn: "onPortFieldChanged"
            },{
                delegate: "#mobiledeviceid",
                event: "change",
                fn: "onMobileDeviceIdFieldChanged"
            },{
                delegate: "#accountid",
                event: "change",
                fn: "onAccountIdFieldChanged"
            },{
                delegate: "#displayPlannedHours",
                event: "check",
                fn: "onDisplayPlannedHoursChange"
            },{
                delegate: "#displayPlannedHours",
                event: "uncheck",
                fn: "onDisplayPlannedHoursChange"
            },{
                delegate: "#btnCancelOpt",
                event: "tap",
                fn: "onCancelButtonTap"
            },{
                delegate: "#btnQuery",
                event: "tap",
                fn: "onRunQueryTap"
            },{
                delegate: "#btnLoadData",
                event: "tap",
                fn: "onLoadDataTap"
            },            
            {
                delegate: "#btnRestartApp",
                event: "tap",
                fn: "onRestartAppButtonTap"
            } 
        ]        
    },

    onGroupBySelectorChange: function (select, newValue, oldValue) {

        var ctrlStore = select.getStore();
        var newIndex = ctrlStore.find('groupByField', newValue);
        
        this.fireEvent("groupFieldChangeCmd", this,  newIndex);
    },
    
    onSortSelectorChange: function (select, newValue, oldValue) {
       
        var ctrlStore = select.getStore();
        var newIndex = ctrlStore.find('sortByField', newValue);
        
//        ctrlStore.each(function(rec){
//            console.log(rec.get('sortByField'));      
//        });        
               
        this.fireEvent("sortFieldChangeCmd", this,  newIndex);
    },
    
    onLanguageSelectorChange: function (select, newValue, oldValue) {

        this.fireEvent("languageChangeCmd", this,  newValue);
    },
    
    onDisplayPlannedHoursChange: function(sender, e, eOpts) {

        this.fireEvent("displayPlannedHoursCmd", sender.getChecked());  
    },
    
    onHostFieldChanged : function( sender, newValue, oldValue, eOpts ) {
        //console.log("Host field changed");
        this.fireEvent("HostFieldChangeCmd", this,  newValue);
    }, 
    
    onPortFieldChanged : function( sender, newValue, oldValue, eOpts ) {
        //console.log("port field changed");
        this.fireEvent("PortFieldChangeCmd", this,  newValue);
    }, 
    
    onMobileDeviceIdFieldChanged : function( sender, newValue, oldValue, eOpts ) {
        //console.log("mobileid field changed");
        this.fireEvent("MobileDeviceIdFieldChangeCmd", this,  newValue);
    }, 
    
    onAccountIdFieldChanged : function( sender, newValue, oldValue, eOpts ) {
        //console.log("accountid field changed");
        this.fireEvent("AccountIdFieldChangeCmd", this,  newValue);
    }, 
    
    onCancelButtonTap: function () {
        
        this.fireEvent("cancelCmd", this);
    },
    onRunQueryTap: function () {
        
        this.fireEvent("runQueryCmd", this);
    },
    onLoadDataTap: function () {
        
        this.fireEvent("loadDataCmd", this);
    },
    onRestartAppButtonTap: function () {
        
        this.fireEvent("restartAppCmd", this);
    }     
}); 