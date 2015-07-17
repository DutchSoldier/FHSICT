package generate;

import com.sun.org.apache.xml.internal.security.utils.Base64;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import utils.Utils;

import javax.crypto.Cipher;
import java.io.File;
import java.security.KeyPair;
import java.security.KeyPairGenerator;

public class Controller {
    public void onBtnGenerate() {
        // Prompt for file name/location.
        File privateFile = Utils.pickFileWrite("Save private key", "private.key");
        if (privateFile == null) {
            return;
        }
        File publicFile = Utils.pickFileWrite("Save public key", "public.key");
        if (publicFile == null) {
            return;
        }

        // Generate the keys, and write the files.
        try {
            KeyPair keys = KeyPairGenerator.getInstance("RSA").generateKeyPair();
            Utils.writeToFile(privateFile, Base64.encode(keys.getPrivate().getEncoded()));
            Utils.writeToFile(publicFile, Base64.encode(keys.getPublic().getEncoded()));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
