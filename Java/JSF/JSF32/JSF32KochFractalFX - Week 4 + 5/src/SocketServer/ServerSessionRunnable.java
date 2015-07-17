/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package SocketServer;

import calculate.Edge;
import enums.ConnCommand;
import enums.ConnState;
import enums.EdgeID;
import enums.FileType;
import static enums.FileType.MappedFile;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;
import java.io.RandomAccessFile;
import java.net.Socket;
import java.nio.MappedByteBuffer;
import java.nio.channels.FileChannel;
import java.nio.channels.FileLock;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.scene.paint.Color;

/**
 *
 * @author Remi_Arts
 */
public class ServerSessionRunnable implements Runnable {

    private static String eol = System.getProperty("line.separator");
    private static String fs = File.separator;

    private Socket conn = null;
    private InputStream inStream = null;
    private OutputStream outStream = null;
    private ObjectInputStream in;
    private ObjectOutputStream out;

    private int sessionID;

    private SocketCalcTask leftTask, rightTask, bottomTask;

    public ServerSessionRunnable(Socket conn, int id) {
        System.out.println("Session started");
        try {
            this.sessionID = id;
            this.conn = conn;
            this.inStream = conn.getInputStream();
            this.outStream = conn.getOutputStream();

            this.in = new ObjectInputStream(inStream);
            this.out = new ObjectOutputStream(outStream);

            out.writeObject(ConnState.Connected);

        } catch (IOException ex) {
            System.out.println("IOException in ctor Runnable: " + ex.getMessage());
            Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void run() {
        if (conn == null || inStream == null || outStream == null || in == null || out == null) {
            System.out.println("an object in Runnable was null: " + eol
                    + "conn: " + (conn == null) + eol
                    + "inStream: " + (inStream == null) + eol
                    + "outStream: " + (outStream == null) + eol
                    + "in: " + (in == null) + eol
                    + "out: " + (out == null) + eol);
        }

        /**
         * The highest level while loop found in the session - this listens to
         * the ConnCommands indicating a client command.
         */
        try {
            try {
                boolean isDone = false;
                while (!isDone) {
                    Object inObject = in.readObject();
//                    System.out.println("object received");
                    if (!(inObject instanceof ConnCommand)) {
                        System.out.println("command was not a ConnCommand");
                        break;
                    }
                    ConnCommand command = (ConnCommand) inObject;
                    System.out.println("-- Command: " + command.toString() + " - ID: " + this.sessionID);

                    switch (command) {
                        case Connect:
                            // notifies the client the connection is completed
                            out.writeObject(ConnState.Connected);
                            out.flush();
                            break;
                        case getEdgesBatch:
                            this.getEdgesBatch();
                            break;
                        case getEdgesZoomed:
                            this.calcZoomedEdges();
                            break;
                        case Disconnect:
                            isDone = true;
                            break;
                        default:
                            System.out.println("unrecognised command: " + command.toString());
                            break;
                    }
                }
            } catch (IOException ex) {
                System.out.println("IOException in while loop Runnable: " + ex.getMessage());
                Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
            } catch (ClassNotFoundException ex) {
                System.out.println("ClassNotFoundException in while loop Runnable: " + ex.getMessage());
                Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
            } finally {
                System.out.println("Session " + this.sessionID + " closed down");
                conn.close();
            }
        } catch (IOException ex) {
            // catches IOException thrown in finally
            System.out.println("IOException closing socket after use: " + ex.getMessage());
        }

    }

    private List<Edge> loadEdgesFromFile(int lvl) throws IOException {
        System.out.println("load edges from file, lvl: " + lvl);
        String fileString = ServerMain.dirPath + fs + lvl + "MappedFile";
        File file = new File(fileString);
        if (file.length() == 0) {
            System.out.println("No file on memory");
            return null;
        }

        List<Edge> output = new ArrayList<>();
        try {
            // Starts neccessary overhead objects to read
            RandomAccessFile raf;
            raf = new RandomAccessFile(file, "rw");
            FileChannel fc = raf.getChannel();
            FileLock lock = fc.lock();

            MappedByteBuffer inBuffer = fc.map(FileChannel.MapMode.READ_ONLY, 0, fc.size());

            while (inBuffer.position() <= fc.size() - 40) {
                Double x1 = inBuffer.getDouble();
                Double x2 = inBuffer.getDouble();
                Double y1 = inBuffer.getDouble();
                Double y2 = inBuffer.getDouble();
                Color color = Color.hsb(inBuffer.getDouble(), 1.0, 1.0);
                Edge e = new Edge(x1, y1, x2, y2, color);
                output.add(e);
            }
            lock.release();

        } catch (FileNotFoundException ex) {
            System.out.println("Unable to locate " + fileString);
        } catch (IOException ex) {
            System.out.println("IOException in loadMappedFile: " + ex.getMessage());
        }
        return output;
    }

    private void saveEdgesToFile(int lvl, List<Edge> edges) {
        if (edges == null) {
            System.out.println("Edges input saveEdgesToFile was null");
            return;
        }
        System.out.println("Saving edges to file, lvl: " + lvl);

        String filePath = ServerMain.dirPath + File.separator + lvl + FileType.MappedFile.toString();

        try {
            // starts file, deletes previous version if needs be
            File outputFile = new File(filePath);
            if (outputFile.exists()) {
                outputFile.delete();
            }

            // starts overhead objects
            RandomAccessFile raf;
            raf = new RandomAccessFile(outputFile, "rw");
            FileChannel fc = raf.getChannel();
            FileLock lock = fc.lock();

            int fileSize = edges.size() * 40;
            MappedByteBuffer outBuffer = fc.map(FileChannel.MapMode.READ_WRITE, 0, fileSize);

            for (Edge e : edges) {
                outBuffer.putDouble(e.X1);
                outBuffer.putDouble(e.X2);
                outBuffer.putDouble(e.Y1);
                outBuffer.putDouble(e.Y2);
                outBuffer.putDouble(e.color.getHue());
            }
            lock.release();

        } catch (IOException ex) {
            System.out.println("IOException in saveToMappedFile: " + ex.getMessage());
        }
    }

    private void getEdgesBatch() {
        try {
            Object inObject = in.readObject();
            if (!(inObject instanceof Integer)) {
                System.out.println("argument calcEdgesBatch was not an Integer");
                out.writeObject(ConnState.Error);
                out.flush();
                return;
            }

            out.writeObject(ConnState.ProcessingCommand);
            out.flush();
            Integer lvl = (Integer) inObject;
            List<Edge> output = this.loadEdgesFromFile(lvl);

            if (output == null) {
                output = this.calcEdgesBatch(lvl);
            }           
            if (output == null) {
                System.out.println("neither method gave a list of edges");
                out.writeObject(ConnState.Error);
                out.flush();
                return;
            }
            // returns output
            System.out.println("returning list of edges - lvl: " + lvl + " - size: " + output.size());
            out.writeObject(output);
            out.writeObject(ConnState.CommandDone);
            out.flush();

        } catch (IOException ex) {
            Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
            System.out.println("IOException getting Edges as batch: " + ex.getMessage());
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private List<Edge> calcEdgesBatch(int lvl) throws IOException {

        System.out.println("calc edges batch, lvl: " + lvl);
        List<Edge> output = null;

        try {
            leftTask = new SocketCalcTask(lvl, EdgeID.Left);
            bottomTask = new SocketCalcTask(lvl, EdgeID.Bottom);
            rightTask = new SocketCalcTask(lvl, EdgeID.Right);

            Future<List<Edge>> futureLeft = ServerMain.pool.submit(leftTask);
            Future<List<Edge>> futureBottom = ServerMain.pool.submit(bottomTask);
            Future<List<Edge>> futureRight = ServerMain.pool.submit(rightTask);

            output = new ArrayList<>();
            output.addAll(futureLeft.get());
            output.addAll(futureBottom.get());
            output.addAll(futureRight.get());

        } catch (InterruptedException ex) {
            System.out.println("InterruptedException in calcEdgesBatch: " + ex.getMessage());
            Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ExecutionException ex) {
            System.out.println("ExecutionException in calcEdgesBatch: " + ex.getMessage());
            Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
        }
        System.out.println("returning " + output.size() + " edges");
        this.saveEdgesToFile(lvl, output);
        return output;
    }

    private void calcZoomedEdges() {
        try {
            Object inObject = in.readObject();
            if (!(inObject instanceof Map)) {
                System.out.println("argument calcZoomedEdges was not a map");
                out.writeObject(ConnState.Error);
                out.flush();
                return;
            }
            // retrieves arguments from map
            Map<String, Object> arguments = (Map<String, Object>) inObject;
            Edge e = (Edge) arguments.get("edge");
            Double zoom = (Double) arguments.get("zoom");
            Double zoomTranslateX = (Double) arguments.get("zoomTranslateX");
            Double zoomTranslateY = (Double) arguments.get("zoomTranslateY");

            // checks whether arguments were not null
            if (e == null || zoom == null || zoomTranslateX == null
                    || zoomTranslateY == null) {
                out.writeObject(ConnState.Error);
                out.flush();
            }

            // returns edge
            out.writeObject(new Edge(
                    e.X1 * zoom + zoomTranslateX,
                    e.Y1 * zoom + zoomTranslateY,
                    e.X2 * zoom + zoomTranslateX,
                    e.Y2 * zoom + zoomTranslateY,
                    e.color));

        } catch (IOException ex) {
            Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
            System.out.println("IOException while calculating edges after zoom");
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(ServerSessionRunnable.class.getName()).log(Level.SEVERE, null, ex);
        } catch (Exception ex) {
            System.out.println("generic exception: " + ex.getMessage());
        }
    }

}
