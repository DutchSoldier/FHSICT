/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package SocketClient;

import calculate.Edge;
import enums.ConnCommand;
import enums.ConnState;
import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;
import java.net.Socket;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Platform;

/**
 *
 * @author Remi_Arts
 */
public class KochSocketClient {

    SocketClientFractalFX application;
    List<Edge> edges;

    private InputStream inStream = null;
    private OutputStream outStream = null;
    private ObjectInputStream in = null;
    private ObjectOutputStream out = null;
    Socket socket = null;
    private boolean isBusy = false;
    private ExecutorService pool = Executors.newFixedThreadPool(1);

    public KochSocketClient(SocketClientFractalFX application) {
        this.application = application;
        this.edges = new ArrayList<>();

        try {
            socket = new Socket("localhost", 8189);

            this.outStream = socket.getOutputStream();
            this.inStream = socket.getInputStream();

            this.out = new ObjectOutputStream(outStream);
            this.in = new ObjectInputStream(inStream);

            System.out.println("Saying hello to server");
            out.writeObject(ConnCommand.Connect);
            out.flush();

            // checks whether connection with server is up and running
            boolean doneSayingHello = false;
            while (!doneSayingHello) {
                Object inObject;
                try {
                    inObject = in.readObject();

                    if ((inObject instanceof ConnState)
                            && (ConnState) inObject == ConnState.Connected) {
                        System.out.println("Connected to server");
                        doneSayingHello = true;
                    } else {
                        System.out.println("no valid object as connection confirmation");
                    }
                } catch (ClassNotFoundException ex) {
                    Logger.getLogger(KochSocketClient.class.getName()).log(Level.SEVERE, null, ex);
                }
            }

        } catch (IOException e) {
            System.out.println("IOException in KochSocketClient ctor: " + e.getMessage());
            System.exit(0);
        }
    }

    void changeLevel(int lvl) {
        if (isBusy) {
            System.out.println("application is busy");
            return;
        }

        pool.execute(new Thread(() -> {
            isBusy = true;
            application.setLevel(lvl);
            this.changeLevelBatch(lvl);
            this.drawEdges();
            isBusy = false;
        }));
    }

    private void changeLevelBatch(int lvl) {
        try {
            // sends query
            out.writeObject(ConnCommand.getEdgesBatch);
            out.writeObject(lvl);
            out.flush();

            // waits for reply
            boolean isDone = false;
            while (!isDone) {
                Object inObject = in.readObject();

                if (inObject instanceof ConnState) {
                    ConnState msg = (ConnState) inObject;

                    if (msg == ConnState.Error) {
                        System.out.println("changeLevelBatch threw an error");
                        return;
                    }

                    if (msg == ConnState.CommandDone) {
                        System.out.println("Command done - changeLevelBatch(" + lvl + ")");
                        return;
                    }
                } else if (inObject instanceof List) {
                    this.edges.clear();
                    this.edges.addAll((List<Edge>) inObject);
                    System.out.println(edges.size() + " edges retrieved");
                } else {
                    System.out.println("unrecognised object sent by server (changeLevelBatch)");
                }
            }

        } catch (IOException ex) {
            System.out.println("IOException in changeLevelBatch: " + ex.getMessage());
            Logger.getLogger(KochSocketClient.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            System.out.println("ClassNotFoundException in ChangeLevelBatch: " + ex.getMessage());
            Logger.getLogger(KochSocketClient.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    void drawEdges() {
        Platform.runLater(() -> {
            application.setTextNrEdges(String.valueOf(this.edges.size()));
            application.clearKochPanel();

            for (Edge e : edges) {
                application.drawEdge(e);
            }
        });
    }

    Edge edgeAfterZoomAndDrag(Edge e, double zoom, double zoomTranslateX, double zoomTranslateY) {
        Edge output = null;
        try {
            // prepares map containing arguments
            Map<String, Object> arguments = new HashMap<>();
            arguments.put("edge", e);
            arguments.put("zoom", zoom);
            arguments.put("zoomTranslateX", zoomTranslateX);
            arguments.put("zoomTranslateY", zoomTranslateY);

            // queries server with command + argument
            out.writeObject(ConnCommand.getEdgesZoomed);
            out.writeObject(arguments);
            out.flush();

            boolean isDone = false;
            while (!isDone) {
                Object inObject = in.readObject();
                if (inObject instanceof ConnState) {
                    // No CommandDone is sent, to reduce cluttering on an already spammy function
                    ConnState state = (ConnState) inObject;
                    if (state == ConnState.Error) {
                        // not thrown in normal flow
                        throw new IOException("ConnState -> Error");
                    }
                } else if (inObject instanceof Edge) {
                    output = (Edge) inObject;
                    isDone = true;
                } else {
                    throw new ClassNotFoundException("no valid return type");
                }
            }
        } catch (IOException ex) {
            System.out.println("IOException in edgeAfterZoomAndDrag: " + ex.getMessage());
            Logger.getLogger(KochSocketClient.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            System.out.println("ClassNotFoundException in edgeAfterZoomAndDrag: " + ex.getMessage());
            Logger.getLogger(KochSocketClient.class.getName()).log(Level.SEVERE, null, ex);
        }

        return output;
    }

    void closeSocket() {
        try {
            // server closes down session on ConnCommand.Disconnect
            out.writeObject(ConnCommand.Disconnect);
            out.flush();
            socket.close();
        } catch (IOException ex) {
            System.out.println("IOException closing down connection: " + ex.getMessage());
            Logger.getLogger(KochSocketClient.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

}
