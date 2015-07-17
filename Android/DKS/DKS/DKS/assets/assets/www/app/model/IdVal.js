Ext.define("DksApp.model.IdVal", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'value',
        fields: [
            { name: 'index', type: 'int'},     
            { name: 'value'  ,type: 'int'    },
            { name: 'dtext'  , type: 'string' },
            { name: 'visible' , type: 'string' },
            { name: 'hvr', type: 'string'}
        ]
    }
});