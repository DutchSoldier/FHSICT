package encryptpwd;

import com.sun.org.apache.xml.internal.security.utils.Base64;
import javafx.fxml.FXML;
import javafx.scene.control.PasswordField;
import org.controlsfx.dialog.Dialogs;
import utils.Utils;

import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.PBEParameterSpec;
import java.awt.*;
import java.io.File;
import java.security.KeyFactory;
import java.security.PrivateKey;
import java.security.SecureRandom;
import java.security.Signature;
import java.security.spec.PKCS8EncodedKeySpec;

public class Controller {
    @FXML
    public PasswordField pwField;

    public void onBtnEncrypt() {
        // Prompt for file name/location.
        File inputFile = Utils.pickFileRead("Input file");
        if (inputFile == null) {
            return;
        }
        File outputFile = Utils.pickFileWrite("Encrypted file", "encrypted.txt");
        if (outputFile == null) {
            return;
        }

        // Encrypt the file.
        try {
            // Generate salt.
            byte[] salt = new byte[8];
            SecureRandom random = new SecureRandom();
            random.nextBytes(salt);

            // Read the password.
            CharSequence passwordInStupidFormat = pwField.getCharacters();
            char[] password = new char[passwordInStupidFormat.length()];
            for (int i = 0; i < passwordInStupidFormat.length(); i++) {
                password[i] = passwordInStupidFormat.charAt(i);
            }
            pwField.clear();
            passwordInStupidFormat = null;

            // Generate key.
            PBEKeySpec keySpec = new PBEKeySpec(password);
            SecretKeyFactory factory = SecretKeyFactory.getInstance("PBEWithMD5AndDES");
            SecretKey key = factory.generateSecret(keySpec);
            keySpec.clearPassword();

            // Init cipher.
            PBEParameterSpec parameterSpec = new PBEParameterSpec(salt, 10000);
            Cipher cipher = Cipher.getInstance("PBEWithMD5AndDES");
            cipher.init(Cipher.ENCRYPT_MODE, key, parameterSpec);

            // Encrypt the file.
            byte[] input = Utils.readFromFile(inputFile).getBytes("UTF-8");
            byte[] ciphered = cipher.doFinal(input);

            // Write the file.
            byte[] output = new byte[1 + salt.length + ciphered.length];
            output[0] = (byte)salt.length;
            System.arraycopy(salt, 0, output, 1, salt.length);
            System.arraycopy(ciphered, 0, output, 1 + salt.length, ciphered.length);
            Utils.writeToFile(outputFile, Base64.encode(output));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
