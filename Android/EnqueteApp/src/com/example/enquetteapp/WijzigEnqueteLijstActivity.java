package com.example.enquetteapp;

import java.util.ArrayList;

import Classes.Database;
import Classes.Enquete;
import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.ListView;

public class WijzigEnqueteLijstActivity extends Activity implements View.OnClickListener{
	Database db = new Database(this);
	ListView listview;
	EnqueteLijstAdapter equeteLijstAdapter;
	Button addEnquete, terug;
	ArrayList<Enquete>enquetes;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_wijzig_enquete_lijst);
		
		addEnquete = (Button)findViewById(R.id.btn_addEnquete);
		addEnquete.setOnClickListener(this);
		terug = (Button)findViewById(R.id.btn_terug);
		terug.setOnClickListener(this);
		enquetes = db.getAlleEnquetes();
		
		//Get a reference to the listview
        listview = (ListView) findViewById(R.id.lv_wijzigEnquetes);
        
        equeteLijstAdapter = new EnqueteLijstAdapter(this, enquetes);
	    
        //Create an adapter that feeds the data to the listview
	    listview.setAdapter(equeteLijstAdapter);
	        
	    //Create an OnItemClickListener to get clicked item back from listview
	    listview.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position,
					long id) {
				Intent intent = new Intent(WijzigEnqueteLijstActivity.this, MaakEnqueteActivity.class);
				int enqueteNr = enquetes.get(position).getEnqueteNr();
				intent.putExtra("enqueteNr", enqueteNr);
				intent.putExtra("wijzigEnquete", true);
				startActivity(intent);
			}
	     });
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.wijzig_enquete_lijst, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub
		if(v==addEnquete){
			Intent intent = new Intent(this, MaakEnqueteActivity.class);
			db.addEnquete(new Enquete(0, null, null, null, null, null));
			int max = db.getMaxEnqueteNr();
			intent.putExtra("enqueteNr", max);
			startActivity(intent);
		}
		else if(v==terug){
			Intent intent = new Intent(this, MenuActivity.class);
			startActivity(intent);
		}
	}

}
