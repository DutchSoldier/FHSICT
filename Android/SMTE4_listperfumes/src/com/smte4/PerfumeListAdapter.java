package com.smte4;

import java.util.List;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

public class PerfumeListAdapter extends ArrayAdapter<Perfume> {
	private Context context;
	private List<Perfume> perfumes;
	
	public PerfumeListAdapter(Context context, List<Perfume> perfumes) {
		super(context, R.layout.main, perfumes);
		this.perfumes = perfumes;
		this.context = context;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		PerfumeView perfumeView = new PerfumeView(context);
		perfumeView.setPerfume(perfumes.get(position));
		return perfumeView;
	}
}
