package com.example.smte41_app;

import android.app.Activity;
import android.os.Bundle;
import android.os.StrictMode;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class LocationActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_location);
		TextView name = (TextView)findViewById(R.id.location_name);
		TextView description = (TextView)findViewById(R.id.description_loc);
		Bundle extras = getIntent().getExtras();
		name.setText(extras.getString("name"));
		description.setText(extras.getString("description"));
		
		Button back = (Button)findViewById(R.id.button_back);
		back.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				finish();
			}
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.location, menu);
		return true;
	}

}
