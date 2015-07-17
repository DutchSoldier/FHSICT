package com.example.dks;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Calendar;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.DatePickerDialog.OnDateSetListener;
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
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.LinearLayout.LayoutParams;
import android.widget.RadioGroup;
import android.widget.Toast;
import android.widget.ToggleButton;

public class KwaliteitsverslagAfsprakenActivity extends Activity implements OnClickListener, OnDateSetListener{

	ToggleButton concept, gereed;
	Button vClear,vGetSign, oClear,oGetSign;
	LinearLayout vContent, oContent;
    signature vSignature, oSignature;
    public static String tempDir;
    public int count = 1;
    public String current = null;
    private Bitmap Bmap;
    View vView, oView;
    static EditText gereedDatum;
	EditText opmerkingen;
	Database db = new Database(this);
	public static Kwaliteitsverslag chosenKwaliteitsverslag;
	int chosenKwaliteitsverslagPosition = 0;
	ImageView ivViHandtekening, ivOpHandtekening;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_kwaliteitsverslag_afspraken);
		
		((RadioGroup) findViewById(R.id.rg_statusdocument)).setOnCheckedChangeListener(ToggleListener);
		
		Bundle extras = getIntent().getExtras();
        
        if (extras != null) {
			chosenKwaliteitsverslagPosition = (int)extras.getInt("chosenKwaliteitsverslagPosition");
		}	
		chosenKwaliteitsverslag = db.getKwaliteitsverslag(chosenKwaliteitsverslagPosition);
        
		tempDir = Environment.getExternalStorageDirectory() + "/" + getResources().getString(R.string.external_dir) + "/";
        prepareDirectory();
        current = count + ".png";
        vContent = (LinearLayout) findViewById(R.id.ll_visschedijk);
        oContent = (LinearLayout) findViewById(R.id.ll_opdrachtgever);
        vSignature = new signature(this, null);
        vSignature.setBackgroundColor(Color.WHITE);
        oSignature = new signature(this, null);
        oSignature.setBackgroundColor(Color.WHITE);
        vContent.addView(vSignature, LayoutParams.FILL_PARENT, LayoutParams.FILL_PARENT);
        oContent.addView(oSignature, LayoutParams.FILL_PARENT, LayoutParams.FILL_PARENT);
        vClear = (Button)findViewById(R.id.btn_handtekeningVisschedijkWissen);
        oClear = (Button)findViewById(R.id.btn_handtekeningOpdrachtgeverWissen);
        vGetSign = (Button)findViewById(R.id.btn_handtekeningVisschedijkVerkrijgen);
        oGetSign = (Button)findViewById(R.id.btn_handtekeningOpdrachtgeverVerkrijgen);
        vView = vContent;
        oView = oContent;
        gereedDatum = (EditText) findViewById(R.id.et_gereeddatum);
        gereedDatum.setOnClickListener(this);
        gereedDatum.setText(chosenKwaliteitsverslag.getGereedDatum());
        opmerkingen = (EditText) findViewById(R.id.et_opmerkingen);
        opmerkingen.setText(chosenKwaliteitsverslag.getOpmerkingen());
        concept = (ToggleButton) findViewById(R.id.tb_concept);
        gereed = (ToggleButton) findViewById(R.id.tb_gereed);
        ivViHandtekening = (ImageView) findViewById(R.id.iv_Vhandtekening);
        ivOpHandtekening = (ImageView) findViewById(R.id.iv_Ohandtekening);
        
		vClear.setOnClickListener(new OnClickListener() 
        {         
            public void onClick(View v) 
            {
                Log.v("log_tag", "Panel Cleared");
                vSignature.clear();
                chosenKwaliteitsverslag.setHandtekeningVisschedijk(null);
        	    db.updateKwaliteitsverslag(chosenKwaliteitsverslag);
        	    ivViHandtekening.setImageDrawable(null);
            }
        });
		oClear.setOnClickListener(new OnClickListener() 
        {         
            public void onClick(View v) 
            {
                Log.v("log_tag", "Panel Cleared");
                oSignature.clear();
                chosenKwaliteitsverslag.setHandtekeningOpdrachtgever(null);
        	    db.updateKwaliteitsverslag(chosenKwaliteitsverslag);
        	    ivOpHandtekening.setImageDrawable(null);
            }
        });
        vGetSign.setOnClickListener(new OnClickListener() 
        {         
            public void onClick(View v) 
            {
                Log.v("log_tag", "Panel Saved");
                vView.setDrawingCacheEnabled(true);
                vSignature.save(vView);
            }
        });
        oGetSign.setOnClickListener(new OnClickListener() 
        {         
            public void onClick(View v) 
            {
                Log.v("log_tag", "Panel Saved");
                oView.setDrawingCacheEnabled(true);
                oSignature.save(oView);
            }
        });
   
        if(chosenKwaliteitsverslag.getStatus() == null){
        	//nothing
        }
        else if(chosenKwaliteitsverslag.getStatus().equals("Gereed") == true){
        	gereed.setChecked(true);
        }
        else if(chosenKwaliteitsverslag.getStatus().equals("Concept") == true){
        	concept.setChecked(true);
        }
        
        if(chosenKwaliteitsverslag.getHandtekeningOpdrachtgever() != null){
        	ByteArrayInputStream stream = new ByteArrayInputStream(chosenKwaliteitsverslag.getHandtekeningOpdrachtgever());
    	    Bitmap bp=BitmapFactory.decodeStream(stream);
    	       
    	    ivOpHandtekening.setImageBitmap(bp);
        }
        
        if(chosenKwaliteitsverslag.getHandtekeningVisschedijk() != null){
        	ByteArrayInputStream stream = new ByteArrayInputStream(chosenKwaliteitsverslag.getHandtekeningVisschedijk());
    	    Bitmap bp=BitmapFactory.decodeStream(stream);

    	    ivViHandtekening.setImageBitmap(bp);
        }
        
        vGetSign.setEnabled(false);
        oGetSign.setEnabled(false);
	}
	
	@Override
	public void onClick(View v) {
		if(v==gereedDatum){
			Calendar c = Calendar.getInstance();
            int mYear = c.get(Calendar.YEAR);
            int mMonth = c.get(Calendar.MONTH);
            int mDay = c.get(Calendar.DAY_OF_MONTH);
			DatePickerDialog dialog = new DatePickerDialog(this, this, mYear, mMonth, mDay);
		    dialog.show();
		}
	}

	@Override
	public void onDateSet(DatePicker arg0, int year, int monthOfYear, int dayOfMonth) {
		monthOfYear = monthOfYear + 1;
		gereedDatum.setText(dayOfMonth + "-"+monthOfYear+"-"+year);
		gereed.setChecked(true);
		concept.setChecked(false);
	}
	
	public void onToggle(View view) {
	    ((RadioGroup)view.getParent()).check(view.getId());
	    // app specific stuff ..
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
            if(Bmap == null)
            {
                Bmap =  Bitmap.createBitmap (vContent.getWidth(), vContent.getHeight(), Bitmap.Config.RGB_565);;
            }
            Canvas canvas = new Canvas(Bmap);
            String FtoSave = tempDir + current;
            File file = new File(FtoSave);
            try 
            {
                FileOutputStream mFileOutStream = new FileOutputStream(file);
                v.draw(canvas); 
                Bmap.compress(Bitmap.CompressFormat.PNG, 90, mFileOutStream); 
                mFileOutStream.flush();
                mFileOutStream.close();
                String url = Images.Media.insertImage(getContentResolver(), Bmap, "title", null);
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
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.kwaliteitsverslag_afspraken, menu);
		return true;
	}
	
	@Override
	protected void onDestroy() {
	    super.onDestroy();
    	
	    db.close();
	}
	
    @Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
	    if ((keyCode == KeyEvent.KEYCODE_BACK)) {
	    	if(gereed.isChecked()==true){
	    		chosenKwaliteitsverslag.setStatus(gereed.getText().toString());
	    		chosenKwaliteitsverslag.setGereedDatum(gereedDatum.getText().toString());
	    	}
	    	else if(concept.isChecked()==true){
	    		chosenKwaliteitsverslag.setStatus(concept.getText().toString());
	    		chosenKwaliteitsverslag.setGereedDatum(null);
	    	}
	    	else{
	    		chosenKwaliteitsverslag.setStatus(null);
	    		chosenKwaliteitsverslag.setGereedDatum(null);
	    	}
	    	
	    	chosenKwaliteitsverslag.setOpmerkingen(opmerkingen.getText().toString());
	    	
	    	if(vSignature.getLastTouchX() != 0 && ivViHandtekening.getDrawable() == null){
	    		//Save Signature to bitmap
			    Bmap =  Bitmap.createBitmap (vContent.getWidth(), vContent.getHeight(), Bitmap.Config.RGB_565);;
			    Canvas canvas = new Canvas(Bmap);
			    vSignature.draw(canvas);
			    ByteArrayOutputStream stream = new ByteArrayOutputStream();
			    Bmap.compress(Bitmap.CompressFormat.PNG, 100, stream); 
			    byte[] bitmapdata = stream.toByteArray();
			    chosenKwaliteitsverslag.setHandtekeningVisschedijk(bitmapdata);
		    }
	    
	    	if(oSignature.getLastTouchX() != 0 && ivOpHandtekening.getDrawable() == null){
	    		//Save Signature to bitmap
	    		Bmap =  Bitmap.createBitmap (oContent.getWidth(), oContent.getHeight(), Bitmap.Config.RGB_565);;
			    Canvas canvas = new Canvas(Bmap);
			    oSignature.draw(canvas);
			    ByteArrayOutputStream stream = new ByteArrayOutputStream();
			    Bmap.compress(Bitmap.CompressFormat.PNG, 100, stream); 
			    byte[] bitmapdata = stream.toByteArray();
			    chosenKwaliteitsverslag.setHandtekeningOpdrachtgever(bitmapdata);
		    }
	    	
	    	db.updateKwaliteitsverslag(chosenKwaliteitsverslag);
	    	
	    	Intent intent = new Intent(this, KwaliteitsverslagDetailsActivity.class);
	    	intent.putExtra("chosenKwaliteitsverslagPosition", chosenKwaliteitsverslag.getKwaliteitsverslagNr() -1);
			startActivity(intent);
	    }
	    return super.onKeyDown(keyCode, event);
	}
}
