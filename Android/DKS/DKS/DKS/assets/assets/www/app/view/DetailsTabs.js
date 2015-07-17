Ext.define('DksApp.view.DetailsTabs', {
    extend: 'Ext.tab.Panel',
    alias: "widget.detailstabs",
    
    config: {
        activeTab: 0,
        tabBar: {
            ui: 'light',
            layout: {
                pack : 'center',
                align: 'center'
            },
            docked: 'bottom',
            height:'70px'
        },
        layout: 'card',
        fullscreen: true,
        scrollable: false,
        items: [
            {   xtype: 'detailstab_algemeen'
            },            
            {
                xtype: 'detailstab_info'
            }
        ]
}
}); 