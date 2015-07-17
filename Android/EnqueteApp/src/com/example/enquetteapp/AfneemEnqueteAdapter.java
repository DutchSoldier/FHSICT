package com.example.enquetteapp;

import java.util.List;

import Classes.Antwoord;
import Classes.Database;
import Classes.Vraag;
import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.ToggleButton;

public class AfneemEnqueteAdapter extends ArrayAdapter<Vraag>{
	public Context context;
	public List<Vraag> vragen;
	ViewHolder holder;
	int i;
	Database db;
	
	public AfneemEnqueteAdapter(Activity context, List<Vraag> vragen){
		super(context, R.layout.vraag_item, vragen);
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
			view = inflater.inflate(R.layout.vraag_item, null, false);

			holder = new ViewHolder();
			holder.vraag = (TextView)view.findViewById(R.id.tv_vraag);
			holder.group = (RadioGroup)view.findViewById(R.id.rg_antwoorden);
			holder.layout = (LinearLayout)view.findViewById(R.id.ll_antwoorden);
			holder.toggle = new ToggleButton(context);
			
			if(vraag.getGroep() == true){
				for(final Antwoord a : vraag.getAntwoorden()){
					holder.toggle = new ToggleButton(context);
					holder.toggle.setText(a.getAntwoord());
					holder.toggle.setTextOn(a.getAntwoord());
					holder.toggle.setTextOff(a.getAntwoord());
					holder.toggle.setId(i);
					holder.toggle.setChecked(a.getSelected());
					holder.toggle.setBackgroundResource(R.drawable.togglestate);
					holder.toggle.setTextAppearance(context, R.style.togglebutton);						
					
					holder.toggle.setOnClickListener(new OnClickListener()
					{
						@Override
					    public void onClick(View view)
					    {
					        // your click actions go here
					    	((RadioGroup)view.getParent()).check(view.getId());
					    	
					    	if(a.getSelected()==true){
					    		int count = a.getCount();
					    		a.setSelected(false);
					    		a.setCount(count - 1);
					    		db.updateAntwoord(a);
					    	}
					    	else if(a.getSelected()==false){
					    		for(Antwoord b: vraag.getAntwoorden()){
					    			if(b.getSelected()==true){
					    				int count = b.getCount();
					    				b.setCount(count - 1);
					    				b.setSelected(false);
					    				db.updateAntwoord(b);
					    			}
					    		}
					    		int count = a.getCount();
					    		a.setCount(count + 1);
					    		a.setSelected(true);
					    		db.updateAntwoord(a);
					    		//vraag.setAntwoord(a.getAntwoord());
					    	}
					    }
					});
					i++;
					holder.group.addView(holder.toggle);				
				}
			}
			else{
				for(final Antwoord a : vraag.getAntwoorden()){
					holder.toggle = new ToggleButton(context);
					holder.toggle.setText(a.getAntwoord());
					holder.toggle.setTextOn(a.getAntwoord());
					holder.toggle.setTextOff(a.getAntwoord());
					holder.toggle.setId(i);
					holder.toggle.setChecked(a.getSelected());
					holder.toggle.setBackgroundResource(R.drawable.togglestate);
					holder.toggle.setTextAppearance(context, R.style.togglebutton);					
					
					holder.toggle.setOnClickListener(new OnClickListener()
					{
						@Override
					    public void onClick(View view)
					    {
							int count = a.getCount();
							if(a.getSelected()==true){
					    		
					    		a.setCount(count - 1);
					    		a.setSelected(false);
					    		db.updateAntwoord(a);
					    	}
					    	else if(a.getSelected()==false){
					    		a.setSelected(true);
					    		a.setCount(count + 1);
					    		db.updateAntwoord(a);
					    		//vraag.setAntwoord(a.getAntwoord());
					    	}
					    }
					});
					i++;
					holder.layout.addView(holder.toggle);
				}
			}	
			view.setTag(holder);
		}
		else{
			view = convertView;
			holder = (ViewHolder) view.getTag();
		}
		ViewHolder viewholder = (ViewHolder) view.getTag();
		
		viewholder.vraag.setText(vraag.getVraag());
		
		holder.group.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener(){
			public void onCheckedChanged(RadioGroup group, int checkedId){
				for (int j = 0; j < group.getChildCount(); j++) {
		            final ToggleButton view = (ToggleButton) group.getChildAt(j);
		            view.setChecked(view.getId() == checkedId);
		        }
			}
		});
		
		view.setTag(viewholder);	
		
		return view;
	}
	
	static class ViewHolder {
		  TextView vraag;
		  RadioGroup group;
		  ToggleButton toggle;
		  LinearLayout layout;
		}
}
