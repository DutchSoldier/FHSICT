/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package web;

import javax.xml.ws.Endpoint;

/**
 *
 * @author Remi_Arts
 */
public class WebServiceStarter {
	
	private static final String url = "http://localhost:8080/AuctionService";
	private static final String url2 = "http://localhost:8080/RegistrationService";
	public static void main(String[] args) {
		Endpoint.publish(url, new Auction());
		Endpoint.publish(url2, new Registration());
	}
	
}
