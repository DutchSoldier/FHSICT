Ext.define("DksApp.view.DetailsTab_Algemeen", {
    extend: "Ext.form.Panel",
    alias: "widget.detailstab_algemeen",

    config: {
        itemId   : 'DetailsTabAlgemeen',
        title    : 'Details',
        iconCls  : 'organize',
        cls      : 'card',
        
        scrollable: {
            direction: 'vertical',
            directionLock: false
        },    

        items: [ {      xtype: 'fieldset',
            items: [
                    {                               
                    	xtype:  'panel',name: 'pnldebtor',layout: 'hbox',
                    	items: [
								    { xtype: 'textfield',label:'Debiteurnr', name: 'wo_debtorNumber',readOnly:true,width:'35%',labelWidth:'50%'},
								    { xtype: 'textfield',label:'Debiteurnaam',name: 'wo_debtorName',readOnly:true,width:'65%'}
								]                            
								    },
								{                               
								xtype:  'panel',name: 'pnlproject',layout: 'hbox',
								items: [
								    { xtype: 'textfield',label:'Projectnr', name: 'wo_projectNumber',readOnly:true,width:'35%',labelWidth:'50%'},
								    { xtype: 'textfield',label:'Projectnaam',name: 'wo_projectName',readOnly:true,width:'65%'}
								]                            
								    }, 
								{                               
								xtype:  'panel',name: 'pnlcontactpers',layout: 'hbox',
								items: [
								        { xtype: 'textfield',label:'Telefoonnr', name: 'cpc_communicationId',id:'cpc_communicationId',readOnly:true,width:'35%',labelWidth:'50%'},
								{ xtype: 'textfield',label:'Contactpers',name: 'wo_contactperson',id: 'wo_contactperson',readOnly:false,width:'65%'}
								]                            
								    },          
								
								{                               
								xtype:  'panel',name: 'pnladres',layout: 'hbox',
								items: [
								{ xtype: 'textfield',label:'Week', name: 'wo_weekNo',readOnly:true,width:'35%',labelWidth:'50%'} ,       
								{ xtype: 'textfield',label:'straat', name: 'aw_street',id: 'aw_street',readOnly:true,width:'65%'}
								]                            
								    },  
								{                               
								xtype:  'panel',name: 'pnladresp',layout: 'hbox',
								items: [
								{ xtype: 'textfield',label:'postcode',name: 'aw_zipCode',id: 'aw_zipCode',readOnly:true,width:'35%',labelWidth:'50%'},
								{ xtype: 'textfield',label:'plaats',name: 'aw_city',id: 'aw_city',readOnly:true,width:'65%'}
								]                            
								    } 
								]},
                       { xtype: 'panel',
                        items: [
                            {xtype: 'nocore_elementen',id:'pnlElementen',name:'pnlElementen', layout :'vbox',height:'180px',useRemark:false},
                            { xtype: 'panel',height:'45px',layout:'hbox',
                              items: [{xtype: 'textfield',name: 'lblRuimtes0',labelWrap:true,value:'',labelWidth:'100%',label: ' ',readOnly:true, width:'8%',cls: 'color: white; background-color: grey;'},                                      
                                      {xtype: 'textfield',name: 'lblRuimtes1',labelWrap:true,value:'',labelWidth:'100%',label: 'Ruimte ',readOnly:true, width:'30%',cls: 'color: white; background-color: grey;'},
                                      {xtype: 'textfield',name: 'lblRuimtes2',labelWrap:true,value:'',labelWidth:'100%',label: 'Ruimtesoort ',readOnly:true, width:'30%',cls: 'color: white; background-color: grey;'},
                                      {xtype: 'textfield',name: 'lblRuimtes3',labelWrap:true,value:'',labelWidth:'100%',label: 'Gecontroleerd ',readOnly:true, width:'20%',cls: 'color: white; background-color: grey;'},
                                      
                                      {xtype: 'button',name:'btnAddRuimte',id:'btnAddRuimte',width:'8%',text:' + ',
                                    	  listeners:{tap:function(){
                                    		           var rm= Ext.getCmp('pnlRuimtes');
                                    		           rm.addItem();
                                    		        }
                                        }
                                      }
                                      ]
                            },
                            {xtype: 'nocore_ruimtes',id:'pnlRuimtes',name:'pnlRuimtes', layout :'vbox',height:'400px'}
                                                        
                                ] // items (fieldset)
                    }] // items (formpanel)

}
});