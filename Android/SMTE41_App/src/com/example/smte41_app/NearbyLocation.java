package com.example.smte41_app;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.StrictMode;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;

public class NearbyLocation extends Activity implements LocationListener {

	int maxDistance = 0;
	ArrayList<String> locationNames = new ArrayList<String>();
	List<Locations> locations = new ArrayList<Locations>();
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_nearby_location);

		final ListView list = (ListView)findViewById(R.id.listview_nearbylocations);
		locations = DataConnection.getLocations();
		final ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, locationNames);
		list.setAdapter(adapter);
		

		
		Spinner spinner = (Spinner) findViewById(R.id.distance_spinner);
		// Create an ArrayAdapter using the string array and a default spinner layout
		ArrayAdapter<CharSequence> distanceAdapter = ArrayAdapter.createFromResource(this,
		        R.array.distance_array, android.R.layout.simple_spinner_item);
		// Specify the layout to use when the list of choices appears
		distanceAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		// Apply the adapter to the spinner
		spinner.setAdapter(distanceAdapter);
		spinner.setOnItemSelectedListener(new OnItemSelectedListener() {
			@Override
			public void onItemSelected(AdapterView<?> arg0, View arg1,
					int position, long arg3) {
				// TODO Auto-generated method stub
				locationNames.clear();
		        switch (position) {
		        case 0: maxDistance = 50;
		        break;
		        case 1: maxDistance = 100;
		        break;
		        case 2: maxDistance = 250;
		        break;
		        case 3: maxDistance = 500;
		        break;
		        case 4: maxDistance = 1000;
		        break;
		        case 5: maxDistance = 2000;
		        break;
		        case 6: maxDistance = 5000;
		        break;
		        case 7: maxDistance = 10000;
		        	break;
		        }
				for(Locations loc : locations) {
					if(checkDistance(loc) < maxDistance) {
						locationNames.add(loc.name);
						System.out.println(loc.name);
					}
				}
				adapter.notifyDataSetChanged();
				list.setOnItemClickListener(new OnItemClickListener() {

					@Override
					public void onItemClick(AdapterView<?> arg0, View arg1, int arg2,
							long arg3) {
						// TODO Auto-generated method stub
						for(Locations loc : locations) {
							if(loc.name == (String)list.getItemAtPosition(arg2).toString()) {
								Intent intent = new Intent(NearbyLocation.this, LocationActivity.class);
								intent.putExtra("name", loc.name);
								intent.putExtra("description", loc.description);
								startActivity(intent);
							}
						}
					}
					
				});
		        System.out.println(Integer.toString(maxDistance));
			}

			@Override
			public void onNothingSelected(AdapterView<?> arg0) {
				// TODO Auto-generated method stub
				maxDistance = 50;
			}
		});


	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	private double checkDistance(Locations loc) {
		double distance = 0;
		LocationManager locManager = (LocationManager) getSystemService(LOCATION_SERVICE);
		locManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, NearbyLocation.this);
		
		Location myLocation = new Location(LocationManager.GPS_PROVIDER);
		Location otherLocation = new Location(LocationManager.GPS_PROVIDER);
		
		myLocation.setLongitude(locManager.getLastKnownLocation(LocationManager.GPS_PROVIDER).getLongitude());
		myLocation.setLatitude(locManager.getLastKnownLocation(LocationManager.GPS_PROVIDER).getLatitude());
		otherLocation.setLatitude(loc.getLocX());
		otherLocation.setLongitude(loc.getLocY());
		
		distance = myLocation.distanceTo(otherLocation);

		System.out.println("afstand naar " + loc.name + " is " + distance + " meter");
		return distance;
	}

	@Override
	public void onLocationChanged(Location location) {
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
