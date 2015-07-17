Ext.define("DksApp.model.Ruimtes", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'rm_id',
        fields: [
            { name: 'rm_id'      , type: 'int' },
            { name: 'rm_naam'	  , type: 'string' },
            { name: 'rm_ruimtekind'	  , type: 'int' },
            { name: 'rm_project'	  , type: 'int' },
            { name: 'rm_document_id'   , type: 'int' },
            { name: 'rm_gecontroleerd'   , type: 'int' },
            { name: 'rm_aantelem', type:'int'},
            { name: 'rm_methode', type:'int'},
            { name: 'rm_vuil', type:'int'},
            { name: 'rm_periodiek', type:'int'}
        ]
    }
});