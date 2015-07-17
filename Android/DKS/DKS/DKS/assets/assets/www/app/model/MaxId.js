Ext.define("DksApp.model.MaxId", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'maxid',
        fields: [
            { name: 'maxid' , type: 'int' }
        ]
    }
});