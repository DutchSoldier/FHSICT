Ext.define("DksApp.model.InQuery", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'iq_id',
        fields: [
            { name: 'iq_id', type:'int'},
            { name: 'iq_store_name', type:'string'},
            { name: 'iq_model_name', type:'string'},
            { name: 'iq_displayField', type:'string'},
            { name: 'iq_valueField', type:'string'},
            { name: 'sort_direction', type:'string'},
            { name: 'sort_property', type:'string'}
            ]
    }
});