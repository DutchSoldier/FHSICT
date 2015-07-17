package com.example.dks;

public class Options {
	private int OptionsNr;
	private String groeperenOp;
	private String sorterenOp;
	private String taal;
	private Boolean displayPlannedHours;
	private int accountId;
	private int deviceId;
	private String host;
	private int port;
	private int gebruikerNr;
	
	public int getGebruikerNr() {
		return gebruikerNr;
	}
	public void setGebruikerNr(int gebruikerNr) {
		this.gebruikerNr = gebruikerNr;
	}
	public int getOptionsNr() {
		return OptionsNr;
	}
	public void setOptionsNr(int optionsNr) {
		OptionsNr = optionsNr;
	}
	public String getGroeperenOp() {
		return groeperenOp;
	}
	public void setGroeperenOp(String groeperenOp) {
		this.groeperenOp = groeperenOp;
	}
	public String getSorterenOp() {
		return sorterenOp;
	}
	public void setSorterenOp(String sorterenOp) {
		this.sorterenOp = sorterenOp;
	}
	public String getTaal() {
		return taal;
	}
	public void setTaal(String taal) {
		this.taal = taal;
	}
	public Boolean getDisplayPlannedHours() {
		return displayPlannedHours;
	}
	public void setDisplayPlannedHours(Boolean displayPlannedHours) {
		this.displayPlannedHours = displayPlannedHours;
	}
	public int getAccountId() {
		return accountId;
	}
	public void setAccountId(int accountId) {
		this.accountId = accountId;
	}
	public int getDeviceId() {
		return deviceId;
	}
	public void setDeviceId(int deviceId) {
		this.deviceId = deviceId;
	}
	public String getHost() {
		return host;
	}
	public void setHost(String host) {
		this.host = host;
	}
	public int getPort() { 
		return port;
	}
	public void setPort(int port) {
		this.port = port;
	}
}
