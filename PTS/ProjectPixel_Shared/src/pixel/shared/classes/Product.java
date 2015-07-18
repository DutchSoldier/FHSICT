/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.awt.Image;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.Serializable;
/**
 *
 * @author Remi_Arts
 */
public class Product implements Serializable{
    private int productnummer;
    private String productnaam;
    private String productbeschrijving;
    private int voorraad;
    private double productprijs;
    private transient BufferedImage foto;
    private transient BufferedImage thumbnail;
    private byte[] bytes;

    /**
     *
     * @param bytes
     */
    public void setBytes(byte[] bytes) {
        this.bytes = bytes;
    }
    
    /**
     *
     * @return
     */
    public byte[] getBytes() {
        return bytes;
    }

    /**
     *
     * @return
     */
    public BufferedImage getFoto() {
        return foto;
    }

    /**
     *
     * @return
     */
    public int getProductnummer() {
        return productnummer;
    }

    /**
     *
     * @return
     */
    public String getProductnaam() {
        return productnaam;
    }

    /**
     *
     * @return
     */
    public String getProductbeschrijving() {
        return productbeschrijving;
    }

    /**
     *
     * @return
     */
    public int getVoorraad() {
        return voorraad;
    }

    /**
     *
     * @return
     */
    public double getProductprijs() {
        return productprijs;
    }
    
    /**
     * @param productnummer
     * @param productnaam
     * @param productbeschrijving
     * @param voorraad
     * @param productprijs 
     * @param foto
     */
    public Product(int productnummer, String productnaam, String productbeschrijving, int voorraad, double productprijs, byte[] foto){
        this.productbeschrijving = productbeschrijving;
        this.productnaam = productnaam;
        this.productnummer = productnummer;
        this.productprijs = productprijs;
        this.voorraad = voorraad;
        this.bytes = foto;

    }
    
    /**
     *
     * @param file
     * @return
     */
    public boolean fotoToByte(File file) {
        if (file.exists()) {
            try {
                FileInputStream fis = new FileInputStream(file);
                ByteArrayOutputStream bos = new ByteArrayOutputStream();

                byte[] buf = new byte[fis.available()]; // 1024
                for (int readNum; (readNum = fis.read(buf)) != -1;) {
                    bos.write(buf, 0, readNum);
                }
                bytes = bos.toByteArray();
                return true;

            } catch (IOException ex) {
                Logger.getLogger(Product.class.getName()).log(Level.SEVERE, null, ex);
                return false;
            }
        }
        return false;
    }
    
    /**
     *
     */
    public void byteToFoto() {
        try {
            System.out.println(bytes);
            foto = ImageIO.read(new ByteArrayInputStream(bytes));

        } catch (IOException ex) {
            Logger.getLogger(Product.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    /**
     *
     */
    public void genereerThumbnail() {
        int width = foto.getWidth();
        int height = foto.getHeight();

        if (width > height) {
            float extraSize = height - 100;
            float percentHeight = (extraSize / height) * 100;
            float percentWidth = width - ((width / 100) * percentHeight);
            BufferedImage img = new BufferedImage(100, 100, foto.getType());
            Image scaledImage = foto.getScaledInstance(100, 100, Image.SCALE_FAST);
            img.createGraphics().drawImage(scaledImage, 0, 0, null);
            BufferedImage img2 = new BufferedImage(100, (int) percentHeight, foto.getType());
            img2 = img.getSubimage(0, 0, 100, 100);
            thumbnail = img2;
        } else {
            float extraSize = width - 100;
            float percentWidth = (extraSize / width) * 100;
            float percentHeight = height - ((height / 100) * percentWidth);
            BufferedImage img = new BufferedImage(100, 100, foto.getType());
            Image scaledImage = foto.getScaledInstance(100, 100, Image.SCALE_FAST);
            img.createGraphics().drawImage(scaledImage, 0, 0, null);
            BufferedImage img2 = new BufferedImage(100, 100, foto.getType());
            img2 = img.getSubimage(0, 0, 100, 100);

            thumbnail = img2;
        }
    }
    
    /**
     *
     * @return
     */
    public BufferedImage getThumbnail() {
        return thumbnail;
    }
}
