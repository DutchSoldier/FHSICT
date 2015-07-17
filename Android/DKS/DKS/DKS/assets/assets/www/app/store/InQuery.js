Ext.define("DksApp.store.InQuery", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.InQuery",
        storeId: "InQuery",
        sorters: [{ property: 'iq_id', direction: 'ASC'}]
    }
});