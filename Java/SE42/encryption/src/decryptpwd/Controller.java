package decryptpwd;

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
import java.io.File;
import java.security.KeyFactory;
import java.security.PublicKey;
import java.security.Signature;
import java.security.spec.X509EncodedKeySpec;

public class Controller {
    @FXML
    public PasswordField pwField;

    public void onBtnDecrypt() {
        // Prompt for file name/location.
        File inputFile = Utils.pickFileRead("Input file");
        if (inputFile == null) {
            return;
        }
        File outputFile = Utils.pickFileWrite("Decrypted file", "decrypted.txt");
        if (outputFile == null) {
            return;
        }

        // Encrypt the file.
        try {
            // Read the input file.
            byte[] input = Base64.decode(Utils.readFromFile(inputFile));
            int saltLength = (int)(input[0] & (0xff));
            byte[] salt = new byte[saltLength];
            byte[] ciphered = new byte[input.length - saltLength - 1];
            System.arraycopy(input, 1, salt, 0, salt.length);
            System.arraycopy(input, salt.length + 1, ciphered, 0, ciphered.length);

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
            cipher.init(Cipher.DECRYPT_MODE, key, parameterSpec);

            // Decrypt the file.
            byte[] output = cipher.doFinal(ciphered);

            // Write the file.
            Utils.writeToFile(outputFile, new String(output, "UTF-8"));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
