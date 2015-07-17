Ext.define("DksApp.store.InQuery1", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.InQueryElement",
        storeId: "InQuery1",
        sorters: [{ property: 'thd_id', direction: 'ASC'}]
    }
});