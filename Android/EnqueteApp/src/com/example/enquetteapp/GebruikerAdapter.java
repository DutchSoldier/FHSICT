package com.example.enquetteapp;

import java.util.List;

import Classes.Database;
import Classes.Enquete;
import Classes.Gebruiker;
import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class GebruikerAdapter extends ArrayAdapter<Gebruiker>{
	public Context context;
	public List<Gebruiker> gebruikers;
	ViewHolder holder;
	Database db;
	
	public GebruikerAdapter(Activity context, List<Gebruiker>gebruikers){
		super(context, R.layout.gebruiker_item, gebruikers);
		this.context = context;
		this.gebruikers = gebruikers;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		View view = null;
		convertView = null;
		final Gebruiker gebruiker = gebruikers.get(position);
		db = new Database(this.context);
		
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			view = inflater.inflate(R.layout.gebruiker_item, null, false);

			holder = new ViewHolder();
			holder.naam = (TextView)view.findViewById(R.id.tv_gebruikerNaam);
			holder.email = (TextView)view.findViewById(R.id.tv_gebruikerEmail);
			holder.geslacht = (TextView)view.findViewById(R.id.tv_gebruikerGeslacht);
			holder.geboorteDatum = (TextView)view.findViewById(R.id.tv_gebruikerGeboorteDatum);
			holder.gebruikerNr = (TextView)view.findViewById(R.id.tv_gebruikerNr);
			holder.enquete = (TextView)view.findViewById(R.id.tv_gebruikerEnquete);
				
			view.setTag(holder);
		}
		else{
			view = convertView;
			holder = (ViewHolder) view.getTag();
		}
		ViewHolder viewholder = (ViewHolder) view.getTag();
		Enquete enquete = db.getEnquete(gebruiker.getEnqueteNr());
		viewholder.naam.setText("Naam: "+gebruiker.getNaam());
		viewholder.email.setText("Email: "+gebruiker.getEmail());
		viewholder.geslacht.setText("Geslacht: "+gebruiker.getGeslacht());
		viewholder.geboorteDatum.setText("Geboorte datum: "+gebruiker.getGeboorteDatum());
		viewholder.gebruikerNr.setText("Nummer: "+gebruiker.getGebruikerNr());
		viewholder.enquete.setText("Enquete: "+enquete.getNaam());
		view.setTag(viewholder);	
		
		return view;
	}
	
	static class ViewHolder {
		  TextView naam;
		  TextView enquete;
		  TextView email;
		  TextView geslacht;
		  TextView geboorteDatum;
		  TextView gebruikerNr;
		}
}
