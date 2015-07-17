package encryptkey;

import com.sun.org.apache.xml.internal.security.utils.Base64;
import utils.Utils;

import javax.crypto.Cipher;
import javax.rmi.CORBA.Util;
import java.io.File;
import java.security.*;
import java.security.spec.PKCS8EncodedKeySpec;

public class Controller {
    public void onBtnEncrypt() {
        // Prompt for file name/location.
        File keyFile = Utils.pickFileRead("Private key");
        if (keyFile == null) {
            return;
        }
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
            // Read the private key.
            PKCS8EncodedKeySpec spec = new PKCS8EncodedKeySpec(Base64.decode(Utils.readFromFile(keyFile)));
            PrivateKey privateKey = KeyFactory.getInstance("RSA").generatePrivate(spec);

            // Read the input file.
            byte[] input = Utils.readFromFile(inputFile).getBytes("UTF-8");

            // Generate the signature of the document using the Signature class
            Signature s = Signature.getInstance("SHA1withRSA");
            s.initSign(privateKey);
            s.update(input);
            byte[] signature = s.sign();

            // Encrypt the file.
            Cipher cipher = Cipher.getInstance("RSA");
            cipher.init(Cipher.ENCRYPT_MODE, privateKey);
            byte[] ciphered = cipher.doFinal(input);

            // Write the file.
            byte[] output = new byte[1 + signature.length + ciphered.length];
            output[0] = (byte)signature.length;
            System.arraycopy(signature, 0, output, 1, signature.length);
            System.arraycopy(ciphered, 0, output, 1 + signature.length, ciphered.length);
            Utils.writeToFile(outputFile, Base64.encode(output));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
