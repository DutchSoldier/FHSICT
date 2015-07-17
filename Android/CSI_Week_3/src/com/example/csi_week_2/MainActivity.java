package com.example.csi_week_2;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.AdapterView.OnItemClickListener;

public class MainActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		CriminalProvider criminalProvider = new CriminalProvider(this);
		Bundle extras = getIntent().getExtras();
		int chosenCriminalPosition = 0;

		if (extras != null) {
			chosenCriminalPosition = (int)extras.getInt("chosenCriminalPosition");
		}

		ListView crimeListview = (ListView)findViewById(R.id.listviewCrimes);
		List<Crime> crimes = new ArrayList<Crime>();
		Criminal chosenCriminal = criminalProvider.GetCriminal(chosenCriminalPosition);
		for(Crime c : chosenCriminal.crimes) {
		crimes.add(c);
		}
		CrimeListAdapter cla = new CrimeListAdapter(this, crimes);
		crimeListview.setAdapter(cla);
		TextView nameTextview = (TextView)findViewById(R.id.nameTextview);
		TextView ageTextview = (TextView)findViewById(R.id.ageTextview);
		TextView genderTextview = (TextView)findViewById(R.id.genderTextview);
		TextView bountyTextview = (TextView)findViewById(R.id.bountyTextview);
		TextView descriptionTextview = (TextView)findViewById(R.id.descriptionTextview);
		ImageView mugshot = (ImageView)findViewById(R.id.mugshotImageview);
		nameTextview.setText(chosenCriminal.name);
		ageTextview.setText(Integer.toString(chosenCriminal.age));
		genderTextview.setText(chosenCriminal.gender);
		mugshot.setImageDrawable(chosenCriminal.mugshot);
		int bounty = 0;
		descriptionTextview.setText("Crimes: " + "\n");

		for(Crime c : chosenCriminal.crimes) {
				bounty += c.bountyInDollars;
			} 
		bountyTextview.setText("€" + bounty);
		

		
		Button b = (Button)findViewById(R.id.report);
		
		final Intent intent = new Intent(MainActivity.this, ReportActivity.class);
		intent.putExtra("chosenCriminalPosition", chosenCriminalPosition);
		
		b.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				startActivity(intent);
			}
		});
	}

	private TextView findByViewId(int nametextview) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	
}
