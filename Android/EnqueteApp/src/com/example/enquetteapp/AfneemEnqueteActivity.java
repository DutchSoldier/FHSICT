package com.example.enquetteapp;

import java.util.ArrayList;

import Classes.Antwoord;
import Classes.Database;
import Classes.Vraag;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.Window;
import android.widget.Button;
import android.widget.ListView;

public class AfneemEnqueteActivity extends Activity implements OnClickListener{
	Database db = new Database(this);
	int enqueteNr;
	ArrayList<Vraag>vragen;
	ArrayList<Antwoord>antwoorden;
	ListView listview;
	Button klaar;
	AfneemEnqueteAdapter adapter;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_afneem_enquete);
		
		Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			enqueteNr = (int)extras.getInt("enqueteNr");
		}
		vragen = db.getAlleEnqueteVragen(enqueteNr);
		
		klaar = (Button)findViewById(R.id.btn_enqueteAf);
		klaar.setOnClickListener(this);
		
		//Get a reference to the listview
        listview = (ListView) findViewById(R.id.lv_enqueteVragen);
              
        adapter = new AfneemEnqueteAdapter(this, vragen);
		
		//Create an adapter that feeds the data to the listview
	    listview.setAdapter(adapter);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.afneem_enquete, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if(v==klaar){
			for(Vraag vr:vragen){
				antwoorden = db.getAlleVraagAntwoorden(vr.getVraagNr());
				for(Antwoord a:antwoorden){
					a.setSelected(false);
					db.updateAntwoord(a);
				}
			}
			Intent intent = new Intent(AfneemEnqueteActivity.this, MenuActivity.class);
			startActivity(intent);
		}
	}

}
