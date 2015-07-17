Ext.define("DksApp.store.Ruimtesoort", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.Ruimtesoort",
        storeId: "Ruimtesoort",
        sorters: [{ property: 'rs_id', direction: 'ASC'}]
    }
});