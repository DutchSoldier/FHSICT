/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package opdr;

import fontys.time.DayInWeek;
import fontys.time.ITime;
import java.util.Calendar;
import java.util.GregorianCalendar;

/**
 *
 * @author Frank
 */
public class Time implements ITime {

    private GregorianCalendar calendar;

    /**
     * creation of a Time-object with year y, month m, day d, hours h and
     * minutes m; if the combination of y-m-d refers to a non-existing date 
     * a correct value of this Time-object will be not guaranteed 
     * @param y
     * @param m 1≤m≤12
     * @param d 1≤d≤31
     * @param h 0≤h≤23
     * @param m 0≤m≤59
     */
    public Time(int y, int m, int d, int h, int min) {
        this.calendar = new GregorianCalendar();
        this.calendar.set(y, m, d, h, min);
    }
    
    /**
     * 
     * @return the concerning year of this time
     */
    @Override
    public int getYear() {
        return this.calendar.get(Calendar.YEAR);
    }

    /**
     * 
     * @return the number of the month of this time (1..12)
     */
    @Override
    public int getMonth() {
        return this.calendar.get(Calendar.MONTH);
    }

    /**
     * 
     * @return the number of the day in the month of this time (1..31)
     */
    @Override
    public int getDay() {
        return this.calendar.get(Calendar.DAY_OF_MONTH);
    }

    /**
     * 
     * @return the number of hours in a day of this time (0..23)
     */
    @Override
    public int getHours() {
        return this.calendar.get(Calendar.HOUR_OF_DAY);
    }

    /**
     * 
     * @return the number of minutes in a hour of this time (0..59)
     */
    @Override
    public int getMinutes() {
        return this.calendar.get(Calendar.MINUTE);
    }
    
    /**
     * 
     * @return the concerning day in the week of this time
     */
    @Override
    public DayInWeek getDayInWeek() {
        switch(this.calendar.get(Calendar.DAY_OF_WEEK)) {
            case Calendar.SUNDAY:
                return DayInWeek.SUN;
            case Calendar.MONDAY:
                return DayInWeek.MON;
            case Calendar.TUESDAY:
                return DayInWeek.TUE;
            case Calendar.WEDNESDAY:
                return DayInWeek.WED;
            case Calendar.THURSDAY:
                return DayInWeek.THU;
            case Calendar.FRIDAY:
                return DayInWeek.FRI;
            case Calendar.SATURDAY:
                return DayInWeek.SAT;
        }
        return DayInWeek.WED;
    }

    /**
     * 
     * @param minutes (a negative value is allowed)
     * @return  this time plus minutes
     */
    @Override
    public ITime plus(int minutes) {
        if (minutes <= 0) {
            throw new IllegalArgumentException("Waarde 0 of kleiner niet toegestaan...");
        }
        return new Time(this.getYear(), this.getMonth(), this.getDay(), this.getHours(), this.getMinutes() + minutes);
    }

    /**
     * 
     * @param time
     * @return the difference between this time and [time] expressed in minutes
     */
    @Override
    public int difference(ITime time) {
        return this.getMinutes() - time.getMinutes();
    }

    @Override
    public int compareTo(ITime o) {
        if (o == null) {
            throw new IllegalArgumentException("Periode mag niet null zijn.");
        }
        GregorianCalendar gc = new GregorianCalendar();
        gc.set(o.getYear(), o.getMonth(), o.getDay(), o.getHours(), o.getMinutes());
        return this.calendar.compareTo(gc);
    }  
}
