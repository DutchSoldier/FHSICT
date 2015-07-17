Ext.define("DksApp.model.TaskElement", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'the_id',
        fields: [
            { name: 'thd_id', type:'int'},
            { name: 'thd_group_id', type:'int'},
            { name: 'thd_inquery_text', type:'string'},
            { name: 'thd_answer_type', type:'int'},
            { name: 'thd_input_element', type:'int'},
            { name: 'thd_weighting', type:'int'},
            { name: 'thd_control', type:'string'},
            { name: 'the_id', type:'int'},
            { name: 'the_empty', type:'string'},
            { name: 'the_inquerynbr', type:'int'},
            { name: 'the_inqueryanswer', type:'int'},
            { name: 'the_document_id', type:'int'},
            { name: 'the_editstate', type: 'int'},
            { name: 'the_remark', type: 'string'},
            { name: 'the_who', type: 'string'},
            { name: 'the_date', type: 'string'},
            { name: 'iq_store_name', type:'string'},
            { name: 'iq_displayField', type:'string'},
            { name: 'iq_valueField', type:'string'},
            { name: 'ia_index', type:'int'}
            ]
    }
});