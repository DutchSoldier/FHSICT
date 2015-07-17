package com.example.enquetteapp;

import Classes.Database;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.Button;

public class MenuActivity extends Activity implements View.OnClickListener{
	Button doeEnquete, maakWijzigEnquete, resultatenEnquete, gebruikers;
	Database db = new Database(this);

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_menu);
		
		doeEnquete = (Button)findViewById(R.id.btn_doeEnquete);
		maakWijzigEnquete = (Button)findViewById(R.id.btn_wijzigEnquete);
		resultatenEnquete = (Button)findViewById(R.id.btn_resultatenEnquete);
		gebruikers = (Button)findViewById(R.id.btn_gebruikers);
		doeEnquete.setOnClickListener(this);
		maakWijzigEnquete.setOnClickListener(this);
		resultatenEnquete.setOnClickListener(this);	
		gebruikers.setOnClickListener(this);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.menu, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		Intent intent;
		
		if (v==doeEnquete) {
			intent = new Intent(this, AfneemEnqueteLijstActivity.class);
			startActivity(intent);
		}		
		else if(v==maakWijzigEnquete){
			intent = new Intent(this, WijzigEnqueteLijstActivity.class);
			startActivity(intent);
		}	
		else if(v==resultatenEnquete){
			intent = new Intent(this, ResultatenEnqueteLijstActivity.class);
			startActivity(intent);
		}
		else if(v==gebruikers){
			intent = new Intent(this, GebruikerLijstActivity.class);
			startActivity(intent);
		}
	}
}
