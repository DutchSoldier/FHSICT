package com.example.dks;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Collections;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.DatePickerDialog.OnDateSetListener;
import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Path;
import android.graphics.RectF;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore.Images;
import android.util.AttributeSet;
import android.util.Log;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.LinearLayout.LayoutParams;
import android.widget.ListView;
import android.widget.RadioGroup;
import android.widget.Toast;
import android.widget.ToggleButton;

public class BezoekverslagAfsprakenActivity extends Activity implements View.OnClickListener, OnDateSetListener{

	ToggleButton concept, gereed;
	Button mClear,mGetSign, addAfspraak, deleteAfspraak, deleteAfspraken;
	LinearLayout mContent;
    signature mSignature;
    public static String tempDir;
    public int count = 1;
    public String current = null;
    private Bitmap mBitmap;
    View mView;
    static EditText gereedDatum;
    ListView listview;  
    BezoekverslagAfsprakenListAdapter bezoekverslagAfsprakenListAdapter;
	Database db = new Database(this);
	ArrayList<Afspraak> afspraken;
	static final int DATE_DIALOG_ID = 0;
	int myYear, myDay, myMonth;
	public static Bezoekverslag chosenBezoekverslag;
	int chosenBezoekverslagPosition = 0;
	int i;
	ImageView ivHandtekening;
	int chosenAfspraak = 0;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_bezoekverslagafspraken);
		
		
		((RadioGroup) findViewById(R.id.rg_statusdocument)).setOnCheckedChangeListener(ToggleListener);
		
		Bundle extras = getIntent().getExtras();
		
		if(extras != null){
			chosenBezoekverslagPosition = (int)extras.getInt("chosenBezoekverslagPosition");
		}	
		chosenBezoekverslag = db.getBezoekverslag(chosenBezoekverslagPosition);
		
		afspraken = db.getAlleBezoekverslagAfspraken(chosenBezoekverslag.getBezoekverslagNr());
		
		tempDir = Environment.getExternalStorageDirectory() + "/" + getResources().getString(R.string.external_dir) + "/";
        prepareDirectory();
        current = count + ".png";
        mContent = (LinearLayout) findViewById(R.id.linearLayout);
        mSignature = new signature(this, null);
        mSignature.setBackgroundColor(Color.WHITE);
        mContent.addView(mSignature, LayoutParams.FILL_PARENT, LayoutParams.FILL_PARENT);
        mClear = (Button)findViewById(R.id.btn_handtekeningwissen);
        mGetSign = (Button)findViewById(R.id.getsign);
        mView = mContent;     
        addAfspraak = (Button)findViewById(R.id.btn_addafspraak);
        addAfspraak.setOnClickListener(this);	
        deleteAfspraak = (Button)findViewById(R.id.btn_deleteafspraak);	
        deleteAfspraak.setOnClickListener(this);
        deleteAfspraken = (Button)findViewById(R.id.btn_deleteafspraken);	 
		deleteAfspraken.setOnClickListener(this);
		concept = (ToggleButton)findViewById(R.id.tb_concept);	
        gereed = (ToggleButton)findViewById(R.id.tb_gereed);
        ivHandtekening = (ImageView)findViewById(R.id.iv_handtekening);
        gereedDatum = (EditText) findViewById(R.id.et_gereeddatum);
        gereedDatum.setOnClickListener(this);
		gereedDatum.setText(chosenBezoekverslag.getGereedDatum());
		
		mClear.setOnClickListener(new OnClickListener() 
        {         
            public void onClick(View v) 
            {
                Log.v("log_tag", "Panel Cleared");
                mSignature.clear();
                chosenBezoekverslag.setHandtekening(null);
        	    db.updateBezoekverslag(chosenBezoekverslag);
        	    ivHandtekening.setImageDrawable(null);
            }
        });

        mGetSign.setOnClickListener(new OnClickListener() 
        {         
            public void onClick(View v) 
            {
                Log.v("log_tag", "Panel Saved");
                mView.setDrawingCacheEnabled(true);
                mSignature.save(mView);
            }
        });
        
		Calendar cal = Calendar.getInstance();
        myYear = cal.get(Calendar.YEAR);
        myMonth = cal.get(Calendar.MONTH);
        myDay = cal.get(Calendar.DAY_OF_MONTH);
		
		//Get a reference to the listview
        listview = (ListView) findViewById(R.id.lv_afspraken);
        listview.setFocusableInTouchMode(true);
        //listview.setFocusable(true);
        bezoekverslagAfsprakenListAdapter = new BezoekverslagAfsprakenListAdapter(this, afspraken);
        
        //Create an adapter that feeds the data to the listview
        listview.setAdapter(bezoekverslagAfsprakenListAdapter);
        
        /*listview.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position,
					long id) {
				listview.setItemChecked(position, true);
				listview.performItemClick(view, position, id);
				chosenAfspraak = position;
			}
	     });*/
        	
		if(chosenBezoekverslag.getStatus() == null){
			//nothing
        }
		else if(chosenBezoekverslag.getStatus().equals("Gereed") == true){
        	gereed.setChecked(true);
        }
        else if(chosenBezoekverslag.getStatus().equals("Concept") == true){
        	concept.setChecked(true);
        }
		
		if(chosenBezoekverslag.getHandtekening() != null){
        	ByteArrayInputStream stream = new ByteArrayInputStream(chosenBezoekverslag.getHandtekening());
    	    Bitmap bp=BitmapFactory.decodeStream(stream);
    	       
    	    ivHandtekening.setImageBitmap(bp);
        }
		
		mGetSign.setEnabled(false);
	}
	
	DatePickerDialog.OnDateSetListener dateListener =  new DatePickerDialog.OnDateSetListener() {

        @Override
        public void onDateSet(DatePicker view, int year, int monthOfYear,
                int dayOfMonth) {
            myYear = year;
            myMonth = monthOfYear;
            myDay = dayOfMonth;
            myMonth = myMonth +1;
            bezoekverslagAfsprakenListAdapter.getItem(bezoekverslagAfsprakenListAdapter.globalPosition).setDatum(myDay +"-"+myMonth+"-"+myYear);
            bezoekverslagAfsprakenListAdapter.notifyDataSetChanged();
        }
 }; 

	 @Override
	    protected Dialog onCreateDialog(int id) {  
	        switch (id) {    
	        case DATE_DIALOG_ID:        
	            return new DatePickerDialog(this,dateListener,myYear, myMonth,myDay );    
	        }    
	        return null;
	    }
	
	@Override
	public void onDateSet(DatePicker view, int year, int monthOfYear,
			int dayOfMonth) {
		monthOfYear = monthOfYear + 1;
		gereedDatum.setText(dayOfMonth + "-"+monthOfYear+"-"+year);
		gereed.setChecked(true);
		concept.setChecked(false);
	}

	@Override
	public void onClick(View v) {
		if (v==addAfspraak) {
			Afspraak a = new Afspraak(0, null, null, null, chosenBezoekverslag.getBezoekverslagNr());
			
			db.addAfspraak(a);
			afspraken = db.getAlleBezoekverslagAfspraken(chosenBezoekverslag.getBezoekverslagNr());
			listview = (ListView) findViewById(R.id.lv_afspraken);        
			bezoekverslagAfsprakenListAdapter = new BezoekverslagAfsprakenListAdapter(this, afspraken);
		    listview.setAdapter(bezoekverslagAfsprakenListAdapter);
		}		
		else if(v==deleteAfspraak) {
			if(db.getAlleBezoekverslagAfspraken(chosenBezoekverslag.getBezoekverslagNr()).isEmpty() == false){
				db.deleteAfspraak(db.getAfspraak(db.getMaxAfspraak(chosenBezoekverslag.getBezoekverslagNr())));
				//db.deleteAfspraak(afspraken.get(chosenAfspraak));
				afspraken = db.getAlleBezoekverslagAfspraken(chosenBezoekverslag.getBezoekverslagNr());
				listview = (ListView) findViewById(R.id.lv_afspraken);        
				bezoekverslagAfsprakenListAdapter = new BezoekverslagAfsprakenListAdapter(this, afspraken);
			    listview.setAdapter(bezoekverslagAfsprakenListAdapter);
			}

		}
		else if(v==deleteAfspraken){
			for(Afspraak a : db.getAlleBezoekverslagAfspraken(chosenBezoekverslag.getBezoekverslagNr())){
				db.deleteAfspraak(a);
			}
			afspraken = db.getAlleBezoekverslagAfspraken(chosenBezoekverslag.getBezoekverslagNr());
			listview = (ListView) findViewById(R.id.lv_afspraken);        
			bezoekverslagAfsprakenListAdapter = new BezoekverslagAfsprakenListAdapter(this, afspraken);
		    listview.setAdapter(bezoekverslagAfsprakenListAdapter);
			
		}
		else if(v==gereedDatum){
			Calendar c = Calendar.getInstance();
            int mYear = c.get(Calendar.YEAR);
            int mMonth = c.get(Calendar.MONTH);
            int mDay = c.get(Calendar.DAY_OF_MONTH);
			DatePickerDialog dialog = new DatePickerDialog(this, this, mYear, mMonth, mDay);
			dialog.show();
		}
	}
	
	public void onToggle(View view) {
	    ((RadioGroup)view.getParent()).check(view.getId());
	}
	
	static final RadioGroup.OnCheckedChangeListener ToggleListener = new RadioGroup.OnCheckedChangeListener() {
		@Override
		public void onCheckedChanged(final RadioGroup radioGroup, final int i) {
	        for (int j = 0; j < radioGroup.getChildCount(); j++) {
	            final ToggleButton view = (ToggleButton) radioGroup.getChildAt(j);
	            view.setChecked(view.getId() == i);
	            
	            if(view.getId() == i && view.getText().equals("Gereed")){
	            	Calendar c = Calendar.getInstance();
	                int mYear = c.get(Calendar.YEAR);
	                int mMonth = c.get(Calendar.MONTH);
	                int mDay = c.get(Calendar.DAY_OF_MONTH);
	                mMonth = mMonth +1;
	        		gereedDatum.setText(mDay+"-"+mMonth+"-"+mYear);
	            }
	            else{
	            	gereedDatum.setText(null);
	            }
	        }
		}
	};

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.verslag, menu);
		return true;
	}

	private boolean prepareDirectory() 
    {
        try 
        {
            if (makedirs()) 
            {
                return true;
            } else {
                return false;
            }
        } catch (Exception e) 
        {
            e.printStackTrace();
            Toast.makeText(this, "Could not initiate File System.. Is Sdcard mounted properly?", 1000).show();
            return false;
        }
    }

    private boolean makedirs() 
    {
        File tempdir = new File(tempDir);
        if (!tempdir.exists())
            tempdir.mkdirs();

        if (tempdir.isDirectory()) 
        {
            File[] files = tempdir.listFiles();
            for (File file : files) 
            {
                if (!file.delete()) 
                {
                    System.out.println("Failed to delete " + file);
                }
            }
        }
        return (tempdir.isDirectory());
    }

    public class signature extends View 
    {
        private static final float STROKE_WIDTH = 5f;
        private static final float HALF_STROKE_WIDTH = STROKE_WIDTH / 2;
        private Paint paint = new Paint();
        private Path path = new Path();

        private float lastTouchX;
        private float lastTouchY;
        private final RectF dirtyRect = new RectF();

        public signature(Context context, AttributeSet attrs) 
        {
             super(context, attrs);
             paint.setAntiAlias(true);
             paint.setColor(Color.BLUE);
             paint.setStyle(Paint.Style.STROKE);
             paint.setStrokeJoin(Paint.Join.ROUND);
             paint.setStrokeWidth(STROKE_WIDTH);
        }

        public void save(View v) 
        {
            Log.v("log_tag", "Width: " + v.getWidth());
            Log.v("log_tag", "Height: " + v.getHeight());
            if(mBitmap == null)
            {
                mBitmap =  Bitmap.createBitmap (mContent.getWidth(), mContent.getHeight(), Bitmap.Config.RGB_565);
            }
            Canvas canvas = new Canvas(mBitmap);
            String FtoSave = tempDir + current;
            File file = new File(FtoSave);
            try 
            {
                FileOutputStream mFileOutStream = new FileOutputStream(file);
                v.draw(canvas); 
                mBitmap.compress(Bitmap.CompressFormat.PNG, 90, mFileOutStream); 
                mFileOutStream.flush();
                mFileOutStream.close();
                String url = Images.Media.insertImage(getContentResolver(), mBitmap, "title", null);
                Log.v("log_tag","url" + url);
            }
            catch(Exception e) 
            { 
                Log.v("log_tag", e.toString()); 
            } 
        }

        public void clear() 
        {
             path.reset();
             invalidate();
        }

        @Override
        protected void onDraw(Canvas canvas) 
        {
             canvas.drawPath(path, paint);
        }

        @Override
        public boolean onTouchEvent(MotionEvent event) 
        {
             float eventX = event.getX();
             float eventY = event.getY();

             switch (event.getAction()) 
             {
               case MotionEvent.ACTION_DOWN:
                     path.moveTo(eventX, eventY);
                     lastTouchX = eventX;
                     lastTouchY = eventY;
                     return true;

               case MotionEvent.ACTION_MOVE:

               case MotionEvent.ACTION_UP:
                     resetDirtyRect(eventX, eventY);
                     int historySize = event.getHistorySize();
                     for (int i = 0; i < historySize; i++) 
                     {
                           float historicalX = event.getHistoricalX(i);
                           float historicalY = event.getHistoricalY(i);
                           expandDirtyRect(historicalX, historicalY);
                           path.lineTo(historicalX, historicalY);
                     }
                     path.lineTo(eventX, eventY);
                     break;

               default:
                     debug("Ignored touch event: " + event.toString());
                     return false;
             }

             invalidate((int) (dirtyRect.left - HALF_STROKE_WIDTH),
                 (int) (dirtyRect.top - HALF_STROKE_WIDTH),
                 (int) (dirtyRect.right + HALF_STROKE_WIDTH),
                 (int) (dirtyRect.bottom + HALF_STROKE_WIDTH));

             lastTouchX = eventX;
             lastTouchY = eventY;

             return true;
        }

        private void debug(String string) 
        {
        }

        private void expandDirtyRect(float historicalX, float historicalY) 
        {
             if (historicalX < dirtyRect.left) 
             {
               dirtyRect.left = historicalX;
             } 
             else if (historicalX > dirtyRect.right) 
             {
               dirtyRect.right = historicalX;
             }

             if (historicalY < dirtyRect.top) 
             {
               dirtyRect.top = historicalY;
             } 
             else if (historicalY > dirtyRect.bottom) 
             {
               dirtyRect.bottom = historicalY;
             }
        }

        private void resetDirtyRect(float eventX, float eventY) 
        {
             dirtyRect.left = Math.min(lastTouchX, eventX);
             dirtyRect.right = Math.max(lastTouchX, eventX);
             dirtyRect.top = Math.min(lastTouchY, eventY);
             dirtyRect.bottom = Math.max(lastTouchY, eventY);
        }
        
        private float getLastTouchX(){
        	return lastTouchX;
        }
    }//signature	
    
    @Override
	protected void onDestroy() {
	    super.onDestroy();
	    db.close();
	}
    
    @Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
	    if ((keyCode == KeyEvent.KEYCODE_BACK)) {
	    	if(gereed.isChecked()==true){
	    		chosenBezoekverslag.setStatus(gereed.getText().toString());
	    		chosenBezoekverslag.setGereedDatum(gereedDatum.getText().toString());
	    	}
	    	else if(concept.isChecked()==true){
	    		chosenBezoekverslag.setStatus(concept.getText().toString());
	    		chosenBezoekverslag.setGereedDatum(null);
	    	}
	    	else{
	    		chosenBezoekverslag.setStatus(null);
	    		chosenBezoekverslag.setGereedDatum(null);
	    	}
	    	
	    	if(mSignature.getLastTouchX() != 0 && ivHandtekening.getDrawable() == null){
	    		//Save Signature to bitmap
	    		mBitmap =  Bitmap.createBitmap (mContent.getWidth(), mContent.getHeight(), Bitmap.Config.RGB_565);;
			    Canvas canvas = new Canvas(mBitmap);
			    mSignature.draw(canvas);
			    ByteArrayOutputStream stream = new ByteArrayOutputStream();
			    mBitmap.compress(Bitmap.CompressFormat.PNG, 100, stream); 
			    byte[] bitmapdata = stream.toByteArray();
			    chosenBezoekverslag.setHandtekening(bitmapdata);
		    }
	    	
	    	for(Afspraak a : afspraken){
	    		//if(db.getAlleAfspraken().contains(a)){
	    			db.updateAfspraak(a);
	    		//}
	    		//else{
	    		//	db.addAfspraak(a);
	    		//}
	    	}
	    	
	    	chosenBezoekverslag.setAfspraken(afspraken);
	    	
	    	db.updateBezoekverslag(chosenBezoekverslag);
	    	
	    	Intent intent = new Intent(this, BezoekverslagDetailsActivity.class);
	    	intent.putExtra("chosenBezoekverslagPosition", chosenBezoekverslag.getBezoekverslagNr() -1);
			startActivity(intent);
	    } 
	    return super.onKeyDown(keyCode, event);
	}
}
