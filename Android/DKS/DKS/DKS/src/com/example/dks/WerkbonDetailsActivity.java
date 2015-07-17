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
import android.text.method.PasswordTransformationMethod;
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
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

public class WerkbonDetailsActivity extends Activity implements OnClickListener, OnDateSetListener{

	public static Werkbon chosenWorkorder;
	TextView projnaam, projNr, titel, debNr, debnaam, telNr, contact, weekNr;
	TextView startDatum, uren, straat, plaats, postcode, huisnummer;
	ToggleButton nietuitvoerbaar, inuitvoering, gereed;
	Button mClear,mGetSign;
	LinearLayout mContent;
    signature mSignature;
    public static String tempDir;
    public int count = 1;
    public String current = null;
    private Bitmap mBitmap;
    View mView;
    static EditText gereedDatum;
	EditText opmerkingen, extraOpmerkingen;
    Database db = new Database(this);
    int chosenWorkorderposition = 0;
    static String status;
    RadioGroup group;
    Paint paintBlue;
    Canvas can;
    ImageView ivHantekening;
    
    @Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_werkbondetails);
		
		((RadioGroup) findViewById(R.id.rg_toggle)).setOnCheckedChangeListener(ToggleListener);
		
		Bundle extras = getIntent().getExtras();
		
		if (extras != null) {
			chosenWorkorderposition = (int)extras.getInt("chosenWorkorderposition");
		}	
		chosenWorkorder = db.getWerkbon(chosenWorkorderposition + 1);
		
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
        ivHantekening = (ImageView)findViewById(R.id.iv_handtekening);	
        projnaam = (TextView)findViewById(R.id.tv_projectnaam);
		projnaam.setText(chosenWorkorder.getProjectnaam());
		projNr = (TextView)findViewById(R.id.tv_projectnr);
		projNr.setText(String.valueOf(chosenWorkorder.getProjectnummer()));
		titel = (TextView)findViewById(R.id.tv_werkbon); 
		titel.setText("Werkbon "+String.valueOf(chosenWorkorder.getWerkbonNr()));
		debNr = (TextView)findViewById(R.id.tv_debnr); 
		debNr.setText(String.valueOf(chosenWorkorder.getDebiteurnummer()));
		debnaam = (TextView)findViewById(R.id.tv_debiteurnaam); 
		debnaam.setText(chosenWorkorder.getDebiteurnaam());
		telNr = (TextView)findViewById(R.id.tv_telefoonNr); 
		telNr.setText(chosenWorkorder.getTelefoonnummer());
		contact = (TextView)findViewById(R.id.tv_contactpers); 
		contact.setText(chosenWorkorder.getContactpersoon());
		weekNr = (TextView)findViewById(R.id.tv_week); 
		weekNr.setText(String.valueOf(chosenWorkorder.getWeeknummer()));
		startDatum = (TextView)findViewById(R.id.tv_startdatum); 
		startDatum.setText(chosenWorkorder.getStartDatum());
		uren = (TextView)findViewById(R.id.tv_uren); 
		uren.setText(String.valueOf(chosenWorkorder.getUren()));
		straat = (TextView)findViewById(R.id.tv_straat); 
		straat.setText(chosenWorkorder.getStraat());
		plaats = (TextView)findViewById(R.id.tv_plaats); 
		plaats.setText(chosenWorkorder.getPlaats());
		postcode = (TextView)findViewById(R.id.tv_postcode); 
		postcode.setText(chosenWorkorder.getPostcode());
		huisnummer = (TextView)findViewById(R.id.tv_huisnummer); 
		huisnummer.setText(chosenWorkorder.getHuisnummer());	
		gereedDatum = (EditText) findViewById(R.id.et_gereeddatum);
        gereedDatum.setOnClickListener(this);
        gereedDatum.setText(chosenWorkorder.getGereedDatum());
        opmerkingen = (EditText) findViewById(R.id.et_opmerkingen);
        opmerkingen.setText(chosenWorkorder.getOpmerkingen());
        extraOpmerkingen = (EditText) findViewById(R.id.et_extraOpmerking);
        extraOpmerkingen.setText(chosenWorkorder.getExtraOpmerking());
        gereed = (ToggleButton) findViewById(R.id.tb_gereed);
        inuitvoering = (ToggleButton) findViewById(R.id.tb_inuitvoering);
        nietuitvoerbaar = (ToggleButton) findViewById(R.id.tb_nietuitvoerbaar);
        
        mClear.setOnClickListener(new OnClickListener() 
        {         
            public void onClick(View v) 
            {
                Log.v("log_tag", "Panel Cleared");
                mSignature.clear();
                chosenWorkorder.setHandtekening(null);
        	    db.updateWerkbon(chosenWorkorder);
        	    ivHantekening.setImageDrawable(null);
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

        
        if(chosenWorkorder.getStatus() == null){
        	//nothing
        }
        else if(chosenWorkorder.getStatus().equals("Gereed") == true){
        	gereed.setChecked(true);
        }
        else if(chosenWorkorder.getStatus().equals("In uitvoering") == true){
        	inuitvoering.setChecked(true);
        }
        else if(chosenWorkorder.getStatus().equals("Niet uitvoerbaar") == true){
        	nietuitvoerbaar.setChecked(true);
        }
        
        //Adding Signature from database
        if(chosenWorkorder.getHandtekening() != null){
        	ByteArrayInputStream stream = new ByteArrayInputStream(chosenWorkorder.getHandtekening());
    	    Bitmap bp=BitmapFactory.decodeStream(stream);
    	    
    	    ivHantekening.setImageBitmap(bp);

        }
        
        mGetSign.setEnabled(false);;
	}
    
	@Override
	public void onDateSet(DatePicker view, int year, int monthOfYear,
			int dayOfMonth) {
		monthOfYear = monthOfYear + 1;
		gereedDatum.setText(dayOfMonth + "-"+monthOfYear+"-"+year);
		gereed.setChecked(true);
		nietuitvoerbaar.setChecked(false);
		inuitvoering.setChecked(false);
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
		getMenuInflater().inflate(R.menu.main, menu);
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
		    	chosenWorkorder.setStatus((String)gereed.getText());
		    	chosenWorkorder.setGereedDatum(gereedDatum.getText().toString());
		    }
		    else if(inuitvoering.isChecked()==true){
		    	chosenWorkorder.setStatus((String)inuitvoering.getText());
		    	chosenWorkorder.setGereedDatum(null);
		    }
		    else if(nietuitvoerbaar.isChecked()==true){
		    	chosenWorkorder.setStatus((String)nietuitvoerbaar.getText());
		    	chosenWorkorder.setGereedDatum(null);
		    }
		    else{
		    	chosenWorkorder.setStatus(null);
		    	chosenWorkorder.setGereedDatum(null);
		    }
		    
		    chosenWorkorder.setOpmerkingen(opmerkingen.getText().toString());
		    chosenWorkorder.setExtraOpmerking(extraOpmerkingen.getText().toString());
		    
		    if(mSignature.getLastTouchX() != 0 && ivHantekening.getDrawable() == null){
		    	//Save Signature to bitmap
			    mBitmap =  Bitmap.createBitmap (mContent.getWidth(), mContent.getHeight(), Bitmap.Config.RGB_565);;
			    Canvas canvas = new Canvas(mBitmap);
			    mSignature.draw(canvas);
			    ByteArrayOutputStream stream = new ByteArrayOutputStream();
			    mBitmap.compress(Bitmap.CompressFormat.PNG, 100, stream); 
			    byte[] bitmapdata = stream.toByteArray();
			    chosenWorkorder.setHandtekening(bitmapdata);
		    }
		     
		    db.updateWerkbon(chosenWorkorder);
	    	
	    	Intent intent = new Intent(this, WerkbonListActivity.class);
			startActivity(intent);
	    }
	    return super.onKeyDown(keyCode, event);
	}
}
