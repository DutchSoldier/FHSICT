package com.example.smte41_app;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class SearchLocation extends Activity {


	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_search_location);
		final EditText searchField = (EditText)findViewById(R.id.edit_search);
		Button back = (Button)findViewById(R.id.back_button);
		back.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				finish();
			}
		});
		
		Button search = (Button)findViewById(R.id.search_button);
		search.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				
				Locations location = DataConnection.searchLocation(searchField.getText().toString());
				Intent intent = new Intent(SearchLocation.this, LocationActivity.class);
				intent.putExtra("name", location.name);
				intent.putExtra("description", location.description);
				startActivity(intent);
			}
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

}
