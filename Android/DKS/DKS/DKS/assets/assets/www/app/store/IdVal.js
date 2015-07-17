Ext.define("DksApp.store.IdVal", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.IdVal",
        storeId: "Idval",
        sorters: [{ property: 'index', direction: 'ASC'}]
    }
});