package com.example.dks;

import java.util.List;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.EditText;

public class BezoekverslagAfsprakenListAdapter extends ArrayAdapter<Afspraak>{
	public Context context;
	public List<Afspraak> afspraken;
	ViewHolder holder;
    static final int DATE_DIALOG_ID = 0;
	int globalPosition;
	String dateSet;
    
	public BezoekverslagAfsprakenListAdapter(Activity context, List<Afspraak> afspraken){
		super(context, R.layout.bezoekverslag_afspraak_item, afspraken);
		this.context = context;
		this.afspraken = afspraken;
	}
	
	public void setDateSet(String dateSet) {
        this.dateSet = dateSet;
        holder.datum.setText(dateSet);
    }
	
	@Override
	public View getView(final int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.bezoekverslag_afspraak_item, null, false);
			holder = new ViewHolder();
			holder.afspraak = (EditText)convertView.findViewById(R.id.et_afspraak);
			holder.wie = (EditText)convertView.findViewById(R.id.et_wie);			
				    
			holder.datum = (EditText)convertView.findViewById(R.id.et_datumAfspraak);
			
			holder.datum.setOnClickListener(new OnClickListener()
			{
			    @Override
			    public void onClick(View view)
			    {                 
                    ((Activity) BezoekverslagAfsprakenListAdapter.this.context)
                    .showDialog(DATE_DIALOG_ID);                   
                    globalPosition = position; 
			    }
			});
			convertView.setTag(holder);
		}
		else{
			holder = (ViewHolder) convertView.getTag();
		}	
		
		
		holder.datum.setText(afspraken.get(position).getDatum());
		holder.afspraak.setText(afspraken.get(position).getAfspraak());
		holder.wie.setText(afspraken.get(position).getWie());
		
		return convertView;
	}
	
	static class ViewHolder {
		  EditText afspraak;
		  EditText wie;
		  EditText datum;
		}
}
