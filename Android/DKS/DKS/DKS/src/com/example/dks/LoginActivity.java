package com.example.dks;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;

public class LoginActivity extends Activity implements View.OnClickListener{

	Button login;
	Database db = new Database(this);
	EditText gebruikersnaam, wachtwoord;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_login);
		
		if(db.getAlleWerkbonnen().size() <= 20){
			db.addWerkbon(new Werkbon(0, 0, "a", 1, "a", null, null, 0, null, 0, "Vaarzenhof", "1a", null, "Uden", null, "Gereed", "10-2-2013", "niks", null,1));
			db.addWerkbon(new Werkbon(0, 0, "b", 2, "b", null, null, 0, null, 0, "Vaarzenhof", "2a", null, "Uden", null, "In uitvoering", null, "niks", null,1));
			db.addWerkbon(new Werkbon(0, 0, "c", 3, "c", null, null, 0, null, 0, "Vaarzenhof", "3a", null, "Uden", null, "Niet uitvoerbaar", null, "niks", null,1));
			db.addWerkbon(new Werkbon(0, 0, "d", 4, "d", null, null, 0, null, 0, "Vaarzenhof", "1b", null, "Uden", null, "In uitvoering", null, "niks", null,1));
			db.addWerkbon(new Werkbon(0, 0, "e", 5, "e", null, null, 0, null, 0, "Vaarzenhof", "1c", null, "Uden", null, "Gereed", "10-4-2013", "niks", null,1));
			db.addWerkbon(new Werkbon(0, 0, "f", 6, "f", null, null, 0, null, 0, "Vaarzenhof", "1d", null, "Uden", null, "Niet uitvoerbaar", null, "niks", null,1));
			db.addWerkbon(new Werkbon(0, 0, "g", 7, "g", null, null, 0, null, 0, "Vaarzenhof", "4", null, "Uden", null, null, null, "niks", null,1));
			db.addWerkbon(new Werkbon(0, 0, "h", 8, "h", null, null, 0, null, 0, "Vaarzenhof", "5", null, "Uden", null, null, null, "niks", null,1));
		}
		
		if(db.getAllKwaliteitsverslagen().size() <= 20){
			db.addKwaliteitsverslag(new Kwaliteitsverslag(0, 0, null, 1, "a", null, null, 0, null, null, null, null, "Gereed", "1-10-2011", "1-10-2013", null, null, null, 1, null));
			db.addKwaliteitsverslag(new Kwaliteitsverslag(0, 0, null, 2, "b", null, null, 0, null, null, null, null, "Concept", "1-10-2012", null, null, null, null, 1, null));
			db.addKwaliteitsverslag(new Kwaliteitsverslag(0, 0, null, 3, "c", null, null, 0, null, null, null, null, null, "1-10-2012", null, null, null, null, 1, null));
			db.addKwaliteitsverslag(new Kwaliteitsverslag(0, 0, null, 4, "d", null, null, 0, null, null, null, null, "Gereed", "1-10-2011", "1-10-2013", null, null, null, 1, null));
			db.addKwaliteitsverslag(new Kwaliteitsverslag(0, 0, null, 5, "e", null, null, 0, null, null, null, null, "Concept", "1-10-2012", null, null, null, null, 1, null));
			db.addKwaliteitsverslag(new Kwaliteitsverslag(0, 0, null, 6, "f", null, null, 0, null, null, null, null, null, "1-10-2011", null, null, null, null, 1, null));
			db.addKwaliteitsverslag(new Kwaliteitsverslag(0, 0, null, 7, "g", null, null, 0, null, null, null, null, "Gereed", "1-10-2011", "1-10-2013", null, null, null, 1, null));
			db.addKwaliteitsverslag(new Kwaliteitsverslag(0, 0, null, 8, "h", null, null, 0, null, null, null, null, "Concept", "1-10-2012", null, null, null, null, 1, null));
		}
		
		if(db.getAlleBezoekverslagen().size() <= 20){
			db.addBezoekverslag(new Bezoekverslag(0, "Goed", null, null, "Niks", "10-12-2013", "Gereed", null, 1, null, null));
			db.addBezoekverslag(new Bezoekverslag(0, "Slecht", null, null, "Niks", null, "Concept", null, 1, null, null));
			db.addBezoekverslag(new Bezoekverslag(0, "Matig", null, null, "Niks", null, null, null, 1, null, null));
			db.addBezoekverslag(new Bezoekverslag(0, "Goed", null, null, "Niks", "10-9-2013", "Gereed", null, 1, null, null));
			db.addBezoekverslag(new Bezoekverslag(0, "Slecht", null, null, "Niks", null, "Concept", null, 1, null, null));
			db.addBezoekverslag(new Bezoekverslag(0, "Matig", null, null, "Niks", null, null, null, 1, null, null));
			db.addBezoekverslag(new Bezoekverslag(0, "Goed", null, null, "Niks", "10-10-2014", "Gereed", null, 1, null, null));
			db.addBezoekverslag(new Bezoekverslag(0, "Goed", null, null, "Niks", "10-10-2015", "Gereed", null, 1, null, null));
		}
		
		if(db.getAlleVragen().isEmpty() == true){
			db.addVraag(new Vraag(0, "Hoe?", null, 0, 1, null));
			db.addVraag(new Vraag(0, "Wat?", null, 0, 1, null));
			db.addVraag(new Vraag(0, "Waar?", null, 0, 1, null));
			db.addVraag(new Vraag(0, "Wanneer?", null, 0, 1, null));
			db.addVraag(new Vraag(0, "Hoelaat?", null, 0, 1, null));
			db.addVraag(new Vraag(0, "Hoe?", null, 0, 2, null));
			db.addVraag(new Vraag(0, "Wat?", null, 0, 2, null));
			db.addVraag(new Vraag(0, "Waar?", null, 0, 2, null));
			db.addVraag(new Vraag(0, "Wanneer?", null, 0, 2, null));
			db.addVraag(new Vraag(0, "Hoelaat?", null, 0, 2, null));
		}
		
		if(db.getAlleAntwoorden().isEmpty() == true){
			db.addAntwoord(new Antwoord(0, "Ja", true, false, 1));
			db.addAntwoord(new Antwoord(0, "Misschien", true, false, 1));
			db.addAntwoord(new Antwoord(0, "Nee", true, false, 1));
			db.addAntwoord(new Antwoord(0, "a", true, false, 2));
			db.addAntwoord(new Antwoord(0, "b", true, false, 2));
			db.addAntwoord(new Antwoord(0, "c", true, false, 2));
			db.addAntwoord(new Antwoord(0, "1", true, false, 3));
			db.addAntwoord(new Antwoord(0, "2", true, false, 3));
			db.addAntwoord(new Antwoord(0, "3", true, false, 3));
			db.addAntwoord(new Antwoord(0, "4", true, false, 3));
			db.addAntwoord(new Antwoord(0, "5", true, false, 3));
			db.addAntwoord(new Antwoord(0, "Ja", true, false, 4));
			db.addAntwoord(new Antwoord(0, "Misschien", true, false, 4));
			db.addAntwoord(new Antwoord(0, "Nee", true, false, 4));
			db.addAntwoord(new Antwoord(0, "a", true, false, 5));
			db.addAntwoord(new Antwoord(0, "b", true, false, 5));
			db.addAntwoord(new Antwoord(0, "c", true, false, 5));
			db.addAntwoord(new Antwoord(0, "1", true, false, 6));
			db.addAntwoord(new Antwoord(0, "2", true, false, 6));
			db.addAntwoord(new Antwoord(0, "3", true, false, 6));
			db.addAntwoord(new Antwoord(0, "4", true, false, 6));
			db.addAntwoord(new Antwoord(0, "5", true, false, 6));
			db.addAntwoord(new Antwoord(0, "Ja", true, false, 7));
			db.addAntwoord(new Antwoord(0, "Misschien", true, false, 7));
			db.addAntwoord(new Antwoord(0, "Nee", true, false, 7));
			db.addAntwoord(new Antwoord(0, "a", true, false, 8));
			db.addAntwoord(new Antwoord(0, "b", true, false, 8));
			db.addAntwoord(new Antwoord(0, "c", true, false, 8));
			db.addAntwoord(new Antwoord(0, "1", true, false, 9));
			db.addAntwoord(new Antwoord(0, "2", true, false, 9));
			db.addAntwoord(new Antwoord(0, "3", true, false, 9));
			db.addAntwoord(new Antwoord(0, "4", true, false, 9));
			db.addAntwoord(new Antwoord(0, "5", true, false, 9));
			db.addAntwoord(new Antwoord(0, "Ja", true, false, 10));
			db.addAntwoord(new Antwoord(0, "Misschien", true, false, 10));
			db.addAntwoord(new Antwoord(0, "Nee", true, false, 10));
		}
		
		if(db.getAlleGebruikers().isEmpty() == true){
			db.addGebruiker(new Gebruiker(0, "remi", null, null, "test", null, null, null, null, null, null, null, 0, null, null, null, null, null, null));
			db.addGebruiker(new Gebruiker(0, "remi2", null, null, "test", null, null, null, null, null, null, null, 0, null, null, null, null, null, null));
		}
		
		login = (Button)findViewById(R.id.btn_login);
		login.setOnClickListener(this);
		gebruikersnaam = (EditText)findViewById(R.id.et_gebruikersnaam);
		wachtwoord = (EditText)findViewById(R.id.et_wachtwoord);
		
		gebruikersnaam.setText("remi");
		wachtwoord.setText("test");

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.login, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if (v==login) {
			if(gebruikersnaam.getText().toString().equals("") == false){
				if(wachtwoord.getText().toString().equals("") == false){
					if(db.getGebruikerMetWachtwoord(gebruikersnaam.getText().toString(), wachtwoord.getText().toString()) != null){
						Gebruiker gebruiker = db.getGebruikerMetWachtwoord(gebruikersnaam.getText().toString(), wachtwoord.getText().toString());
						Intent intent = new Intent(this, AppMenuActivity.class);
						intent.putExtra("gebruikerNr", gebruiker.getGebruikerNr());
						startActivity(intent);
					}
					else{
						AlertDialog alertDialog;
						alertDialog = new AlertDialog.Builder(this).create();
						alertDialog.setTitle("Fout!");
						alertDialog.setMessage("Gebruikersnaam of wachtwoord is incorrect!");
						alertDialog.setCancelable(false);
						alertDialog.setButton("ok", new DialogInterface.OnClickListener() {
					        public void onClick(DialogInterface dialog, int id) {
					            dialog.cancel();
					        }
					    });
						alertDialog.show();
					}
				}
				else{
					AlertDialog alertDialog;
					alertDialog = new AlertDialog.Builder(this).create();
					alertDialog.setTitle("Fout!");
					alertDialog.setMessage("Wachtwoord is nog niet ingevuld!");
					alertDialog.setButton("ok", new DialogInterface.OnClickListener() {
				        public void onClick(DialogInterface dialog, int id) {
				            dialog.cancel();
				        }
				    });
					alertDialog.show();
				}
			}
			else{
				AlertDialog alertDialog;
				alertDialog = new AlertDialog.Builder(this).create();
				alertDialog.setTitle("Fout!");
				alertDialog.setMessage("Gebruikersnaam is nog niet ingevuld!");
				alertDialog.setButton("ok", new DialogInterface.OnClickListener() {
			        public void onClick(DialogInterface dialog, int id) {
			            dialog.cancel();
			        }
			    });
				alertDialog.show();
			}
		}	
	}
}
