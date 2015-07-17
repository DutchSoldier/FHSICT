package com.example.shout;

import java.io.ByteArrayOutputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;

public class MakeProfileActivity extends Activity implements View.OnClickListener{
	private static final int REQUEST_CODE = 1;
	private Bitmap bitmap;
	Button save;
	ImageButton photo;
	EditText fname, lname, age, hobby1, hobby2, hobby3;
	ImageView image;
	DatabaseHandler db = new DatabaseHandler(this);
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
		setContentView(R.layout.activity_make_profile);
		
		save = (Button)findViewById(R.id.save_profile);
		save.setOnClickListener(this);
		
		photo = (ImageButton)findViewById(R.id.photo_button);
		
		image = (ImageView)findViewById(R.id.iv_profilepicture);
		
		fname = (EditText)findViewById(R.id.edit_firstname);
		lname = (EditText)findViewById(R.id.edit_lastname);
		age = (EditText)findViewById(R.id.edit_age);
		hobby1 = (EditText)findViewById(R.id.edit_hobby1);
		hobby2 = (EditText)findViewById(R.id.edit_hobby2);
		hobby3 = (EditText)findViewById(R.id.edit_hobby3);
	}

	public void pickImage(View View) {
        Intent intent = new Intent();
        intent.setType("image/*");
        intent.setAction(Intent.ACTION_GET_CONTENT);
        intent.addCategory(Intent.CATEGORY_OPENABLE);
        startActivityForResult(intent, REQUEST_CODE);
    }
	
	@Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == REQUEST_CODE && resultCode == Activity.RESULT_OK)
            try {
                // We need to recyle unused bitmaps
                if (bitmap != null) {
                    bitmap.recycle();
                }
                InputStream stream = getContentResolver().openInputStream(
                        data.getData());
                bitmap = BitmapFactory.decodeStream(stream);
                stream.close();
                image.setImageBitmap(bitmap);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
        super.onActivityResult(requestCode, resultCode, data);
    }
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.load, menu);
		return true;
	}

	@Override
	public void onClick(View v) {
		
		
		if(v == save) {
			
			if(fname.getText().length() != 0){
				if(lname.getText().length() != 0){
					if(age.getText().length() != 0){
						if(hobby1.getText().length() != 0){
							if(hobby2.getText().length() != 0){
								if(hobby3.getText().length() != 0){
									if(image.getDrawable() != null){
										//Foto van ImageView naar Bytes
										Bitmap bitmap = (Bitmap)((BitmapDrawable) image.getDrawable()).getBitmap();
									    ByteArrayOutputStream stream = new ByteArrayOutputStream();
									    bitmap.compress(Bitmap.CompressFormat.JPEG, 100, stream);
									    byte[] bitmapdata = stream.toByteArray();
										
										//Profiel opslaan in database
										db.addContact(new Deelnemer(1, fname.getText().toString(), 
												lname.getText().toString(), Integer.parseInt(age.getText().toString()), 
												bitmapdata, hobby1.getText().toString(), hobby2.getText().toString(), hobby3.getText().toString()));
										
										Intent intent = new Intent(this, PublicChatActivity.class);
										startActivity(intent);
									}
									else{
										AlertDialog ad = new AlertDialog.Builder(this).create();  
										ad.setCancelable(false); // This blocks the 'BACK' button  
										ad.setMessage("Choose a picture!");  
										ad.setButton("OK", new DialogInterface.OnClickListener() {  
										    @Override  
										    public void onClick(DialogInterface dialog, int which) {  
										        dialog.dismiss();                      
										    }  
										});  
										ad.show(); 
									}
									
								}
								else{
									AlertDialog ad = new AlertDialog.Builder(this).create();  
									ad.setCancelable(false); // This blocks the 'BACK' button  
									ad.setMessage("Fill in 3th hobby!");  
									ad.setButton("OK", new DialogInterface.OnClickListener() {  
									    @Override  
									    public void onClick(DialogInterface dialog, int which) {  
									        dialog.dismiss();                      
									    }  
									});  
									ad.show(); 
								}
							}
							else{
								AlertDialog ad = new AlertDialog.Builder(this).create();  
								ad.setCancelable(false); // This blocks the 'BACK' button  
								ad.setMessage("Fill in 2th hobby!");  
								ad.setButton("OK", new DialogInterface.OnClickListener() {  
								    @Override  
								    public void onClick(DialogInterface dialog, int which) {  
								        dialog.dismiss();                      
								    }  
								});  
								ad.show();
							}
						}
						else{
							AlertDialog ad = new AlertDialog.Builder(this).create();  
							ad.setCancelable(false); // This blocks the 'BACK' button  
							ad.setMessage("Fill in 1th hobby!");  
							ad.setButton("OK", new DialogInterface.OnClickListener() {  
							    @Override  
							    public void onClick(DialogInterface dialog, int which) {  
							        dialog.dismiss();                      
							    }  
							});  
							ad.show();
						}
					}
					else{
						AlertDialog ad = new AlertDialog.Builder(this).create();  
						ad.setCancelable(false); // This blocks the 'BACK' button  
						ad.setMessage("Fill in age!");  
						ad.setButton("OK", new DialogInterface.OnClickListener() {  
						    @Override  
						    public void onClick(DialogInterface dialog, int which) {  
						        dialog.dismiss();                      
						    }  
						});  
						ad.show();
					}
				}
				else{
					AlertDialog ad = new AlertDialog.Builder(this).create();  
					ad.setCancelable(false); // This blocks the 'BACK' button  
					ad.setMessage("Fill in lastname!");  
					ad.setButton("OK", new DialogInterface.OnClickListener() {  
					    @Override  
					    public void onClick(DialogInterface dialog, int which) {  
					        dialog.dismiss();                      
					    }  
					});  
					ad.show();
				}
			}
			else{
				AlertDialog ad = new AlertDialog.Builder(this).create();  
				ad.setCancelable(false); // This blocks the 'BACK' button  
				ad.setMessage("Fill in firstname!");  
				ad.setButton("OK", new DialogInterface.OnClickListener() {  
				    @Override  
				    public void onClick(DialogInterface dialog, int which) {  
				        dialog.dismiss();                      
				    }  
				});  
				ad.show();
			}
			
		}
	}
	
	@Override
	protected void onDestroy() {
	    super.onDestroy();
	    db.close();
	}
}
