/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.awt.Rectangle;
import java.io.Serializable;
import java.util.Date;
import pixel.shared.enums.EffectType;

/**
 *
 * @author Remi_Arts
 */
public class BewerkteFoto extends Foto implements Serializable {

    private static final long serialVersionUID = 7573017448423518259L;
    private int fotoBewerktNummer;
    private Rectangle cropRect;
    private Date bewerktDatum;

    public Date getBewerktDatum() {
        return bewerktDatum;
    }

    public void setCropRect(Rectangle cropRect) {
        this.cropRect = cropRect;
    }

    public void setEffectType(EffectType effectType) {
        this.effectType = effectType;
    }

    public Rectangle getCropRect() {
        return cropRect;
    }

    /**
     * 
     * @return 
     */
    public EffectType getEffectType() {
        return effectType;
    }
    
    private EffectType effectType;
    
    /**
     * 
     * @param effectType 
     */
    public void setFotoType(EffectType effectType) {
        this.effectType = effectType;
    }
    
    /**
     * 
     * @return 
     */
    public int getFotoBewerktNummer() {
        return fotoBewerktNummer;
    }

    /**
     * 
     * @param fotoBewerktNummer 
     */
    public void setFotoBewerktNummer(int fotoKlantNummer) {
        this.fotoBewerktNummer = fotoKlantNummer;
    }
    
   

    /**
     *
     * @param extensie
     */
    public BewerkteFoto(String extensie) {
        super(extensie);
    }

    /**
     *
     * @param fotoNummer
     */
    public BewerkteFoto(int fotoNummer, int fotoBewerktNummer, int x1, int y1, int x2, int y2, EffectType type, Date bewerktDatum) {
        super(fotoNummer);
        this.cropRect = new Rectangle(x1, y1, x2, y2);
        this.effectType = type;
        this.fotoBewerktNummer = fotoBewerktNummer;
        this.bewerktDatum = bewerktDatum;
    }
    
    /**
     * 
     * @param fotoNummer 
     */
    public BewerkteFoto(int fotoNummer) {
        super(fotoNummer);
    }
}


