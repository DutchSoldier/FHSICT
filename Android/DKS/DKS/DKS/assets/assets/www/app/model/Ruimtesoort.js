Ext.define("DksApp.model.Ruimtesoort", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'rs_id',
        fields: [
            { name: 'rs_id'      , type: 'int' },
            { name: 'rs_naam'	  , type: 'string' }
        ]
    }
});