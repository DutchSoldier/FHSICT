/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.Serializable;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.imageio.ImageIO;
import pixel.shared.enums.EffectType;

/**
 *
 * @author Luc
 */
public class Foto implements Serializable {

    // transient ervoor zetten zorgt ervoor dat dit niet met RMI wordt doorgestuurd.
    private transient BufferedImage foto;
    private transient BufferedImage thumbnail;
    private int fotoNummer;
    private FotoDetails details;
    private byte[] bytes;
    private String extensie;

    /**
     *
     * @return
     */
    public String getExtensie() {
        return extensie;
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
     * @param bytes
     */
    public void setBytes(byte[] bytes) {
        this.bytes = bytes;
    }
    
    /**
     *
     * @param value
     */
    public void setFotoNummer(int value) {
        this.fotoNummer = value;
    }

    /**
     *
     * @param extensie
     */
    public Foto(String extensie) {
        this.extensie = extensie;
    }

    /**
     *
     * @param fotoNummer
     */
    public Foto(int fotoNummer) {
        this.fotoNummer = fotoNummer;
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
                Logger.getLogger(Foto.class.getName()).log(Level.SEVERE, null, ex);
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
            /*ByteArrayInputStream bis = new ByteArrayInputStream(bytes);
             Iterator<?> readers = ImageIO.getImageReadersByFormatName("jpg");

             ImageReader reader = (ImageReader) readers.next();
             Object source = bis;

             ImageInputStream iis;
             iis = ImageIO.createImageInputStream(source);

             reader.setInput(iis, true);
             ImageReadParam param = reader.getDefaultReadParam();

             Image image = reader.read(0, param);
             foto = new BufferedImage(image.getWidth(null), image.getHeight(null), BufferedImage.TYPE_INT_RGB);
             Graphics2D g2 = foto.createGraphics();
             g2.drawImage(image, null, null);*/
            //System.out.println(bytes);
            foto = ImageIO.read(new ByteArrayInputStream(bytes));

        } catch (IOException ex) {
            Logger.getLogger(Foto.class.getName()).log(Level.SEVERE, null, ex);
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
    public BufferedImage getFoto() {
        return foto;
    }

    /**
     *
     * @return
     */
    public BufferedImage getThumbnail() {
        return thumbnail;
    }

    /**
     *
     * @return
     */
    public int getFotoNummer() {
        return fotoNummer;
    }
    
    /**
     *
     * @return
     */
    public FotoDetails getFotoDetails() {
        return details;
    }
 
}
