package com.example.dks;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class KwaliteitsverslagListAdapter extends ArrayAdapter<Kwaliteitsverslag>{
	public Context context;
	public List<Kwaliteitsverslag> kwaliteitsverslagen;
	ViewHolder holder;
	
	public KwaliteitsverslagListAdapter(Activity context, List<Kwaliteitsverslag> kwaliteitsverslagen){
		super(context, R.layout.kwaliteitsverslag_item, kwaliteitsverslagen);
		this.context = context;
		this.kwaliteitsverslagen = kwaliteitsverslagen;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.kwaliteitsverslag_item, null, false);
			holder = new ViewHolder();
			holder.plaats = (TextView)convertView.findViewById(R.id.tv_plaats);
			holder.eindDatum = (TextView)convertView.findViewById(R.id.tv_einddatum);
			holder.projectnaam = (TextView)convertView.findViewById(R.id.tv_projectnaam);
			holder.projectnummer = (TextView)convertView.findViewById(R.id.tv_projectnr);
			holder.startDatum = (TextView)convertView.findViewById(R.id.tv_startdatum);
			holder.status = (TextView)convertView.findViewById(R.id.tv_status);
			holder.straat = (TextView)convertView.findViewById(R.id.tv_straat);
			
			convertView.setTag(holder);
		}
		else{
			holder = (ViewHolder) convertView.getTag();
			
		}		
		holder.eindDatum.setText(kwaliteitsverslagen.get(position).getGereedDatum());
		holder.plaats.setText(kwaliteitsverslagen.get(position).getPlaats());
		holder.straat.setText(kwaliteitsverslagen.get(position).getStraat());
		holder.status.setText(kwaliteitsverslagen.get(position).getStatus());
		holder.projectnummer.setText(String.valueOf(kwaliteitsverslagen.get(position).getProjectnummer()));
		holder.projectnaam.setText(kwaliteitsverslagen.get(position).getProjectnaam());
		holder.startDatum.setText(kwaliteitsverslagen.get(position).getStartDatum());
		
		return convertView;
	}
	
	static class ViewHolder {
		  TextView projectnummer;
		  TextView projectnaam;
		  TextView startDatum;
		  TextView eindDatum;
		  TextView straat;
		  TextView plaats;
		  TextView status;
		}
}
