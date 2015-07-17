package com.example.smte41_app;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.StatusLine;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.json.JSONArray;
import org.json.JSONObject;

public class DataConnection {
	
	public static ArrayList<Locations> getLocations () {
		ArrayList<Locations> locations = new ArrayList<Locations>();
		ArrayList<NameValuePair> params = new ArrayList<NameValuePair>();
		
		String request = postRequest("smteGetLocations", params);
		try {
			JSONArray jsonArray = new JSONArray(request);
			for (int i = 0; i < jsonArray.length(); i++) {
				JSONObject ob = jsonArray.getJSONObject(i);
				locations.add(new Locations((String)ob.getString("name"), (double)ob.getDouble("locx"), (double)ob.getDouble("locy"), (String)ob.getString("description")));
			}
		} catch (Exception ex) {
			Logger.getLogger(DataConnection.class.getName()).log(Level.SEVERE, null, ex);
		}
		return locations;
	}
	
	public static Locations searchLocation(String name) {
		Locations location = null;
		ArrayList<NameValuePair> params = new ArrayList<NameValuePair>();
		params.add(new BasicNameValuePair("name", name));
		String request = postRequest("smteSearchLocation", params);
		System.out.println("test" + request);
		try {
			JSONArray jsonArray = new JSONArray(request);
			JSONObject ob = jsonArray.getJSONObject(0);
			location = new Locations((String)ob.getString("Name"), (double)ob.getDouble("LocX"), (double)ob.getDouble("LocY"), (String)ob.getString("Description"));
			System.out.println(location.name + ", " + location.description + ", " + location.getLocX() + ", " + location.getLocY());
		}
		catch (Exception ex) {
			Logger.getLogger(DataConnection.class.getName()).log(Level.SEVERE, null, ex);
		}
		return location;
	}
	
	public static boolean saveNewLocation(String name, String description, double locx, double locy) {
		ArrayList<NameValuePair> params = new ArrayList<NameValuePair>();
		params.add(new BasicNameValuePair("name", name));
		params.add(new BasicNameValuePair("description", description));
		params.add(new BasicNameValuePair("locx", Double.toString(locx)));
		params.add(new BasicNameValuePair("locy", Double.toString(locy)));
		
		String request = postRequest("smteSaveNewLocation", params);
		try {
			JSONArray jsonArray = new JSONArray(request);
			JSONObject ob = jsonArray.getJSONObject(0);

			String s = (String)ob.get("Success");
			if (s.equals("True")) {	
				return true;
			}
		} 
		
		catch (Exception ex) {
			Logger.getLogger(DataConnection.class.getName()).log(Level.SEVERE, null, ex);
		}
		return false;
	}
	
	public static String postRequest(String page, ArrayList<NameValuePair> postData) {
		StringBuilder builder = new StringBuilder();
		HttpClient client = new DefaultHttpClient();
		HttpPost post = new HttpPost("http://athena.fhict.nl/users/i252753/" + page +".php");

		try {
			post.setEntity(new UrlEncodedFormEntity(postData, "UTF-8"));
			HttpResponse response = client.execute(post);
			StatusLine statusLine = response.getStatusLine();

			int statusCode = statusLine.getStatusCode();

			if (statusCode == 200) {
				HttpEntity entity = response.getEntity();
				InputStream content = entity.getContent();        
				BufferedReader reader = new BufferedReader(new InputStreamReader(content));

				String line;
				while ((line = reader.readLine()) != null) {
					builder.append(line);
				}

				return builder.toString();	
			}           
		} catch (IOException ex) {
			Logger.getLogger(DataConnection.class.getName()).log(Level.SEVERE, null, ex);
		}
		return null;
	}
}
