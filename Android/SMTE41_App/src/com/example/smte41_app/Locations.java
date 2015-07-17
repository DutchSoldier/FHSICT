package com.example.smte41_app;

import android.graphics.drawable.Drawable;
import android.location.Location;



public class Locations {
	public static final String CLASS_NAME = "Locations";
	public String name;
	public Location location;
	public String description;
	public Drawable photo;
	private double locx;
	private double locy;
	
	/**
	 * @return the location
	 */
	public Location getLocation() {
		return location;
	}
	
	/**
	 * 
	 * @return longitude
	 */
	public double getLocX() {
		return this.locx;
	}
	
	/**
	 * 
	 * @return latitude
	 */
	public double getLocY() {
		return this.locy;
	}

	/**
	 * @param location the location to set
	 */
	public void setLocation(Location location) {
		this.location = location;
	}

	/**
	 * @return the name
	 */
	public String getName() {
		return name;
	}
	
	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		this.name = name;
	}

	
	/**
	 * @return the description
	 */
	public String getDescription() {
		return description;
	}
	
	/**
	 * @param description the description to set
	 */
	public void setDescription(String description) {
		this.description = description;
	}
	
	/**
	 * @return the photo
	 */
	public Drawable getPhoto() {
		return photo;
	}
	
	/**
	 * @param photo the photo to set
	 */
	public void setPhoto(Drawable photo) {
		this.photo = photo;
	}
	

	public Locations(String name, double locy, double locx, String description){

		this.name = name;
		this.description = description;
		this.locx = locx;
		this.locy = locy;
	}
}
