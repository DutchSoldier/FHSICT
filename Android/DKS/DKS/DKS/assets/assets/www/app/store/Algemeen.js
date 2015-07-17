Ext.define("DksApp.store.Algemeen", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.InQueryElement",
        storeId: "Algemeen",
        sorters: [{ property: 'thd_id', direction: 'ASC'}]
    }
});