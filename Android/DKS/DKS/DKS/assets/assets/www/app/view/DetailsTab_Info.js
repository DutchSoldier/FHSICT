Ext.define("DksApp.view.DetailsTab_Info", {
    extend: "Ext.form.Panel",
    alias: "widget.detailstab_info",

    config: {
        itemId   : 'DetailsTabInfo',
        title    : 'Afspraken',
        iconCls  : 'info_plain',
        cls      : 'card',
        scrollable:false,
        items: [{
            xtype: 'fieldset',
            id: 'velden_info',
            items: [ 
                {
                xtype:  'panel',name: 'pnl_status',layout: 'vbox',height:'300px',
                items: [
                        {
                        	xtype:  'panel',name: 'pnl_status',layout: 'hbox',height:'50px',
                        	items:[        
                {xtype: 'textfield',name: 'txt_statusdoc',value: 'Status document :',readOnly:true, width:'50%',cls: 'color: white; background-color: grey;'},        
                {xtype: 'nocore_segbutton',name: 'status',id: 'status',store: 'DocState',btntext:'dtext',width:'50%'},
                	]},     
                { xtype: 'datepickerfield',label:'gereed datum',dateFormat:'d-m-Y',id:'txtReadyDate',name: 'wo_finishDate',readOnly:false,width:'50%',labelWidth:'25%'},
                
                {                               
                    xtype:  'panel',name: 'pnlGespreksonderwerpen',layout: 'vbox',height:'400px',
                    items: [  {xtype: 'textfield',name: 'textr9',height:'30px',labelWrap:true,value:'',labelWidth:'100%',label: 'Opmerkingen ',readOnly:true, width:'100%',cls: 'color: white; background-color: grey;'},
                              { xtype: 'textareafield', name: 'wo_remarks',id: 'wo_remarks',readOnly:false,width:'100%',labelWidth:'0%',maxRows:6},
                           ]                            
                 }
                ]},
                {xtype:'panel',layout:'hbox',
                items:[
                {xtype:'panel',layout:'vbox',width:'50%',
                	
                items:[
                { xtype:'signature',id:'signcanvascontroller',name: 'signcanvascontroller',layout: 'hbox',width:'100%',height:'320px',html: 'Handtekening Controleur<p><canvas id="signcanvascontroller_cv" width="300px" height="280px">no canvas support</canvas>', },
                { xtype:'button',text:'handtekening wissen',width:'70%',height:'40px',
                  listeners: {
                  tap: function(button,e){ 
                       //move this to an controller
                       sign = Ext.getCmp('signcanvascontroller');   
                       sign.clear();   
                      }
                  }
                }]},
                {xtype:'panel',layout:'vbox',width:'50%',
                	
                    items:[
                { xtype:'signature',id:'signcanvasklant',name: 'signcanvasklant',layout: 'hbox',width:'100%',height:'320px',html: 'Handtekening Opdrachtgever<p><canvas id="signcanvasklant_cv" width="300px" height="280px">no canvas support</canvas>', },
                { xtype:'button',text:'handtekening wissen',width:'70%',height:'40px',
                  listeners: {
                  tap: function(button,e){ 
                       //move this to an controller
                       sign = Ext.getCmp('signcanvasklant');   
                       sign.clear();   
                      }
                  }
                }
                
                
                ]}
                
                
                
                ]}
                
                
               ] // items (detailstab_info)
        }]}
});