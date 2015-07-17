Ext.define("DksApp.store.Address", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.Address",

        sorters: [{ property: 'aw_id', direction: 'ASC'}]
    }
});