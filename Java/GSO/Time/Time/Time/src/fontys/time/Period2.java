/**
 *
 * @author Simon_van_Amstel
 */
package fontys.time;

public class Period2 implements IPeriod
{
    private ITime beginTijd;
    private long duur;
    private ITime eindTijd;

    @Override
    public ITime getBeginTime() 
    {
        return beginTijd;
    }

    @Override
    public ITime getEndTime() 
    {
        return eindTijd;
    }

    @Override
    public int getLength() 
    {
        return (int) duur;
    }

    @Override
    public void setBeginTime(ITime beginTime)
    {
        this.beginTijd = beginTime;
    }

    @Override
    public void setEndTime(ITime endTime) 
    {
         this.eindTijd = endTime;
    }

    @Override
    public void move(int minutes) 
    {
        eindTijd.plus(minutes);
        beginTijd.plus(minutes);
    }

    @Override
    public void changeLengthWith(int minutes)
    {
        if (minutes > 0)
        {
            eindTijd.plus(minutes);
        }
        else
        {
            System.out.println("Input cannot be negative");
        }
    }

    @Override
    public boolean isPartOf(IPeriod period) 
    {
        if(this.beginTijd.compareTo(period.getBeginTime()) > 0 && this.eindTijd.compareTo(period.getEndTime()) < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    @Override
    public IPeriod unionWith(IPeriod period) 
    {
        //als de periodes overlappen
        if(period.getEndTime().compareTo(this.beginTijd) >= 0 || period.getBeginTime().compareTo(this.eindTijd) <= 0)
        {
            if(period.isPartOf(this))
            {
                return period;
            }
        
            else if (this.isPartOf(period))
            {
                return this;
            }
            else if (this.beginTijd.compareTo(period.getEndTime()) <= 0)
            {
                Period p = new Period(period.getEndTime().difference(this.beginTijd));
                p.setBeginTime(this.beginTijd);
                p.setEndTime(period.getEndTime());
                return p;
            }
            else if (period.getBeginTime().compareTo(this.eindTijd) <= 0)
            {
                Period p = new Period(this.getEndTime().difference(period.getBeginTime()));
                p.setBeginTime(period.getBeginTime());
                p.setEndTime(this.eindTijd);
                return p;
            }
        }

        //als er geen overlap is
        return null;
    }

    @Override
    public IPeriod intersectionWith(IPeriod period) 
    {
        //als de periodes overlappen
        if(period.getEndTime().compareTo(this.beginTijd) >= 0 || period.getBeginTime().compareTo(this.eindTijd) <= 0)
        {
            if(period.isPartOf(this))
            {
                return this;
            }
        
            else if (this.isPartOf(period))
            {
                return period;
            }
                else if (this.beginTijd.compareTo(period.getEndTime()) <= 0)
            {
                Period p = new Period(period.getEndTime().difference(this.beginTijd));
                p.setBeginTime(period.getBeginTime());
                p.setEndTime(this.eindTijd);
                return p;
            }
            else if (period.getBeginTime().compareTo(this.eindTijd) <= 0)
            {
                Period p = new Period(this.getEndTime().difference(period.getBeginTime()));
                p.setBeginTime(this.beginTijd);
                p.setEndTime(period.getEndTime());
                return p;
            }
        }

        //als er geen overlap is
        return null;
    }
}
