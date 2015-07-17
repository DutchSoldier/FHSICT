package com.example.shout;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

public class DeelnemerLijstAdapter extends ArrayAdapter<Deelnemer>{
	public Context context;
	public List<Deelnemer> deelnemers;
	
	public DeelnemerLijstAdapter(Activity context, List<Deelnemer> deelnemers) {
		super(context, R.layout.deelnemer_item, deelnemers);
		this.context = context;
		this.deelnemers = deelnemers;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.deelnemer_item, null, false);
		}


		
		return convertView;
	}
}
