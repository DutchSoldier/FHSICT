Ext.define("DksApp.view.DetailsView", {
    extend: "Ext.form.Panel",
    alias: "widget.detailsview",
  
    config: {             
        fullscreen: true,
        layout: 'fit',
        scrollable:false,
        items: [
            {
                id: "detailsViewToolbar",
                xtype: "toolbar",
                docked: "top",
                //title: GetLocaleString("Workorder") + " wo. number",
                height:'70px',
                defaults: {
                    iconMask: true,
                    ui: "plain"
                },                 
                items: [{
                    xtype: "button",
                    iconCls:"list",
                    id: "btnBackToList",
                    height:'60px',
                    width:'60px'
                }]
            },
            {
                xtype: 'detailstabs'
            }
        ],
        listeners: [
                    {
                        delegate: "#btnBackToList",
                        event: "tap",
                        fn: "onBackToListTap"
                    }
                ]      
    },
    onBackToListTap: function () {
        this.fireEvent("backToListCmd", this);
    }  
}); 