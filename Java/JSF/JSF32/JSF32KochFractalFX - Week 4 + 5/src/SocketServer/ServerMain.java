/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package SocketServer;

import java.io.File;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

/**
 *
 * @author Remi_Arts
 */
public class ServerMain {

    public static ExecutorService pool = Executors.newCachedThreadPool();
    public static String dirPath = "C:\\Users\\Remi_Arts\\Desktop\\JSF32";

    public static void main(String[] args) {

        try {
            File dir = new File(dirPath);
            dir.mkdir();

            // establish server socket
            ServerSocket s = new ServerSocket(8189);
            System.out.println("Server started");

            int nextID = 1;
            while (true) {
                //threadblocking until a connection is made, then starts a new runnable for it
                // repeats until program quit
                System.out.println("Waiting for client");
                Socket incoming = s.accept();
                System.out.println("Client accepted, starting thread.");
                pool.execute(new ServerSessionRunnable(incoming, nextID++));

            }

        } catch (IOException ex) {
            System.out.println("IOException in main: " + ex.getMessage());
            ex.printStackTrace();
        }
    }

}
