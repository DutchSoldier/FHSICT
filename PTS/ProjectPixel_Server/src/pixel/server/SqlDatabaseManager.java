/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Frank
 */
public class SqlDatabaseManager {
    /**
     *
     */
    public static final String url = "jdbc:mysql://localhost:3306/";
    /**
     *
     */
    public static final String database = "projectpixel";
    /**
     *
     */
    public static final String user = "pixel";
    /**
     *
     */
    public static final String password = "pixel";
    
    private ArrayList<SqlDatabaseClient> clients = new ArrayList<SqlDatabaseClient>();
    private Object lock = new Object();
    
    /**
     *
     */
    public SqlDatabaseManager() {
        
    }
    
    /**
     *
     * @return
     */
    public SqlDatabaseClient getClient() {
        try {
            return new SqlDatabaseClient(this);
        } catch (SQLException ex) {
            Logger.getLogger(SqlDatabaseManager.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
    
    /**
     *
     * @param client
     */
    public void addClient(SqlDatabaseClient client) {
        synchronized(lock) {
            clients.add(client);
        }
    }
    
    /**
     *
     * @param client
     */
    public void removeClient(SqlDatabaseClient client) {
        synchronized(lock) {
            clients.remove(client);
        }
    }    
}
