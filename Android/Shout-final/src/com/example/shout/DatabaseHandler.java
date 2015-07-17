package com.example.shout;

import java.util.ArrayList;
import java.util.List;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHandler extends SQLiteOpenHelper{
	
	// All Static variables
    // Database Version
    private static final int DATABASE_VERSION = 1;
 
    // Database Name
    private static final String DATABASE_NAME = "shout";
 
    // Contacts table name
    private static final String TABLE_DEELNEMERS = "deelnemer";
 
    // Contacts Table Columns names
    private static final String KEY_ID = "id";
    private static final String KEY_FNAME = "fname";
    private static final String KEY_LNAME = "lname";
    private static final String KEY_AGE = "age";
    private static final String KEY_PROFILE = "foto";
    private static final String KEY_HOBBY1 = "hobby1";
    private static final String KEY_HOBBY2= "hobby2";
    private static final String KEY_HOBBY3 = "hobby3";
        
    public DatabaseHandler(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }
 
    // Creating Tables
    @Override
    public void onCreate(SQLiteDatabase db) {
        String CREATE_DEELNEMERS_TABLE = "CREATE TABLE " + TABLE_DEELNEMERS + "("
                + KEY_ID + " INTEGER PRIMARY KEY AUTOINCREMENT," + KEY_FNAME + " TEXT," 
        		+ KEY_LNAME + " TEXT,"+ KEY_AGE + " INTEGER,"+ KEY_PROFILE + " BLOB,"
                + KEY_HOBBY1 + " TEXT,"+ KEY_HOBBY3 + " TEXT,"+ KEY_HOBBY2 + " TEXT" + ")";
        db.execSQL(CREATE_DEELNEMERS_TABLE);
    }
 
    // Upgrading database
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        // Drop older table if existed
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_DEELNEMERS);
 
        // Create tables again
        onCreate(db);
    }
    
    // Adding new contact
    public void addContact(Deelnemer deelnemer) {
    	SQLiteDatabase db = this.getWritableDatabase();
 
	    ContentValues values = new ContentValues();
	    values.put(KEY_FNAME, deelnemer.getFirstname());
	    values.put(KEY_LNAME, deelnemer.getLastname());
	    values.put(KEY_AGE, deelnemer.getAge()); 
	    values.put(KEY_PROFILE, deelnemer.getProfilepicture()); 
	    values.put(KEY_HOBBY1, deelnemer.getHobby1()); 
	    values.put(KEY_HOBBY2, deelnemer.getHobby2()); 
	    values.put(KEY_HOBBY3, deelnemer.getHobby3()); 
	    
	    // Inserting Row
	    db.insert(TABLE_DEELNEMERS, null, values);
	    db.close(); // Closing database connection
    }
        
 // Getting All Contacts
    public List<Deelnemer> getAllContacts() {
       List<Deelnemer> contactList = new ArrayList<Deelnemer>();
       // Select All Query
       String selectQuery = "SELECT  * FROM " + TABLE_DEELNEMERS;
    
       SQLiteDatabase db = this.getWritableDatabase();
       Cursor cursor = db.rawQuery(selectQuery, null);
    
       // looping through all rows and adding to list
       if (cursor.moveToFirst()) {
           do {
        	   Deelnemer deelnemer = null;
        	   deelnemer.setId(cursor.getInt(0));
        	   deelnemer.setFirstname(cursor.getString(1));
        	   deelnemer.setLastname(cursor.getString(2));
        	   deelnemer.setAge(cursor.getInt(3));
        	   deelnemer.setProfilepicture(cursor.getBlob(4));
        	   deelnemer.setFirstname(cursor.getString(5));
        	   deelnemer.setFirstname(cursor.getString(6));
        	   deelnemer.setFirstname(cursor.getString(7));

               // Adding contact to list
               contactList.add(deelnemer);
           } while (cursor.moveToNext());
       }
    
       // return contact list
       return contactList;
   }
    
    // Getting single contact
    public Deelnemer getContact(int id) {
        SQLiteDatabase db = this.getReadableDatabase();
     
        Cursor cursor = db.query(TABLE_DEELNEMERS, new String[] { KEY_ID,
                KEY_FNAME, KEY_LNAME, KEY_AGE, KEY_PROFILE, KEY_HOBBY1, KEY_HOBBY2, KEY_HOBBY3 }, KEY_ID + "=?",
                new String[] { String.valueOf(id) }, null, null, null, null);
        if (cursor != null)
            cursor.moveToFirst();
     
        Deelnemer contact = new Deelnemer(Integer.parseInt(cursor.getString(0)),
                cursor.getString(1), cursor.getString(2), cursor.getInt(3), cursor.getBlob(4),
                cursor.getString(5),cursor.getString(6),cursor.getString(7));
        // return contact
        return contact;
    }
    
    // Updating single contact
    public int updateContact(Deelnemer deelnemer) {
	    SQLiteDatabase db = this.getWritableDatabase();
	    
	    ContentValues values = new ContentValues();
	    //values.put(KEY_ID, deelnemer.getId());
	    values.put(KEY_FNAME, deelnemer.getFirstname());
	    values.put(KEY_LNAME, deelnemer.getLastname());
	    values.put(KEY_AGE, deelnemer.getAge());
	    values.put(KEY_PROFILE, deelnemer.getProfilepicture());
	    values.put(KEY_HOBBY1, deelnemer.getHobby1());
	    values.put(KEY_HOBBY2, deelnemer.getHobby2());
	    values.put(KEY_HOBBY3, deelnemer.getHobby3());
    
    // updating row
	    return db.update(TABLE_DEELNEMERS, values, KEY_ID + "=" +
	    		"1", null);
    }
    
    public boolean dataBaseEmpty(){
    	
    	String selectQuery = "SELECT * FROM " + TABLE_DEELNEMERS;
    	SQLiteDatabase db = this.getWritableDatabase();
    	Cursor mCursor = db.rawQuery( selectQuery, null);
        Boolean rowExists;
   
        if (mCursor.getCount() > 0){
        	// there are rows in the table
        	rowExists = false;
        }
        else{
        	rowExists = true;
        }
        return rowExists;
    }
    
}