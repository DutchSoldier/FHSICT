Ext.define("DksApp.store.DKS", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.IdVal",
        storeId: "DKS",
        sorters: [{ property: 'index', direction: 'ASC'}]
    }
});