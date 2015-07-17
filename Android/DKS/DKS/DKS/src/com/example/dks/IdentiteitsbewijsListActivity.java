package com.example.dks;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.Window;

public class IdentiteitsbewijsListActivity extends Activity {

	Database db = new Database(this);
	int gebruikerNr;
	public static Gebruiker chosenGebruiker;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_identiteitsbewijs_list);
		
		Bundle extras = getIntent().getExtras();
		if (extras != null) {
			gebruikerNr = (int)extras.getInt("gebruikerNr");
			chosenGebruiker = db.getGebruiker(gebruikerNr);
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.identiteitsbewijzen, menu);
		return true;	
	}
	
	@Override
	protected void onDestroy() {
	    super.onDestroy();
	    db.close();
	}
}
