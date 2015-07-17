package com.example.dks;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.AdapterView.OnItemClickListener;

public class KwaliteitsverslagListActivity extends Activity  implements View.OnClickListener{

	Button options, refresh, download;
	Database db = new Database(this);
	ListView listview;
	KwaliteitsverslagListAdapter adapter;
	int gebruikerNr;
	public static Gebruiker chosenGebruiker;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_kwaliteitsverslag_list);
		
		Bundle extras = getIntent().getExtras();
		if (extras != null) {
			gebruikerNr = (int)extras.getInt("gebruikerNr");
			chosenGebruiker = db.getGebruiker(gebruikerNr);
		}
		
		download = (Button)findViewById(R.id.btn_download);
		options = (Button)findViewById(R.id.btn_options);
		refresh = (Button)findViewById(R.id.btn_refresh);
		
		download.setOnClickListener(this);		
		options.setOnClickListener(this); 
		refresh.setOnClickListener(this);
		
		//Get a reference to the listview
        listview = (ListView) findViewById(R.id.lv_kwaliteitverslagen);
        
        adapter = new KwaliteitsverslagListAdapter(this, db.getAlleGebruikerKwaliteitsverslagen(chosenGebruiker.getGebruikerNr()));
	    
        //Create an adapter that feeds the data to the listview
	    listview.setAdapter(adapter);
	        
	    //Create an OnItemClickListener to get clicked item back from listview
	    listview.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position,
					long id) {
				Intent intent = new Intent(KwaliteitsverslagListActivity.this, KwaliteitsverslagDetailsActivity.class);
				intent.putExtra("chosenKwaliteitsverslagPosition", position);
				startActivity(intent);
			}
	     });
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.kwaliteits_list, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if (v==download) {
			
		}		
		else if(v==options) {
			Intent intent = new Intent(this, OptionsActivity.class);
			startActivity(intent);
		}
		else if(v==refresh){
			listview = (ListView) findViewById(R.id.lv_workorders);        
			adapter = new KwaliteitsverslagListAdapter(this, db.getAllKwaliteitsverslagen());
		    listview.setAdapter(adapter);
		}
	}
	
	@Override
	protected void onDestroy() {
	    super.onDestroy();
	    db.close();
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
	    if ((keyCode == KeyEvent.KEYCODE_BACK)) {
	    	Intent intent = new Intent(this, AppMenuActivity.class);
			startActivity(intent);
	    }
	    return super.onKeyDown(keyCode, event);
	}
}