package com.example.shout;

import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.os.StrictMode;
import android.view.Menu;
import android.view.Window;
import android.view.WindowManager;

public class LoadActivity extends Activity {

	DatabaseHandler db = new DatabaseHandler(this);
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
		setContentView(R.layout.activity_load);
		StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
		StrictMode.setThreadPolicy(policy);
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_load);
		
		Thread splashThread = new Thread() {

            @Override
            public void run() {
              try {
                 int waited = 0;
                  while (waited < 3000) {
                        sleep(100);
                        waited += 100;
                          }
                      } 
                      catch (InterruptedException e) {
                          // do nothing
                      } 
                  finally {
                      finish();

                      
                      if(db.dataBaseEmpty() == true){
                    	  Intent intent = new Intent(LoadActivity.this, MakeProfileActivity.class);
                          startActivity(intent);  
                      }
                      else{
                          Intent intent = new Intent(LoadActivity.this, PublicChatActivity.class);
                          startActivity(intent);
                      }
                      }
                   }
                };
                splashThread.start();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.load, menu);
		return true;
	}

	@Override
	protected void onDestroy() {
	    super.onDestroy();
	    db.close();
	}
}
