package com.smte4;

import android.content.Context;
import android.view.LayoutInflater;
import android.widget.LinearLayout;
import android.widget.TextView;

public class PerfumeView extends LinearLayout {

	public PerfumeView(Context context) {
		super(context);
		LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
		inflater.inflate(R.layout.perfume, this);
	}
	
	public void setPerfume(Perfume perfume) {
		TextView nameView = (TextView) findViewById(R.id.textViewName);
		nameView.setText(perfume.name);
		
		TextView priceView = (TextView) findViewById(R.id.textViewPrice);
		priceView.setText(String.format("$ %d,-",perfume.price));
	}
}
