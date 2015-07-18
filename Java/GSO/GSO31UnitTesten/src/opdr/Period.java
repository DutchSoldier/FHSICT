/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package opdr;

import fontys.time.IPeriod;
import fontys.time.ITime;

/**
 *
 * @author Frank
 */
public class Period implements IPeriod {
    
    private ITime bt;
    
    private ITime et;
    
    /**
     * creation of a period with begin time bt and end time et
     * @param bt  begin time bt must be earlier than end time et
     * @param et 
     */
   public Period(ITime bt, ITime et) {
        int verschil = et.difference(bt);
        if (verschil > 0) {
            this.bt = bt;
            this.et = et;
        } else {
            throw new IllegalArgumentException("Eindtijd kan niet voor begintijd. De eindtijd kan ook niet gelijk zijn aan begintijd.");
        }
   }
    /**
     * 
     * @return the begin time of this period
     */
    @Override
    public ITime getBeginTime() {
        return this.bt;
    }

    /**
     * 
     * @return the end time of this period
     */
    @Override
    public ITime getEndTime() {
        return this.et;
    }

    /**
     * 
     * @return the length of this period expressed in minutes (always positive)
     */
    @Override
    public int length() {
        return this.et.difference(this.bt);
    }

    /**
     * beginTime will be the new begin time of this period
     * @param beginTime must be earlier than the current end time
     * of this period
     */
    @Override
    public void setBeginTime(ITime beginTime) {
        int verschil = this.et.difference(beginTime);
        if (verschil <= 0) {
            throw new IllegalArgumentException("Verschil mag niet 0 of kleiner zijn.");
        }
        this.bt = beginTime;
    }

    /**
     * endTime will be the new end time of this period
     * @param beginTime must be later than the current begin time
     * of this period
     */
    @Override
    public void setEndTime(ITime endTime) {
        int verschil = endTime.difference(this.bt);
        if (verschil <= 0) {
            throw new IllegalArgumentException("Verschil mag niet 0 of kleiner zijn.");
        }
        this.et = endTime;
    }

    /**
     * the begin and end time of this period will be moved up both with [minutes]
     * minutes
     * @param minutes (a negative value is allowed)
     */
    @Override
    public void move(int minutes) {
        if (minutes <= 0) {
            throw new IllegalArgumentException("Verschil mag niet 0 of kleiner zijn.");  
        }
        this.bt.plus(minutes);
        this.et.plus(minutes);
    }

    /**
     * the end time of this period will be moved up with [minutes] minutes
     * @param minutes  minutes + length of this period must be positive  
     */
    @Override
    public void changeLengthWith(int minutes) {
        et.plus(minutes);
    }

    /**
     * 
     * @param period
     * @return true if all moments within this period are included within [period], 
     * otherwise false
     */
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

    /**
     * 
     * @param period
     * @return if this period and [period] are consecutive or possess a
     * common intersection, then the smallest period p will be returned, 
     * for which this period and [period] are part of p, 
     * otherwise null will be returned 
     */
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
