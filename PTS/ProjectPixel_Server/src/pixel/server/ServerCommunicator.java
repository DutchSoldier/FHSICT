/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server;

import java.io.IOException;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.parsers.ParserConfigurationException;
import org.xml.sax.SAXException;
import pixel.server.core.CoresManager;
import pixel.shared.classes.Account;
import pixel.shared.classes.Cube;
import pixel.shared.classes.Foto;
import pixel.shared.classes.FotoDetails;
import pixel.shared.classes.BewerkteFoto;
import pixel.shared.classes.Factuur;
import pixel.shared.classes.OrderRegel;
import pixel.shared.classes.Persoon;
import pixel.shared.classes.Product;
import pixel.shared.classes.ProductDetails;
import pixel.shared.enums.EffectType;
import pixel.shared.enums.FotograafType;
import pixel.shared.enums.PersoonType;
import pixel.shared.interfaces.IClientCommunicator;
import pixel.shared.interfaces.IServerCommunicator;

/**
 * @author Frank A class that the client uses to communicate with the server.
 * (pull)
 */
public class ServerCommunicator extends UnicastRemoteObject implements IServerCommunicator {

    // dit 'transient' maken, zorgt ervoor dat RMI deze variable niet naar de client(s) stuurt.
    private transient int currentClientId = 0;
    private final transient Object objectLock = new Object();

    /**
     * @throws RemoteException
     */
    public ServerCommunicator() throws RemoteException {
    }

    /**
     * @param client
     * @return
     * @throws RemoteException
     */
    @Override
    public int onClientConnected(IClientCommunicator client) throws RemoteException {
        synchronized (objectLock) { // zorgt ervoor dat een object niet hetzelfde id verkrijgt.
            int clientId = currentClientId++;
            Server.getClients().put(clientId, client);
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.INFO, "Client: [id=" + clientId + "] connected and registered on the server.");
            return clientId;
        }
    }

    /**
     * @param clientId
     * @throws RemoteException
     */
    @Override
    public void onClientDisconnected(int clientId) throws RemoteException {
        synchronized (objectLock) {
            Server.getClients().remove(clientId);
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.INFO, "Client: [id=" + clientId + "] disconnected and unregistered from the server.");
        }
    }

    /**
     * @param email
     * @param password
     * @return
     * @throws RemoteException
     */
    @Override
    public Account inloggen(String email, String password) throws RemoteException {
        try {
            return SqlDatabaseMethods.inloggen(email, password);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     * @param email
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean uitloggen(String email) throws RemoteException {
        try {
            return SqlDatabaseMethods.uitloggen(email);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     * @param email
     * @param password
     * @param type
     * @param naam
     * @param adres
     * @param fotograafType
     * @param lang
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean registreren(String email, String password, PersoonType type, String naam, String adres, FotograafType fotograafType, String lang) throws RemoteException {
        try {
            return SqlDatabaseMethods.registreren(email, password, type, naam, adres, fotograafType, lang);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     * @param email
     * @param password
     * @param type
     * @param naam
     * @param adres
     * @param lang
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean klantRegistreren(String email, String password, PersoonType type, String naam, String adres, String lang) throws RemoteException {
        try {
            return SqlDatabaseMethods.klantRegistreren(email, password, type, naam, adres, lang);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     *
     * @param fotoNummer
     * @param prijs
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean setPrijs(int fotoNummer, double prijs) throws RemoteException {
        try {
            return SqlDatabaseMethods.setPrijs(fotoNummer, prijs);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     *
     * @param email
     * @param fotonummer
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean fotoKoppelen(String email, int fotonummer) throws RemoteException {
        try {
            return SqlDatabaseMethods.fotoKoppelen(email, fotonummer);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     *
     * @param email
     * @param fotonummer
     * @param type
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean bewerkteFotoKoppelen(String email, int fotonummer, EffectType type, int x1, int y1, int x2, int y2) throws RemoteException {
        try {
            return SqlDatabaseMethods.bewerkteFotoKoppelen(email, fotonummer, type, x1, y1, x2, y2);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     *
     * @param email
     * @return
     * @throws RemoteException
     */
    @Override
    public ArrayList<Foto> getGekoppeldeFotos(String email, int dagenTerug) throws RemoteException {
        try {
            return SqlDatabaseMethods.getGekoppeldeFotos(email, dagenTerug);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }
    
    /**
     * 
     * @param email
     * @param dagenTerug
     * @return
     * @throws RemoteException 
     */
    @Override
    public ArrayList<BewerkteFoto> getBewerkteFotos(String email, int dagenTerug) throws RemoteException {
        try {
            return SqlDatabaseMethods.getBewerkteFotos(email, dagenTerug);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     *
     * @param email
     * @return
     * @throws RemoteException
     */
    @Override
    public ArrayList<Foto> getMijnFotos(String email, int dagenTerug) throws RemoteException {
        try {
            return SqlDatabaseMethods.getMijnFotos(email, dagenTerug);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    @Override
    public ArrayList<Foto> getPublicFotos(int dagenTerug) throws RemoteException {
        try {
            return SqlDatabaseMethods.getPublicFotos(dagenTerug);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     *
     * @param fotoNummer
     * @return
     * @throws RemoteException
     */
    @Override
    public FotoDetails getFotoDetails(int fotoNummer) throws RemoteException {
        try {
            return SqlDatabaseMethods.getFotoDetails(fotoNummer);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     *
     * @param clientId
     * @param email
     * @param fotos
     * @param productFotos
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean fotoToevoegen(final int clientId, final String email, Foto[] fotos, boolean productFotos) throws RemoteException {
        for (final Foto foto : fotos) {
            CoresManager.getLowPriorityThreadPool().submit(new Runnable() {
                @Override
                public void run() {
                    Foto toSave = foto;
                    try {
                        int result = -1;
                        result = (SqlDatabaseMethods.fotoToevoegen(email, toSave));
                        foto.setFotoNummer(result);
                        try {
                            Server.getClients().get(clientId).refreshPhoto(foto);
                        } catch (RemoteException ex) {
                            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    } catch (SQLException ex) {
                        Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
            });
        }
        return true;
    }

    /**
     * @param naam
     * @param beschrijving
     * @param voorraad
     * @param prijs
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean productToevoegen(String naam, String beschrijving, int voorraad, double prijs, byte[] bytes) throws RemoteException {
        try {
            return SqlDatabaseMethods.productToevoegen(naam, beschrijving, voorraad, prijs, bytes);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     * @return @throws RemoteException
     */
    @Override
    public ArrayList<Cube> getCurrencies() throws RemoteException {
        ArrayList<Cube> currencies = new ArrayList<>();
        try {
            XMLParser.parseXML();
            currencies = XMLParser.getCurrencyList();
        } catch (IOException | SAXException | ParserConfigurationException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
        }
        return currencies;
    }

    /**
     * @return @throws RemoteException
     */
    @Override
    public ArrayList<Product> getProducten() throws RemoteException {
        try {
            return SqlDatabaseMethods.getProducten();
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     * @param productnummer
     * @return
     * @throws RemoteException
     */
    @Override
    public ProductDetails getProductDetails(int productnummer) throws RemoteException {
        try {
            return SqlDatabaseMethods.getProductDetails(productnummer);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     * @return @throws RemoteException
     */
    @Override
    public ArrayList<Foto> getProductFotos() throws RemoteException {
        try {
            return SqlDatabaseMethods.getProductFotos();
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     * @param productnummer
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean deleteProduct(int productnummer) throws RemoteException {
        try {
            return SqlDatabaseMethods.deleteProduct(productnummer);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     * @param productnaam
     * @param productbeschrijving
     * @param voorraad
     * @param productprijs
     * @param bytes
     * @param productNummer
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean wijzigProduct(String productnaam, String productbeschrijving, int voorraad, double productprijs, byte[] bytes, int productNummer) throws RemoteException {
        try {
            return SqlDatabaseMethods.wijzigProduct(productnaam, productbeschrijving, voorraad, productprijs, bytes, productNummer);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     * @param productnaam
     * @return
     * @throws RemoteException
     */
    @Override
    public int getProductNummer(String productnaam) throws RemoteException {
        try {
            return SqlDatabaseMethods.getProductNummer(productnaam);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return 0;
        }
    }

    /**
     *
     * @param password
     * @return
     */
    @Override
    public String hash(String password) {
        return SHAHashing.hash(password);
    }

    /**
     * @param fotonummer
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean fotoOpenbaren(int fotonummer) throws RemoteException {
        try {
            return SqlDatabaseMethods.fotoOpenbaren(fotonummer);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

    /**
     *
     * @param email
     * @param type
     * @param fotonummer
     * @return
     * @throws RemoteException
     */
    @Override
    public int rateFoto(String email, FotograafType type, int fotonummer) throws RemoteException {
        try {
            return SqlDatabaseMethods.rateFoto(email, type, fotonummer);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return -1;
        }
    }

    /**
     * @return @throws RemoteException
     */
    @Override
    public ArrayList<Persoon> getPersonen() throws RemoteException {
        try {
            return SqlDatabaseMethods.getPersonen();
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    @Override
    public Persoon GetPersoonsGegevens(String email) throws RemoteException {
        try {
            return SqlDatabaseMethods.GetPersoonGegevens(email);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     *
     * @param email
     * @param naam
     * @param wachtwoord
     * @param type
     * @param adres
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean wijzigPersoonEnWachtwoord(String email, String naam, String wachtwoord, PersoonType type, String adres) throws RemoteException {
        try {
            return SqlDatabaseMethods.wijzigPersoonEnWachtwoord(email, naam, wachtwoord, type, adres);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    /**
     *
     * @param email
     * @param naam
     * @param type
     * @param adres
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean wijzigPersoon(String email, String naam, PersoonType type, String adres) throws RemoteException {
        try {
            return SqlDatabaseMethods.wijzigPersoon(email, naam, type, adres);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    /**
     *
     * @param email
     * @param wachtwoord
     * @return
     * @throws RemoteException
     */
    @Override
    public boolean checkWachtwoord(String email, String wachtwoord) throws RemoteException {
        try {
            return SqlDatabaseMethods.checkWachtwoord(email, wachtwoord);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    /**
     * @param factuurnummer
     * @return
     * @throws RemoteException 
     */
    @Override
    public ArrayList<OrderRegel> getOrderRegels(int factuurnummer) throws RemoteException {
        try {
            return SqlDatabaseMethods.getOrderRegels(factuurnummer);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     * @return
     * @throws RemoteException 
     */
    @Override
    public ArrayList<Factuur> getAlleFacturen() throws RemoteException {
        try {
            return SqlDatabaseMethods.getAlleFacturen();
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     * @param email
     * @return
     * @throws RemoteException 
     */
    @Override
    public ArrayList<Factuur> getKlantFacturen(String email) throws RemoteException {
        try {
            return SqlDatabaseMethods.getKlantFacturen(email);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        }
    }

    /**
     * @param email
     * @return
     * @throws RemoteException 
     */
    @Override
    public int factuurToevoegen(String email) throws RemoteException {
        try {
            return SqlDatabaseMethods.factuurToevoegen(email);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return 0;
        }
    }

    /**
     * @param factuurnummer
     * @param productnummer
     * @param fotoklantnummer
     * @param fotobewerktnummer
     * @param aantal
     * @param prijs
     * @return
     * @throws RemoteException 
     */
    @Override
    public boolean orderRegelToevoegen(int factuurnummer, int productnummer, int fotoklantnummer, int fotobewerktnummer, int aantal, double prijs) throws RemoteException {
        try {
            return SqlDatabaseMethods.orderRegelToevoegen(factuurnummer, productnummer, fotoklantnummer, fotobewerktnummer, aantal, prijs);
        } catch (SQLException ex) {
            Logger.getLogger(ServerCommunicator.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }

}
