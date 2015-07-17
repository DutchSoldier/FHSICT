package com.example.dks;

import java.util.ArrayList;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.database.sqlite.SQLiteStatement;

public class Database extends SQLiteOpenHelper{

	ArrayList<Werkbon> werkbonnen;
	ArrayList<Vraag> vragen;
	ArrayList<Antwoord> antwoorden;
	ArrayList<Afspraak> afspraken;
	ArrayList<Bezoekverslag> bezoekverslagen;
	ArrayList<Kwaliteitsverslag> kwaliteitsverslagen;
	ArrayList<Identiteitsbewijs> identiteitsbewijzen;
	ArrayList<Controle> controles;
	ArrayList<Bedrijf> bedrijven;
	ArrayList<Gebruiker> gebruikers;
	ArrayList<Options> options;
	Context context;
	
	// Database Version
    private static final int DATABASE_VERSION = 1;
 
	//Database name
	private static String DATABASE_NAME = "NocoreApp";
	
	public Database(Context context) {
		super(context, DATABASE_NAME, null, DATABASE_VERSION);
	}

	@Override
	public void onCreate(SQLiteDatabase db) {
		//Create tables
		String CREATE_BEDRIJF = "CREATE TABLE Bedrijf (BedrijfkNr INTEGER PRIMARY KEY AUTOINCREMENT, Naam TEXT, Land TEXT, Plaats TEXT, Straat TEXT, Huisnummer TEXT, Postcode TEXT)";
		String CREATE_GEBRUIKER = "CREATE TABLE Gebruiker (GebruikerNr INTEGER PRIMARY KEY AUTOINCREMENT, Gebruikersnaam TEXT, Naam TEXT, Achternaam TEXT, Wachtwoord TEXT, Type TEXT, Land TEXT, Plaats TEXT, Straat TEXT, Huisnummer TEXT, Postcode TEXT, Telefoonnummer TEXT, BedrijfNr INTEGER, FOREIGN KEY (BedrijfNr) REFERENCES Bedrijf (BedrijfNr))";
		String CREATE_WERKBON = "CREATE TABLE Werkbon (WerkbonNr INTEGER PRIMARY KEY AUTOINCREMENT, Debiteurnummer INTEGER, Debiteurnaam TEXT, Projectnummer INTEGER, Projectnaam TEXT, Telefoonnummer TEXT, Contactpersoon TEXT, Weeknummer INTEGER, StartDatum TEXT, Uren DOUBLE, Straat TEXT, Huisnummer TEXT, Postcode TEXT, Plaats TEXT, ExtraOpmerking TEXT, Status TEXT, GereedDatum TEXT, Opmerkingen TEXT, Handtekening BLOB, GebruikerNr INTEGER, FOREIGN KEY (GebruikerNr) REFERENCES Gebruiker (GebruikerNr))";
		String CREATE_BEZOEKVERSLAG = "CREATE TABLE Bezoekverslag (BezoekverslagNr INTEGER PRIMARY KEY AUTOINCREMENT, Relatie TEXT, Contactpersoon TEXT, Onderwerp TEXT, GespreksOnderwerpen TEXT, GereedDatum TEXT, Status TEXT, Handtekening BLOB, GebruikerNr INTEGER, FOREIGN KEY (GebruikerNr) REFERENCES Gebruiker (GebruikerNr))";
		String CREATE_KWALITEITSVERSLAG = "CREATE TABLE Kwaliteitsverslag (KwaliteitsverslagNr INTEGER PRIMARY KEY AUTOINCREMENT, Debiteurnummer INTEGER, Debiteurnaam TEXT, Projectnummer INTEGER, Projectnaam TEXT, Telefoonnummer TEXT, Contactpersoon TEXT, Weeknummer INTEGER, Straat TEXT, Huisnummer TEXT, Postcode TEXT, Plaats TEXT, Status TEXT, StartDatum TEXT,GereedDatum TEXT, Opmerkingen TEXT, HandtekeningVisschedijk BLOB, HandtekeningOpdrachtgever BLOB, GebruikerNr INTEGER, FOREIGN KEY (GebruikerNr) REFERENCES Gebruiker (GebruikerNr))";	
		String CREATE_VRAAG = "CREATE TABLE Vraag (VraagNr INTEGER PRIMARY KEY AUTOINCREMENT, Vraag TEXT, Antwoord TEXT, KwaliteitsverslagNr INTEGER, BezoekverslagNr INTEGER, FOREIGN KEY (KwaliteitsverslagNr) REFERENCES Kwaliteitsverslag (KwaliteitsverslagNr), FOREIGN KEY (BezoekverslagNr) REFERENCES Bezoekverslag (BezoekverslagNr))";
		String CREATE_ANTWOORD = "CREATE TABLE Antwoord (AntwoordNr INTEGER PRIMARY KEY AUTOINCREMENT, Antwoord TEXT, Visible INTEGER, Selected INTEGER, VraagNr INTEGER, FOREIGN KEY (VraagNr) REFERENCES Vraag (VraagNr))";
		String CREATE_AFSPRAAK = "CREATE TABLE Afspraak (AfspraakNr INTEGER PRIMARY KEY AUTOINCREMENT, Afspraak TEXT, Wie TEXT, Datum TEXT, BezoekverslagNr INTEGER, FOREIGN KEY (BezoekverslagNr) REFERENCES Bezoekverslag (BezoekverslagNr))";
		String CREATE_IDENTITEITSBEWIJS = "CREATE TABLE Identiteitsbewijs (IdentiteitsbewijskNr INTEGER PRIMARY KEY AUTOINCREMENT, Naam TEXT, Type TEXT, VervalDatum TEXT, Sofinummer INTEGER, GebruikerNr INTEGER, FOREIGN KEY (GebruikerNr) REFERENCES Gebruiker (GebruikerNr))";
		String CREATE_OPTIONS = "CREATE TABLE Options (OptionsNr INTEGER PRIMARY KEY AUTOINCREMENT, GroeperenOp TEXT, SorterenOp TEXT, Taal TEXT, DisplayPlannedHours INTEGER, AccountId INTEGER, DeviceId INTEGER, Host TEXT, Port INTEGER, GebruikerNr INTEGER, FOREIGN KEY (GebruikerNr) REFERENCES Gebruiker (GebruikerNr))";
		String CREATE_CONTROLE = "CREATE TABLE Controle (ControleNr INTEGER PRIMARY KEY AUTOINCREMENT)";
		db.execSQL(CREATE_BEDRIJF);
		db.execSQL(CREATE_GEBRUIKER);
		db.execSQL(CREATE_WERKBON);
		db.execSQL(CREATE_BEZOEKVERSLAG);
		db.execSQL(CREATE_KWALITEITSVERSLAG);
		db.execSQL(CREATE_VRAAG);
		db.execSQL(CREATE_ANTWOORD);
		db.execSQL(CREATE_AFSPRAAK);
		db.execSQL(CREATE_IDENTITEITSBEWIJS);
		db.execSQL(CREATE_OPTIONS);
		db.execSQL(CREATE_CONTROLE);
	}
	
	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		db.execSQL("DROP TABLE IF EXISTS " + "Bedrijf");
		db.execSQL("DROP TABLE IF EXISTS " + "Gebruiker");
		db.execSQL("DROP TABLE IF EXISTS " + "Werkbon");
		db.execSQL("DROP TABLE IF EXISTS " + "Bezoekverslag");
		db.execSQL("DROP TABLE IF EXISTS " + "Kwaliteitsverslag");
		db.execSQL("DROP TABLE IF EXISTS " + "Vraag");
		db.execSQL("DROP TABLE IF EXISTS " + "Antwoord");
		db.execSQL("DROP TABLE IF EXISTS " + "Afspraak");
		db.execSQL("DROP TABLE IF EXISTS " + "Identiteitsbewijs");
		db.execSQL("DROP TABLE IF EXISTS " + "Options");
		db.execSQL("DROP TABLE IF EXISTS " + "Controle");
        
		// Create tables again
        onCreate(db);
	}
	
	//Getting all
	public ArrayList<Werkbon> getAlleWerkbonnen(){
		
		werkbonnen = new ArrayList<Werkbon>();
		String selectQuery = "SELECT * FROM Werkbon ";
		
		SQLiteDatabase db = this.getWritableDatabase();
		
		Cursor cursor = db.rawQuery(selectQuery, null);
	    
	// looping through all rows and adding to list
	       if (cursor.moveToFirst()) {
	           do {
	        	   Werkbon werkbon = new Werkbon(0, 0, null, 0, null, null, null, 0, null, 0, null, null, null, null, null, null, null, null, null, 0);
	        	   werkbon.setWerkbonNr(cursor.getInt(0));
	        	   werkbon.setDebiteurnummer(cursor.getInt(1));
	        	   werkbon.setDebiteurnaam(cursor.getString(2));
	        	   werkbon.setProjectnummer(cursor.getInt(3));
	        	   werkbon.setProjectnaam(cursor.getString(4));
	        	   werkbon.setTelefoonnummer(cursor.getString(5));
	        	   werkbon.setContactpersoon(cursor.getString(6));
	        	   werkbon.setWeeknummer(cursor.getInt(7));
	        	   werkbon.setStartDatum(cursor.getString(8));
	        	   werkbon.setUren(cursor.getDouble(9));
	        	   werkbon.setStraat(cursor.getString(10));
	        	   werkbon.setHuisnummer(cursor.getString(11));
	        	   werkbon.setPostcode(cursor.getString(12));
	        	   werkbon.setPlaats(cursor.getString(13));
	        	   werkbon.setExtraOpmerking(cursor.getString(14));
	        	   werkbon.setStatus(cursor.getString(15));
	        	   werkbon.setGereedDatum(cursor.getString(16));
	        	   werkbon.setOpmerkingen(cursor.getString(17));
	        	   werkbon.setHandtekening(cursor.getBlob(18));
	        	   werkbon.setGebruikerNr(cursor.getInt(19));
	        	   
	// Adding to list
	        	   werkbonnen.add(werkbon);
	           } while (cursor.moveToNext());
	       }
	       return werkbonnen;
	}
	
	//Getting all
	public ArrayList<Werkbon> getAlleGebruikerWerkbonnen(int id){
		
		werkbonnen = new ArrayList<Werkbon>();
		
		SQLiteDatabase db = this.getWritableDatabase();
		
		Cursor cursor = db.query("Werkbon", new String[] { "WerkbonNr",
	    		"Debiteurnummer", "Debiteurnaam", "Projectnummer", "Projectnaam", 
	    		"Telefoonnummer", "Contactpersoon", "Weeknummer", "StartDatum",
	    		"Uren", "Straat", "Huisnummer", "Postcode", 
	    		"Plaats", "ExtraOpmerking", "Status", "GereedDatum", "Opmerkingen",
	    		"Handtekening", "GebruikerNr"}, "GebruikerNr" + "=?",
	            new String[] { String.valueOf(id) }, null, null, null, null);
	    
	    
	// looping through all rows and adding to list
	       if (cursor.moveToFirst()) {
	           do {
	        	   Werkbon werkbon = new Werkbon(0, 0, null, 0, null, null, null, 0, null, 0, null, null, null, null, null, null, null, null, null, 0);
	        	   werkbon.setWerkbonNr(cursor.getInt(0));
	        	   werkbon.setDebiteurnummer(cursor.getInt(1));
	        	   werkbon.setDebiteurnaam(cursor.getString(2));
	        	   werkbon.setProjectnummer(cursor.getInt(3));
	        	   werkbon.setProjectnaam(cursor.getString(4));
	        	   werkbon.setTelefoonnummer(cursor.getString(5));
	        	   werkbon.setContactpersoon(cursor.getString(6));
	        	   werkbon.setWeeknummer(cursor.getInt(7));
	        	   werkbon.setStartDatum(cursor.getString(8));
	        	   werkbon.setUren(cursor.getDouble(9));
	        	   werkbon.setStraat(cursor.getString(10));
	        	   werkbon.setHuisnummer(cursor.getString(11));
	        	   werkbon.setPostcode(cursor.getString(12));
	        	   werkbon.setPlaats(cursor.getString(13));
	        	   werkbon.setExtraOpmerking(cursor.getString(14));
	        	   werkbon.setStatus(cursor.getString(15));
	        	   werkbon.setGereedDatum(cursor.getString(16));
	        	   werkbon.setOpmerkingen(cursor.getString(17));
	        	   werkbon.setHandtekening(cursor.getBlob(18));
	        	   werkbon.setGebruikerNr(cursor.getInt(19));
	        	   
	// Adding to list
	        	   werkbonnen.add(werkbon);
	           } while (cursor.moveToNext());
	       }
	       return werkbonnen;
	}
	
	// Getting single
	public Werkbon getWerkbon(int id) {
	    SQLiteDatabase db = this.getReadableDatabase();
	 
	    Cursor cursor = db.query("Werkbon", new String[] { "WerkbonNr",
	    		"Debiteurnummer", "Debiteurnaam", "Projectnummer", "Projectnaam", 
	    		"Telefoonnummer", "Contactpersoon", "Weeknummer", "StartDatum",
	    		"Uren", "Straat", "Huisnummer", "Postcode", 
	    		"Plaats", "ExtraOpmerking", "Status", "GereedDatum", "Opmerkingen",
	    		"Handtekening", "GebruikerNr"}, "WerkbonNr" + "=?",
	            new String[] { String.valueOf(id) }, null, null, null, null);
	    if (cursor != null)
	        cursor.moveToFirst();
	    
		   Werkbon werkbon = new Werkbon(0, 0, null, 0, null, null, null, 0, null, 0, null, null, null, null, null, null, null, null, null, 0);
		   werkbon.setWerkbonNr(cursor.getInt(0));
    	   werkbon.setDebiteurnummer(cursor.getInt(1));
    	   werkbon.setDebiteurnaam(cursor.getString(2));
    	   werkbon.setProjectnummer(cursor.getInt(3));
    	   werkbon.setProjectnaam(cursor.getString(4));
    	   werkbon.setTelefoonnummer(cursor.getString(5));
    	   werkbon.setContactpersoon(cursor.getString(6));
    	   werkbon.setWeeknummer(cursor.getInt(7));
    	   werkbon.setStartDatum(cursor.getString(8));
    	   werkbon.setUren(cursor.getDouble(9));
    	   werkbon.setStraat(cursor.getString(10));
    	   werkbon.setHuisnummer(cursor.getString(11));
    	   werkbon.setPostcode(cursor.getString(12));
    	   werkbon.setPlaats(cursor.getString(13));
    	   werkbon.setExtraOpmerking(cursor.getString(14));
    	   werkbon.setStatus(cursor.getString(15));
    	   werkbon.setGereedDatum(cursor.getString(16));
    	   werkbon.setOpmerkingen(cursor.getString(17));
    	   werkbon.setHandtekening(cursor.getBlob(18));
    	   werkbon.setGebruikerNr(cursor.getInt(19));
    	   
	// return 
	    return werkbon;
	}
	
	public void addWerkbon(Werkbon werkbon) {
    	SQLiteDatabase db = this.getWritableDatabase();
    	
	    ContentValues values = new ContentValues();
	    values.put("Debiteurnummer", werkbon.getDebiteurnummer());
	    values.put("Debiteurnaam", werkbon.getDebiteurnaam());
	    values.put("Projectnummer", werkbon.getProjectnummer());
	    values.put("Projectnaam", werkbon.getProjectnaam());
	    values.put("Telefoonnummer", werkbon.getTelefoonnummer());
	    values.put("Contactpersoon", werkbon.getContactpersoon());
	    values.put("Weeknummer", werkbon.getWeeknummer());
	    values.put("StartDatum", werkbon.getStartDatum());
	    values.put("Uren", werkbon.getUren());
	    values.put("Straat", werkbon.getStraat());
	    values.put("Huisnummer", werkbon.getHuisnummer());
	    values.put("Postcode", werkbon.getPostcode());
	    values.put("Plaats", werkbon.getPlaats());
	    values.put("ExtraOpmerking", werkbon.getExtraOpmerking());
	    values.put("Status", werkbon.getStatus());
	    values.put("GereedDatum", werkbon.getGereedDatum());
	    values.put("Opmerkingen", werkbon.getOpmerkingen());
	    values.put("Handtekening", werkbon.getHandtekening());
	    values.put("GebruikerNr", werkbon.getGebruikerNr());
	    
	// Inserting Row
	    db.insert("Werkbon", null, values);
	    db.close(); // Closing database connection
    }
	
	public int updateWerkbon(Werkbon werkbon) {
	    SQLiteDatabase db = this.getWritableDatabase();
	    
	    ContentValues values = new ContentValues();
	    values.put("Debiteurnummer", werkbon.getDebiteurnummer());
	    values.put("Debiteurnaam", werkbon.getDebiteurnaam());
	    values.put("Projectnummer", werkbon.getProjectnummer());
	    values.put("Projectnaam", werkbon.getProjectnaam());
	    values.put("Telefoonnummer", werkbon.getTelefoonnummer());
	    values.put("Contactpersoon", werkbon.getContactpersoon());
	    values.put("Weeknummer", werkbon.getWeeknummer());
	    values.put("StartDatum", werkbon.getStartDatum());
	    values.put("Uren", werkbon.getUren());
	    values.put("Straat", werkbon.getStraat());
	    values.put("Huisnummer", werkbon.getHuisnummer());
	    values.put("Postcode", werkbon.getPostcode());
	    values.put("Plaats", werkbon.getPlaats());
	    values.put("ExtraOpmerking", werkbon.getExtraOpmerking());
	    values.put("Status", werkbon.getStatus());
	    values.put("GereedDatum", werkbon.getGereedDatum());
	    values.put("Opmerkingen", werkbon.getOpmerkingen());
	    values.put("Handtekening", werkbon.getHandtekening());
	    values.put("GebruikerNr", werkbon.getGebruikerNr());
    
    // updating row
	    return db.update("Werkbon", values, "WerkbonNr" + "=" +
	    		werkbon.getWerkbonNr(), null);
    }
	
	public void deleteWerkbon(Werkbon werkbon) {
		SQLiteDatabase db = this.getWritableDatabase();
	
	// deleting row	
		db.delete("Werkbon", "WerkbonNr" + "=" + werkbon.getWerkbonNr(), null);
	}
	

	//Getting all
	public ArrayList<Antwoord> getAlleAntwoorden(){
		antwoorden = new ArrayList<Antwoord>();
		String selectQuery = "select * from Antwoord ";
		
		SQLiteDatabase db = this.getWritableDatabase();
		
		Cursor cursor = db.rawQuery(selectQuery, null);
	    
	// looping through all rows and adding to list
	       if (cursor.moveToFirst()) {
	           do {
	        	   Antwoord antwoord = new Antwoord(0, null, null, null, 0);
	        	   antwoord.setAntwoordNr(cursor.getInt(0));
	        	   antwoord.setAntwoord(cursor.getString(1));
	               antwoord.setVisible(cursor.getInt(2)>0);
	               antwoord.setVraagNr(cursor.getInt(3));
	        	   
	// Adding contact to list
	        	   antwoorden.add(antwoord);
	           } while (cursor.moveToNext());
	       }
	       return antwoorden;
	}
	
	//Getting all
		public ArrayList<Antwoord> getAlleVraagAntwoorden(int id){
			antwoorden = new ArrayList<Antwoord>();
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.query("Antwoord", new String[] { "AntwoordNr",
		    		"Antwoord", "Visible", "Selected","VraagNr"}, "VraagNr" + "=?",
		            new String[] { String.valueOf(id) }, null, null, null, null);
		    
		// looping through all rows and adding to list
			if (cursor != null)   
			if (cursor.moveToFirst()) {
		           do {
		        	   Antwoord antwoord = new Antwoord(0, null, null, null, 0);
		        	   antwoord.setAntwoordNr(cursor.getInt(0));
		        	   antwoord.setAntwoord(cursor.getString(1));
		               antwoord.setVisible(cursor.getInt(2)>0);
		               antwoord.setSelected(cursor.getInt(3)>0);
		               antwoord.setVraagNr(cursor.getInt(4));
		        	   
		// Adding contact to list
		        	   antwoorden.add(antwoord);
		           } while (cursor.moveToNext());
		       }
		       return antwoorden;
		}
	
	// Getting single
	public Antwoord getAntwoord(int id) {
		SQLiteDatabase db = this.getReadableDatabase();
		 
		    Cursor cursor = db.query("Antwoord", new String[] { "AntwoordNr",
		    		"Antwoord", "Visible", "Selected","VraagNr"}, "AntwoordNr" + "=?",
		            new String[] { String.valueOf(id) }, null, null, null, null);
		    if (cursor != null)
		        cursor.moveToFirst();
		    
			    Antwoord antwoord = new Antwoord(0, null, null, null, 0);
	     	    antwoord.setAntwoordNr(cursor.getInt(0));
	     	    antwoord.setAntwoord(cursor.getString(1));
	            antwoord.setVisible(cursor.getInt(2)>0);
	            antwoord.setSelected(cursor.getInt(3)>0);
	            antwoord.setVraagNr(cursor.getInt(4));
		    
	// return 
	            return antwoord;
	}
	
	public void addAntwoord(Antwoord antwoord) {
    	SQLiteDatabase db = this.getWritableDatabase();
 
	    ContentValues values = new ContentValues();
	    values.put("Antwoord", antwoord.getAntwoord());
	    values.put("Visible", antwoord.getVisible());
	    values.put("Selected", antwoord.getSelected());
	    values.put("VraagNr", antwoord.getVraagNr());
	    
	// Inserting Row
	    db.insert("Antwoord", null, values);
	    db.close(); // Closing database connection
    }
	
	public int updateAntwoord(Antwoord antwoord) {
	    SQLiteDatabase db = this.getWritableDatabase();
	    
	    ContentValues values = new ContentValues();
	    values.put("Antwoord", antwoord.getAntwoord());
	    values.put("Visible", antwoord.getVisible());
	    values.put("Selected", antwoord.getSelected());
	    values.put("VraagNr", antwoord.getVraagNr());

    // updating row
	    return db.update("Antwoord", values, "AntwoordNr" + "=" +
	    		antwoord.getAntwoordNr(), null);
    }
	
	public void deleteAntwoord(Antwoord antwoord) {
		SQLiteDatabase db = this.getWritableDatabase();
		
	// deleting row	
		db.delete("Antwoord", "AntwoordNr" + "=" + antwoord.getAntwoordNr(), null);
	}
	
	//Getting all
	public ArrayList<Vraag> getAlleVragen(){
		vragen = new ArrayList<Vraag>();
		String selectQuery = "SELECT * FROM Vraag";
		
		SQLiteDatabase db = this.getWritableDatabase();
		
		Cursor cursor = db.rawQuery(selectQuery, null);
	    
	// looping through all rows and adding to list
	       if (cursor.moveToFirst()) {
	           do {
	        	   Vraag vraag = new Vraag(0, null, null, 0, 0, null);
	        	   vraag.setVraagNr(cursor.getInt(0));
	        	   vraag.setVraag(cursor.getString(1));
	        	   vraag.setAntwoord(cursor.getString(2));       	   
	        	   vraag.setKwaliteitsverslagNr(cursor.getInt(3));
	        	   vraag.setBezoekverslagNr(cursor.getInt(4));
	        	   vraag.setAntwoorden(getAlleVraagAntwoorden(cursor.getInt(0)));
	// Adding to list
	               vragen.add(vraag);
	           } while (cursor.moveToNext());
	       }

	       return vragen;
	}
	
	//Getting all
	public ArrayList<Vraag> getAlleBezoekverslagVragen(int id){
		vragen = new ArrayList<Vraag>();
		
		SQLiteDatabase db = this.getWritableDatabase();
			
		Cursor cursor = db.query("Vraag", new String[] { "VraagNr",
	    		"Vraag", "Antwoord", "KwaliteitsverslagNr", "BezoekverslagNr"}, "BezoekverslagNr" + "=?",
	            new String[] { String.valueOf(id) }, null, null, null, null);
	    	    
	// looping through all rows and adding to list
		if (cursor != null)
		if (cursor.moveToFirst()) {
		     do {
		    	 Vraag vraag = new Vraag(0, null, null, 0, 0, null);
		    	 vraag.setVraagNr(cursor.getInt(0));
		    	 vraag.setVraag(cursor.getString(1));
		    	 vraag.setAntwoord(cursor.getString(2));
		    	 vraag.setKwaliteitsverslagNr(cursor.getInt(3));
	        	 vraag.setBezoekverslagNr(cursor.getInt(4));
		    	 vraag.setAntwoorden(getAlleVraagAntwoorden(cursor.getInt(0)));
	// Adding to list
		         vragen.add(vraag);
		         } while (cursor.moveToNext());
		    }
		 return vragen;
	}
		
	//Getting all
	public ArrayList<Vraag> getAlleKwaliteitsverslagVragen(int id){
		vragen = new ArrayList<Vraag>();
			
		SQLiteDatabase db = this.getWritableDatabase();
			
		Cursor cursor = db.query("Vraag", new String[] { "VraagNr",
	    		"Vraag", "Antwoord", "KwaliteitsverslagNr", "BezoekverslagNr"}, "KwaliteitsverslagNr" + "=?",
	            new String[] { String.valueOf(id) }, null, null, null, null);	    
		    
	// looping through all rows and adding to list
		if (cursor != null)
		if (cursor.moveToFirst()) {
		     do {
		    	 Vraag vraag = new Vraag(0, null, null, 0, 0, null);
		    	 vraag.setVraagNr(cursor.getInt(0));
		    	 vraag.setVraag(cursor.getString(1));
		    	 vraag.setAntwoord(cursor.getString(2));
		    	 vraag.setKwaliteitsverslagNr(cursor.getInt(3));
	        	 vraag.setBezoekverslagNr(cursor.getInt(4));
		    	 vraag.setAntwoorden(getAlleVraagAntwoorden(cursor.getInt(0)));
	// Adding to list
		         vragen.add(vraag);
		         } while (cursor.moveToNext());
		    }

		 return vragen;
	}
	
	// Getting single
	public Vraag getVraag(int id) {
			SQLiteDatabase db = this.getReadableDatabase();
			 
			Cursor cursor = db.query("Vraag", new String[] { "VraagNr",
			    		"Vraag", "Antwoord", "KwaliteitsverslagNr", "BezoekverslagNr"}, "VraagNr" + "=?",
			            new String[] { String.valueOf(id) }, null, null, null, null);
			    if (cursor != null)
			        cursor.moveToFirst();
			    
			    	Vraag vraag = new Vraag(0, null, null, 0, 0, null);
	        	    vraag.setVraagNr(cursor.getInt(0));
	        	    vraag.setVraag(cursor.getString(1));
		        	vraag.setAntwoord(cursor.getString(2));
	        	    vraag.setKwaliteitsverslagNr(cursor.getInt(3));
		        	vraag.setBezoekverslagNr(cursor.getInt(4));
		        	vraag.setAntwoorden(getAlleVraagAntwoorden(cursor.getInt(0)));
		        	
	// return 
	        return vraag;
	}
	
	public void addVraag(Vraag vraag) {
    	SQLiteDatabase db = this.getWritableDatabase();
 
	    ContentValues values = new ContentValues();
	    values.put("Vraag", vraag.getVraag());
	    values.put("Antwoord", vraag.getAntwoord());
	    values.put("KwaliteitsverslagNr", vraag.getKwaliteitsverslagNr());
	    values.put("BezoekverslagNr", vraag.getBezoekverslagNr());
	
	    // Inserting Row
	    db.insert("Vraag", null, values);
	    db.close(); // Closing database connection
    }
	
	public int updateVraag(Vraag vraag) {
	    SQLiteDatabase db = this.getWritableDatabase();
	    
	    ContentValues values = new ContentValues();
	    values.put("Vraag", vraag.getVraag());
	    values.put("Antwoord", vraag.getAntwoord());
	    values.put("KwaliteitsverslagNr", vraag.getKwaliteitsverslagNr());
	    values.put("BezoekverslagNr", vraag.getBezoekverslagNr()); 

    // updating row
	    return db.update("Vraag", values, "VraagNr" + "=" +
	    		vraag.getVraagNr(), null);
    }
	
	public void deleteVraag(Vraag vraag) {
		SQLiteDatabase db = this.getWritableDatabase();
	
	// deleting row	
		db.delete("Vraag", "VraagNr" + "=" + vraag.getVraagNr(), null);
	}

	//Getting all
	public ArrayList<Afspraak> getAlleAfspraken(){
		afspraken = new ArrayList<Afspraak>();
		String selectQuery = "select * from Afspraak";
		
		SQLiteDatabase db = this.getWritableDatabase();
		
		Cursor cursor = db.rawQuery(selectQuery, null);
	    
	// looping through all rows and adding to list
	       if (cursor.moveToFirst()) {
	           do {
	        	   Afspraak afspraak = new Afspraak(0, null, null, null, 0);
	        	   afspraak.setAfspraakNr(cursor.getInt(0));
	        	   afspraak.setAfspraak(cursor.getString(1));
	        	   afspraak.setWie(cursor.getString(2));
	        	   afspraak.setDatum(cursor.getString(3));
	        	   afspraak.setBezoekverslagNr(cursor.getInt(4));

	// Adding to list
	        	   afspraken.add(afspraak);
	           } while (cursor.moveToNext());
	       }

	       return afspraken;
	}
	
	//Getting all
	public ArrayList<Afspraak> getAlleBezoekverslagAfspraken(int id){
		afspraken = new ArrayList<Afspraak>();
		
		SQLiteDatabase db = this.getWritableDatabase();
		
		Cursor cursor = db.query("Afspraak", new String[] { "AfspraakNr",
	    		"Afspraak", "Wie", "Datum", "BezoekverslagNr"}, "BezoekverslagNr" + "=?",
	            new String[] { String.valueOf(id) }, null, null, null, null);
	    
	    
	// looping through all rows and adding to list
		if (cursor != null)
	       if (cursor.moveToFirst()) {
	           do {
	        	   Afspraak afspraak = new Afspraak(0, null, null, null, 0);
	        	   afspraak.setAfspraakNr(cursor.getInt(0));
	        	   afspraak.setAfspraak(cursor.getString(1));
	        	   afspraak.setWie(cursor.getString(2));
	        	   afspraak.setDatum(cursor.getString(3));
	        	   afspraak.setBezoekverslagNr(cursor.getInt(4));

	// Adding to list
	        	   afspraken.add(afspraak);
	           } while (cursor.moveToNext());
	       }

	       return afspraken;
	}
	
	public int getMaxAfspraak(int id) {
		SQLiteDatabase db = this.getReadableDatabase();
	   
	    final String MY_QUERY = "SELECT MAX(AfspraakNr) AS AfspraakNr FROM Afspraak WHERE BezoekverslagNr =" + String.valueOf(id);
	    Cursor mCursor = db.rawQuery(MY_QUERY, null);  
	    
	    try {
	          if (mCursor.getCount() > 0) {
	            mCursor.moveToFirst();
	            id = mCursor.getInt(0);
	          }
	        } 
	    catch (Exception e) {
	          System.out.println(e.getMessage());
	        } 
	    finally {
	        	db.close();
	        }
	    
	    return id;
	}
	
	// Getting single
	public Afspraak getAfspraak(int id) {
			SQLiteDatabase db = this.getReadableDatabase();
			 
			Cursor cursor = db.query("Afspraak", new String[] { "AfspraakNr",
			    		"Afspraak", "Wie", "Datum", "BezoekverslagNr"}, "AfspraakNr" + "=?",
			            new String[] { String.valueOf(id) }, null, null, null, null);
			    if (cursor != null)
			        cursor.moveToFirst();
			    
			    	Afspraak afspraak = new Afspraak(0, null, null, null, 0);
			    	afspraak.setAfspraakNr(cursor.getInt(0));
		        	afspraak.setAfspraak(cursor.getString(1));
		        	afspraak.setWie(cursor.getString(2));
		        	afspraak.setDatum(cursor.getString(3));
		        	afspraak.setBezoekverslagNr(cursor.getInt(4));
		        	
	// return 
	        return afspraak;
	}
	
	public void addAfspraak(Afspraak afspraak) {
    	SQLiteDatabase db = this.getWritableDatabase();
 
	    ContentValues values = new ContentValues();
	    values.put("Afspraak", afspraak.getAfspraak());
	    values.put("Wie", afspraak.getWie());
	    values.put("Datum", afspraak.getDatum());
	    values.put("BezoekverslagNr", afspraak.getBezoekverslagNr());
	    
	// Inserting Row
	    db.insert("Afspraak", null, values);
	    db.close(); // Closing database connection
    }
	
	public int updateAfspraak(Afspraak afspraak) {
	    SQLiteDatabase db = this.getWritableDatabase();
	    
	    ContentValues values = new ContentValues();
	    values.put("Afspraak", afspraak.getAfspraak());
	    values.put("Wie", afspraak.getWie());
	    values.put("Datum", afspraak.getDatum());
	    values.put("BezoekverslagNr", afspraak.getBezoekverslagNr());

    // updating row
	    return db.update("Afspraak", values, "AfspraakNr" + "=" +
	    		afspraak.getAfspraakNr(), null);
    }
	
	public void deleteAfspraak(Afspraak afspraak) {
		SQLiteDatabase db = this.getWritableDatabase();
	
	// deleting row	
		db.delete("Afspraak", "AfspraakNr" + "=" + afspraak.getAfspraakNr(), null);
	}
	
	//Getting all
	public ArrayList<Bezoekverslag> getAlleBezoekverslagen(){
		bezoekverslagen = new ArrayList<Bezoekverslag>();
		String selectQuery = "SELECT * FROM Bezoekverslag";
		
		SQLiteDatabase db = this.getWritableDatabase();
		
		Cursor cursor = db.rawQuery(selectQuery, null);
	    
	// looping through all rows and adding to list
	       if (cursor.moveToFirst()) {
	           do {
	        	   Bezoekverslag bezoekverslag = new Bezoekverslag(0, null, null, null, null, null, null, null, 0, null, null);
	        	   bezoekverslag.setBezoekverslagNr(cursor.getInt(0));
	        	   bezoekverslag.setRelatie(cursor.getString(1));
	        	   bezoekverslag.setContactpersoon(cursor.getString(2));
	        	   bezoekverslag.setOnderwerp(cursor.getString(3));
	        	   bezoekverslag.setGespreksOnderwerpen(cursor.getString(4));
	        	   bezoekverslag.setGereedDatum(cursor.getString(5));
	        	   bezoekverslag.setStatus(cursor.getString(6));
	        	   bezoekverslag.setHandtekening(cursor.getBlob(7));
	        	   bezoekverslag.setGebruikerNr(cursor.getInt(8));
	        	   //bezoekverslag.setVragen(getAlleBezoekverslagVragen(cursor.getInt(0)));
	        	   //bezoekverslag.setAfspraken(getAlleBezoekverslagAfspraken(cursor.getInt(0)));  
	        	   
	        	   // Adding to list
	        	   bezoekverslagen.add(bezoekverslag);
	           } while (cursor.moveToNext());
	       }

	       return bezoekverslagen;
	}
	
	//Getting all
	public ArrayList<Bezoekverslag> getAlleGebruikerBezoekverslagen(int id){
		bezoekverslagen = new ArrayList<Bezoekverslag>();
		
		SQLiteDatabase db = this.getWritableDatabase();
		
		Cursor cursor = db.query("Bezoekverslag", new String[] { "BezoekverslagNr",
	    		"Relatie", "Contactpersoon", "Onderwerp", "GespreksOnderwerpen",
	    		"GereedDatum", "Status", "Handtekening", "GebruikerNr"}, "GebruikerNr" + "=?",
	            new String[] { String.valueOf(id) }, null, null, null, null);
	    
	// looping through all rows and adding to list
	       if (cursor.moveToFirst()) {
	           do {
	        	   Bezoekverslag bezoekverslag = new Bezoekverslag(0, null, null, null, null, null, null, null, 0, null, null);
	        	   bezoekverslag.setBezoekverslagNr(cursor.getInt(0));
	        	   bezoekverslag.setRelatie(cursor.getString(1));
	        	   bezoekverslag.setContactpersoon(cursor.getString(2));
	        	   bezoekverslag.setOnderwerp(cursor.getString(3));
	        	   bezoekverslag.setGespreksOnderwerpen(cursor.getString(4));
	        	   bezoekverslag.setGereedDatum(cursor.getString(5));
	        	   bezoekverslag.setStatus(cursor.getString(6));
	        	   bezoekverslag.setHandtekening(cursor.getBlob(7));
	        	   bezoekverslag.setGebruikerNr(cursor.getInt(8));
	        	   bezoekverslag.setVragen(getAlleBezoekverslagVragen(cursor.getInt(0)));
	        	   bezoekverslag.setAfspraken(getAlleBezoekverslagAfspraken(cursor.getInt(0)));  
	        	   
	        	   // Adding to list
	        	   bezoekverslagen.add(bezoekverslag);
	           } while (cursor.moveToNext());
	       }
	       return bezoekverslagen;
	}
	
	// Getting single
	public Bezoekverslag getBezoekverslag(int id) {
			SQLiteDatabase db = this.getReadableDatabase();
			 
			Cursor cursor = db.query("Bezoekverslag", new String[] { "BezoekverslagNr",
			    		"Relatie", "Contactpersoon", "Onderwerp", "GespreksOnderwerpen",
			    		"GereedDatum", "Status", "Handtekening", "GebruikerNr"}, "BezoekverslagNr" + "=?",
			            new String[] { String.valueOf(id) }, null, null, null, null);
			    if (cursor != null)
			        cursor.moveToFirst();
			    
			    Bezoekverslag bezoekverslag = new Bezoekverslag(0, null, null, null, null, null, null, null, 0, null, null);
	        	bezoekverslag.setBezoekverslagNr(cursor.getInt(0));
	        	bezoekverslag.setRelatie(cursor.getString(1));
	        	bezoekverslag.setContactpersoon(cursor.getString(2));
	        	bezoekverslag.setOnderwerp(cursor.getString(3));
	        	bezoekverslag.setGespreksOnderwerpen(cursor.getString(4));
	        	bezoekverslag.setGereedDatum(cursor.getString(5));
	        	bezoekverslag.setStatus(cursor.getString(6));
	        	bezoekverslag.setHandtekening(cursor.getBlob(7));
	        	bezoekverslag.setGebruikerNr(cursor.getInt(8));
	        	//bezoekverslag.setVragen(getAlleBezoekverslagVragen(cursor.getInt(0)));
	        	//bezoekverslag.setAfspraken(getAlleBezoekverslagAfspraken(cursor.getInt(0)));  
	        	   	
	// return 
	        return bezoekverslag;
	}
	
	public void addBezoekverslag(Bezoekverslag bezoekverslag) {
    	SQLiteDatabase db = this.getWritableDatabase();
 
	    ContentValues values = new ContentValues();
	    values.put("Relatie", bezoekverslag.getRelatie());
	    values.put("Contactpersoon", bezoekverslag.getContactpersoon());
	    values.put("Onderwerp", bezoekverslag.getOnderwerp());
	    values.put("GespreksOnderwerpen", bezoekverslag.getGespreksOnderwerpen());
	    values.put("GereedDatum", bezoekverslag.getGereedDatum());
	    values.put("Status", bezoekverslag.getStatus());
	    values.put("Handtekening", bezoekverslag.getHandtekening());
	    values.put("GebruikerNr", bezoekverslag.getGebruikerNr());
	    
	// Inserting Row
	    db.insert("Bezoekverslag", null, values);
	    db.close(); // Closing database connection
    }
	
	public int updateBezoekverslag(Bezoekverslag bezoekverslag) {
	    SQLiteDatabase db = this.getWritableDatabase();
	    
	    ContentValues values = new ContentValues();
	    values.put("Relatie", bezoekverslag.getRelatie());
	    values.put("Contactpersoon", bezoekverslag.getContactpersoon());
	    values.put("Onderwerp", bezoekverslag.getOnderwerp());
	    values.put("GespreksOnderwerpen", bezoekverslag.getGespreksOnderwerpen());
	    values.put("GereedDatum", bezoekverslag.getGereedDatum());
	    values.put("Status", bezoekverslag.getStatus());
	    values.put("Handtekening", bezoekverslag.getHandtekening());
	    values.put("GebruikerNr", bezoekverslag.getGebruikerNr());

    // updating row
	    return db.update("Bezoekverslag", values, "BezoekverslagNr" + "=" +
	    		bezoekverslag.getBezoekverslagNr(), null);
    }
	
	public void deleteBezoekverslag(Bezoekverslag bezoekverslag) {
		SQLiteDatabase db = this.getWritableDatabase();
	
	// deleting row	
		db.delete("Bezoekverslag", "BezoekverslagNr" + "=" + bezoekverslag.getBezoekverslagNr(), null);
	}
	
	//Getting all
		public ArrayList<Kwaliteitsverslag> getAllKwaliteitsverslagen(){
			
			kwaliteitsverslagen = new ArrayList<Kwaliteitsverslag>();
			String selectQuery = "SELECT * FROM Kwaliteitsverslag ";
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.rawQuery(selectQuery, null);
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Kwaliteitsverslag kwaliteitsverslag = new Kwaliteitsverslag(0, 0, null, 0, null, null, null, 0, null, null, null, null, null, null, null, null, null, null, 0, null);
		        	   kwaliteitsverslag.setKwaliteitsverslagNr(cursor.getInt(0));
		        	   kwaliteitsverslag.setDebiteurnummer(cursor.getInt(1));
		        	   kwaliteitsverslag.setDebiteurnaam(cursor.getString(2));
		        	   kwaliteitsverslag.setProjectnummer(cursor.getInt(3));
		        	   kwaliteitsverslag.setProjectnaam(cursor.getString(4));
		        	   kwaliteitsverslag.setTelefoonnummer(cursor.getString(5));
		        	   kwaliteitsverslag.setContactpersoon(cursor.getString(6));
		        	   kwaliteitsverslag.setWeeknummer(cursor.getInt(7));
		        	   kwaliteitsverslag.setStraat(cursor.getString(8));
		        	   kwaliteitsverslag.setHuisnummer(cursor.getString(9));
		        	   kwaliteitsverslag.setPostcode(cursor.getString(10));
		        	   kwaliteitsverslag.setPlaats(cursor.getString(11));
		        	   kwaliteitsverslag.setStatus(cursor.getString(12));
		        	   kwaliteitsverslag.setStartDatum(cursor.getString(13));
		        	   kwaliteitsverslag.setGereedDatum(cursor.getString(14));
		        	   kwaliteitsverslag.setOpmerkingen(cursor.getString(15));
		        	   kwaliteitsverslag.setHandtekeningVisschedijk(cursor.getBlob(16));
		        	   kwaliteitsverslag.setHandtekeningOpdrachtgever(cursor.getBlob(17));
		        	   kwaliteitsverslag.setGebruikerNr(cursor.getInt(18));
		        	   //kwaliteitsverslag.setVragen(getAlleKwaliteitsverslagVragen(cursor.getInt(0)));
		        	  
		        	   // Adding to list
		        	   kwaliteitsverslagen.add(kwaliteitsverslag);
		           } while (cursor.moveToNext());
		       }
		       return kwaliteitsverslagen;
		}
		
		//Getting all
		public ArrayList<Kwaliteitsverslag> getAlleGebruikerKwaliteitsverslagen(int id){
			
			kwaliteitsverslagen = new ArrayList<Kwaliteitsverslag>();
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.query("Kwaliteitsverslag", new String[] { "KwaliteitsverslagNr",
		    		"Debiteurnummer", "Debiteurnaam", "Projectnummer", "Projectnaam", 
		    		"Telefoonnummer", "Contactpersoon", "Weeknummer", "Straat", "Huisnummer", "Postcode", 
		    		"Plaats", "Status", "StartDatum", "GereedDatum", "Opmerkingen",
		    		"HandtekeningVisschedijk", "HandtekeningOpdrachtgever", "GebruikerNr"}, "GebruikerNr" + "=?",
		            new String[] { String.valueOf(id) }, null, null, null, null);	    
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Kwaliteitsverslag kwaliteitsverslag = new Kwaliteitsverslag(0, 0, null, 0, null, null, null, 0, null, null, null, null, null, null, null, null, null, null, 0, null);
		        	   kwaliteitsverslag.setKwaliteitsverslagNr(cursor.getInt(0));
		        	   kwaliteitsverslag.setDebiteurnummer(cursor.getInt(1));
		        	   kwaliteitsverslag.setDebiteurnaam(cursor.getString(2));
		        	   kwaliteitsverslag.setProjectnummer(cursor.getInt(3));
		        	   kwaliteitsverslag.setProjectnaam(cursor.getString(4));
		        	   kwaliteitsverslag.setTelefoonnummer(cursor.getString(5));
		        	   kwaliteitsverslag.setContactpersoon(cursor.getString(6));
		        	   kwaliteitsverslag.setWeeknummer(cursor.getInt(7));
		        	   kwaliteitsverslag.setStraat(cursor.getString(8));
		        	   kwaliteitsverslag.setHuisnummer(cursor.getString(9));
		        	   kwaliteitsverslag.setPostcode(cursor.getString(10));
		        	   kwaliteitsverslag.setPlaats(cursor.getString(11));
		        	   kwaliteitsverslag.setStatus(cursor.getString(12));
		        	   kwaliteitsverslag.setStartDatum(cursor.getString(13));
		        	   kwaliteitsverslag.setGereedDatum(cursor.getString(14));
		        	   kwaliteitsverslag.setOpmerkingen(cursor.getString(15));
		        	   kwaliteitsverslag.setHandtekeningVisschedijk(cursor.getBlob(16));
		        	   kwaliteitsverslag.setHandtekeningOpdrachtgever(cursor.getBlob(17));
		        	   kwaliteitsverslag.setGebruikerNr(cursor.getInt(18));
		        	   kwaliteitsverslag.setVragen(getAlleKwaliteitsverslagVragen(cursor.getInt(0)));
		        	   
		       		
		        	   // Adding to list
		        	   kwaliteitsverslagen.add(kwaliteitsverslag);
		           } while (cursor.moveToNext());
		       }
		       return kwaliteitsverslagen;
		}
		
		// Getting single
		public Kwaliteitsverslag getKwaliteitsverslag(int id) {
		    SQLiteDatabase db = this.getReadableDatabase();
		 
		    Cursor cursor = db.query("Kwaliteitsverslag", new String[] { "KwaliteitsverslagNr",
		    		"Debiteurnummer", "Debiteurnaam", "Projectnummer", "Projectnaam", 
		    		"Telefoonnummer", "Contactpersoon", "Weeknummer", "Straat", "Huisnummer", "Postcode", 
		    		"Plaats", "Status", "StartDatum", "GereedDatum", "Opmerkingen",
		    		"HandtekeningVisschedijk", "HandtekeningOpdrachtgever", "GebruikerNr"}, "KwaliteitsverslagNr" + "=?",
		            new String[] { String.valueOf(id) }, null, null, null, null);
		    if (cursor != null)
		        cursor.moveToFirst();
		    
		       Kwaliteitsverslag kwaliteitsverslag = new Kwaliteitsverslag(0, 0, null, 0, null, null, null, 0, null, null, null, null, null, null, null, null, null, null, 0, null);
		       kwaliteitsverslag.setKwaliteitsverslagNr(cursor.getInt(0));
        	   kwaliteitsverslag.setDebiteurnummer(cursor.getInt(1));
        	   kwaliteitsverslag.setDebiteurnaam(cursor.getString(2));
        	   kwaliteitsverslag.setProjectnummer(cursor.getInt(3));
        	   kwaliteitsverslag.setProjectnaam(cursor.getString(4));
        	   kwaliteitsverslag.setTelefoonnummer(cursor.getString(5));
        	   kwaliteitsverslag.setContactpersoon(cursor.getString(6));
        	   kwaliteitsverslag.setWeeknummer(cursor.getInt(7));
        	   kwaliteitsverslag.setStraat(cursor.getString(8));
        	   kwaliteitsverslag.setHuisnummer(cursor.getString(9));
        	   kwaliteitsverslag.setPostcode(cursor.getString(10));
        	   kwaliteitsverslag.setPlaats(cursor.getString(11));
        	   kwaliteitsverslag.setStatus(cursor.getString(12));
        	   kwaliteitsverslag.setStartDatum(cursor.getString(13));
        	   kwaliteitsverslag.setGereedDatum(cursor.getString(14));
        	   kwaliteitsverslag.setOpmerkingen(cursor.getString(15));
        	   kwaliteitsverslag.setHandtekeningVisschedijk(cursor.getBlob(16));
        	   kwaliteitsverslag.setHandtekeningOpdrachtgever(cursor.getBlob(17));
        	   kwaliteitsverslag.setGebruikerNr(cursor.getInt(18));
        	   //kwaliteitsverslag.setVragen(getAlleKwaliteitsverslagVragen(cursor.getInt(0)));
       		
		// return 
		    return kwaliteitsverslag;
		}
		
		public void addKwaliteitsverslag(Kwaliteitsverslag kwaliteitsverslag) {
	    	SQLiteDatabase db = this.getWritableDatabase();
	 
		    ContentValues values = new ContentValues();
		    values.put("Debiteurnummer", kwaliteitsverslag.getDebiteurnummer());
		    values.put("Debiteurnaam", kwaliteitsverslag.getDebiteurnaam());
		    values.put("Projectnummer", kwaliteitsverslag.getProjectnummer());
		    values.put("Projectnaam", kwaliteitsverslag.getProjectnaam());
		    values.put("Telefoonnummer", kwaliteitsverslag.getTelefoonnummer());
		    values.put("Contactpersoon", kwaliteitsverslag.getContactpersoon());
		    values.put("Weeknummer", kwaliteitsverslag.getWeeknummer());
		    values.put("Straat", kwaliteitsverslag.getStraat());
		    values.put("Huisnummer", kwaliteitsverslag.getHuisnummer());
		    values.put("Postcode", kwaliteitsverslag.getPostcode());
		    values.put("Plaats", kwaliteitsverslag.getPlaats());
		    values.put("Status", kwaliteitsverslag.getStatus());
		    values.put("StartDatum", kwaliteitsverslag.getStartDatum());
		    values.put("GereedDatum", kwaliteitsverslag.getGereedDatum());
		    values.put("Opmerkingen", kwaliteitsverslag.getOpmerkingen());
		    values.put("HandtekeningVisschedijk", kwaliteitsverslag.getHandtekeningVisschedijk());
		    values.put("HandtekeningOpdrachtgever", kwaliteitsverslag.getHandtekeningOpdrachtgever());
		    values.put("GebruikerNr", kwaliteitsverslag.getGebruikerNr());
		    
		// Inserting Row
		    db.insert("Kwaliteitsverslag", null, values);
		    db.close(); // Closing database connection
	    }
		
		public int updateKwaliteitsverslag(Kwaliteitsverslag kwaliteitsverslag) {
		    SQLiteDatabase db = this.getWritableDatabase();
		    
		    ContentValues values = new ContentValues();
		    values.put("Debiteurnummer", kwaliteitsverslag.getDebiteurnummer());
		    values.put("Debiteurnaam", kwaliteitsverslag.getDebiteurnaam());
		    values.put("Projectnummer", kwaliteitsverslag.getProjectnummer());
		    values.put("Projectnaam", kwaliteitsverslag.getProjectnaam());
		    values.put("Telefoonnummer", kwaliteitsverslag.getTelefoonnummer());
		    values.put("Contactpersoon", kwaliteitsverslag.getContactpersoon());
		    values.put("Weeknummer", kwaliteitsverslag.getWeeknummer());
		    values.put("Straat", kwaliteitsverslag.getStraat());
		    values.put("Huisnummer", kwaliteitsverslag.getHuisnummer());
		    values.put("Postcode", kwaliteitsverslag.getPostcode());
		    values.put("Plaats", kwaliteitsverslag.getPlaats());
		    values.put("Status", kwaliteitsverslag.getStatus());
		    values.put("StartDatum", kwaliteitsverslag.getStartDatum());
		    values.put("GereedDatum", kwaliteitsverslag.getGereedDatum());
		    values.put("Opmerkingen", kwaliteitsverslag.getOpmerkingen());
		    values.put("HandtekeningVisschedijk", kwaliteitsverslag.getHandtekeningVisschedijk());
		    values.put("HandtekeningOpdrachtgever", kwaliteitsverslag.getHandtekeningOpdrachtgever());
		    values.put("GebruikerNr", kwaliteitsverslag.getGebruikerNr());
		    
	    // updating row
		    return db.update("Kwaliteitsverslag", values, "KwaliteitsverslagNr" + "=" +
		    		kwaliteitsverslag.getKwaliteitsverslagNr(), null);
	    }
		
		public void deleteKwaliteitsverslag(Kwaliteitsverslag kwaliteitsverslag) {
			SQLiteDatabase db = this.getWritableDatabase();
		
		// deleting row	
			db.delete("Kwaliteitsverslag", "KwaliteitsverslagNr" + "=" + kwaliteitsverslag.getKwaliteitsverslagNr(), null);
		}
		
		//Getting all
		public ArrayList<Gebruiker> getAlleGebruikers(){
			gebruikers = new ArrayList<Gebruiker>();
			String selectQuery = "SELECT * FROM Gebruiker";
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.rawQuery(selectQuery, null);
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Gebruiker gebruiker = new Gebruiker(0, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, null, null);
		        	   gebruiker.setGebruikerNr(cursor.getInt(0));
		        	   gebruiker.setGebruikersnaam(cursor.getString(1));
		        	   gebruiker.setNaam(cursor.getString(2));
		        	   gebruiker.setAchternaam(cursor.getString(3));
		        	   gebruiker.setWachtwoord(cursor.getString(4));
		        	   gebruiker.setType(cursor.getString(5));
		        	   gebruiker.setLand(cursor.getString(6));
		        	   gebruiker.setPlaats(cursor.getString(7));
		        	   gebruiker.setStraat(cursor.getString(8));
		        	   gebruiker.setHuisnummer(cursor.getString(9));
		        	   gebruiker.setPostcode(cursor.getString(10));
		        	   gebruiker.setTelefoonnummer(cursor.getString(11));
		        	   gebruiker.setBedrijfNr(cursor.getInt(12));
		        	   /*gebruiker.setWerkbon(getAlleGebruikerWerkbonnen(cursor.getInt(0)));
		        	   gebruiker.setBezoekverslag(getAlleGebruikerBezoekverslagen(cursor.getInt(0)));
		        	   gebruiker.setControles(getAlleGebruikerControles(cursor.getInt(0)));
		        	   gebruiker.setKwaliteitsverslag(getAlleGebruikerKwaliteitsverslagen(cursor.getInt(0)));
		        	   gebruiker.setOptions(getAlleGebruikerOptions(cursor.getInt(0)));
		        	   gebruiker.setIdentiteitsbewijs(getAlleGebruikerIdentiteitsbewijzen(cursor.getInt(0)));*/
		        	   
		// Adding to list
		        	   gebruikers.add(gebruiker);
		           } while (cursor.moveToNext());
		       }

		       return gebruikers;
		}
		
		//Getting all
		public ArrayList<Gebruiker> getAlleBedrijfGebruikers(int id){
			gebruikers = new ArrayList<Gebruiker>();
			
			SQLiteDatabase db = this.getWritableDatabase(); 
			
			Cursor cursor = db.query("Gebruiker", new String[] { "GebruikerNr",
		    		"Gebruikersnaam", "Naam", "Achternaam", "Wachtwoord", "Type", "Land", "Plaats", "Straat",
		    		"Huisnummer", "Postcode", "Telefoonnummer", "BedrijfNr"}, "BedrijfNr" + "=?",
		            new String[] { String.valueOf(id) }, null, null, null, null);
		    
		// looping through all rows and adding to list
			if (cursor != null)
		       if (cursor.moveToFirst()) {
		           do {
		        	   Gebruiker gebruiker = new Gebruiker(0, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, null, null);
		        	   gebruiker.setGebruikerNr(cursor.getInt(0));
		        	   gebruiker.setGebruikersnaam(cursor.getString(1));
		        	   gebruiker.setNaam(cursor.getString(2));
		        	   gebruiker.setAchternaam(cursor.getString(3));
		        	   gebruiker.setWachtwoord(cursor.getString(4));
		        	   gebruiker.setType(cursor.getString(5));
		        	   gebruiker.setLand(cursor.getString(6));
		        	   gebruiker.setPlaats(cursor.getString(7));
		        	   gebruiker.setStraat(cursor.getString(8));
		        	   gebruiker.setHuisnummer(cursor.getString(9));
		        	   gebruiker.setPostcode(cursor.getString(10));
		        	   gebruiker.setTelefoonnummer(cursor.getString(11));
		        	   gebruiker.setBedrijfNr(cursor.getInt(12));
		        	   /*gebruiker.setWerkbon(getAlleGebruikerWerkbonnen(cursor.getInt(0)));
		        	   gebruiker.setBezoekverslag(getAlleGebruikerBezoekverslagen(cursor.getInt(0)));
		        	   gebruiker.setControles(getAlleGebruikerControles(cursor.getInt(0)));
		        	   gebruiker.setKwaliteitsverslag(getAlleGebruikerKwaliteitsverslagen(cursor.getInt(0)));
		        	   gebruiker.setOptions(getAlleGebruikerOptions(cursor.getInt(0)));
		        	   gebruiker.setIdentiteitsbewijs(getAlleGebruikerIdentiteitsbewijzen(cursor.getInt(0)));*/
		        	      
		// Adding to list
		        	   gebruikers.add(gebruiker);
		           } while (cursor.moveToNext());
		       }

		       return gebruikers;
		}
		
		public Gebruiker getGebruikerMetWachtwoord(String gebruikersnaam, String wachtwoord) {
			SQLiteDatabase db = this.getReadableDatabase();
		   
		    final String MY_QUERY = "SELECT * FROM Gebruiker WHERE Gebruikersnaam = " + "'" +gebruikersnaam + "'" + " AND Wachtwoord = " + "'" + wachtwoord + "'";
		    Cursor cursor = db.rawQuery(MY_QUERY, null);  
 
		    if (cursor != null){
		        cursor.moveToFirst();
		            Gebruiker gebruiker = new Gebruiker(0, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, null, null);
		            gebruiker.setGebruikerNr(cursor.getInt(0));
		        	gebruiker.setGebruikersnaam(cursor.getString(1));
		        	gebruiker.setNaam(cursor.getString(2));
		        	gebruiker.setAchternaam(cursor.getString(3));
		        	gebruiker.setWachtwoord(cursor.getString(4));
		        	gebruiker.setType(cursor.getString(5));
		        	gebruiker.setLand(cursor.getString(6));
		        	gebruiker.setPlaats(cursor.getString(7));
		        	gebruiker.setStraat(cursor.getString(8));
		        	gebruiker.setHuisnummer(cursor.getString(9));
		        	gebruiker.setPostcode(cursor.getString(10));
		        	gebruiker.setTelefoonnummer(cursor.getString(11));
		        	gebruiker.setBedrijfNr(cursor.getInt(12));
		        	/*gebruiker.setWerkbon(getAlleGebruikerWerkbonnen(cursor.getInt(0)));
		        	gebruiker.setBezoekverslag(getAlleGebruikerBezoekverslagen(cursor.getInt(0)));
		        	gebruiker.setControles(getAlleGebruikerControles(cursor.getInt(0)));
		        	gebruiker.setKwaliteitsverslag(getAlleGebruikerKwaliteitsverslagen(cursor.getInt(0)));
		        	gebruiker.setOptions(getAlleGebruikerOptions(cursor.getInt(0)));
		        	gebruiker.setIdentiteitsbewijs(getAlleGebruikerIdentiteitsbewijzen(cursor.getInt(0)));*/
		     
		          return gebruiker;
		          }
		    else{
		    	return null;
		    }	    	
		} 
		    
		    
		
		// Getting single
		public Gebruiker getGebruiker(int id) {
				SQLiteDatabase db = this.getReadableDatabase();
				 
				Cursor cursor = db.query("Gebruiker", new String[] { "GebruikerNr",
						"Gebruikersnaam", "Naam", "Achternaam", "Wachtwoord", "Type", "Land", "Plaats", "Straat",
				    	"Huisnummer", "Postcode", "Telefoonnummer", "BedrijfNr"}, "GebruikerNr" + "=?",
				            new String[] { String.valueOf(id) }, null, null, null, null);
				    if (cursor != null)
				        cursor.moveToFirst();
				    
				    Gebruiker gebruiker = new Gebruiker(0, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, null, null, null);
				    gebruiker.setGebruikerNr(cursor.getInt(0));
		        	gebruiker.setGebruikersnaam(cursor.getString(1));
		        	gebruiker.setNaam(cursor.getString(2));
		        	gebruiker.setAchternaam(cursor.getString(3));
		        	gebruiker.setWachtwoord(cursor.getString(4));
		        	gebruiker.setType(cursor.getString(5));
		        	gebruiker.setLand(cursor.getString(6));
		        	gebruiker.setPlaats(cursor.getString(7));
		        	gebruiker.setStraat(cursor.getString(8));
		        	gebruiker.setHuisnummer(cursor.getString(9));
		        	gebruiker.setPostcode(cursor.getString(10));
		        	gebruiker.setTelefoonnummer(cursor.getString(11));
		        	gebruiker.setBedrijfNr(cursor.getInt(12));
		        	/*gebruiker.setWerkbon(getAlleGebruikerWerkbonnen(cursor.getInt(0)));
		        	gebruiker.setBezoekverslag(getAlleGebruikerBezoekverslagen(cursor.getInt(0)));
		        	gebruiker.setControles(getAlleGebruikerControles(cursor.getInt(0)));
		        	gebruiker.setKwaliteitsverslag(getAlleGebruikerKwaliteitsverslagen(cursor.getInt(0)));
		        	gebruiker.setOptions(getAlleGebruikerOptions(cursor.getInt(0)));
		        	gebruiker.setIdentiteitsbewijs(getAlleGebruikerIdentiteitsbewijzen(cursor.getInt(0)));*/
		        	   
		// return 
		        return gebruiker;
		}
		
		public void addGebruiker(Gebruiker gebruiker) {
	    	SQLiteDatabase db = this.getWritableDatabase();
	 
		    ContentValues values = new ContentValues();
		    values.put("Gebruikersnaam", gebruiker.getGebruikersnaam());
		    values.put("Naam", gebruiker.getNaam());
		    values.put("Achternaam", gebruiker.getAchternaam());
		    values.put("Wachtwoord", gebruiker.getWachtwoord());
		    values.put("Type", gebruiker.getType());
		    values.put("Land", gebruiker.getLand());
		    values.put("Plaats", gebruiker.getPlaats());
		    values.put("Straat", gebruiker.getStraat());
		    values.put("Huisnummer", gebruiker.getHuisnummer());
		    values.put("Postcode", gebruiker.getPostcode());
		    values.put("Telefoonnummer", gebruiker.getTelefoonnummer());
		    values.put("BedrijfNr", gebruiker.getBedrijfNr());
		    
		// Inserting Row
		    db.insert("Gebruiker", null, values);
		    db.close(); // Closing database connection
	    }
		
		public int updateGebruiker(Gebruiker gebruiker) {
		    SQLiteDatabase db = this.getWritableDatabase();
		    
		    ContentValues values = new ContentValues();
		    values.put("Gebruikersnaam", gebruiker.getGebruikersnaam());
		    values.put("Naam", gebruiker.getNaam());
		    values.put("Achternaam", gebruiker.getAchternaam());
		    values.put("Wachtwoord", gebruiker.getWachtwoord());
		    values.put("Type", gebruiker.getType());
		    values.put("Land", gebruiker.getLand());
		    values.put("Plaats", gebruiker.getPlaats());
		    values.put("Straat", gebruiker.getStraat());
		    values.put("Huisnummer", gebruiker.getHuisnummer());
		    values.put("Postcode", gebruiker.getPostcode());
		    values.put("Telefoonnummer", gebruiker.getTelefoonnummer());
		    values.put("BedrijfNr", gebruiker.getBedrijfNr());

	    // updating row
		    return db.update("Gebruiker", values, "GebruikerNr" + "=" +
		    		gebruiker.getGebruikerNr(), null);
	    }
		
		public void deleteGebruiker(Gebruiker gebruiker) {
			SQLiteDatabase db = this.getWritableDatabase();
		
		// deleting row	
			db.delete("Gebruiker", "GebruikerNr" + "=" + gebruiker.getGebruikerNr(), null);
		}
		
		//Getting all
		public ArrayList<Bedrijf> getAlleBedrijven(){
			bedrijven = new ArrayList<Bedrijf>();
			String selectQuery = "select * from Bedrijf";
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.rawQuery(selectQuery, null);
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Bedrijf bedrijf = new Bedrijf();
					   bedrijf.setBedrijfNr(cursor.getInt(0));
					   bedrijf.setNaam(cursor.getString(1));
					   bedrijf.setLand(cursor.getString(2));
					   bedrijf.setPlaats(cursor.getString(3));
					   bedrijf.setStraat(cursor.getString(4));
					   bedrijf.setHuisnummer(cursor.getString(5));
					   bedrijf.setPostcode(cursor.getString(6));
					   bedrijf.setGebruikers(getAlleBedrijfGebruikers(cursor.getInt(0)));
					   
		// Adding to list
		        	   bedrijven.add(bedrijf);
		           } while (cursor.moveToNext());
		       }

		       return bedrijven;
		}
		
		// Getting single
		public Bedrijf getBedrijf(int id) {
				SQLiteDatabase db = this.getReadableDatabase();
				 
				Cursor cursor = db.query("Bedrijf", new String[] { "BedrijfNr",
				    		"Naam", "Land", "Plaats", "Straat",
				    		"Huisnummer", "Postcode"}, "BedrijfNr" + "=?",
				            new String[] { String.valueOf(id) }, null, null, null, null);
				    if (cursor != null)
				        cursor.moveToFirst();
				    
				    Bedrijf bedrijf = new Bedrijf();
				    bedrijf.setBedrijfNr(cursor.getInt(0));
				    bedrijf.setNaam(cursor.getString(1));
				    bedrijf.setLand(cursor.getString(2));
				    bedrijf.setPlaats(cursor.getString(3));
				    bedrijf.setStraat(cursor.getString(4));
				    bedrijf.setHuisnummer(cursor.getString(5));
				    bedrijf.setPostcode(cursor.getString(6));
				    bedrijf.setGebruikers(getAlleBedrijfGebruikers(cursor.getInt(0)));
					   	
		// return 
		        return bedrijf;
		}
		
		public void addBedrijf(Bedrijf bedrijf) {
	    	SQLiteDatabase db = this.getWritableDatabase();
	 
		    ContentValues values = new ContentValues();
		    values.put("Naam", bedrijf.getNaam());
		    values.put("Land", bedrijf.getLand());
		    values.put("Plaats", bedrijf.getPlaats());
		    values.put("Straat", bedrijf.getStraat());
		    values.put("Huisnummer", bedrijf.getHuisnummer());
		    values.put("Postcode", bedrijf.getPostcode());
		    
		// Inserting Row
		    db.insert("Bedrijf", null, values);
		    db.close(); // Closing database connection
	    }
		
		public int updateBedrijf(Bedrijf bedrijf) {
		    SQLiteDatabase db = this.getWritableDatabase();
		    
		    ContentValues values = new ContentValues();
		    values.put("Naam", bedrijf.getNaam());
		    values.put("Land", bedrijf.getLand());
		    values.put("Plaats", bedrijf.getPlaats());
		    values.put("Straat", bedrijf.getStraat());
		    values.put("Huisnummer", bedrijf.getHuisnummer());
		    values.put("Postcode", bedrijf.getPostcode());

	    // updating row
		    return db.update("Bedrijf", values, "BedrijfNr" + "=" +
		    		bedrijf.getBedrijfNr(), null);
	    }
		
		public void deleteBedrijf(Bedrijf bedrijf) {
			SQLiteDatabase db = this.getWritableDatabase();
		
		// deleting row	
			db.delete("Bedrijf", "BedrijfNr" + "=" + bedrijf.getBedrijfNr(), null);
		}
		
		//Getting all
		public ArrayList<Identiteitsbewijs> getAlleIdentiteitsbewijzen(){
			identiteitsbewijzen = new ArrayList<Identiteitsbewijs>();
			String selectQuery = "select * from Identiteitsbewijs";
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.rawQuery(selectQuery, null);
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Identiteitsbewijs identiteitsbewijs = new Identiteitsbewijs();
		        	   identiteitsbewijs.setIdentiteitsbewijsNr(cursor.getInt(0));
		        	   identiteitsbewijs.setNaam(cursor.getString(1));
		        	   identiteitsbewijs.setType(cursor.getString(2));
		        	   identiteitsbewijs.setVervalDatum(cursor.getString(3));
		        	   identiteitsbewijs.setSofinummer(cursor.getInt(4));
		        	   identiteitsbewijs.setGebruikerNr(cursor.getInt(5));
		        	   
		// Adding to list
					   identiteitsbewijzen.add(identiteitsbewijs);
		           } while (cursor.moveToNext());
		       }

		       return identiteitsbewijzen;
		}
		
		//Getting all
		public ArrayList<Identiteitsbewijs> getAlleGebruikerIdentiteitsbewijzen(int id){
			identiteitsbewijzen = new ArrayList<Identiteitsbewijs>();
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.query("Identiteitsbewijs", new String[] { "IdentiteitsbewijsNr",
		    		"Naam", "Type", "VervalDatum", "Sofinummer", "GebruikerNr"}, "GebruikerNr" + "=?",
		            new String[] { String.valueOf(id) }, null, null, null, null);		    
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Identiteitsbewijs identiteitsbewijs = new Identiteitsbewijs();
		        	   identiteitsbewijs.setIdentiteitsbewijsNr(cursor.getInt(0));
		        	   identiteitsbewijs.setNaam(cursor.getString(1));
		        	   identiteitsbewijs.setType(cursor.getString(2));
		        	   identiteitsbewijs.setVervalDatum(cursor.getString(3));
		        	   identiteitsbewijs.setSofinummer(cursor.getInt(4));
		        	   identiteitsbewijs.setGebruikerNr(cursor.getInt(5));
		        	   
		// Adding to list
					   identiteitsbewijzen.add(identiteitsbewijs);
		           } while (cursor.moveToNext());
		       }

		       return identiteitsbewijzen;
		}
		
		// Getting single
		public Identiteitsbewijs getIdentiteitsbewijs(int id) {
				SQLiteDatabase db = this.getReadableDatabase();
				 
				Cursor cursor = db.query("Identiteitsbewijs", new String[] { "IdentiteitsbewijsNr",
				    		"Naam", "Type", "VervalDatum", "Sofinummer", "GebruikerNr"}, "IdentiteitsbewijsNr" + "=?",
				            new String[] { String.valueOf(id) }, null, null, null, null);
				    if (cursor != null)
				        cursor.moveToFirst();
				    
				    Identiteitsbewijs identiteitsbewijs = new Identiteitsbewijs();
		        	identiteitsbewijs.setIdentiteitsbewijsNr(cursor.getInt(0));
		        	identiteitsbewijs.setNaam(cursor.getString(1));
		        	identiteitsbewijs.setType(cursor.getString(2));
		        	identiteitsbewijs.setVervalDatum(cursor.getString(3));
		        	identiteitsbewijs.setSofinummer(cursor.getInt(4));
		        	identiteitsbewijs.setGebruikerNr(cursor.getInt(5));
		        	
		// return 
		        return identiteitsbewijs;
		}
		
		public void addIdentiteitsbewijs(Identiteitsbewijs identiteitsbewijs) {
	    	SQLiteDatabase db = this.getWritableDatabase();
	 
		    ContentValues values = new ContentValues();
		    values.put("Naam", identiteitsbewijs.getNaam());
		    values.put("Type", identiteitsbewijs.getType());
		    values.put("VervalDatum", identiteitsbewijs.getVervalDatum());
		    values.put("Sofinummer", identiteitsbewijs.getSofinummer());
		    values.put("GebruikerNr", identiteitsbewijs.getGebruikerNr());
		    
		// Inserting Row
		    db.insert("Bedrijf", null, values);
		    db.close(); // Closing database connection
	    }
		
		public int updateIdentiteitsbewijs(Identiteitsbewijs identiteitsbewijs) {
		    SQLiteDatabase db = this.getWritableDatabase();
		    
		    ContentValues values = new ContentValues();
		    values.put("Naam", identiteitsbewijs.getNaam());
		    values.put("Type", identiteitsbewijs.getType());
		    values.put("VervalDatum", identiteitsbewijs.getVervalDatum());
		    values.put("Sofinummer", identiteitsbewijs.getSofinummer());
		    values.put("GebruikerNr", identiteitsbewijs.getGebruikerNr());
		    
	    // updating row
		    return db.update("Identiteitsbewijs", values, "IdentiteitsbewijsNr" + "=" +
		    		identiteitsbewijs.getIdentiteitsbewijsNr(), null);
	    }
		
		public void deleteIdentiteitsbewijs(Identiteitsbewijs identiteitsbewijs) {
			SQLiteDatabase db = this.getWritableDatabase();
		
		// deleting row	
			db.delete("Identiteitsbewijs", "IdentiteitsbewijsNr" + "=" + identiteitsbewijs.getIdentiteitsbewijsNr(), null);
		}
		
		//Getting all
		public ArrayList<Options> getAlleOptions(){
			options = new ArrayList<Options>();
			String selectQuery = "select * from Options";
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.rawQuery(selectQuery, null);
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Options option = new Options();
		        	   option.setOptionsNr(cursor.getInt(0));
		        	   option.setGroeperenOp(cursor.getString(1));
		        	   option.setSorterenOp(cursor.getString(2));
		        	   option.setTaal(cursor.getString(3));
		        	   option.setDisplayPlannedHours(cursor.getInt(4)>0);
		        	   option.setAccountId(cursor.getInt(5));
		        	   option.setDeviceId(cursor.getInt(6));
		        	   option.setHost(cursor.getString(7));
		        	   option.setPort(cursor.getInt(8));
		        	   option.setGebruikerNr(cursor.getInt(9));
		        	   
		// Adding to list
		        	   options.add(option);
		           } while (cursor.moveToNext());
		       }

		       return options;
		}
		
		//Getting all
		public ArrayList<Options> getAlleGebruikerOptions(int id){
			options = new ArrayList<Options>();
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.query("Options", new String[] { "OptionsNr",
		    		"GroeperenOp", "SorterenOp", "Taal", "DisplayPlannedHours", "AccountId",
		    		"DeviceId", "Host", "Port", "GebruikerNr"}, "GebruikerNr" + "=?",
		            new String[] { String.valueOf(id) }, null, null, null, null);    
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Options option = new Options();
		        	   option.setOptionsNr(cursor.getInt(0));
		        	   option.setGroeperenOp(cursor.getString(1));
		        	   option.setSorterenOp(cursor.getString(2));
		        	   option.setTaal(cursor.getString(3));
		        	   option.setDisplayPlannedHours(cursor.getInt(4)>0);
		        	   option.setAccountId(cursor.getInt(5));
		        	   option.setDeviceId(cursor.getInt(6));
		        	   option.setHost(cursor.getString(7));
		        	   option.setPort(cursor.getInt(8));
		        	   option.setGebruikerNr(cursor.getInt(9));
		        	   
		// Adding to list
		        	   options.add(option);
		           } while (cursor.moveToNext());
		       }

		       return options;
		}
		
		// Getting single
		public Options getOptions(int id) {
				SQLiteDatabase db = this.getReadableDatabase();
				 
				Cursor cursor = db.query("Options", new String[] { "OptionsNr",
				    		"GroeperenOp", "SorterenOp", "Taal", "DisplayPlannedHours", "AccountId",
				    		"DeviceId", "Host", "Port", "GebruikerNr"}, "OptionsNr" + "=?",
				            new String[] { String.valueOf(id) }, null, null, null, null);
				    if (cursor != null)
				        cursor.moveToFirst();
				    
				    Options option = new Options();
		        	option.setOptionsNr(cursor.getInt(0));
		        	option.setGroeperenOp(cursor.getString(1));
		        	option.setSorterenOp(cursor.getString(2));
		        	option.setTaal(cursor.getString(3));
		        	option.setDisplayPlannedHours(cursor.getInt(4)>0);
		        	option.setAccountId(cursor.getInt(5));
		        	option.setDeviceId(cursor.getInt(6));
		        	option.setHost(cursor.getString(7));
		        	option.setPort(cursor.getInt(8));
		        	option.setGebruikerNr(cursor.getInt(9));
		        	
		// return 
		        return option;
		}
		
		public void addOptions(Options options) {
	    	SQLiteDatabase db = this.getWritableDatabase();
	 
		    ContentValues values = new ContentValues();
		    values.put("GroeperenOp", options.getGroeperenOp());
		    values.put("SorterenOp", options.getSorterenOp());
		    values.put("Taal", options.getTaal());
		    values.put("DisplayPlannedHours", options.getDisplayPlannedHours());
		    values.put("AccountId", options.getAccountId());
		    values.put("DeviceId", options.getDeviceId());
		    values.put("Host", options.getHost());
		    values.put("Port", options.getPort());
		    values.put("GebruikerNr", options.getGebruikerNr());
		    
		// Inserting Row
		    db.insert("Options", null, values);
		    db.close(); // Closing database connection
	    }
		
		public int updateOptions(Options options) {
		    SQLiteDatabase db = this.getWritableDatabase();
		    
		    ContentValues values = new ContentValues();
		    values.put("GroeperenOp", options.getGroeperenOp());
		    values.put("SorterenOp", options.getSorterenOp());
		    values.put("Taal", options.getTaal());
		    values.put("DisplayPlannedHours", options.getDisplayPlannedHours());
		    values.put("AccountId", options.getAccountId());
		    values.put("DeviceId", options.getDeviceId());
		    values.put("Host", options.getHost());
		    values.put("Port", options.getPort());
		    values.put("GebruikerNr", options.getGebruikerNr());
		    
	    // updating row
		    return db.update("Options", values, "OptionsNr" + "=" +
		    		options.getOptionsNr(), null);
	    }
		
		public void deleteOptions(Options options) {
			SQLiteDatabase db = this.getWritableDatabase();
		
		// deleting row	
			db.delete("Options", "OptionsNr" + "=" + options.getOptionsNr(), null);
		}
		
		//Getting all
		public ArrayList<Controle> getAlleControles(){
			controles = new ArrayList<Controle>();
			String selectQuery = "SELECT * FROM Controle";
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.rawQuery(selectQuery, null);
		    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Controle controle = new Controle();
		        	   controle.setControleNr(cursor.getInt(0));
		        	   controle.setGebruikerNr(cursor.getInt(1));
		        	   
		// Adding to list
		        	   controles.add(controle);
		           } while (cursor.moveToNext());
		       }

		       return controles;
		}
		
		//Getting all
		public ArrayList<Controle> getAlleGebruikerControles(int id){
			controles = new ArrayList<Controle>();
			
			SQLiteDatabase db = this.getWritableDatabase();
			
			Cursor cursor = db.query("Controle", new String[] { "ControleNr", "GebruikerNr"}, "GebruikerNr" + "=?",
		            new String[] { String.valueOf(id) }, null, null, null, null);
		    	    
		// looping through all rows and adding to list
		       if (cursor.moveToFirst()) {
		           do {
		        	   Controle controle = new Controle();
		        	   controle.setControleNr(cursor.getInt(0));
		        	   controle.setGebruikerNr(cursor.getInt(1));
		        	   
		// Adding to list
		        	   controles.add(controle);
		           } while (cursor.moveToNext());
		       }

		       return controles;
		}
		
		// Getting single
		public Controle getControle(int id) {
				SQLiteDatabase db = this.getReadableDatabase();
				 
				Cursor cursor = db.query("Controle", new String[] { "ControleNr", "GebruikerNr"}, "ControleNr" + "=?",
				            new String[] { String.valueOf(id) }, null, null, null, null);
				    if (cursor != null)
				        cursor.moveToFirst();
				    
				    Controle controle = new Controle();
		        	controle.setControleNr(cursor.getInt(0));
		        	controle.setGebruikerNr(cursor.getInt(1));
		        	
		// return 
		        return controle;
		}
		
		public void addControle(Controle controle) {
	    	SQLiteDatabase db = this.getWritableDatabase();
	 
		    ContentValues values = new ContentValues();
		    values.put("GebruikerNr", controle.getGebruikerNr());
		    
		// Inserting Row
		    db.insert("Controle", null, values);
		    db.close(); // Closing database connection
	    }
		
		public int updateControle(Controle controle) {
		    SQLiteDatabase db = this.getWritableDatabase();
		    
		    ContentValues values = new ContentValues();
		    values.put("GebruikerNr", controle.getGebruikerNr());

	    // updating row
		    return db.update("Controle", values, "ControleNr" + "=" +
		    		controle.getControleNr(), null);
	    }
		
		public void deleteControle(Controle controle) {
			SQLiteDatabase db = this.getWritableDatabase();
		
		// deleting row	
			db.delete("Controle", "ControleNr" + "=" + controle.getControleNr(), null);
		}
}
