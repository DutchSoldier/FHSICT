package com.example.dks;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class WerkbonListAdapter extends ArrayAdapter<Werkbon> {
	public Context context;
	public List<Werkbon> workorders;
	ViewHolder holder;
	
	public WerkbonListAdapter(Activity context, List<Werkbon> workorders){
		super(context, R.layout.werkbon_item, workorders);
		this.context = context;
		this.workorders = workorders;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.werkbon_item, null, false);
			holder = new ViewHolder();
			holder.projectnaam = (TextView)convertView.findViewById(R.id.tv_projectnaam);
			holder.werkbonNr = (TextView)convertView.findViewById(R.id.tv_werkbonNr);
			holder.gereedDatum = (TextView)convertView.findViewById(R.id.tv_gereedDatum);
			holder.status = (TextView)convertView.findViewById(R.id.tv_status);
			holder.adres = (TextView)convertView.findViewById(R.id.tv_adres);
			holder.opmerkingen = (TextView)convertView.findViewById(R.id.tv_opmerkingen);
			convertView.setTag(holder);
		}
		else{
			holder = (ViewHolder) convertView.getTag();
			
		}		

		holder.werkbonNr.setText("Nummer: "+String.valueOf(workorders.get(position).getWerkbonNr()));
		holder.projectnaam.setText("Project: "+workorders.get(position).getProjectnaam());
		holder.gereedDatum.setText(workorders.get(position).getGereedDatum());
		holder.status.setText(workorders.get(position).getStatus());
		holder.adres.setText(workorders.get(position).getStraat()+" "+workorders.get(position).getHuisnummer()+" "+workorders.get(position).getPlaats());
		holder.opmerkingen.setText(workorders.get(position).getOpmerkingen());
		
		return convertView;
	}
	
	static class ViewHolder {
		  TextView werkbonNr;
		  TextView projectnaam;
		  TextView gereedDatum;
		  TextView status;
		  TextView adres;
		  TextView opmerkingen;
		}
}
