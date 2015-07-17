Ext.define("DksApp.store.Afspraken", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.TaskElement",
        //storeId: "Afspraken",
        sorters: [{ property: 'thd_id', direction: 'ASC'}]
    }
});