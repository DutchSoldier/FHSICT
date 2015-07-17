package com.example.dks;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioGroup;
import android.widget.ToggleButton;

public class BezoekverslagDetailsActivity extends Activity implements View.OnClickListener {
	//public Context context;
	RadioGroup group;
	Button afspraken;
	ToggleButton toggle;
	EditText contactpersoon, relatie, onderwerp, gespreksonderwerpen;
	BezoekverslagDetailsListAdapter vraagListAdapter;
	Database db = new Database(this);
	public static Bezoekverslag chosenBezoekverslag;
	int chosenBezoekverslagPosition = 0;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_bezoekverslagdetails);
		//VraagProvider provider = new VraagProvider();
		//provider.MakeVragen();
		
		Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			chosenBezoekverslagPosition = (int)extras.getInt("chosenBezoekverslagPosition");
		}	
		chosenBezoekverslag = db.getBezoekverslag(chosenBezoekverslagPosition + 1);
		
			//Get a reference to the listview
	        final ListView listview = (ListView) findViewById(R.id.lv_vragen);    
	        vraagListAdapter = new BezoekverslagDetailsListAdapter(this, db.getAlleBezoekverslagVragen(chosenBezoekverslag.getBezoekverslagNr()));
	        
	        //Create an adapter that feeds the data to the listview
	        listview.setAdapter(vraagListAdapter); 
		 
        afspraken = (Button)findViewById(R.id.btn_afspraken);
        afspraken.setOnClickListener(this);	
		contactpersoon = (EditText)findViewById(R.id.et_contactpers);
		contactpersoon.setText(chosenBezoekverslag.getContactpersoon());
		relatie = (EditText)findViewById(R.id.et_relatie);
		relatie.setText(chosenBezoekverslag.getRelatie());
		onderwerp = (EditText)findViewById(R.id.et_onderwerp);
		onderwerp.setText(chosenBezoekverslag.getOnderwerp());
		gespreksonderwerpen = (EditText)findViewById(R.id.et_gespreksonderwerpen);
		gespreksonderwerpen.setText(chosenBezoekverslag.getGespreksOnderwerpen());
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if(v==afspraken){
			chosenBezoekverslag.setRelatie(relatie.getText().toString());
			chosenBezoekverslag.setContactpersoon(contactpersoon.getText().toString());
			chosenBezoekverslag.setOnderwerp(onderwerp.getText().toString());
			chosenBezoekverslag.setGespreksOnderwerpen(gespreksonderwerpen.getText().toString());
			
			db.updateBezoekverslag(chosenBezoekverslag);
			
			Intent intent = new Intent(BezoekverslagDetailsActivity.this, BezoekverslagAfsprakenActivity.class);
			intent.putExtra("chosenBezoekverslagPosition", chosenBezoekverslag.getBezoekverslagNr());
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
	    	chosenBezoekverslag.setRelatie(relatie.getText().toString());
			chosenBezoekverslag.setContactpersoon(contactpersoon.getText().toString());
			chosenBezoekverslag.setOnderwerp(onderwerp.getText().toString());
			chosenBezoekverslag.setGespreksOnderwerpen(gespreksonderwerpen.getText().toString());
			
			db.updateBezoekverslag(chosenBezoekverslag);
			
	    	Intent intent = new Intent(this, BezoekverslagListActivity.class);
			startActivity(intent);
	    }
	    return super.onKeyDown(keyCode, event);
	}
}
