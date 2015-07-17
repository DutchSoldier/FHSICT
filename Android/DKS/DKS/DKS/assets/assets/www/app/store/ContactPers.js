Ext.define("DksApp.store.ContactPers", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.ContactPers",

        sorters: [{ property: 'cpt_id', direction: 'ASC'}]
    }
});