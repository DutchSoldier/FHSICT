package com.example.dks;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.Button;

public class ControleListActivity extends Activity implements View.OnClickListener{

	Button download, options, refresh;
	Database db = new Database(this);
	int gebruikerNr;
	public static Gebruiker chosenGebruiker;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_controle_list);
		
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
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.controle_list, menu);
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

		}
	}
	
	@Override
	protected void onDestroy() {
	    super.onDestroy();
	    db.close();
	}
}
