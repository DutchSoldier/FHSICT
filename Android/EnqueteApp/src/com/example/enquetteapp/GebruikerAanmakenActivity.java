package com.example.enquetteapp;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import Classes.Database;
import Classes.Gebruiker;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog;
import android.app.DatePickerDialog.OnDateSetListener;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;

public class GebruikerAanmakenActivity extends Activity implements  View.OnClickListener, OnDateSetListener{
	Spinner spinner;
	EditText naam, email;
	Button saveGebruiker;
	static EditText geboorteDatum;
	Database db = new Database(this);
	Gebruiker gebruiker;
	int enqueteNr;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_gebruiker_aanmaken);
		
		Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			enqueteNr = (int)extras.getInt("enqueteNr");
		}
		
		spinner = (Spinner)findViewById(R.id.sp_geslacht);
		List<String> list = new ArrayList<String>();
		list.add("Man");
		list.add("Vrouw");
		
		ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item,list);
          
		dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
          
		spinner.setAdapter(dataAdapter);	
		
		geboorteDatum = (EditText)findViewById(R.id.et_geboorteDatum);
		geboorteDatum.setOnClickListener(this); 
		saveGebruiker = (Button)findViewById(R.id.btn_saveGebruiker);
		saveGebruiker.setOnClickListener(this);
		naam = (EditText)findViewById(R.id.et_naam);
		email = (EditText)findViewById(R.id.et_email);
	}

	@Override
	public void onDateSet(DatePicker view, int year, int monthOfYear,
			int dayOfMonth) {
		monthOfYear = monthOfYear + 1;
		geboorteDatum.setText(dayOfMonth + "-"+monthOfYear+"-"+year);
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.gebruiker_aanmaken, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if(v==geboorteDatum){
			Calendar c = Calendar.getInstance();
            int mYear = c.get(Calendar.YEAR);
            int mMonth = c.get(Calendar.MONTH);
            int mDay = c.get(Calendar.DAY_OF_MONTH);
			DatePickerDialog dialog = new DatePickerDialog(this, this, mYear, mMonth, mDay);
		    dialog.show();
		}
		else if(v==saveGebruiker){
			String name = naam.getText().toString();
			String mail = email.getText().toString();
			String datum = geboorteDatum.getText().toString();
			String geslacht = spinner.getSelectedItem().toString();
			
			
			if(naam.getText().length() != 0){
				if(email.getText().length()!=0){
					if(geboorteDatum.getText().length()!=0){
						gebruiker = new Gebruiker(0, name, geslacht, datum, mail, enqueteNr);
						db.addGebruiker(gebruiker);
						Intent intent = new Intent(GebruikerAanmakenActivity.this, AfneemEnqueteActivity.class);
						intent.putExtra("enqueteNr", enqueteNr);
						startActivity(intent);
					}
					else{
						AlertDialog ad = new AlertDialog.Builder(this).create();  
						ad.setCancelable(false); // This blocks the 'BACK' button  
						ad.setMessage("Vul een geboorte datum in!");  
						ad.setButton("OK", new DialogInterface.OnClickListener() {  
						    @Override  
						    public void onClick(DialogInterface dialog, int which) {  
						        dialog.dismiss();                      
						    }  
						});  
						ad.show();
					}
				}
				else{
					AlertDialog ad = new AlertDialog.Builder(this).create();  
					ad.setCancelable(false); // This blocks the 'BACK' button  
					ad.setMessage("Vul een email adres in!");  
					ad.setButton("OK", new DialogInterface.OnClickListener() {  
					    @Override  
					    public void onClick(DialogInterface dialog, int which) {  
					        dialog.dismiss();                      
					    }  
					});  
					ad.show();
				}
			}
			else{
				AlertDialog ad = new AlertDialog.Builder(this).create();  
				ad.setCancelable(false); // This blocks the 'BACK' button  
				ad.setMessage("Vul een naam in!");  
				ad.setButton("OK", new DialogInterface.OnClickListener() {  
				    @Override  
				    public void onClick(DialogInterface dialog, int which) {  
				        dialog.dismiss();                      
				    }  
				});  
				ad.show();
			}
			
		}
	}

}
