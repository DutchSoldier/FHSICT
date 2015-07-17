package com.example.enquetteapp;

import java.util.ArrayList;

import Classes.Database;
import Classes.Enquete;
import Classes.Gebruiker;
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

public class MaakEnqueteActivity extends Activity implements View.OnClickListener{
	Button saveEnquete, deleteEnquete;
	Database db = new Database(this);
	CheckBox anoniem;
	Enquete enquete;
	EditText naam, beschrijving;
	int enqueteNr;
	Boolean bl;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_maak_enquete);
		
		anoniem =(CheckBox)findViewById(R.id.cb_anoniem);
		saveEnquete = (Button)findViewById(R.id.btn_saveEnquete);
		saveEnquete.setOnClickListener(this);
		deleteEnquete = (Button)findViewById(R.id.btn_deleteEnquete);
		deleteEnquete.setOnClickListener(this);
		naam = (EditText)findViewById(R.id.et_enqueteNaam);
		beschrijving = (EditText)findViewById(R.id.et_enqueteBeschrijving);
		
		
		Bundle extras = getIntent().getExtras();
		if (extras != null) {
			enqueteNr = (int)extras.getInt("enqueteNr");
			if(extras.getBoolean("wijzigEnquete") ==true){
				deleteEnquete.setVisibility(1);
			}
		}
		enquete = db.getEnquete(enqueteNr);
		anoniem.setChecked(enquete.getAnoniem());
		naam.setText(enquete.getNaam());
		beschrijving.setText(enquete.getBeschrijving());
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.maak_enquete, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if(v==saveEnquete){
			if(naam.getText().length() != 0){				
				enquete.setAnoniem(anoniem.isChecked());
				enquete.setNaam(naam.getText().toString());
				enquete.setBeschrijving(beschrijving.getText().toString());
				db.updateEnquete(enquete);
				Intent intent = new Intent(MaakEnqueteActivity.this, VragenLijstActivity.class);
				intent.putExtra("enqueteNr", enquete.getEnqueteNr());
				startActivity(intent);
			}else{
				AlertDialog ad = new AlertDialog.Builder(this).create();  
				ad.setCancelable(false); // This blocks the 'BACK' button  
				ad.setMessage("Vul enquete naam in!");  
				ad.setButton("OK", new DialogInterface.OnClickListener() {  
				    @Override  
				    public void onClick(DialogInterface dialog, int which) {  
				        dialog.dismiss();                      
				    }  
				});  
				ad.show();
			}			
		}
		if(v==deleteEnquete){
			AlertDialog.Builder ad = new AlertDialog.Builder(this);  
			ad.setCancelable(true); // This blocks the 'BACK' button  
			ad.setMessage("Wilt u echt de enquete verwijderen?"); 
			ad.setPositiveButton("OK", new DialogInterface.OnClickListener() {  
			    @Override  
			    public void onClick(DialogInterface dialog, int which) {  
			        dialog.dismiss();  			        
			        ArrayList<Gebruiker> gebruikers = db.getAlleEnqueteGebruikers(enquete.getEnqueteNr());
			        for(Gebruiker g: gebruikers){
				        db.deleteGebruiker(g);
			        }
			        db.deleteEnquete(enquete);
			        Intent intent = new Intent(MaakEnqueteActivity.this, WijzigEnqueteLijstActivity.class);
					startActivity(intent);
			    }  
			});  
			ad.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {  
			    @Override  
			    public void onClick(DialogInterface dialog, int which) {  
			        dialog.dismiss();  
			    }  
			}); 
			AlertDialog alert = ad.create();
			alert.show();
		}
	}
}
