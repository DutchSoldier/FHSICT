Ext.define("DksApp.view.RuimtesView", {
    extend: "Ext.form.Panel",
    alias: "widget.ruimtesview",

    config: {
        //itemId   : 'DetailsTabRuimte',
        title    : 'Ruimtes',        
        fullscreen: true,
        layout: 'fit',
        
        scrollable: {
            direction: 'vertical',
            directionLock: false
        },    

        items: [ 
                	{
                		xtype: "toolbar",
                		docked: "top",
                		title: "Ruimte",
                		height:'70px',
                		items: [{xtype:'button',text:'gereed',id:"gereed",height:'50px'},
                		        {xtype: "spacer"},
                                {xtype:'button',text:'niet gereed',id:"nietgereed",height:'50px'}
                		]
                	},
                 {      xtype: 'panel',
            items: [                   
                    {xtype: 'nocore_elementen',id:'pnlElemRuimte',name:'pnlElemRuimte', layout :'vbox',height:'80%',useRemark:false,padding : '5px'}
                  ] // items (formpanel)

}],

listeners: [
          
            {
                delegate: "#gereed",
                event: "tap",
                fn: "onGereedTap"
            },{
                delegate: "#nietgereed",
                event: "tap",
                fn: "onNietGereedTap"
            }
        ]   },
        onGereedTap:function(){
        	var ruimtecontroller = _myAppGlobal.getController('Ruimtes');
        	ruimtecontroller.storeData(true);
        },
        onNietGereedTap:function(){
        	var ruimtecontroller = _myAppGlobal.getController('Ruimtes');
        	ruimtecontroller.storeData(false);
        }
,
applyTitle:function(newTitle,oldTitle){
	this.getAt(0).setTitle(newTitle);
},
updateTitle:function(newTitle,oldTitle){
	this.getAt(0).setTitle(newTitle);
}}
);



