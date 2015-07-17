Ext.define("DksApp.store.Relaties", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.Relaties",
        storeId:"Relaties",
        sorters: [{ property: 'Nummer', direction: 'ASC'}]
    }
});