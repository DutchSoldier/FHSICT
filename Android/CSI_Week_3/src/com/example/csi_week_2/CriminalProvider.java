package com.example.csi_week_2;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Random;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.location.Location;


/**
 * This class can be used to generate random criminals, and retrieve them based on their index.
 * @author Michael
 *
 */
public class CriminalProvider{
	
	/**
	 * This list contains the generated criminals.
	 * Notice the static. This means that all CriminalProvider classes share the same list.
	 */
	private static ArrayList<Criminal> criminalList;
	
	/**
	 * This map contains all the available mugshot id's
	 */
	private  HashMap<Integer, Integer> mugshotsMap;
	
	
	/**
	 * This context can be used to acquire the resources.
	 */
	private Context context;
	
	
	/**
	 * Gets a drawable representing the mugshot.
	 * @param index The requested mugshot (0..4)
	 * @return the mugshot
	 */
	private Drawable getMugshot(int index)
	{
		Integer id = mugshotsMap.get(new Integer(index));
		return context.getResources().getDrawable(id);
	}
	
	/**
	 * Creates a random criminal.
	 * It chooses random elements from the resource files.
	 * @return The randomly created criminal
	 */
	private Criminal createRandomCriminal()
	{
		
		Criminal randomCriminal = new Criminal();
		Random r = new Random();
		//read the criminal names from the xml files and store it in a variable
		String[] criminalNames = context.getResources().getStringArray(R.array.names);
		//read the criminal details from the xml files and store it in a variable
		String[] criminalDetails = context.getResources().getStringArray(R.array.criminaldescription);

		
		//Todo 1 choose a random name from the criminals.xml file
		randomCriminal.name = criminalNames[r.nextInt(5)];
		//Todo 2 choose a random gender (male/female)
		randomCriminal.gender = r.nextBoolean()?"Male":"Female";
		//Todo 3 choose a random age
		randomCriminal.age = 10 + r.nextInt(100);
		//Todo 4 Create a random latitude and longitude and use it as the lastKnownPosition
		
		randomCriminal.location = new Location("");
		randomCriminal.location.setLatitude(-180.0 + r.nextDouble() * 180.0);
		randomCriminal.location.setLongitude(-180.0 + r.nextDouble() * 180.0);
		
		//Todo 5 Choose a random description from the criminaldetails.xml file
		int crimeIndex = r.nextInt(4);
		randomCriminal.description = criminalDetails[r.nextInt(5)];
		//Todo 6 Choose a random mugshot using getMugshot
		randomCriminal.mugshot = getMugshot(r.nextInt(5));
		//Todo 7 Create a random number of crimes, by calling the createRandomCrime function
		randomCriminal.crimes = new ArrayList<Crime>();
		int numCrimes = 1 + r.nextInt(3);
		for (int i = 0 ; i < numCrimes; i++)
		{
			Crime crime = createRandomCrime();
			randomCriminal.crimes.add(crime);
		}
		
		
		return randomCriminal;
	}
	
	
	/**
	 * Creates a random crime. The name and description are picked from the resource files.
	 * @return The random crime.
	 */
	private Crime createRandomCrime()
	{
	
		Crime randomCrime = new Crime();
	
		Random r = new Random();
		//read the crime names from the xml files and store it in a variable
		String[] crimeNames = context.getResources().getStringArray(R.array.crimename);
		//read the crime details from the xml files and store it in a variable
		String[] crimeDetails = context.getResources().getStringArray(R.array.crimedescription);
				
		int randomInt = r.nextInt(5);
		//Todo 1 Choose a random name and description for the crime (Note they should both use the same index)
		randomCrime.name = crimeNames[randomInt];
		randomCrime.description = crimeDetails[randomInt];
		//Todo 2 Choose a random bounty in dollars
		randomCrime.bountyInDollars = r.nextInt(100000);
		return randomCrime;
	}
	
	
	/**
	 * Call this method to create a list with random criminals
	 * @param int numberOfCriminals the number of random criminals to generate
	 */
	public void generateRandomCriminals(int numberOfCriminals)
	{
		criminalList.clear();
		for (int i = 0 ; i < numberOfCriminals ; i++)
		{
			Criminal newRandomCriminal = createRandomCriminal();
			criminalList.add(newRandomCriminal);
		}
	}
	
	
	/**
	 * Constructor of the CriminalProvider.
	 * @param context The context (i.e. the activity) that is using this provider.
	 */
	public CriminalProvider(Context context)
	{
		if(criminalList == null)
		{
			criminalList = new ArrayList<Criminal>();
		}
		
		//Populate the drawable id's
		mugshotsMap = new HashMap<Integer, Integer>();
		mugshotsMap.put(0, R.drawable.mugshot1);
		mugshotsMap.put(1, R.drawable.mugshot2);
		mugshotsMap.put(2, R.drawable.mugshot3);
		mugshotsMap.put(3, R.drawable.mugshot4);
		mugshotsMap.put(4, R.drawable.mugshot5);
		
		this.context = context;

	}
	
	
	/**
	 * Get the list with all stored random criminals
	 * @return the list with criminals
	 */
	public ArrayList<Criminal> GetCriminals()
	{
		return criminalList;
	}
	
	/**
	 * Gets one specific criminal from the list.
	 * @param index The index in the list to get the criminal at.
	 * @return The found criminal
	 */
	public Criminal GetCriminal(int index)
	{
		return criminalList.get(index);

	}

	/**
	 * Gets the amount of criminals that are stored in the list
	 * @return the number of criminals
	 */
	public int getNumberOfCriminals()
	{
		return criminalList.size();
	}

}

