Ext.define("DksApp.store.InfoData", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.InQueryElement",
        storeId: "InfoData",
        sorters: [{ property: 'thd_id', direction: 'ASC'}]
    }
});