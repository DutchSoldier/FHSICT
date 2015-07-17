Ext.define("DksApp.store.JaNee", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.IdVal",
        storeId: "JaNee",
        sorters: [{ property: 'index', direction: 'ASC'}]
    }
});