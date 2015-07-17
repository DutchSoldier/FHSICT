package com.example.csi_week_2;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class CriminalListAdapter extends ArrayAdapter<Criminal> {
	public Context context;
	public List<Criminal> criminals;
	
	public CriminalListAdapter(Activity context, List<Criminal> criminals) {
		super(context, R.layout.criminallistitem, criminals);
		this.context = context;
		this.criminals = criminals;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.criminallistitem, null, false);
		}
		
		ImageView mugshot = (ImageView)convertView.findViewById(R.id.criminalMugshot);
		mugshot.setImageDrawable(criminals.get(position).mugshot);
		
		TextView naam = (TextView)convertView.findViewById(R.id.criminalName);
		naam.setText(criminals.get(position).name + "\t");
		
		int bounty = 0;
		
		for(Crime c : criminals.get(position).crimes) {
			bounty += c.bountyInDollars;
		}
		
		TextView totalBounty = (TextView)convertView.findViewById(R.id.criminalBounty);
		totalBounty.setText("€" + bounty);

		
		return convertView;
	}

}
