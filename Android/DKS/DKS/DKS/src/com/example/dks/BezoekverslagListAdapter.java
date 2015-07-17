package com.example.dks;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class BezoekverslagListAdapter extends ArrayAdapter<Bezoekverslag>{
	public Context context;
	public List<Bezoekverslag> bezoekverslagen;
	ViewHolder holder;
	
	public BezoekverslagListAdapter(Activity context, List<Bezoekverslag> bezoekverslagen){
		super(context, R.layout.bezoekverslag_item, bezoekverslagen);
		this.context = context;
		this.bezoekverslagen = bezoekverslagen;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.bezoekverslag_item, null, false);
			holder = new ViewHolder();
			holder.relatie = (TextView)convertView.findViewById(R.id.tv_relatie);
			holder.onderwerp = (TextView)convertView.findViewById(R.id.tv_onderwerp);
			holder.datum = (TextView)convertView.findViewById(R.id.tv_datum);
			holder.concept = (TextView)convertView.findViewById(R.id.tv_concept);
			
			convertView.setTag(holder);
		}
		else{
			holder = (ViewHolder) convertView.getTag();
		}		
		holder.datum.setText(bezoekverslagen.get(position).getGereedDatum());
		holder.concept.setText(bezoekverslagen.get(position).getStatus());
		holder.relatie.setText(bezoekverslagen.get(position).getRelatie());
		holder.onderwerp.setText(bezoekverslagen.get(position).getOnderwerp());
		
		return convertView;
	}
	
	static class ViewHolder {
		  TextView relatie;
		  TextView onderwerp;
		  TextView datum;
		  TextView concept;
		}
}

