package com.example.csi_week_2;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;
import android.util.Log;

public class CriminalsList extends Activity {
	 /** Called when the activity is first created. */
	
	@Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.criminals_list_activity);
        
        CriminalProvider criminalProvider = new CriminalProvider(this);

        criminalProvider.generateRandomCriminals(5);
        
        
        //Get a reference to the listview
        ListView listview = (ListView) findViewById(R.id.listviewCriminelen);
        List<Criminal> criminals = new ArrayList<Criminal>();
        criminals = criminalProvider.GetCriminals();

        CriminalListAdapter criminalListAdapter = new CriminalListAdapter(this, criminals);
        //Create an adapter that feeds the data to the listview
        listview.setAdapter(criminalListAdapter);
        
        listview.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position,
					long id) {
				// TODO Auto-generated method stub
				Intent intent = new Intent(CriminalsList.this, MainActivity.class);
				intent.putExtra("chosenCriminalPosition", position);
				startActivity(intent);
			}
        });
    }
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
}
