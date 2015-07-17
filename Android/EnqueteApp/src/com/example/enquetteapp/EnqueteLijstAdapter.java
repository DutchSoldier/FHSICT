package com.example.enquetteapp;

import java.util.List;

import Classes.Enquete;
import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class EnqueteLijstAdapter extends ArrayAdapter<Enquete>{
	public Context context;
	public List<Enquete> enquetes;
	ViewHolder holder;
	
	public EnqueteLijstAdapter(Activity context, List<Enquete> enquetes){
		super(context, R.layout.enquete_item, enquetes);
		this.context = context;
		this.enquetes = enquetes;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.enquete_item, null, false);
			holder = new ViewHolder();
			holder.naam = (TextView)convertView.findViewById(R.id.tv_naam);
			holder.nummer = (TextView)convertView.findViewById(R.id.tv_nummer);
			holder.beschrijving = (TextView)convertView.findViewById(R.id.tv_beschrijving);
			
			convertView.setTag(holder);
		}
		else{
			holder = (ViewHolder) convertView.getTag();
		}		
		holder.nummer.setText(String.valueOf(enquetes.get(position).getEnqueteNr()));
		holder.naam.setText(enquetes.get(position).getNaam());
		holder.beschrijving.setText(enquetes.get(position).getBeschrijving());
		
		return convertView;
	}
	
	static class ViewHolder {
		  TextView nummer;
		  TextView naam;
		  TextView beschrijving;
		}
}
