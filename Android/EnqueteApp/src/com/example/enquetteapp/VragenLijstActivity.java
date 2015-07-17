package com.example.enquetteapp;

import java.util.ArrayList;

import Classes.Database;
import Classes.Vraag;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.ListView;

public class VragenLijstActivity extends Activity implements OnClickListener{
	Button addVraag, klaar;
	Vraag vraag;
	Database db = new Database(this);
	int enqueteNr;
	ArrayList<Vraag>vragen;
	ListView listview;
	VragenLijstAdapter vragenLijstAdapter;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_vragen_lijst);
		
		Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			enqueteNr = (int)extras.getInt("enqueteNr");
		}
		vragen = db.getAlleEnqueteVragen(enqueteNr);
		addVraag = (Button)findViewById(R.id.btn_addvraag);
		addVraag.setOnClickListener(this);
		klaar = (Button)findViewById(R.id.btn_klaar);
		klaar.setOnClickListener(this);
		
		//Get a reference to the listview
        listview = (ListView) findViewById(R.id.lv_vragenLijst);
        
        vragenLijstAdapter = new VragenLijstAdapter(this, vragen);
		
		//Create an adapter that feeds the data to the listview
	    listview.setAdapter(vragenLijstAdapter);
	        
	    //Create an OnItemClickListener to get clicked item back from listview
	    listview.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position,
					long id) {
				Intent intent = new Intent(VragenLijstActivity.this, MaakVraagActivity.class);
				int chosenVraag = vragen.get(position).getVraagNr();
				intent.putExtra("chosenVraagposition", chosenVraag);
				intent.putExtra("enqueteNr", enqueteNr);
				startActivity(intent);
			}
	     });
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {

		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.vragen_lijst, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if(v== addVraag){
			vraag = new Vraag(0, null, null, null, enqueteNr, null);
			db.addVraag(vraag);
			int max = db.getMaxVraagNr();
			Intent intent = new Intent(VragenLijstActivity.this, MaakVraagActivity.class);
			intent.putExtra("enqueteNr", enqueteNr);
			intent.putExtra("vraagNr", max);
			startActivity(intent);
		}
		else if(v==klaar){
			if(vragen.isEmpty()){
				AlertDialog ad = new AlertDialog.Builder(this).create();  
				ad.setCancelable(false); // This blocks the 'BACK' button  
				ad.setMessage("Voeg minimaal 1 vraag toe!");  
				ad.setButton("OK", new DialogInterface.OnClickListener() {  
				    @Override  
				    public void onClick(DialogInterface dialog, int which) {  
				        dialog.dismiss();                      
				    }  
				});  
				ad.show();
			}else{
			Intent intent = new Intent(VragenLijstActivity.this, MenuActivity.class);
			startActivity(intent);
			}
		}
	}
}
