/**
 * Created by Eclipse.
 * User: Calin
 * Date: 10.02.2012
 * Time: 13:26
 */

(function() {
  var callbacks, root, counter, cbref, getOptions;
 
  root = this;
  callbacks = {};
  counter = 0;   
  
  cbref = function(hash) {
    var f;
    f = "cb" + (counter += 1);
    callbacks[f] = hash;
    return f;
  };
  
  getOptions = function(opts, success, error) {
    var cb, has_cbs;
    cb = {};
    has_cbs = false;
    
    if (typeof success === "function") {
      has_cbs = true;
      cb.success = success;
    }
    if (typeof error === "function") {
      has_cbs = true;
      cb.error = error;
    }
    if (has_cbs) {
      opts.callback = cbref(cb);
    }
    
    return opts;
  };  
              
  root.DataAccessPlugin = (function() {
                         
    DataAccessPlugin.prototype.openDBs = {};
    
    //js plugin constructor:
    //  dbOptions[0] = string = database name 
    //  dbOptions[1] = boolean = if the database does not exists this flag will to tell the native code to copy the database from resource folder to project douments. If the database does exists, this flag doesnt do anything
    //    
    function DataAccessPlugin(dbOptions, openSuccess, openError) {
               
      this.dbPath = dbOptions[0];
      this.openSuccess = openSuccess;
      this.openError = openError;
                         
      if (!dbOptions[0]) {
        throw new Error("Cannot create a DataAccessPlugin instance without a dbPath");
      }
                         
      this.openSuccess || (this.openSuccess = function() {
        console.log("DB opened: " + dbPath);
      });
                         
      this.openError || (this.openError = function(e) {
        console.log(e.message);
        throw new Error(e.message);

      });
                         
      this.open(dbOptions, this.openSuccess, this.openError);
    }
                         
    DataAccessPlugin.handleCallback = function(ref, type, obj) {
      var _ref;
                         
      if ((_ref = callbacks[ref]) != null) {
        if (typeof _ref[type] === "function") {
          _ref[type](obj);
        }
      }
                         
      callbacks[ref] = null;
                         
      delete callbacks[ref];
    };
                                                  
    DataAccessPlugin.prototype.executeSql = function(message, success, error) {
            var opts = getOptions({
                        query: [].concat(message || [])
              }, success, error);
              
        //Cordova.exec("DataAccessPlugi.executeSql", opts);     
		Cordova.exec(success, error, "DataAccessPlugin", "executeSql", message);
    };
    
    
    DataAccessPlugin.prototype.execBatch = function(message, success, error) {
            var opts = getOptions({
                        query: [].concat(message || [])
              }, success, error);
              
        //Cordova.exec("DataAccessPlugi.executeSql", opts);     
		Cordova.exec(success, error, "DataAccessPlugin", "execBatch", message);
    };
                           
    DataAccessPlugin.prototype.logtoserver = function(message, success, error) {
                                           console.log('logtoserver'+opts); 
        var opts = getOptions({
                        logmessage: [].concat(message || [])
                              }, success, error);
                             
        Cordova.exec("DataAccessPlugin.logtoserver", opts);         
    };                           
                           
    DataAccessPlugin.prototype.SynchronizeDB = function(message, success, error) {                     
      var opts = getOptions({
                    datasets: [].concat(message || [])
          }, success, error);
                           
      //Cordova.exec("DataAccessPlugin.SynchronizeDB", opts);          
        console.log("sync");                   
        Cordova.exec(success, error, "DataAccessPlugin", "synchronise", message);
   };  
                           
    DataAccessPlugin.prototype.Upload = function(message, success, error) {             
      var opts = getOptions({
                         datasets: [].concat(message || [])
                            }, success, error);          
        //Cordova.exec("DataAccessPlugin.loadData", opts);
		Cordova.exec(success, error, "DataAccessPlugin", "upload", message);                         
    }; 
                         
    DataAccessPlugin.prototype.open = function(dbOptions, success, error) {
      
      if (!(this.dbPath in this.openDBs)) {
        this.openDBs[this.dbPath] = true;
                         
		Cordova.exec(success, error, "DataAccessPlugin", "openDb", dbOptions);
      }
    };
                      
    DataAccessPlugin.prototype.close = function(success, error) {
                         
      if (this.dbPath in this.openDBs) {
        delete this.openDBs[this.dbPath];
                         
        //Cordova.exec("DataAccessPlugin.close", opts);
      }
    };
                           
	DataAccessPlugin.prototype.loadData = function(message, success, error) {

	    var opts = getOptions({
                        query: [].concat(message || [])
              }, success, error);
                 
        //Cordova.exec("DataAccessPlugin.loadData", opts);
		Cordova.exec(success, error, "DataAccessPlugin", "loadData", message); 
	};
	
	DataAccessPlugin.prototype.SynchroniseDB = function(message, success, error) {
	    var opts = getOptions({
                        query: [].concat(message || [])
              }, success, error);
                 
        //Cordova.exec("DataAccessPlugin.loadData", opts);
		Cordova.exec(success, error, "DataAccessPlugin", "synchronise", message); 
	};
	
	DataAccessPlugin.prototype.displayToast = function(message, success, error) {
		Cordova.exec(success, error, "DataAccessPlugin", "displayToast", [message]);
	};
                         
    return DataAccessPlugin;
  })();
 
}).call(this);
