package com.example.enquetteapp;

import java.util.List;

import Classes.Vraag;
import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class VragenLijstAdapter extends ArrayAdapter<Vraag>{
	public Context context;
	public List<Vraag> vragen;
	ViewHolder holder;
    
	public VragenLijstAdapter(Activity context, List<Vraag>vragen){
		super(context, R.layout.vraag_item, vragen);
		this.context = context;
		this.vragen = vragen;
	}
	
	@Override
	public View getView(final int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.vraag_item, null, false);
			holder = new ViewHolder();
			holder.vraag = (TextView)convertView.findViewById(R.id.tv_vraag);
			
			convertView.setTag(holder);
		}
		else{
			holder = (ViewHolder) convertView.getTag();
		}	
		holder.vraag.setText(vragen.get(position).getVraag());
		
		return convertView;
	}
	
	static class ViewHolder {
		  TextView vraag;
		}
}
