package com.example.enquetteapp;

import java.util.List;

import Classes.Antwoord;
import Classes.Database;
import Classes.Vraag;
import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

public class ResultatenAdapter extends ArrayAdapter<Vraag>{
	public Context context;
	public List<Vraag> vragen;
	ViewHolder holder;
	Database db;
	
	public ResultatenAdapter(Activity context, List<Vraag>vragen){
		super(context, R.layout.resultaat_item, vragen);
		this.context = context;
		this.vragen = vragen;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		View view = null;
		convertView = null;
		final Vraag vraag = vragen.get(position);
		db = new Database(this.context);
		
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			view = inflater.inflate(R.layout.resultaat_item, null, false);

			holder = new ViewHolder();
			holder.vraag = (TextView)view.findViewById(R.id.tv_vraag);
			holder.layout = (LinearLayout)view.findViewById(R.id.rl_antwoorden);
			holder.antwoord = new TextView(context);
			for(Antwoord a: vraag.getAntwoorden()){
				holder.antwoord = new TextView(context);
				holder.antwoord.setText(a.getAntwoord() + " = "+ a.getCount());
				holder.layout.addView(holder.antwoord);
			}
				
			view.setTag(holder);
		}
		else{
			view = convertView;
			holder = (ViewHolder) view.getTag();
		}
		ViewHolder viewholder = (ViewHolder) view.getTag();
		
		viewholder.vraag.setText(vraag.getVraag());
		
		view.setTag(viewholder);	
		
		return view;
	}
	
	static class ViewHolder {
		  TextView vraag;
		  LinearLayout layout;
		  TextView antwoord;
		}
}
