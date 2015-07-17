window.canvasplugin = function(canparent,canvasEl,callback){
	canparent.findPos();
	var canvasProps = {
		mimeType: "image/png",
		xpos: canparent.posX+5,
		ypos: canparent.posY,
		width: canvasEl.width-5,
		height: canvasEl.height,
		screenWidth: window.innerWidth // no WebView.getContentWidth(), use this instead
	};

	//call the Plugin execute method()
	cordova.exec(callback,function(err){
		callback('Error: ' + err);	
	},"CanvasPlugin","toDataURL",[canvasProps.mimeType,
							canvasProps.xpos,
							canvasProps.ypos,
							canvasProps.width,
							canvasProps.height,
							canvasProps.screenWidth]);	
}