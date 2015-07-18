package pixel.shared.interfaces;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.Date;
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

/**
 *
 * @author Luc An interface that the client uses to communicate with the server.
 * (pull)
 */
public interface IServerCommunicator extends Remote {

    /**
     * @param client
     * @return clientId.
     * @throws RemoteException
     */
    public int onClientConnected(IClientCommunicator client) throws RemoteException;

    /**
     * @param clientId
     * @throws RemoteException
     */
    public void onClientDisconnected(int clientId) throws RemoteException;

    /**
     * @param email
     * @param password
     * @return
     * @throws RemoteException
     */
    public Account inloggen(String email, String password) throws RemoteException;

    /**
     * @param email
     * @return
     * @throws RemoteException
     */
    public boolean uitloggen(String email) throws RemoteException;

    /**
     *
     * @param email
     * @param fotonummer
     * @return
     * @throws RemoteException
     */
    public boolean fotoKoppelen(String email, int fotonummer) throws RemoteException;

    /**
     * 
     * @param email
     * @param fotonummer
     * @param type
     * @return
     * @throws RemoteException 
     */
    public boolean bewerkteFotoKoppelen(String email, int fotonummer, EffectType type, int x1, int y1, int x2, int y2) throws RemoteException;
    
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
    public boolean registreren(String email, String password, PersoonType type, String naam, String adres, FotograafType fotograafType, String lang) throws RemoteException;

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
    public boolean klantRegistreren(String email, String password, PersoonType type, String naam, String adres, String lang) throws RemoteException;
    
    /**
     * @param fotoNummer
     * @param prijs
     * @return
     * @throws RemoteException
     */
    public boolean setPrijs(int fotoNummer, double prijs) throws RemoteException;

    /**
     * @param clientId 
     * @param email
     * @param fotos 
     * @param productFotos 
     * @return
     * @throws RemoteException
     */
    public boolean fotoToevoegen(int clientId, String email, Foto[] fotos, boolean productFotos) throws RemoteException;

    /**
     * @param email 
     * @return
     * @throws RemoteException
     */
    public ArrayList<Foto> getGekoppeldeFotos(String email, int dagenTerug) throws RemoteException;
    
    /**
     * 
     * @param email
     * @param dagenTerug
     * @return
     * @throws RemoteException 
     */
    public ArrayList<BewerkteFoto> getBewerkteFotos(String email, int dagenTerug) throws RemoteException;
    
    /**
     * 
     * @param email
     * @param dagenTerug
     * @return
     * @throws RemoteException 
     */
    public ArrayList<Foto> getMijnFotos(String email, int dagenTerug) throws RemoteException;
    
    /**
     * 
     * @param dagenTerug
     * @return
     * @throws RemoteException 
     */
    public ArrayList<Foto> getPublicFotos(int dagenTerug) throws RemoteException;

    /**
     * @param fotoNummer
     * @return
     * @throws RemoteException
     */
    public FotoDetails getFotoDetails(int fotoNummer) throws RemoteException;

    /**
     * @param naam
     * @param beschrijving
     * @param voorraad
     * @param prijs
     * @param bytes 
     * @return
     * @throws RemoteException
     */
    public boolean productToevoegen(String naam, String beschrijving, int voorraad, double prijs, byte[] bytes) throws RemoteException;

    /**
     * @return
     * @throws RemoteException
     */
    public ArrayList<Cube> getCurrencies() throws RemoteException;
    
    /**
     * @return
     * @throws RemoteException 
     */
    public ArrayList<Product> getProducten() throws RemoteException;
    
    /**
     * @param productnummer
     * @return
     * @throws RemoteException 
     */
    public ProductDetails getProductDetails(int productnummer)throws RemoteException;
    
    /**
     *
     * @return
     * @throws RemoteException
     */
    public ArrayList<Foto> getProductFotos() throws RemoteException;
    
    /**
     * @param productnummer
     * @return
     * @throws RemoteException 
     */
    public boolean deleteProduct(int productnummer)throws RemoteException;
    
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
    public boolean wijzigProduct(String productnaam, String productbeschrijving, int voorraad, double productprijs, byte[] bytes, int productNummer)throws RemoteException;

    /**
     * 
     * @param productnaam
     * @return
     * @throws RemoteException 
     */
    public int getProductNummer(String productnaam) throws RemoteException;
    
    /**
     *
     * @param password
     * @return
     * @throws RemoteException
     */
    public String hash(String password) throws RemoteException;
    
    /**
     * @param fotonummer
     * @return
     * @throws RemoteException 
     */
    public boolean fotoOpenbaren(int fotonummer) throws RemoteException;

    /**
     *
     * @param email
     * @param type
     * @param fotonummer
     * @return
     * @throws RemoteException
     */
    public int rateFoto(String email, FotograafType type, int fotonummer) throws RemoteException;
    
    
    /**
     * @return
     * @throws RemoteException 
     */
    public ArrayList<Persoon> getPersonen() throws RemoteException;
    
    /**
     * 
     * @param email
     * @return
     * @throws RemoteException 
     */
    public Persoon GetPersoonsGegevens(String email) throws RemoteException;
    
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
    public boolean wijzigPersoonEnWachtwoord (String email, String naam, String wachtwoord, PersoonType type, String adres) throws RemoteException;
    
    /**
     * 
     * @param email
     * @param naam
     * @param type
     * @param adres
     * @return
     * @throws RemoteException 
     */
    public boolean wijzigPersoon(String email, String naam, PersoonType type, String adres) throws RemoteException;

    /**
     * 
     * @param email
     * @param wachtwoord
     * @return
     * @throws RemoteException 
     */
    public boolean checkWachtwoord(String email, String wachtwoord) throws RemoteException;
    
    /**
     * @param factuurnummer
     * @param productnummer
     * @param foto_klantnummer
     * @param aantal
     * @param prijs
     * @return
     * @throws RemoteException 
     */
    public ArrayList<OrderRegel> getOrderRegels(int factuurnummer)throws RemoteException;
    
    /**
     * @param factuurnummer
     * @param email
     * @param datum
     * @return
     * @throws RemoteException 
     */
    public ArrayList<Factuur> getAlleFacturen()throws RemoteException;
    
    /**
     * @param factuurnummer
     * @param email
     * @param datum
     * @return
     * @throws RemoteException 
     */
    public ArrayList<Factuur> getKlantFacturen(String email)throws RemoteException;
    
    /**
     * @param email
     * @return
     * @throws RemoteException 
     */
    public int factuurToevoegen(String email) throws RemoteException;
    
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
    public boolean orderRegelToevoegen(int factuurnummer, int productnummer, int fotoklantnummer, int fotobewerktnummer, int aantal, double prijs) throws RemoteException;
}
