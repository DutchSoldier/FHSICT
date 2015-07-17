package com.example.shout;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

public class ChatLijstAdapter extends ArrayAdapter<Chat>{
	public Context context;
	public List<Chat> chats;
	
	public ChatLijstAdapter(Activity context, List<Chat> chats) {
		super(context, R.layout.chat_item, chats);
		this.context = context;
		this.chats = chats;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) { 	
		if(convertView == null) {
			LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflater.inflate(R.layout.chat_item, null, false);
		}


		
		return convertView;
	}
}
