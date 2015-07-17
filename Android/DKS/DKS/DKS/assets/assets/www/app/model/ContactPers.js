Ext.define("DksApp.model.ContactPers", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'ctp_id',
        fields: [
            { name: 'ctp_id'         , type: 'int'    },
            { name: 'ctp_firstName'  , type: 'string' },
            { name: 'ctp_lastName'	, type: 'string' }
        ]
    }
});