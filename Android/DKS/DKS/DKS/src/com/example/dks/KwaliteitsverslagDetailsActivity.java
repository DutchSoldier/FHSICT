package com.example.dks;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.ToggleButton;

public class KwaliteitsverslagDetailsActivity extends Activity implements View.OnClickListener {

	Button afspraken;
	ToggleButton vloer4,vloer5,vloer6,vloer7,vloer8;
	ToggleButton vloerStof,vloerStrepen,vloerRandv,vloerMethode;
	ToggleButton interieur4,interieur5,interieur6,interieur7,interieur8;
	ToggleButton interieurStof,interieurVlek,interieurSpin,interieurMethode;
	ToggleButton inventaris4,inventaris5,inventaris6,inventaris7,inventaris8;
	ToggleButton inventarisStof,inventarisVlek,inventarisVinger,inventarisMethode;
	ToggleButton toilet4,toilet5,toilet6,toilet7,toilet8;
	ToggleButton toiletStof,toiletVlek,toiletAanslag,toiletMethode;
	ToggleButton glas4,glas5,glas6,glas7,glas8;
	ToggleButton uitgenodigdJa, uitgenodigdNee, aanwezigJa,aanwezigNee;
	TextView debiteurnaam, debiteurnr, projectnaam, projectnr, plaats;
	TextView telefoonnr, contactpersoon, weeknr, postcode, straat;
	Database db = new Database(this);
	public static Kwaliteitsverslag chosenKwaliteitsverslag;
	int chosenKwaliteitsverslagPosition = 0;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_kwaliteitsverslag_details);
		afspraken = (Button)findViewById(R.id.btn_afspraken);
        afspraken.setOnClickListener(this);
        
        ((RadioGroup) findViewById(R.id.rg_vloer_ondeldeel)).setOnCheckedChangeListener(ToggleListener);
        ((RadioGroup) findViewById(R.id.rg_interieur_ondeldeel)).setOnCheckedChangeListener(ToggleListener);
        ((RadioGroup) findViewById(R.id.rg_inventaris_ondeldeel)).setOnCheckedChangeListener(ToggleListener);
        ((RadioGroup) findViewById(R.id.rg_toiletWasruimtes_ondeldeel)).setOnCheckedChangeListener(ToggleListener);
        ((RadioGroup) findViewById(R.id.rg_glasbewassing_ondeldeel)).setOnCheckedChangeListener(ToggleListener);
        ((RadioGroup) findViewById(R.id.rg_opdrachtgeverUitgenodigd)).setOnCheckedChangeListener(ToggleListener);
        ((RadioGroup) findViewById(R.id.rg_opdrachtgeverAanwezig)).setOnCheckedChangeListener(ToggleListener);
        
        Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			chosenKwaliteitsverslagPosition = (int)extras.getInt("chosenKwaliteitsverslagPosition");
		}	
		chosenKwaliteitsverslag = db.getKwaliteitsverslag(chosenKwaliteitsverslagPosition + 1);
		
		debiteurnaam = (TextView)findViewById(R.id.tv_debiteurnaam);
		debiteurnaam.setText(chosenKwaliteitsverslag.getDebiteurnaam());
		debiteurnr = (TextView)findViewById(R.id.tv_debiteurnr);
		debiteurnr.setText(String.valueOf(chosenKwaliteitsverslag.getDebiteurnummer()));
		projectnaam = (TextView)findViewById(R.id.tv_projectnaam);
		projectnaam.setText(chosenKwaliteitsverslag.getProjectnaam());
		projectnr = (TextView)findViewById(R.id.tv_projectnr);
		projectnr.setText(String.valueOf(chosenKwaliteitsverslag.getProjectnummer()));
		plaats = (TextView)findViewById(R.id.tv_plaats);
		plaats.setText(chosenKwaliteitsverslag.getPlaats());
		telefoonnr = (TextView)findViewById(R.id.tv_telefoonnr);
		telefoonnr.setText(chosenKwaliteitsverslag.getTelefoonnummer());
		contactpersoon = (TextView)findViewById(R.id.tv_contactpers);
		contactpersoon.setText(chosenKwaliteitsverslag.getContactpersoon());
		weeknr = (TextView)findViewById(R.id.tv_week);
		weeknr.setText(String.valueOf(chosenKwaliteitsverslag.getWeeknummer()));
		postcode = (TextView)findViewById(R.id.tv_postcode);
		postcode.setText(chosenKwaliteitsverslag.getPostcode());
		straat = (TextView)findViewById(R.id.tv_straat);
		straat.setText(chosenKwaliteitsverslag.getStraat());
	}

	@Override
	public void onClick(View v) {
		if(v==afspraken){
			db.updateKwaliteitsverslag(chosenKwaliteitsverslag);
			Intent intent = new Intent(this, KwaliteitsverslagAfsprakenActivity.class);
			intent.putExtra("chosenKwaliteitsverslagPosition", chosenKwaliteitsverslag.getKwaliteitsverslagNr());
			startActivity(intent);
		}
	}
	
	public void onToggle(View view) {
	    ((RadioGroup)view.getParent()).check(view.getId());
	}
	
	static final RadioGroup.OnCheckedChangeListener ToggleListener = new RadioGroup.OnCheckedChangeListener() {
		@Override
		public void onCheckedChanged(final RadioGroup radioGroup, final int i) {
	        for (int j = 0; j < radioGroup.getChildCount(); j++) {
	            final ToggleButton view = (ToggleButton) radioGroup.getChildAt(j);
	            view.setChecked(view.getId() == i);
	        }
		}
	};
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.kwaliteitsverslag_details, menu);
		return true;
	}
	
	@Override
	protected void onDestroy() {
	    super.onDestroy();	    
	    db.close();
	}
	
    @Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
	    if ((keyCode == KeyEvent.KEYCODE_BACK)) {
	    	db.updateKwaliteitsverslag(chosenKwaliteitsverslag);
	    	
	    	Intent intent = new Intent(this, KwaliteitsverslagListActivity.class);
			startActivity(intent);
	    }
	    return super.onKeyDown(keyCode, event);
	}
}
