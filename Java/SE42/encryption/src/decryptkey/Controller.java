package decryptkey;

import com.sun.org.apache.xml.internal.security.utils.Base64;
import org.controlsfx.dialog.Dialogs;
import utils.Utils;

import javax.crypto.Cipher;
import java.io.File;
import java.security.KeyFactory;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.Signature;
import java.security.spec.PKCS8EncodedKeySpec;
import java.security.spec.X509EncodedKeySpec;

public class Controller {
    public void onBtnDecrypt() {
        // Prompt for file name/location.
        File keyFile = Utils.pickFileRead("Public key");
        if (keyFile == null) {
            return;
        }
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
            // Read the public key.
            X509EncodedKeySpec spec = new X509EncodedKeySpec(Base64.decode(Utils.readFromFile(keyFile)));
            PublicKey publicKey = KeyFactory.getInstance("RSA").generatePublic(spec);

            // Read the input file.
            byte[] input = Base64.decode(Utils.readFromFile(inputFile));
            int signatureLength = (int)(input[0] & (0xff));
            byte[] signature = new byte[signatureLength];
            byte[] ciphered = new byte[input.length - signatureLength - 1];
            System.arraycopy(input, 1, signature, 0, signature.length);
            System.arraycopy(input, signature.length + 1, ciphered, 0, ciphered.length);

            // Decrypt the file.
            Cipher cipher = Cipher.getInstance("RSA");
            cipher.init(Cipher.DECRYPT_MODE, publicKey);
            byte[] output = cipher.doFinal(ciphered);

            // Verify the signature of the document using the Signature class
            Signature s = Signature.getInstance("SHA1withRSA");
            s.initVerify(publicKey);
            s.update(output);
            if (s.verify(signature)) {
                Dialogs.create()
                    .title("Signature is valid")
                    .message("The signature of the file is valid.")
                    .showInformation();
            } else {
                Dialogs.create()
                    .title("Signature is invalid")
                    .message("The signature of the file is not valid.")
                    .showError();
                return;
            }

            // Write the file.
            Utils.writeToFile(outputFile, new String(output, "UTF-8"));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
