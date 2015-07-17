package com.example.enquetteapp;

import Classes.Database;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.view.Menu;
import android.view.Window;

public class LoadActivity extends Activity {
	Database db = new Database(this);

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_load);
		
		StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
		StrictMode.setThreadPolicy(policy);
		super.onCreate(savedInstanceState);
		
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

                          Intent intent = new Intent(LoadActivity.this, MenuActivity.class);
                          startActivity(intent);

                      }
                   }
                };
                splashThread.start();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.menu, menu);
		return true;
	}

}
