/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client;

import java.util.Random;

/**
 *
 * @author Bas
 */
public class GeneratePassword {
    /**
     *
     * @return
     */
    public static String generateRandomPassword() {
        char[] chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".toCharArray();
        StringBuilder sb = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < 10; i++) {
            char c = chars[random.nextInt(chars.length)];
            sb.append(c);
        }
        String pass = sb.toString();
        return pass;
    }
}
