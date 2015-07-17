package com.example.shout;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Toast;

public class PublicChatActivity extends Activity  implements View.OnClickListener{
	private class AddUserTask extends AsyncTask<Void, Void, Void> {
		@Override
		protected Void doInBackground(Void... params) {
			//WebConnectie.addMessage("testbericht van die phoney jeweet", "mijnmacadress");
			return null;
		}
	}
	

	Button send;
	ImageButton profile, deelnemers;
	DatabaseHandler db = new DatabaseHandler(this);
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_public_chat);
		
		send = (Button)findViewById(R.id.sendbutton);
		send.setOnClickListener(this);
		profile = (ImageButton)findViewById(R.id.profielbutton);
		profile.setOnClickListener(this);
		deelnemers = (ImageButton)findViewById(R.id.deelnemersbutton);
		deelnemers.setOnClickListener(this);
	
		 ListView mainListView = (ListView) findViewById( R.id.publicChatListview );

		  
		    String[] personen = new String[] { "Lesley: Hey lekker weertje he?!", "Rob", "Menno", "Roberta",
		                                      "Manuela", "Lisabel", "Hans", "Michael", "Frans", "Rita", "Giana",
		                                      "Karin","Charlotte","Karlijn"}; 
		    
		    String[] bericht = new String[] { "Hey lekker weertje he?!", "Ja klopt"};  
		    
		    
		    ArrayList<String> personenList = new ArrayList<String>();
		    ArrayList<String> berichtenList = new ArrayList<String>();
		    personenList.addAll( Arrays.asList(personen) );
		    personenList.addAll( Arrays.asList(bericht) );
		    
		    // Create ArrayAdapter using the person list.
		    ArrayAdapter<String> listAdapter = new ArrayAdapter<String>(this, R.layout.simplerow, personenList);
		    
		    
		    
		    
		    
		    // Set the ArrayAdapter as the ListView's adapter.
		    mainListView.setAdapter( listAdapter );
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.load, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		if(v == send) {
			//send message
		}
		else if (v == profile) {
			Intent intent = new Intent(this, ChangeProfileActivity.class);
			startActivity(intent);
		}
		else if (v == deelnemers) {
			Intent intent = new Intent(this, DeelnemerLijstActivity.class);
			startActivity(intent);
		}
	}
	
	@Override
	protected void onDestroy() {
	    super.onDestroy();
	    db.close();
	}
}
