Ext.define('DksApp.view.Relaties', {
 
    extend: 'Ext.Panel',
    alias: 'widget.relaties',
 
    config: {
        height: '50%',
        itemId: 'relaties',
        left: '5%',
        padding: 10,
        top: '0%',
        width: '40%',
        hideOnMaskTap: true,
        modal: true,
        items: [
            {
                xtype: 'list',
                height: '100%',
                itemTpl: 
                    '<div>Relatie</div>',
                store: 'Relaties',
                emptyText:'Lege lijst'
            }
        ]
    }
});