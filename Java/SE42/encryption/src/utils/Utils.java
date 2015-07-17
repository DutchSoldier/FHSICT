package utils;

import com.sun.org.apache.xerces.internal.impl.dv.util.Base64;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.*;

/**
 * Created by Michon on 26-1-2015.
 */
public class Utils {
    public static File baseDir = new File("C:\\Users\\Michon\\Documents\\test");
    /**
     * Set the contents of a file.
     *
     * @param file The file.
     * @param contents The new contents.
     */
    public static void writeToFile(File file, String contents) {
        BufferedWriter writer = null;
        try {
            writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file), "utf-8"));
            writer.write(contents);
        } catch (IOException ex) {
        } finally {
            try {
                writer.close();
            } catch (Exception ex) {
            }
        }
    }

    /**
     * Read an entire file into a string.
     *
     * @param file The file.
     * @return The contents of the file.
     */
    public static String readFromFile(File file) {
        FileInputStream fis = null;
        try {
            fis = new FileInputStream(file);
            byte[] data = new byte[(int) file.length()];
            fis.read(data);
            return new String(data, "UTF-8");
        } catch (IOException ex) {
        } finally {
            try {
                fis.close();
            } catch (Exception ex) {
            }
        }
        return null;
    }

    /**
     * Pick a file for reading.
     *
     * @param title The title of the dialog.
     * @return The picked file, or null.
     */
    public static File pickFileRead(String title) {
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle(title);
        fileChooser.setInitialDirectory(baseDir);
        return fileChooser.showOpenDialog(new Stage());
    }

    /**
     * Pick a file for writing.
     *
     * @param title The title of the dialog.
     * @param initialName The default file name.
     * @return The picked file, or null.
     */
    public static File pickFileWrite(String title, String initialName) {
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle(title);
        fileChooser.setInitialDirectory(baseDir);
        fileChooser.setInitialFileName(initialName);
        return fileChooser.showSaveDialog(new Stage());
    }
}
