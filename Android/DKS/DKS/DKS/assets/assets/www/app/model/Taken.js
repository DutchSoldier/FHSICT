Ext.define("DksApp.model.Taken", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'tsk_id',
        fields: [
            { name: 'tsk_id'      , type: 'int' },
            { name: 'tsk_naam'	  , type: 'string' },
            { name: 'tsk_werknemer'	, type: 'int' },
            { name: 'tsk_project' , type: 'int' },
            { name: 'tsk_from'	  , type: 'date' },
            { name: 'tsk_until'	  , type: 'date' }
        ]
    }
});