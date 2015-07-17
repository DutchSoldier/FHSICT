Ext.define("DksApp.store.NeeJa", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.IdVal",
        storeId: "NeeJa",
        sorters: [{ property: 'value', direction: 'ASC'}]
    }
});