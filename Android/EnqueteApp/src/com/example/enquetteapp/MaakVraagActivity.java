package com.example.enquetteapp;

import java.util.ArrayList;

import Classes.Antwoord;
import Classes.Database;
import Classes.Vraag;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ListView;

public class MaakVraagActivity extends Activity implements View.OnClickListener{
	Button saveVraag, addAntwoord, deleteAntwoord;
	Database db = new Database(this);
	Vraag vraag;
	int vraagNr;
	CheckBox groep;
	EditText vraagBeschrijving;
	ListView listview;
	ArrayList<Antwoord>antwoorden;
	MaakVraagAdapter maakVraagAdapter;
	Boolean bestaandeVraag = false;
	int enqueteNr;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_maak_vraag);
		
		saveVraag = (Button)findViewById(R.id.btn_saveVraag);
		addAntwoord = (Button)findViewById(R.id.btn_addAntwoord);
		deleteAntwoord = (Button)findViewById(R.id.btn_deleteAntwoord);
		groep = (CheckBox)findViewById(R.id.cb_groepAntwoorden);
		vraagBeschrijving = (EditText)findViewById(R.id.et_vraag);
		listview = (ListView)findViewById(R.id.lv_antwoorden);		
		saveVraag.setOnClickListener(this);		
		addAntwoord.setOnClickListener(this); 
		deleteAntwoord.setOnClickListener(this);
		
		Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			if(extras.getInt("vraagNr") > 0){
				bestaandeVraag = false;
				vraagNr = extras.getInt("vraagNr");
			}else if(extras.getInt("chosenVraagposition")>0){
				bestaandeVraag = true;
				vraagNr = extras.getInt("chosenVraagposition");
			}
			enqueteNr = extras.getInt("enqueteNr");
		}	
		
		
		vraag = db.getVraag(vraagNr);
		if(bestaandeVraag== true){
			groep.setChecked(vraag.getGroep());
			vraagBeschrijving.setText(vraag.getVraag());
		}
		antwoorden = db.getAlleVraagAntwoorden(vraagNr);
		
		maakVraagAdapter = new MaakVraagAdapter(this, antwoorden);
        
        //Create an adapter that feeds the data to the listview
        listview.setAdapter(maakVraagAdapter);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.maak_vraag, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if (v==saveVraag) {
			if(vraagBeschrijving.getText().length() == 0){
				AlertDialog ad = new AlertDialog.Builder(this).create();  
				ad.setCancelable(false); // This blocks the 'BACK' button  
				ad.setMessage("Vul vraag in!");  
				ad.setButton("OK", new DialogInterface.OnClickListener() {  
				    @Override  
				    public void onClick(DialogInterface dialog, int which) {  
				        dialog.dismiss();                      
				    }  
				});  
				ad.show();
			}else{
				if(antwoorden.size() < 2){
					AlertDialog ad = new AlertDialog.Builder(this).create();  
					ad.setCancelable(false); // This blocks the 'BACK' button  
					ad.setMessage("Voeg op zijn minst 2 antwoorden toe!");  
					ad.setButton("OK", new DialogInterface.OnClickListener() {  
					    @Override  
					    public void onClick(DialogInterface dialog, int which) {  
					        dialog.dismiss();                      
					    }  
					});  
					ad.show();
				}else{
					Boolean multipleChoise;
					if (groep.isChecked()){
						multipleChoise = false;
					}else{
						multipleChoise = true;
					}
					
					vraag.setGroep(multipleChoise);
					vraag.setVraag(vraagBeschrijving.getText().toString());
					db.updateVraag(vraag);
					Intent intent = new Intent(this, VragenLijstActivity.class);
					intent.putExtra("enqueteNr", enqueteNr);
					startActivity(intent);
				}
			}
		}		
		else if(v==addAntwoord) {
			db.addAntwoord(new Antwoord(0, null, null, 0, vraagNr));
			antwoorden = db.getAlleVraagAntwoorden(vraagNr);
			maakVraagAdapter = new MaakVraagAdapter(this, antwoorden);
	        listview.setAdapter(maakVraagAdapter);
			
		}
		else if(v==deleteAntwoord){
			int max = db.getMaxAntwoordNr();
			Antwoord antwoord = db.getAntwoord(max);
			db.deleteAntwoord(antwoord);
			antwoorden = db.getAlleVraagAntwoorden(vraagNr);
			maakVraagAdapter = new MaakVraagAdapter(this, antwoorden);
	        listview.setAdapter(maakVraagAdapter);
		}
	}
}
