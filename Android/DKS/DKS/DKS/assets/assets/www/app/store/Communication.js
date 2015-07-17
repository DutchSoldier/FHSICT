Ext.define("DksApp.store.Communication", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.Communication",

        sorters: [{ property: 'cpc_id', direction: 'ASC'}]
    }
});