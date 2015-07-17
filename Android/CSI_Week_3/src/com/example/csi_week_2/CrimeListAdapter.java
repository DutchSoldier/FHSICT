package com.example.csi_week_2;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class CrimeListAdapter extends ArrayAdapter<Crime> {
	private Context context;
	private List<Crime> crimes;

	public CrimeListAdapter(Activity context, List<Crime> crimes) {
		super(context, R.layout.crimelistitem, crimes);
		this.context = context;
		this.crimes = crimes;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.crimelistitem, null, false);
		}
		
		TextView crimeName = (TextView)convertView.findViewById(R.id.crimeName);
		TextView crimeBounty = (TextView)convertView.findViewById(R.id.crimeBounty);
		TextView crimeDescription = (TextView)convertView.findViewById(R.id.crimeDescription);
		
		return convertView;
	}
}
