package com.example.smte41_app;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.view.Menu;
import android.view.View;
import android.widget.Button;

public class MainActivity extends Activity implements View.OnClickListener {

	Button newlocation, nearbylocation, searchlocation;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		newlocation = (Button)findViewById(R.id.new_location);
		nearbylocation = (Button)findViewById(R.id.nearby_location);
		searchlocation = (Button)findViewById(R.id.search_location);
		
		newlocation.setOnClickListener(this); 
		
		nearbylocation.setOnClickListener(this); 

		searchlocation.setOnClickListener(this);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}


	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub
		if (v==newlocation) {
			Intent intent = new Intent(this, NewLocation.class);
			startActivity(intent);
		}
		
		else if(v==nearbylocation) {
			Intent intent = new Intent(this, NearbyLocation.class);
			startActivity(intent);
		}
		else if(v==searchlocation){
			Intent intent = new Intent(this, SearchLocation.class);
			startActivity(intent);
		}
	}
	
}
