Ext.define("DksApp.store.Elementen", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.InQueryElement",
        storeId: "Elementen",
        sorters: [{ property: 'thd_inquery_text', direction: 'ASC'}]
    }
});