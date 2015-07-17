package com.example.csi_week_2;

import android.app.Activity;
import android.content.Context;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.Vibrator;
import android.view.Menu;
import android.view.View;
import android.widget.Button;

public class ReportActivity extends Activity implements LocationListener{
	
	Vibrator v = (Vibrator) getSystemService(Context.VIBRATOR_SERVICE);
	Criminal chosenCriminal;
	int chosenCriminalPosition;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.report_activity);
		CriminalProvider criminalProvider = new CriminalProvider(this);
		
		Bundle extras = getIntent().getExtras();

		if (extras != null) {
			chosenCriminalPosition = (int)extras.getInt("chosenCriminalPosition");
		}
		chosenCriminal = criminalProvider.GetCriminal(chosenCriminalPosition);
		
		Button b = (Button)findViewById(R.id.back);
		
		b.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				finish();
			}
		});
		
		LocationManager locationmanager = (LocationManager) getSystemService(LOCATION_SERVICE);
		locationmanager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 10, 250, this);
		
		
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
		double afstand;
		Location criminalLocation = null;
		criminalLocation.setLatitude(chosenCriminal.location.getLatitude());
		criminalLocation.setLongitude(chosenCriminal.location.getLongitude());
		Location myLocation = null;
		myLocation.setLatitude(arg0.getLatitude());
		myLocation.setLongitude(arg0.getLongitude());
		
		afstand = myLocation.distanceTo(criminalLocation);
		
		if(afstand < 100) {
			v.vibrate(500);
		}
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
