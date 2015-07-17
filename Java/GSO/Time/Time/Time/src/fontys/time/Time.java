/**
 *
 * @author Luc Martens
 */

package fontys.time;

import java.util.GregorianCalendar;

public class Time implements ITime { 
    
    GregorianCalendar calendar;
    
    /**
    * creation of a Time-object with year y, month m, day d, hours h and
    * minutes m; if the combination of y-m-d refers to a non-existing date 
    * a correct value of this Time-object will be not guaranteed 
    * @param y
    * @param m 1≤m≤12
    * @param d 1≤d≤31
    * @param h 0≤h≤23
    * @param min 0≤m≤59
    */
    public Time(int y, int m, int d, int h, int min)
    {
        calendar = new GregorianCalendar(y, m, d, h, min);
    }
    
    @Override
    public int getYear() {
        return calendar.get(GregorianCalendar.YEAR);
    }

    @Override
    public int getMonth() {
        return calendar.get(GregorianCalendar.MONTH);
    }

    @Override
    public int getDay() {
        return calendar.get(GregorianCalendar.DAY_OF_MONTH);
    }

    @Override
    public int getHours() {
        return calendar.get(GregorianCalendar.HOUR_OF_DAY);
    }

    @Override
    public int getMinutes() {
        return calendar.get(GregorianCalendar.MINUTE);
    }

    @Override
    public DayInWeek getDayInWeek() {
        DayInWeek[ ] dayInWeek = DayInWeek.values();
        return dayInWeek[calendar.get(GregorianCalendar.DAY_OF_WEEK)];
    }

    @Override
    public ITime plus(int minutes) {
        calendar.add(GregorianCalendar.MINUTE, minutes);
        return this;
    }

    @Override
    public int difference(ITime time) {
       GregorianCalendar c = new GregorianCalendar(time.getYear(), time.getMonth() , time.getDay(), time.getHours(), time.getMinutes());
       int result = (int)((this.calendar.getTimeInMillis() - c.getTimeInMillis())/60000);
       return result;
    }

    @Override
    public int compareTo(ITime o) {
        GregorianCalendar c = new GregorianCalendar(o.getYear(), o.getMonth() , o.getDay(), o.getHours(), o.getMinutes());
        
        return this.calendar.compareTo(c);
    }
}
