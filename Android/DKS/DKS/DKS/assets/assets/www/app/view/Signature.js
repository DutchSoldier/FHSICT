Ext.define('DksApp.view.Signature', {
           extend: 'Ext.Panel',
           alias : 'widget.signature',
           config: {
             title    : 'Handtekening',
             iconCls  : 'info_plain',
             cls      : 'card',
             //html: 'Handtekening<p><canvas id="signaturecanvas" width="50%" height="280px">no canvas support</canvas>',
             scroll:false,
             topview:this,
             style: {borderColor:'#00FF00', borderStyle:'solid', borderWidth:'2px', backgroundColor:'white'},
             listeners: {                 
                 drawCircleEvent: function(x,y){
                   this.drawCircle(x,y)
                    }
                  }
              },       
           layout:{
           type: 'vbox',
           pack: "center",
           align: "center"
           },
       	constructor: function(config)
    	{ 
    	  this.callParent([config]);
    	  //console.log(' canvas config : ',this.config);
    	},
    	applyTopview:function(newTopview,oldTopview){
    		//console.log('Set top view ');
    		//console.log(newTopview);
    		this.topview = newTopview;
    	},
    	updateTopview: function(newTopview,oldTopview){
    		//console.log('Apply top view ');
    		//console.log(newTopview);
    		this.topview = newTopview;
    	},   
        setupControl: function() {
          // console.log('setup');
           me = this;
           this.setupCanvas();  
           me.vertoffset = 0;
           me.canvas.ontouchstart = this.onhandleStartTouch;
           me.canvas.ontouchend = this.onhandleEndTouch;
           me.canvas.ontouchmove = this.onhandleMove;
           me.canvas.onmousemove = this.onhandleMouseMove;
           } ,
           
        setupCanvas:   function() {
           me = this;
           me.canvas = document.getElementById(me.id+'_cv');
           //console.log(me.canvas);
           me.ctx = me.canvas.getContext("2d");
           me.ctx.clearRect(0,0,300,250);
           coords = me.getCumulativeOffset(me.canvas,me.id);
           me.offsetX = coords.x;
           me.offsetY = coords.y;//+38;
        //   console.log('offset ; '+me.offsetX+' '+me.offsetY);
           this.drawBg();
           me.changed = false;
           },
           
       drawBg: function () {
          // me.ctx.strokeStyle = "rgb(55,55,255)";
          // me.ctx.beginPath();
          // me.ctx.moveTo(1, 1);
          // me.ctx.lineTo(me.width-1, 1);
          // me.ctx.stroke();
          // me.ctx.lineTo(me.width-1, me.height-1);
          // me.ctx.stroke();
          // me.ctx.lineTo(1, me.height-1);
          // me.ctx.stroke();
          // me.ctx.lineTo(1, 1);
          // me.ctx.stroke();
           //ctx.font = "36pt Arial";
           //ctx.fillStyle = "rgb(180,33,33)";
           //ctx.fillText("X", 10, 75);
           },
           
        drawCircle: function (x, y) {
           me = this;	
           me.ctx.strokeStyle = "rgb(55,55,255)";
           //me.canvas = document.getElementById(this.signatureid);
           me.ctx.beginPath();
           if (me.oldX && me.oldY) {
        	 //me.canvas = document.getElementById(this.signatureid);
        	 me.ctx.moveTo(me.oldX, me.oldY);
             me.ctx.lineTo(x, y);
             me.ctx.stroke();
             me.ctx.closePath();
       //    console.log(x+' '+y);
           }
           me.oldX = x;
           me.oldY = y;
           },
           
        loadCanvas: function (dataURL,delegate,object){
              me = this;
             // canvas = document.getElementById('signaturecanvas');
             // context = canvas.getContext("2d");
       
              // load image from data url
              if ((dataURL!='') && (dataURL!==undefined) && (dataURL!==null)){
                var imageObj = new Image();
                imageObj.onload = function() {
                me.ctx.drawImage(this, 0, 0);
                //console.log('onload image');
                //console.log(object);
                object.fireEvent(delegate, object, object);
                   };
                   //console.log('set image '+dataURL);
                imageObj.src = dataURL;
              } else
              {
            	object.fireEvent(delegate, object, object);  
              }	  
             // me.drawBg();
            },
           
         clear:function(){
             //console.log('clear canvas');
        	 me = this;
             me.ctx.clearRect(0,0,me.ctx.width,me.ctx.height);
             //me.canvas = document.getElementById(this.signatureid);
             me.canvas.width = me.canvas.width;
           },
           
         findPos: function(){       	 
             me = this;
             var obj = me.canvas;
             me.posX = obj.offsetLeft;
             me.posY = obj.offsetTop;
             while(obj.offsetParent){
               me.posX=me.posX+obj.offsetParent.offsetLeft;
               me.posY=me.posY+obj.offsetParent.offsetTop;
               if(obj==document.getElementsByTagName('body')[0]){break}
               else{obj=obj.offsetParent;}
              }
           },
           
         getCumulativeOffset: function (obj,parentid) {
            var left, top;
            left = top = 0;
            if (obj.offsetParent) {
            do {
              left += obj.offsetLeft;
              top  += obj.offsetTop;
             //console.log('cum offset '+obj.id+' '+obj.offsetLeft+' '+obj.offsetTop);
          //    } while ((obj = obj.offsetParent) && (obj.id!="signatureid"));
           } while ((obj = obj.offsetParent) && (obj.id!=parentid));
             left += obj.offsetLeft;
             top  += obj.offsetTop;
             //console.log('cum offset '+obj.id+' '+obj.offsetLeft+' '+obj.offsetTop);
           }
           return {
             x : left,
             y : top
              };
           },
           
         onhandleStartTouch:function(e){
        	 //console.log('touchstart');
        	 //console.log(e);
        	 // use trick to name canvas id the same as ext js component
        	 me = Ext.getCmp(e.srcElement.id.slice(0,-3));
        	 //console.log(me);
        	 var scrollable = me.topview.getScrollable();
        	 if (scrollable!==undefined){
        	   var scroller = scrollable.getScroller();
        	   if (scroller!==undefined){
                 me.vertoffset = scroller.position.y;             
                 scroller.setDisabled(true);
        	   }
        	 } 
           //console.log('vert offset '+me.vertoffset);
           },
           
        onhandleEndTouch:function(e){
           //console.log('touch end ');	
           //console.log(e);
        // use trick to name canvas id the same as ext js component
           me = Ext.getCmp(e.srcElement.id.slice(0,-3));
       	   //console.log(me);
           delete me.oldX;
           delete me.oldY;
           var scrollable = me.topview.getScrollable();
      	   if (scrollable!==undefined){
      	     var scroller = scrollable.getScroller();
      	     if (scroller!==undefined){
               scroller.setDisabled(false);
      	     }
      	   }
         },
           
        onhandleMouseMove:function (e) {
           var x = e.offsetX,
           y = e.offsetY;
        //   console.log('handlemousemove '+x+' '+y);
           //if (me.clicked){
           //me.drawCircle(x,y);
           //} 	
           },
           
          // onhandleTouchStart: function(e){
          //   me.up('detailstab_info');
          // console.log('touch start');
          // }
           
         onhandleMove: function(e){
           
           var x, y, i;
           //console.log(e);
           me = Ext.getCmp(e.srcElement.id.slice(0,-3));
           //var coords = me.getCumulativeOffset(me.canvas,me.id);
           //console.log(coords);
           //me.offsetX = coords.x;
           //me.offsetY = coords.y;
           
           me.findPos();           
           for (i = 0; i < e.targetTouches.length; i++) {
        	 me.changed = true;  
             var x = e.targetTouches[i].clientX - me.posX
             var y = e.targetTouches[i].clientY - me.posY + me.vertoffset;   
             //console.log('x:'+x+' '+e.targetTouches[i].clientX+' y:'+y+' '+e.targetTouches[i].clientY);
             me.drawCircle(x,y);           
           
           }
         }
           
           });