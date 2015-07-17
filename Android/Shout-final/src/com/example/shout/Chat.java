package com.example.shout;

public class Chat {
	private String firstname;
	private String text;
	
	
	public String getFirstname() {
		return firstname;
	}
	public void setFirstname(String firstname) {
		this.firstname = firstname;
	}
	public String getText() {
		return text;
	}
	public void setText(String text) {
		this.text = text;
	}
	
	public Chat(String firstname, String text){
		this.firstname = firstname;
		this.text = text;
	}
}
