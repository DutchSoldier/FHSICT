var _loadingData;

Ext.define("DksApp.controller.Options", {
    extend: "Ext.app.Controller",
    
    //http://stackoverflow.com/questions/10679175/sencha-touch-2-set-label-in-controller
    config: {
        refs: {
            mainlistView: "mainlistview",
            optionsView: "optionsview"
        },
        control: {
            optionsView: {
                cancelCmd: "onCancelCmd",
                restartAppCmd: "onRestartAppCmd",
                runQueryCmd:"onrunQueryCmd",
                loadDataCmd:"onloadDataCmd",
                groupFieldChangeCmd: "onGroupFieldChangeCmd",
                sortFieldChangeCmd: "onSortFieldChangeCmd",
                languageChangeCmd: "onLanguageChangeCmd",
                displayPlannedHoursCmd: "onDisplayPlannedHoursCmd",
                HostFieldChangeCmd: "onHostFieldChangeCmd",
                PortFieldChangeCmd: "onPortFieldChangeCmd",
                MobileDeviceIdFieldChangeCmd: "onMobileDeviceIdFieldChangeCmd",
                AccountIdFieldChangeCmd: "onAccountIdFieldChangeCmd"
            },
            
        }
    },
    
    // Transitions
    slideLeftTransition: { type: 'slide', direction: 'left' },
    slideRightTransition: { type: 'slide', direction: 'right' },  
    
    // Commands
    onCancelCmd: function () {
    
        Ext.Viewport.animateActiveItem(this.getMainlistView(), this.slideRightTransition);
    },
    onrunQueryCmd: function () {
        var queryCtrl = Ext.getCmp('sqlcommand');
        var statement = [queryCtrl.getValue()];

        dbPlugin.executeSql(
               statement, 
               function(res) {
                    //console.log("**** query result ok ");                                 
               },
               
               function(e) {
                    console.log("Error while running statement!");
                    alert("Error while running statement!"+e);
               }
    );
    },
    onloadDataCmd: function () {
        var queryCtrl = Ext.getCmp('sqlcommand');
        var statement = [queryCtrl.getValue()];
        //.log(statement);
        dbPlugin.loadData(
               statement, 
               function(res) {
                    var jsnStr = JSON.stringify(res.rows);
                    //console.log("**** query result as json obj: " + jsnStr);                                 
               },
               
               function(e) {
                    console.log("Error while running statement!");
                    alert("Error while running statement!"+e);
               }
    );
    },
    onRestartAppCmd: function () {
                   
        ShowToast("Restarting the app. Please wait ...");
        
        //Todo: memory leak here? app memory usage grows 8Mb after restart; boolean parameter (which tells it to do a hard reload)
        //      does not seems to do anything to fix this memory consumption increase
        //
        //Update: it seems related to the "onDeviceReady" event in index.html (http://support.microsoft.com/kb/830555)
        window.location.reload(true);
    },    
    
    onGroupFieldChangeCmd: function (sender, newIndex){
        
        if (_loadingData == false) {
            SaveConfig("mainlistGroupField", newIndex);
            
        }
    },
    
    //it's saved by index to avoid localization mess while saving/retrieving from db
    onSortFieldChangeCmd: function (sender, newIndex){
        
        if (_loadingData == false) {
            SaveConfig("mainlistSortField", newIndex);
        }
    },
    
    onHostFieldChangeCmd: function (sender, newValue){
        
        if (_loadingData == false) {
            SaveConfig("host", newValue);
        }
    },
    
    onPortFieldChangeCmd: function (sender, newValue){
        
        if (_loadingData == false) {
            SaveConfig("port", newValue);
        }
    },
       
    onMobileDeviceIdFieldChangeCmd: function (sender, newValue){
        
        if (_loadingData == false) {
            SaveConfig("mobiledeviceid", newValue);
        }
    },
    
    onAccountIdFieldChangeCmd: function (sender, newValue){
        
        if (_loadingData == false) {
            SaveConfig("accountid", newValue);
        }
    },
    
    onLanguageChangeCmd: function (sender, newValue) {

        if (_loadingData == false) {
            SaveConfig("language", newValue);
        }
    },
    
    onDisplayPlannedHoursCmd: function (newValue) {
        
        if (_loadingData == false) {
            SaveConfig("displayPlannedHours", newValue);
            configs["displayPlannedHours"] = newValue;
        }
    },
    
    
    //Events
    launch: function () {

        this.callParent();
    },
    
    init: function () {
        
        this.callParent();
    },
    
    bindData: function() {
        _loadingData = true;
        
        //group by selector
        
        var groupByCtrl = Ext.getCmp('groupBySelector');
        var groupByStore = groupByCtrl.getStore();
                 
        var rec = groupByStore.getAt(configs["mainlistGroupField"]);
        groupByCtrl.setValue(rec.data.groupByField);
        
        //sort selector
        var sortCtrl = Ext.getCmp('sortSelector');
        var sortStore = sortCtrl.getStore();

        var rec = sortStore.getAt(configs["mainlistSortField"]);
        sortCtrl.setValue(rec.data.sortByField);
        
        //language selector
        Ext.getCmp('languageSelector').setValue(configs["language"]);
        
        //display planned hours check
        Ext.getCmp('displayPlannedHours').setChecked(configs["displayPlannedHours"]);
        
        Ext.getCmp('accountid').setValue(configs["accountid"]);
        Ext.getCmp('host').setValue(configs["host"]);
        Ext.getCmp('port').setValue(configs["port"]);
        Ext.getCmp('mobiledeviceid').setValue(configs["mobiledeviceid"]);
        
        _loadingData = false;
    }
});