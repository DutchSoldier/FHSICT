package com.example.enquetteapp;

import java.util.ArrayList;

import Classes.Antwoord;
import Classes.Database;
import Classes.Enquete;
import Classes.Vraag;
import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.Window;
import android.widget.ListView;

public class ResultatenActivity extends Activity {
	Database db = new Database(this);
	ArrayList<Vraag>vragen;
	Enquete enquete;
	ArrayList<Antwoord>antwoorden;
	ResultatenAdapter adapter;
	int enqueteNr;
	ListView listview;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_resultaten);
		
		Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			enqueteNr = (int)extras.getInt("chosenEnqueteposition");
		}
		
		vragen = db.getAlleEnqueteVragen(enqueteNr);
		
		//Get a reference to the listview
        listview = (ListView) findViewById(R.id.lv_resultaten);
        
        adapter = new ResultatenAdapter(this, vragen);
	    
        //Create an adapter that feeds the data to the listview
	    listview.setAdapter(adapter);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.resultaten, menu);
		return true;
	}

}
