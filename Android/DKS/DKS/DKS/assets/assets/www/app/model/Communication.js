Ext.define("DksApp.model.Communication", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'cpc_id',
        fields: [
            { name: 'cpc_id' , type: 'int'    },            
            { name: 'cpc_is_id'	, type: 'int' },
            { name: 'cpc_contactPersId'	, type: 'int' },
            { name: 'cpc_workorder_id' , type: 'int'},
            { name: 'cpc_communicationId'  , type: 'string' }
        ]
    }
});