package com.example.shout;

import java.util.ArrayList;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.KvmSerializable;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.util.Log;

public class WebConnectie {
	public static final String URL = "http://192.168.1.2/WebServices/chat?wsdl";
	public static final String NAMESPACE = "http://smptserver/";

	public WebConnectie() {
	}
	
	
	public static void addUser(String voornaam, String achternaam, int leeftijd, String hobby1, String hobby2, String hobby3, String macAdress) {
		SoapObject request = new SoapObject(NAMESPACE, "addUser");     
		request.addProperty("arg0", voornaam);
		request.addProperty("arg1", achternaam);
		request.addProperty("arg2", leeftijd);
		request.addProperty("arg3", hobby1);
		request.addProperty("arg4", hobby2);
		request.addProperty("arg5", hobby3);
		request.addProperty("arg6", macAdress);
		
		SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.setOutputSoapObject(request);
        
        try {
            HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
            androidHttpTransport.call("\"http://smptserver/addUser\"", envelope);
      } catch (Exception e) {
            e.printStackTrace();
      }
	}
	
	public static void addMessage(String message, String macAddress) {
		SoapObject request = new SoapObject(NAMESPACE, "addMessage");     
		request.addProperty("arg0", message);
		request.addProperty("arg1", macAddress);
		
		SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.setOutputSoapObject(request);
        
        try {
            HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
            androidHttpTransport.call("\"http://smptserver/addMessage\"", envelope);
        } catch (Exception e) {
            e.printStackTrace();
        }
	}
	
	public static ArrayList<String> getOnlineUsers() {
		SoapObject request = new SoapObject(NAMESPACE, "getOnlineUsers");   
		SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.setOutputSoapObject(request);
        
        try {
            HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
            androidHttpTransport.call("\"http://smptserver/getOnlineUsers\"", envelope);
           
            KvmSerializable ks = (KvmSerializable)envelope.bodyIn;
            
            ArrayList<String> result = new ArrayList<String>();
            if (ks != null) {
            	
            	for(int i=0;i<ks.getPropertyCount();i++)
                {
            		result.add(ks.getProperty(0).toString());
                }
            	return result;
            }
            
      } catch (Exception e) {
            e.printStackTrace();
      }
      return null;
	}
}
