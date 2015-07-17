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
import android.widget.ListView;

public class ResultatenEnqueteLijstActivity extends Activity {
	Database db = new Database(this);
	ListView listview;
	EnqueteLijstAdapter enqueteLijstAdapter;
	ArrayList<Enquete> enquetes;
	Enquete enquete;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_resultaten_enquete_lijst);
		enquetes = db.getAlleEnquetes();
		//Get a reference to the listview
        listview = (ListView) findViewById(R.id.lv_resultatenEnquetes);
        
        enqueteLijstAdapter = new EnqueteLijstAdapter(this, enquetes);
	    
        //Create an adapter that feeds the data to the listview
	    listview.setAdapter(enqueteLijstAdapter);
	        
	    //Create an OnItemClickListener to get clicked item back from listview
	    listview.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position,
					long id) {
				enquete = enquetes.get(position);
				Intent intent = new Intent(ResultatenEnqueteLijstActivity.this, ResultatenActivity.class);
				intent.putExtra("chosenEnqueteposition", enquete.getEnqueteNr());
				startActivity(intent);
			}
	     });
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.resultaten_enquete_lijst, menu);
		return true;
	}

}
