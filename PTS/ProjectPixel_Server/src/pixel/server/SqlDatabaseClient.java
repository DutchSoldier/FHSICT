/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Frank
 */
public class SqlDatabaseClient implements AutoCloseable {

    private SqlDatabaseManager manager;
    private Connection connection;
    private PreparedStatement st;

    /**
     *
     * @param manager
     * @throws SQLException
     */
    public SqlDatabaseClient(SqlDatabaseManager manager) throws SQLException {
        this.manager = manager;

        this.connect();

        this.manager.addClient(this);
    }
    
    /**
     *
     * @param sql
     * @return
     * @throws SQLException
     */
    public PreparedStatement prepareStatement(String sql) throws SQLException {
        if (st != null)
            st.clearParameters();
        st = this.connection.prepareStatement(sql);
        return st;
    }
    
    /**
     *
     * @param sql
     * @param param
     * @return
     * @throws SQLException
     */
    public PreparedStatement prepareStatement (String sql, int param) throws SQLException {
         if (st != null)
            st.clearParameters();
        st = this.connection.prepareStatement(sql, param);
        return st;
    }

    /**
     *
     * @throws SQLException
     */
    public void connect() throws SQLException {
        this.connection = DriverManager.getConnection(SqlDatabaseManager.url + SqlDatabaseManager.database, SqlDatabaseManager.user, SqlDatabaseManager.password);
        this.connection.setAutoCommit(true);
    }

    /**
     *
     * @throws SQLException
     */
    public void disconnect() throws SQLException {
        this.connection.close();
    }

    @Override
    public void close() {
        try {
            if (connection != null)
                this.disconnect();
        } catch (SQLException ex) {
            Logger.getLogger(SqlDatabaseClient.class.getName()).log(Level.SEVERE, null, ex);
        }
        try {
            if (st != null)
                this.st.close();
        } catch (SQLException ex) {
            Logger.getLogger(SqlDatabaseClient.class.getName()).log(Level.SEVERE, null, ex);
        }
        this.manager.removeClient(this);
    }
}
