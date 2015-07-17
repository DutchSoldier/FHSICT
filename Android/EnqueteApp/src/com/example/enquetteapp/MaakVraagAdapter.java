package com.example.enquetteapp;

import java.util.List;

import Classes.Antwoord;
import Classes.Database;
import android.app.Activity;
import android.content.Context;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.EditText;

public class MaakVraagAdapter extends ArrayAdapter<Antwoord>{
	public Context context;
	public List<Antwoord> antwoorden;
	ViewHolder holder;
	Database db;
    
	public MaakVraagAdapter(Activity context, List<Antwoord> antwoorden){
		super(context, R.layout.antwoord_item, antwoorden);
		this.context = context;
		this.antwoorden = antwoorden;
	}
	
	@Override
	public View getView(final int position, View convertView, ViewGroup parent) { 	
		db = new Database(this.context);
		final Antwoord antwoord = antwoorden.get(position);
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.antwoord_item, null, false);
			holder = new ViewHolder();
			holder.antwoord = (EditText)convertView.findViewById(R.id.et_antwoord);
			holder.antwoord.setId(antwoord.getAntwoordNr());
			holder.antwoord.addTextChangedListener(new TextWatcher() {
		        @Override
		        public void afterTextChanged(Editable s) {
		        	// TODO Auto-generated method stub
		        }
		        @Override
		        public void beforeTextChanged(CharSequence s, int start, int count, int after) {
		            // TODO Auto-generated method stub
		        }
		        @Override
		        public void onTextChanged(CharSequence s, int start, int before, int count) {
		        	antwoord.setAntwoord(s.toString());
		        	db.updateAntwoord(antwoord);
		        } 
		    });

			convertView.setTag(holder);
		}
		else{
			holder = (ViewHolder) convertView.getTag();
		}	
		holder.antwoord.setText(antwoorden.get(position).getAntwoord());
		
		return convertView;
	}
	
	static class ViewHolder {
		  EditText antwoord;
		}
}
