Ext.define("DksApp.store.DocState", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.IdVal",
        storeId: "DocState",
        sorters: [{ property: 'index', direction: 'ASC'}]
    }
});