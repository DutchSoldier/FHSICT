package PTS31_Server;

import fontys.observer.BasicPublisher;
import java.awt.Color;
import java.awt.geom.Point2D;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.ConcurrentModificationException;
import java.util.logging.Logger;

/**
 *
 * @author Remi_Arts
 */
public class Wedstrijd {
    private ArrayList<Speler> spelers;
   
    private Level level;
    private Boolean afgelopen;
    private Puck puck;
    private int rondes;
    private double delay;    
    private Thread loop;
    private BasicPublisher bp;
    public int[] direction = {0, 0, 0};
    private JoinableSpel gamelobby;
    private DatabaseKoppeling dbk;
    private boolean collisionHappened = false;
    

    public Puck getPuck() {
        return puck;
    }

    public ArrayList<Speler> getSpelers() {
        return spelers;
    }
    
    public boolean CPUOnly() {
        boolean AllCPU = true;
        for (Speler s : spelers) {
            if(!(s instanceof CPU)) {
                AllCPU = false;
            }
        }
        return AllCPU;
    }

    public Level getLevel() {
       return level;
    }
    
    public int getRondes()  {
        return rondes;
    }
    
    public Boolean isAfgelopen(){
        return afgelopen;
    }
    
    public Wedstrijd(ArrayList<Gebruiker> spelers, BasicPublisher bp, JoinableSpel gamelobby) {
        try {
            dbk = new DatabaseKoppeling(null);
        } catch (RemoteException ex) {
            Logger.getLogger(Wedstrijd.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        rondes = Constanten.AANTAL_RONDES;
        afgelopen = false;
        level = new Level();
        this.bp = bp;
        this.gamelobby = gamelobby;
        
        this.spelers = new ArrayList<>();
        for (int i = 0; i < spelers.size(); i++ ) {
            Gebruiker g = spelers.get(i);
            Color c;
            if (i == 0) {
                c = Color.RED;
            } else if (i == 1) {
                c = Color.BLUE;
            } else {
                c = Color.GREEN;
            }
            if (g instanceof CPU) {
                this.spelers.add(new CPU(g.getNaam(), g.rating, level.getEdges().get(6+i), c));
            }
            else {
                this.spelers.add(i, new Speler(g.getNaam(), g.rating, level.getEdges().get(6+i), c)); 
            }
        }

        spawnPuck();
        startLoop();
        
    }
    
    public void startLoop() {
        loop = new Thread() {
            @Override
            public void run() {
                GameLoop();
            }
        };
        loop.start();
    }
    
    private void GameLoop() {
        while(!afgelopen) {
            update();
            try {loop.sleep(1000/Constanten.TARGET_FPS);} catch(Exception e) {}
        }
    }
    
    public void update() {        
        //if true, puck is gespawned
        /*Point2D oldPuckLocation = puck.getPositie();
        ArrayList<Point2D> oldPlayerLocations = new ArrayList();
        for (Speler s : spelers) {
            oldPlayerLocations.add(s.getPositie());
        }*/
        if (delay > 50) {
            Edge inGoal = puck.bewegen();
            if(inGoal != null) {
                if (puck.getLastSpeler() != null && inGoal != puck.getLastSpeler().getGoal()) {
                    rondes--;
                    puck.getLastSpeler().setScore(1);
                    new Thread(new dbupdater(1, puck.getLastSpeler().getNaam())).start();
                    Speler slechteKeeper = null;
                    for (Speler s : spelers) {
                        if(s.getGoal() == inGoal) {
                            slechteKeeper = s;
                        }
                    }
                    slechteKeeper.setScore(-1);
                    new Thread(new dbupdater(-1, slechteKeeper.getNaam())).start();
                    bp.inform(bp, "Scored", rondes, new int[] {spelers.get(0).getScore(), spelers.get(1).getScore(), spelers.get(2).getScore()});
                }
                spawnPuck();
            }
        }
              
        //cpu's bewegen
        for (int i = 0; i < 3; i++) {
            delay++;
            if (spelers.get(i) instanceof CPU) {
                CPU cpu = (CPU)spelers.get(i);
                cpu.volgPuck(puck, i);
            }
        }
        
        //beweging spelers
        for (int i = 0;i < 3;i++) {
            if(direction[i] != 0)
            {
                Speler s = spelers.get(i);
                if(s.bewegen(direction[i])) {
                    //Point middelpunt = new Point(s.getPositie().x - s.getRadius(), s.getPositie().y - s.getRadius());
                }
            }
        }
            
        //einde spel
        if(rondes == 0){
            eindeSpel();
        }
        
        //failsafe voor als de puck toch uit de driehoek weet te ontsnappen
        if (puck.getPositie().x < 0 || puck.getPositie().x > 1000 || puck.getPositie().y < 0 || puck.getPositie().y > 1000)
        {
            spawnPuck();
        }
        try {
            bp.inform(bp, "Puck", /*oldPuckLocation*/collisionHappened, puck.getPositie());
            Speler spelertje = puck.getLastSpeler();
            int lastspelerint = 3;
            if(spelertje != null) {
                lastspelerint = spelers.indexOf(spelertje);
            }
            bp.inform(bp, "Glow", null, lastspelerint);
            ArrayList<Point2D> newPlayerLocations = new ArrayList();
            for (Speler s : spelers) {
                newPlayerLocations.add(s.getPositie());
            }
            bp.inform(bp, "Speler", /*oldPlayerLocations*/null, newPlayerLocations);
        } catch (ConcurrentModificationException cme) {}
    }
    
    private void spawnPuck() {
        delay = 0;
        puck =  new Puck(Constanten.PUCK_SNELHEID , Math.random()*2, this);
    }

    private void eindeSpel()
    {
        afgelopen = true;
        gamelobby.EndGame();
    }

    void swapPlayerWithCPU(int spelerId) {
        new Thread(new dbupdater(-10, spelers.get(spelerId).getNaam())).start();
        spelers.set(spelerId, new CPU("CPU" + spelerId, 0, spelers.get(spelerId).getGoal(), spelers.get(spelerId).getHue()));
    }
    
    public void changeCollisionHappened(boolean b)
    {
        collisionHappened = b;
    }
    
    class dbupdater implements Runnable {
        private String speler;
        private int score;
        public dbupdater(int score, String speler) {
            this.score = score;
            this.speler = speler;
        }
        @Override
        public void run() {
            int i = dbk.getRating(speler) + score;
            if(i > 0) {
                dbk.setRating(speler, i);
            }
        }
    }
}
