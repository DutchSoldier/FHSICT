package Classes;

import java.util.ArrayList;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class Database extends SQLiteOpenHelper{

	ArrayList<Vraag> vragen;
	ArrayList<Antwoord> antwoorden;
	ArrayList<Enquete> enquetes;
	ArrayList<Gebruiker> gebruikers;

	// Database Version
	private static final int DATABASE_VERSION = 1;

	//Database name
	private static String DATABASE_NAME = "EnqueteApp";

	public Database(Context context) {
		super(context, DATABASE_NAME, null, DATABASE_VERSION);
	}

	@Override
	public void onCreate(SQLiteDatabase db) {
		//Create tables
		String CREATE_ENQUETE = "CREATE TABLE Enquete (EnqueteNr INTEGER PRIMARY KEY AUTOINCREMENT, Naam TEXT, Beschrijving TEXT, Anoniem INTEGER)";
		String CREATE_GEBRUIKER = "CREATE TABLE Gebruiker (GebruikerNr INTEGER PRIMARY KEY AUTOINCREMENT, Naam TEXT, Geslacht TEXT, GeboorteDatum TEXT, Email TEXT, EnqueteNr INTEGER, FOREIGN KEY (EnqueteNr) REFERENCES Enquete (EnqueteNr))";
		String CREATE_VRAAG = "CREATE TABLE Vraag (VraagNr INTEGER PRIMARY KEY AUTOINCREMENT, Vraag TEXT, Antwoord TEXT, Groep INTEGER, EnqueteNr INTEGER, FOREIGN KEY (EnqueteNr) REFERENCES Enquete (EnqueteNr))";
		String CREATE_ANTWOORD = "CREATE TABLE Antwoord (AntwoordNr INTEGER PRIMARY KEY AUTOINCREMENT, Antwoord TEXT, Selected INTEGER, Count INTEGER, VraagNr INTEGER, FOREIGN KEY (VraagNr) REFERENCES Vraag (VraagNr))";
		db.execSQL(CREATE_ENQUETE);
		db.execSQL(CREATE_GEBRUIKER);
		db.execSQL(CREATE_VRAAG);
		db.execSQL(CREATE_ANTWOORD);
	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		db.execSQL("DROP TABLE IF EXISTS " + "Gebruiker");
		db.execSQL("DROP TABLE IF EXISTS " + "Vraag");
		db.execSQL("DROP TABLE IF EXISTS " + "Antwoord");
		db.execSQL("DROP TABLE IF EXISTS " + "Enquete");

		// Create tables again
		onCreate(db);
	}

	//Getting all
	public ArrayList<Antwoord> getAlleAntwoorden(){
		antwoorden = new ArrayList<Antwoord>();
		String selectQuery = "select * from Antwoord ";

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.rawQuery(selectQuery, null);

		// looping through all rows and adding to list
		if (cursor.moveToFirst()) {
			do {
				Antwoord antwoord = new Antwoord(0, null, null, 0, 0);
				antwoord.setAntwoordNr(cursor.getInt(0));
				antwoord.setAntwoord(cursor.getString(1));
				antwoord.setSelected(cursor.getInt(2)>0);
				antwoord.setCount(cursor.getInt(3));
				antwoord.setVraagNr(cursor.getInt(4));
				// Adding contact to list
				antwoorden.add(antwoord);
			} while (cursor.moveToNext());
		}
		return antwoorden;
	}

	//Getting all
	public ArrayList<Antwoord> getAlleVraagAntwoorden(int id){
		antwoorden = new ArrayList<Antwoord>();

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.query("Antwoord", new String[] { "AntwoordNr",
				"Antwoord", "Selected","Count", "VraagNr"}, "VraagNr" + "=?",
				new String[] { String.valueOf(id) }, null, null, null, null);

		// looping through all rows and adding to list
		if (cursor != null)   
			if (cursor.moveToFirst()) {
				do {
					Antwoord antwoord = new Antwoord(0, null, null, 0, 0);
					antwoord.setAntwoordNr(cursor.getInt(0));
					antwoord.setAntwoord(cursor.getString(1));
					antwoord.setSelected(cursor.getInt(2)>0);
					antwoord.setCount(cursor.getInt(3));
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
				"Antwoord", "Selected","Count", "VraagNr"}, "AntwoordNr" + "=?",
				new String[] { String.valueOf(id) }, null, null, null, null);
		if (cursor != null)
			cursor.moveToFirst();

		Antwoord antwoord = new Antwoord(0, null, null, 0, 0);
		antwoord.setAntwoordNr(cursor.getInt(0));
		antwoord.setAntwoord(cursor.getString(1));
		antwoord.setSelected(cursor.getInt(2)>0);
		antwoord.setCount(cursor.getInt(3));
		antwoord.setVraagNr(cursor.getInt(4));

		// return 
				return antwoord;
	}

	//Getting max number
	public int getMaxAntwoordNr(){
		int antwoordNr;
		String selectQuery = "select MAX(AntwoordNr) from Antwoord ";

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.rawQuery(selectQuery, null);
		if (cursor != null)
			cursor.moveToFirst();

		antwoordNr = cursor.getInt(0);

		return antwoordNr;
	}

	public void addAntwoord(Antwoord antwoord) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put("Antwoord", antwoord.getAntwoord());
		values.put("Selected", antwoord.getSelected());
		values.put("Count", antwoord.getCount());
		values.put("VraagNr", antwoord.getVraagNr());

		// Inserting Row
		db.insert("Antwoord", null, values);
		db.close(); // Closing database connection
	}

	public int updateAntwoord(Antwoord antwoord) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put("Antwoord", antwoord.getAntwoord());
		values.put("Selected", antwoord.getSelected());
		values.put("Count", antwoord.getCount());
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
	public ArrayList<Vraag> getAlleEnqueteVragen(int id){
		vragen = new ArrayList<Vraag>();

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.query("Vraag", new String[] { "VraagNr",
				"Vraag", "Antwoord", "Groep", "EnqueteNr"}, "EnqueteNr" + "=?",
				new String[] { String.valueOf(id) }, null, null, null, null);

		// looping through all rows and adding to list
		if (cursor != null)
			if (cursor.moveToFirst()) {
				do {
					Vraag vraag = new Vraag(0, null, null, null, 0, null);
					vraag.setVraagNr(cursor.getInt(0));
					vraag.setVraag(cursor.getString(1));
					vraag.setAntwoord(cursor.getString(2));
					vraag.setGroep(cursor.getInt(3)>0);
					vraag.setEnqueteNr(cursor.getInt(4));
					vraag.setAntwoorden(getAlleVraagAntwoorden(cursor.getInt(0)));
					// Adding to list
					vragen.add(vraag);
				} while (cursor.moveToNext());
			}
		return vragen;
	}

	//Getting all
	public ArrayList<Vraag> getAlleVragen(){
		vragen = new ArrayList<Vraag>();
		String selectQuery = "SELECT * FROM Vraag";

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.rawQuery(selectQuery, null);

		// looping through all rows and adding to list
		if (cursor.moveToFirst()) {
			do {
				Vraag vraag = new Vraag(0, null, null, null, 0, null);
				vraag.setVraagNr(cursor.getInt(0));
				vraag.setVraag(cursor.getString(1));
				vraag.setAntwoord(cursor.getString(2));       	   
				vraag.setGroep(cursor.getInt(3)>0);
				vraag.setEnqueteNr(cursor.getInt(4));
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
				"Vraag", "Antwoord", "Groep", "EnqueteNr"}, "VraagNr" + "=?",
				new String[] { String.valueOf(id) }, null, null, null, null);
		if (cursor != null)
			cursor.moveToFirst();

		Vraag vraag = new Vraag(0, null, null, null, 0, null);
		vraag.setVraagNr(cursor.getInt(0));
		vraag.setVraag(cursor.getString(1));
		vraag.setAntwoord(cursor.getString(2));
		vraag.setGroep(cursor.getInt(3)>0);
		vraag.setEnqueteNr(cursor.getInt(4));
		vraag.setAntwoorden(getAlleVraagAntwoorden(cursor.getInt(0)));

		// return 
				return vraag;
	}

	//Getting max number
	public int getMaxVraagNr(){
		int vraagNr;
		String selectQuery = "select MAX(VraagNr) from Vraag ";

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.rawQuery(selectQuery, null);
		if (cursor != null)
			cursor.moveToFirst();

		vraagNr = cursor.getInt(0);

		return vraagNr;
	}

	public void addVraag(Vraag vraag) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put("Vraag", vraag.getVraag());
		values.put("Antwoord", vraag.getAntwoord());
		values.put("Groep", vraag.getGroep());
		values.put("EnqueteNr", vraag.getEnqueteNr());

		// Inserting Row
		db.insert("Vraag", null, values);
		db.close(); // Closing database connection
	}

	public int updateVraag(Vraag vraag) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put("Vraag", vraag.getVraag());
		values.put("Antwoord", vraag.getAntwoord());
		values.put("Groep", vraag.getGroep());
		values.put("EnqueteNr", vraag.getEnqueteNr()); 

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
	public ArrayList<Enquete> getAlleEnquetes(){
		enquetes = new ArrayList<Enquete>();
		String selectQuery = "select * from Enquete ";

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.rawQuery(selectQuery, null);

		// looping through all rows and adding to list
		if (cursor.moveToFirst()) {
			do {
				Enquete enquete = new Enquete(0, null, null, null, null, null);
				enquete.setEnqueteNr(cursor.getInt(0));
				enquete.setNaam(cursor.getString(1));
				enquete.setBeschrijving(cursor.getString(2));
				enquete.setAnoniem(cursor.getInt(3)>0);

				// Adding contact to list
				enquetes.add(enquete);
			} while (cursor.moveToNext());
		}
		return enquetes;
	}

	// Getting single
	public Enquete getEnquete(int id) {
		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.query("Enquete", new String[] { "EnqueteNr",
				"Naam", "Beschrijving", "Anoniem"}, "EnqueteNr" + "=?",
				new String[] { String.valueOf(id) }, null, null, null, null);
		if (cursor != null)
			cursor.moveToFirst();

		Enquete enquete = new Enquete(0, null, null, null, null, null);
		enquete.setEnqueteNr(cursor.getInt(0));
		enquete.setNaam(cursor.getString(1));
		enquete.setBeschrijving(cursor.getString(2));
		enquete.setAnoniem(cursor.getInt(3)>0);

		// return 
				return enquete;
	}

	//Getting max number
	public int getMaxEnqueteNr(){
		int enqueteNr;
		String selectQuery = "select MAX(EnqueteNr) from Enquete ";

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.rawQuery(selectQuery, null);
		if (cursor != null)
			cursor.moveToFirst();

		enqueteNr = cursor.getInt(0);

		return enqueteNr;
	}

	public void addEnquete(Enquete enquete) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put("Naam", enquete.getNaam());
		values.put("Beschrijving", enquete.getBeschrijving());
		values.put("Anoniem", enquete.getAnoniem());

		// Inserting Row
		db.insert("Enquete", null, values);
		db.close(); // Closing database connection
	}

	public int updateEnquete(Enquete enquete) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put("Naam", enquete.getNaam());
		values.put("Beschrijving", enquete.getBeschrijving());
		values.put("Anoniem", enquete.getAnoniem());

		// updating row
		return db.update("Enquete", values, "EnqueteNr" + "=" +
				enquete.getEnqueteNr(), null);
	}

	public void deleteEnquete(Enquete enquete) {
		SQLiteDatabase db = this.getWritableDatabase();

		// deleting row	
		db.delete("Enquete", "EnqueteNr" + "=" + enquete.getEnqueteNr(), null);
	}

	//Getting all
	public ArrayList<Gebruiker> getAlleGebruikers(){
		gebruikers = new ArrayList<Gebruiker>();
		String selectQuery = "select * from Gebruiker ";

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.rawQuery(selectQuery, null);

		// looping through all rows and adding to list
		if (cursor.moveToFirst()) {
			do {
				Gebruiker gebruiker = new Gebruiker(0, null, null, null, null, 0);
				gebruiker.setGebruikerNr(cursor.getInt(0));
				gebruiker.setNaam(cursor.getString(1));
				gebruiker.setGeslacht(cursor.getString(2));
				gebruiker.setGeboorteDatum(cursor.getString(3));
				gebruiker.setEmail(cursor.getString(4));
				gebruiker.setEnqueteNr(cursor.getInt(5));

				// Adding contact to list
				gebruikers.add(gebruiker);
			} while (cursor.moveToNext());
		}
		return gebruikers;
	}

	//Getting all
	public ArrayList<Gebruiker> getAlleEnqueteGebruikers(int id){
		gebruikers = new ArrayList<Gebruiker>();

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.query("Gebruiker", new String[] { "GebruikerNr",
				"Naam", "Geslacht","GeboorteDatum", "Email", "EnqueteNr"}, "EnqueteNr" + "=?",
				new String[] { String.valueOf(id) }, null, null, null, null);

		// looping through all rows and adding to list
		if (cursor != null)   
			if (cursor.moveToFirst()) {
				do {
					Gebruiker gebruiker = new Gebruiker(0, null, null, null, null, 0);
					gebruiker.setGebruikerNr(cursor.getInt(0));
					gebruiker.setNaam(cursor.getString(1));
					gebruiker.setGeslacht(cursor.getString(2));
					gebruiker.setGeboorteDatum(cursor.getString(3));
					gebruiker.setEmail(cursor.getString(4));
					gebruiker.setEnqueteNr(cursor.getInt(5));

					// Adding contact to list
					gebruikers.add(gebruiker);
				} while (cursor.moveToNext());
			}
		return gebruikers;
	}

	// Getting single
	public Gebruiker getGebruiker(int id) {
		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.query("Gebruiker", new String[] { "GebruikerNr",
				"Naam", "Geslacht","GeboorteDatum", "Email", "EnqueteNr"}, "GebruikerNr" + "=?",
				new String[] { String.valueOf(id) }, null, null, null, null);
		if (cursor != null)
			cursor.moveToFirst();

		Gebruiker gebruiker = new Gebruiker(0, null, null, null, null, 0);
		gebruiker.setGebruikerNr(cursor.getInt(0));
		gebruiker.setNaam(cursor.getString(1));
		gebruiker.setGeslacht(cursor.getString(2));
		gebruiker.setGeboorteDatum(cursor.getString(3));
		gebruiker.setEmail(cursor.getString(4));
		gebruiker.setEnqueteNr(cursor.getInt(5));

		// return 
				return gebruiker;
	}

	//Getting max number
	public int getMaxGebruikerNr(){
		int gebruikerNr;
		String selectQuery = "select MAX(GebruikerNr) from Gebruiker ";

		SQLiteDatabase db = this.getReadableDatabase();

		Cursor cursor = db.rawQuery(selectQuery, null);
		if (cursor != null)
			cursor.moveToFirst();

		gebruikerNr = cursor.getInt(0);

		return gebruikerNr;
	}

	public void addGebruiker(Gebruiker gebruiker) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put("Naam", gebruiker.getNaam());
		values.put("Geslacht", gebruiker.getGeslacht());
		values.put("GeboorteDatum", gebruiker.getGeboorteDatum());
		values.put("Email", gebruiker.getEmail());
		values.put("EnqueteNr", gebruiker.getEnqueteNr());

		// Inserting Row
		db.insert("Gebruiker", null, values);
		db.close(); // Closing database connection
	}

	public int updateGebruiker(Gebruiker gebruiker) {
		SQLiteDatabase db = this.getWritableDatabase();

		ContentValues values = new ContentValues();
		values.put("Naam", gebruiker.getNaam());
		values.put("Geslacht", gebruiker.getGeslacht());
		values.put("GeboorteDatum", gebruiker.getGeboorteDatum());
		values.put("Email", gebruiker.getEmail());
		values.put("EnqueteNr", gebruiker.getEnqueteNr());

		// updating row
		return db.update("Gebruiker", values, "GebruikerNr" + "=" +
				gebruiker.getGebruikerNr(), null);
	}

	public void deleteGebruiker(Gebruiker gebruiker) {
		SQLiteDatabase db = this.getWritableDatabase();

		// deleting row	
		db.delete("Gebruiker", "GebruikerNr" + "=" + gebruiker.getGebruikerNr(), null);
	}
}
