Ext.define("DksApp.model.Workorder", {
    extend: "Ext.data.Model",
    config: {
        idProperty: 'wo_number',
        fields: [
            //fields filled by sync with the desktop
           
            { name: 'wo_number'         , type: 'int'    },
            { name: 'wo_debtorNumber'   , type: 'string' },
            { name: 'wo_debtorName'     , type: 'string' },
            { name: 'wo_projectNumber'  , type: 'string' },
            { name: 'wo_projectName'    , type: 'string' },
            { name: 'wo_startDate'      , type: 'date'  },
            { name: 'wo_startTime'      , type: 'date', dateFormat: 'g:i:s' },
            { name: 'wo_weekNo'         , type: 'int'    },
            { name: 'wo_hoursPlanned'   , type: 'int'    }, //displaying is optional !
            { name: 'wo_contactperson'  , type: 'string' },
            { name: 'WO_SMALLDESC'      , type: 'string'  },  
            //fields filled on the device            
            { name: 'wo_status'         , type: 'int' },
            //{ name: 'wo_signature', type: '????' }, //image type; to be sent over rest
            { name: 'wo_finishDate'     , type: 'date' },
            { name: 'wo_finishTime'     , type: 'date', dateFormat: 'g:i:s' },  
            { name: 'wo_hoursWorked'    , type: 'int'     },
            { name: 'wo_remarks'        , type: 'string'  },   
            { name: 'wo_signature'      , type: 'string'  },
            { name: 'wo_signklant'      , type: 'string'  },
            { name: 'wsq_id'            , type: 'int'     }, 
            { name: 'ds_description'    , type: 'string'  },
            { name: 'aw_street'         , type: 'string'  },
            { name: 'aw_houseNumber'    , type: 'string'  },     
            { name: 'aw_city'           , type: 'string'  }   
            
        ],
        //hasMany  : {model: 'Task', name: 'tasks'}        
    }
});