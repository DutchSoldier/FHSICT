package com.example.csi_week_2;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class CriminalsList extends Activity {
	public String name = "com.example.csi_week_2.name";
	 /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.criminals_list_activity);
        
        //Get a reference to the listview
        ListView listview = (ListView) findViewById(R.id.listviewCriminelen);
        //Get a reference to the list with names
        final String [] criminals = getResources().getStringArray(R.array.names);
        //Create an adapter that feeds the data to the listview
        listview.setAdapter(new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1, criminals));
        listview.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position,
					long id) {
				// TODO Auto-generated method stub
				name = criminals[position];
				Intent intent = new Intent(CriminalsList.this, MainActivity.class);
				intent.putExtra("name", name);
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
