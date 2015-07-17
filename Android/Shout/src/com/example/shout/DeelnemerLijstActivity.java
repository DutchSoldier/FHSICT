package com.example.shout;

import java.util.ArrayList;
import java.util.Arrays;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.Window;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class DeelnemerLijstActivity extends Activity {
  
  private ListView mainListView ;
  private ArrayAdapter<String> listAdapter ;
  
  /** Called when the activity is first created. */
  @Override
  public void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    requestWindowFeature(Window.FEATURE_NO_TITLE);
    setContentView(R.layout.activity_deelnemer_lijst);
    
    // Find the ListView resource. 
    mainListView = (ListView) findViewById( R.id.listviewDeelnemers );

    // Create and populate a List of planet names.
    String[] personen = new String[] { "Lesley", "Rob", "Menno", "Roberta",
                                      "Manuela", "Lisabel", "Hans", "Michael", "Frans", "Rita", "Giana",
                                      "Karin","Charlotte","Karlijn"};  
    ArrayList<String> personenList = new ArrayList<String>();
    personenList.addAll( Arrays.asList(personen) );
    
    // Create ArrayAdapter using the planet list.
    listAdapter = new ArrayAdapter<String>(this, R.layout.simplerow, personenList);
    
    
    
    // Set the ArrayAdapter as the ListView's adapter.
    mainListView.setAdapter( listAdapter );      
  }
  @Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.deelnemer_lijst, menu);
		return true;
	}
}

