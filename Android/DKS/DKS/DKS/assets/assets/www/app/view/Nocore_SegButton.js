Ext.define("DksApp.view.Nocore_SegButton",{   
	extend:"Ext.SegmentedButton",
	alias: "widget.nocore_segbutton",	
	setupDone: false,
	indexSet: -1,
	indexGet: -1,
	valueSet:null,
	valueGet:null,
	config:{
       pressedCls: 'PressedRedCls',
       allowMultiple: false,
	   height:'100%',
	   state:null,
	   store:null,
	   multiselect:false,
	   btntext:null
    },
	constructor: function(config)
	{ 
	  this.callParent([config]);
	},
	setupControl : function(aStr,btn,cntrl,callback){
	   var me=this;
	   if (me.setupDone!=true){
	   me.store=aStr;
	   var bitems = me.getItems();
       var ln = bitems.length;
       //console.log("Segmented control "+this.name+" length : "+ln);
       var astore = Ext.getStore(aStr);
       var cnt = astore.getCount();
       //console.log(aStr+' length : '+cnt);
	   if (ln!=cnt) {
         if (astore && btn){   
           var viscnt = 0; 
           //console.log("test 1");
           for(var i=0;i<cnt;i++){ 
        	   mdl = astore.getAt(i);
        	   var vis = mdl.get('visible'); 
        	   if (vis=='true'){ 
      	           viscnt++;
               }
           }
        	 
	       var btnwidth = 100 / viscnt;
	       //console.log("Test 2");
	       for(var i=0;i<cnt;i++){     
             mdl = astore.getAt(i);   
             //console.log("" + mdl.get('visible'));
             var vis = mdl.get('visible');
             if (vis=='true'){ 
               //console.log("insert button");
	           this.insert(i,{text: mdl.get(btn),height:'40px',width:btnwidth.toString()+'%',id:cntrl+i.toString()});
             }
	       }  
	   //    this.applyItems();
	     } else
	     {
	      console.log('Store not definied '+this.getStore()+' '+this.btntext);
	     }
	   }
	   if(callback!=null){
	     me.addListener('toggle',callback);
	   }
	   //console.log("Segmented control "+this.name+" done");
	   me.setupDone = true;
	   }
	}
	,
	setState: function(astate,avalue,emp,editstate){
	  //console.log("Segmented control set state "+this.name+" enter");		
      var me = this;		
	  me.state = astate;
	  me.pressedButtons = [];
	  var i=-1;
	  if ((astate>-1)&&(emp=='1')&&(editstate!=4)){	    
	    do {
	      i++;    
	    }
	    while ((i!=me.state)&&(i<this.items.items.length));
        me.pressedButtons[0]=this.items.items[i];        
      } 
	  me.indexSet = i;
	  me.setPressedButtons(me.pressedButtons); 
	  if (me.pressedButtons==[]){
		  me.valueSet = null;
	  } else
	  {
		  me.valueSet = avalue;
	  }	  
	  //console.log("Segmented control set state "+this.name+" exit");	
	},
	setStateMultiple: function(astate,emp,editstate){
		//console.log("Segmented control set state multiple "+this.name+" enter");		
      var me = this;		
	  me.state = astate;
	  me.pressedButtons = [];
	  var i=-1;
	  var j=0;
	  
	  //if (astate!==undefined){
	  //  console.log('state '+astate.toString());
	  //}
	  
	  if ((astate>-1)&&(emp=='1')&&(editstate!=4)){	    
	    do {
	      i++;    
	      if (me.state&(1 << i)){
	    	  me.pressedButtons[j]=this.items.items[i];
	    	  //console.log('pressed buttons '+me.pressedButtons[j]);
	    	  j++;
	      }
	    }
	    while (i<this.items.items.length);              
      } 
      //console.log('all '+me.pressedButtons);
	  me.setPressedButtons(me.pressedButtons); 
	  if (me.pressedButtons==[]){
		  me.valueSet = null;
	  } else
	  {
		  me.valueSet = astate;
	  }	  
	  //console.log("Segmented control set state multiple "+this.name+" exit");	
	},
	getState: function(){
	  var me = this;
	  var arr = me.getPressedButtons();
	  var i = -1;
	  //console.log(this.items.items.length+" "+items);
	  xxx = this;
	  //console.log("Pressedbutton "+arr[0]);
	  if (arr[0]) {	    	   
	    do {
	      i++;    
	      //console.log("Pressedbutton "+this.items.items[i].id+' '+arr[0]);
	      //console.log(arr[0]);
	    }
	    while ((this.items.items[i]!=arr[0])&&(i<this.items.items.length));
	    me.indexGet = i;
	    var astore=Ext.getStore(me.store);
	    var cnt = astore.getCount();
	    var j = -1;
	    var mdl = null;
	    if (cnt!=0){
	    	var idx;	
	    	do {
	    		j++;
	    		mdl = astore.getAt(j);
	    		if (mdl!==undefined){
	    			idx = mdl.get('index');
	    		}else
	    		{   idx = j;
	    			//console.log(me.store +' has empty index');
	    		}
	    	} while ((idx!=i) && (j<cnt));
	    } //else
	    //{
	    //  console.log('Segbuttom : store is empty');	
	    //}
	    if (j<cnt){
	      //console.log('value found '+mdl.get('value'));
	      me.valueGet = mdl.get('value');	
	      return mdl.get('value');//arr[0].id;
	    } else
	    {   me.valueGet = null;
	    	return -1; }	
	  } else
	  { me.valueGet = null;
	    return -1;
	  }}
	,
	  getStateMultiple: function(){
		  var me = this;
		  var arr = me.getPressedButtons();
		  var i = -1;
		  //console.log('Get state multiple '+arr);
		  //xxx = this;
		  //console.log("Pressedbutton "+arr[0]);
		  var val=0;
		 
		  for (var j=0;j<arr.length;j++){			  
			  i = -1;
			  if (arr[j]) {	    	   
			    do {
			      i++;    
			      if (this.items.items[i]==arr[j]){
			    	  val = val | (1 << i); 
			    	  //console.log('Val orred '+val.toString());
			      }
			    }
			    while (i<this.items.items.length);		    
			  }  
		  }		  
		 
		  return val;
	}
});