Ext.define("DksApp.model.Relaties", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'id',
        fields: [
            { name: 'id'      , type: 'int' },
            { name: 'Nummer'  , type: 'int' },
            { name: 'Naam'	  , type: 'string' },
            { name: 'Zoeknaam', type: 'string' }
        ]
    }
});