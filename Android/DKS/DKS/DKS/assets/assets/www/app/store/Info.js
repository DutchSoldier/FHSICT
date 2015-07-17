Ext.define("DksApp.store.Info", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.InQueryElement",
        storeId: "Info",
        sorters: [{ property: 'thd_id', direction: 'ASC'}]
    }
});