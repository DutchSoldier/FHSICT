Ext.define("DksApp.store.Workorders", {
    extend: "Ext.data.Store",

    config: {
        model: "DksApp.model.Workorder",

        //sorters: [{ property: 'wo_weekNo', direction: 'DESC'}],
        grouper: {
              sortProperty: GetSortField(configs["mainlistSortField"]),
              direction: "ASC",
              groupFn: function (record) {               
                      //if (configs["mainlistGroupField"] == 0)
                          return "Week: " + record.data.wo_weekNo;
                      //else
                      //    return record.data.wo_debtorName;
                                      
                  }
            }        
        }
    }
);