Ext.define("DksApp.store.Ruimtes", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.Ruimtes",
        storeId: "Ruimtes",
        sorters: [{ property: 'rm_id', direction: 'ASC'}]
    }
});