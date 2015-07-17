package com.example.enquetteapp;

import java.util.ArrayList;

import Classes.Database;
import Classes.Gebruiker;
import android.app.Activity;
import android.os.Bundle;
import android.view.Window;
import android.widget.ListView;

public class GebruikerLijstActivity extends Activity {
	Database db = new Database(this);
	ListView listview;
	ArrayList<Gebruiker>gebruikers;
	GebruikerAdapter adapter;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_gebruiker_lijst);
		if(db.getAlleGebruikers().size() > 0){
			gebruikers = db.getAlleGebruikers();
			listview = (ListView) findViewById(R.id.lv_gebruikers);
	        
			adapter = new GebruikerAdapter(this, gebruikers);
		    
	        //Create an adapter that feeds the data to the listview
		    listview.setAdapter(adapter);
		}	
	}
}
