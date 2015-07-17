package com.example.smte41_app;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.StrictMode;
import android.provider.MediaStore;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;


public class NewLocation extends Activity implements LocationListener{	
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_new_location);


		final EditText name = (EditText)findViewById(R.id.edit_name);
		final EditText description = (EditText)findViewById(R.id.edit_description);

		
		Button cancel = (Button)findViewById(R.id.cancel);
		ImageButton photo = (ImageButton)findViewById(R.id.photo_button);
		Button save = (Button)findViewById(R.id.save_location);

		
		cancel.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				finish();
			}
		});
		
		photo.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
			    Intent takePictureIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
			    startActivityForResult(takePictureIntent, 1);
			}
		});
		

		
		save.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				LocationManager locManager = (LocationManager) getSystemService(LOCATION_SERVICE);
				locManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, NewLocation.this);
				DataConnection.saveNewLocation(name.getText().toString(), description.getText().toString(), locManager.getLastKnownLocation(LocationManager.GPS_PROVIDER).getLongitude() , locManager.getLastKnownLocation(LocationManager.GPS_PROVIDER).getLatitude());
				
				AlertDialog.Builder alert = new AlertDialog.Builder(NewLocation.this);
				alert.setTitle("Great succes!");
				alert.setPositiveButton("mooi!", new DialogInterface.OnClickListener() {
					
					@Override
					public void onClick(DialogInterface dialog, int which) {
						// TODO Auto-generated method stub
						finish();
					}
				});
				alert.show();
			};

				
			

		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onLocationChanged(Location arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onProviderDisabled(String provider) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onProviderEnabled(String provider) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onStatusChanged(String provider, int status, Bundle extras) {
		// TODO Auto-generated method stub
		
	}
}
