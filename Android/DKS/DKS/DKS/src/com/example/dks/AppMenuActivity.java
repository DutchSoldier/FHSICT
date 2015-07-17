package com.example.dks;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.Button;

public class AppMenuActivity extends Activity implements View.OnClickListener{

	Button werkbonlijst, idlijst, kwaliteitslijst, bezoekverslagenlijst, controleslijst;
	Database db = new Database(this);
	int gebruikerNr;
	public static Gebruiker chosenGebruiker;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_app_menu);
		
		werkbonlijst = (Button)findViewById(R.id.btn_werkbonlijst);
		idlijst = (Button)findViewById(R.id.btn_idlijst);
		kwaliteitslijst = (Button)findViewById(R.id.btn_kwaliteitslijst);
		bezoekverslagenlijst = (Button)findViewById(R.id.btn_bezoekverslagenlijst);
		controleslijst = (Button)findViewById(R.id.btn_controleslijst);
		werkbonlijst.setOnClickListener(this);		
		idlijst.setOnClickListener(this); 
		kwaliteitslijst.setOnClickListener(this);
		bezoekverslagenlijst.setOnClickListener(this);
		controleslijst.setOnClickListener(this);
		
		Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			gebruikerNr = (int)extras.getInt("gebruikerNr");
			chosenGebruiker = db.getGebruiker(gebruikerNr);
		}	
		
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if (v==werkbonlijst) {
			Intent intent = new Intent(this, WerkbonListActivity.class);
			intent.putExtra("gebruikerNr", chosenGebruiker.getGebruikerNr());
			startActivity(intent);
		}		
		else if(v==idlijst) {
			Intent intent = new Intent(this, IdentiteitsbewijsListActivity.class);
			intent.putExtra("gebruikerNr", chosenGebruiker.getGebruikerNr());
			startActivity(intent);
		}
		else if(v==kwaliteitslijst){
			Intent intent = new Intent(this, KwaliteitsverslagListActivity.class);
			intent.putExtra("gebruikerNr", chosenGebruiker.getGebruikerNr());
			startActivity(intent);
		}
		else if(v==bezoekverslagenlijst){
			Intent intent = new Intent(this, BezoekverslagListActivity.class);
			intent.putExtra("gebruikerNr", chosenGebruiker.getGebruikerNr());
			startActivity(intent);
		}
		else if(v==controleslijst){
			Intent intent = new Intent(this, ControleListActivity.class);
			intent.putExtra("gebruikerNr", chosenGebruiker.getGebruikerNr());
			startActivity(intent);
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
	    	Intent intent = new Intent(this, LoginActivity.class);
			startActivity(intent);
	    	
	    }
	    return super.onKeyDown(keyCode, event);
	}
}
