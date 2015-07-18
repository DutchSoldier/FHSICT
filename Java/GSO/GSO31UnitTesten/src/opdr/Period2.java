/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package opdr;

import fontys.time.IPeriod;
import fontys.time.ITime;
import java.util.Calendar;
import java.util.GregorianCalendar;

/**
 *
 * @author Frank
 */
public class Period2 implements IPeriod {
    
    private ITime bt;
    
    private ITime et;
    
    private long periode;

    /**
     * creation of a period with begin time bt and end time et
     *
     * @param bt begin time bt must be earlier than end time et
     * @param periode
     */
    public Period2(ITime bt, long periode) {
        this.bt = bt;
        this.periode = periode;
        if (this.periode >= 0) {
            GregorianCalendar date = new GregorianCalendar(bt.getYear(), bt.getMonth(), bt.getDay(), bt.getHours(), bt.getMinutes());
            date.add(Calendar.MINUTE, (int)periode);
            this.et = new Time(date.get(Calendar.YEAR), date.get(Calendar.MONTH), date.get(Calendar.DAY_OF_MONTH), date.get(Calendar.HOUR_OF_DAY), date.get(Calendar.MINUTE));
        }
    }

    @Override
    public ITime getBeginTime() {
        return this.bt;
    }

    @Override
    public ITime getEndTime() {
        return this.et;
    }

    @Override
    public int length() {
        return this.et.difference(this.bt);
    }

    @Override
    public void setBeginTime(ITime beginTime) {
        int verschil = this.et.difference(beginTime);
        if (verschil <= 0) {
            throw new IllegalArgumentException("Verschil mag niet 0 of kleiner zijn.");
        }
        this.bt = beginTime;
    }

    @Override
    public void setEndTime(ITime endTime) {
        int verschil = endTime.difference(this.bt);
        if (verschil <= 0) {
            throw new IllegalArgumentException("Verschil mag niet 0 of kleiner zijn.");
        }
        this.et = endTime;
    }

    @Override
    public void move(int minutes) {
        if (minutes <= 0) {
            throw new IllegalArgumentException("Verschil mag niet 0 of kleiner zijn.");  
        }
        this.bt.plus(minutes);
        this.et.plus(minutes);
    }

    @Override
    public void changeLengthWith(int minutes) {
        et.plus(minutes);
    }

    @Override
    public boolean isPartOf(IPeriod period) {
        if (period == null) {
            throw new IllegalArgumentException("Periode mag niet null zijn.");
        }
        ITime beginTime = period.getBeginTime();
        ITime eindTime = period.getEndTime();
        if (beginTime.difference(this.getBeginTime()) >= 0) {
            if (eindTime.difference(this.getEndTime()) <= 0) {
                return true;
            }
        }
        return false;
    }

    @Override
    public IPeriod unionWith(IPeriod period) {
        if (period == null) {
            throw new IllegalArgumentException("Periode mag niet null zijn.");
        }
        ITime beginTime = period.getBeginTime();
        ITime endTime = period.getEndTime();
        IPeriod tempPeriod;
        if (endTime.difference(this.getBeginTime()) <= 0 || this.getEndTime().difference(beginTime) <= 0) {
            return null;
        } else if (this.getBeginTime().difference(beginTime) >= 0 && endTime.difference(this.getEndTime()) >= 0) {
            tempPeriod = new Period(beginTime, endTime);
            return tempPeriod;
        } else if (beginTime.difference(this.getBeginTime()) >= 0 && endTime.difference(this.getEndTime()) >= 0) {
            tempPeriod = new Period(this.getBeginTime(), endTime);
            return tempPeriod;
        } else if (beginTime.difference(this.getBeginTime()) >= 0 && this.getEndTime().difference(endTime) >= 0) {
            tempPeriod = new Period(this.getBeginTime(), this.getEndTime());
            return tempPeriod;
        } else if (this.getBeginTime().difference(beginTime) >= 0 && this.getEndTime().difference(endTime) >= 0) {
            tempPeriod = new Period(beginTime, this.getEndTime());
            return tempPeriod;
        }
        return null;
    }

    /**
     * 
     * @param period
     * @return the largest period which is part of this period 
     * and [period] will be returned; if the intersection is empty null will 
     * be returned
     */
    @Override
    public IPeriod intersectionWith(IPeriod period) {             
        if (period == null) {
            throw new IllegalArgumentException("Periode mag niet null zijn.");
        }
        ITime beginTime = period.getBeginTime();
        ITime endTime = period.getEndTime();
        IPeriod tempPeriod;
        if (endTime.difference(this.getBeginTime()) <= 0 || this.getEndTime().difference(beginTime) <= 0) {
            return null;
        } else if (this.getBeginTime().difference(beginTime) >= 0 && endTime.difference(this.getEndTime()) >= 0) {           
            tempPeriod = new Period(this.getBeginTime(), this.getEndTime());
            return tempPeriod;
        } else if (beginTime.difference(this.getBeginTime()) >= 0 && endTime.difference(this.getEndTime()) >= 0) {
            tempPeriod = new Period(beginTime, this.getEndTime());
            return tempPeriod;
        } else if (beginTime.difference(this.getBeginTime()) >= 0 && this.getEndTime().difference(endTime) >= 0) {
            tempPeriod = new Period(beginTime, endTime);
            return tempPeriod;
        } else if (this.getBeginTime().difference(beginTime) >= 0 && this.getEndTime().difference(endTime) >= 0) { 
            tempPeriod = new Period(this.getBeginTime(), endTime);
            return tempPeriod;
        }
        return null;
    }  
}
