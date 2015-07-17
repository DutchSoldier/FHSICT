Ext.define("DksApp.store.SMG", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.IdVal",
        storeId: "SMG",
        sorters: [{ property: 'index', direction: 'ASC'}]
    }
});