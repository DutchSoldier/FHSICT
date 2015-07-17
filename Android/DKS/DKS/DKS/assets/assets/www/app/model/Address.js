Ext.define("DksApp.model.Address", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'aw_id',
        fields: [
            { name: 'aw_id'         , type: 'int'    },
            { name: 'aw_street'     , type: 'string' },
            { name: 'aw_houseNumber', type: 'string' },
            { name: 'aw_zipCode'    , type: 'string' },
            { name: 'aw_city'       , type: 'string' },
            { name: 'aw_country'    , type: 'string' }
        ]
    }
});