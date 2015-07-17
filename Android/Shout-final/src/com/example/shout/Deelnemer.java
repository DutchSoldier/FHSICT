package com.example.shout;


import android.graphics.drawable.Drawable;

public class Deelnemer {
	private String firstname;
	private String lastname;
	private int  age;
	private byte[] profilepicture;
	private String hobby1;
	private String hobby2;
	private String hobby3;
	private int id;
		
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getAge() {
		return age;
	}

	public void setAge(int age) {
		this.age = age;
	}
	
	public String getFirstname() {
		return firstname;
	}
	
	public void setFirstname(String firstname) {
		this.firstname = firstname;
	}
	
	public String getLastname() {
		return lastname;
	}
	
	public void setLastname(String lastname) {
		this.lastname = lastname;
	}
	
	public byte[] getProfilepicture() {
		return profilepicture;
	}
	
	public void setProfilepicture(byte[] profilepicture) {
		this.profilepicture = profilepicture;
	}
	
	public String getHobby1() {
		return hobby1;
	}
	
	public void setHobby1(String hobby1) {
		this.hobby1 = hobby1;
	}
	
	public String getHobby2() {
		return hobby2;
	}
	
	public void setHobby2(String hobby2) {
		this.hobby2 = hobby2;
	}
	
	public String getHobby3() {
		return hobby3;
	}
	
	public void setHobby3(String hobby3) {
		this.hobby3 = hobby3;
	}
	
	public Deelnemer(int id, String firstname, String lastname, int age, byte[] profilepicture,
			String hobby1, String hobby2, String hobby3){
		this.firstname = firstname;
		this.lastname = lastname;
		this.age = age;
		this.profilepicture = profilepicture;
		this.hobby1 = hobby1;
		this.hobby2 = hobby2;
		this.hobby3 = hobby3;
	}
	

}
