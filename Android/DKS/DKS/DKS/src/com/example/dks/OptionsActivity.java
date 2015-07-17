package com.example.dks;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;

public class OptionsActivity extends Activity implements View.OnClickListener{

	Button runQuery, loadData;
	Database db = new Database(this);
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_options);
		
		String[] items = new String[] {"Weeknummer", "Debiteur"};
		Spinner spinnergroeperen = (Spinner) findViewById(R.id.sp_groeperen);
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
		            android.R.layout.simple_spinner_item, items);
		adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinnergroeperen.setAdapter(adapter);
		
		Spinner spinnersorteren = (Spinner) findViewById(R.id.sp_sorteren);
		spinnersorteren.setAdapter(adapter);
		
		String[] items2 = new String[] {"Dutch", "English"};
		Spinner spinnertaal = (Spinner) findViewById(R.id.sp_taal);
		ArrayAdapter<String> adapter2 = new ArrayAdapter<String>(this,
		            android.R.layout.simple_spinner_item, items2);
		adapter2.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinnertaal.setAdapter(adapter2);
		
		runQuery = (Button)findViewById(R.id.btn_runQuery);		
		loadData = (Button)findViewById(R.id.btn_loadData);
				
		runQuery.setOnClickListener(this); 
		loadData.setOnClickListener(this);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if (v==runQuery) {

		}
		else if(v==loadData){

		}
	}
	
	@Override
	protected void onDestroy() {
	    super.onDestroy();
	    db.close();
	}
}
