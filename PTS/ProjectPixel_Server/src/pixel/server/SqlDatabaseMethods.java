/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server;

import java.io.ByteArrayInputStream;
import java.sql.*;
import java.util.ArrayList;
import pixel.shared.classes.Account;
import pixel.shared.classes.Foto;
import pixel.shared.classes.FotoDetails;
import pixel.shared.enums.OnlineStatus;
import pixel.shared.enums.PersoonType;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.persistence.*;
import javax.persistence.criteria.CriteriaQuery;
import pixel.shared.classes.BewerkteFoto;
import pixel.shared.classes.Factuur;
import pixel.shared.classes.OrderRegel;
import pixel.shared.classes.Persoon;
import pixel.shared.classes.Product;
import pixel.shared.classes.ProductDetails;
import pixel.shared.enums.EffectType;
import pixel.shared.enums.FotograafType;

/**
 * @author Bas
 */
public class SqlDatabaseMethods {

    static final EntityManagerFactory emf = Persistence.createEntityManagerFactory("pixelPU");
    static EntityManager em = emf.createEntityManager();

    /**
     * @param email
     * @param password
     * @return
     * @throws SQLException
     */
    public static Account inloggen(String email, String password) throws SQLException {
        Persoon p = null;
        try {
            Query q = em.createNamedQuery("Persoon.find", Persoon.class);
            q.setParameter("email", email);
            p = (Persoon) q.getSingleResult();
        } catch (NoResultException ex) {
            return null;
        }
        
        if (!p.getWachtwoord().equals(password)) {
            return null;
        }

        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            if (p.getType() != null && p.getEmail() != null) {
                FotograafType ftype = FotograafType.GEEN;
                PreparedStatement st = client.prepareStatement("Select TYPE from FOTOGRAAF WHERE EMAIL = ? LIMIT 1;");
                st.setString(1, email);
                ResultSet rs = st.executeQuery();
                if (rs.next()) {
                    ftype = FotograafType.valueOf(rs.getObject("TYPE").toString());
                }
                Account account = new Account(p.getEmail(), PersoonType.valueOf(p.getType()), ftype);
                p.setStatus(OnlineStatus.ONLINE);
                if (!em.getTransaction().isActive()) {
                    em.getTransaction().begin();
                }
                em.merge(p);
                em.getTransaction().commit();
                return account;
            }
        }
        return null;
    }

    /**
     * @param email
     * @return
     * @throws SQLException
     */
    public static boolean uitloggen(String email) throws SQLException {
        Persoon p = null;
        try {
            Query q = em.createNamedQuery("Persoon.find", Persoon.class);
            q.setParameter("email", email);
            p = (Persoon) q.getSingleResult();
            p.setStatus(OnlineStatus.OFFLINE);
            if (!em.getTransaction().isActive()) {
                em.getTransaction().begin();
            }
            em.merge(p);
            em.flush();
            em.getTransaction().commit();
            return true;
        } catch (NoResultException ex) {
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
     * @throws SQLException
     */
    public static boolean registreren(String email, String password, PersoonType type, String naam, String adres, FotograafType fotograafType, String lang) throws SQLException {
        Persoon p = new Persoon(email, naam, SHAHashing.hash(password), adres, type, OnlineStatus.OFFLINE);
        /*Query q = em.createNamedQuery("Persoon.find", Persoon.class);
         q.setParameter("email", email);
         if (q.getResultList().size() > 0) {
         return false; // er is al een persoon met deze mail geregistreerd.
         }*/
        Email mail = new Email(email, password, lang);
        mail.mail();
        /*if (!mail.mail()) {
         return false;
         }*/

        if (!em.getTransaction().isActive()) {
            em.getTransaction().begin();
        }
        em.persist(p);
        em.flush();
        em.getTransaction().commit();

        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("INSERT INTO Fotograaf (Email, Type) VALUES (?, ?);");
            st.setString(1, email);
            st.setString(2, fotograafType.toString());
            return st.executeUpdate() > 0;
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
     * @throws SQLException
     */
    public static boolean klantRegistreren(String email, String password, PersoonType type, String naam, String adres, String lang) throws SQLException {
        Persoon p = new Persoon(email, naam, SHAHashing.hash(password), adres, type, OnlineStatus.OFFLINE);
        Query q = em.createNamedQuery("Persoon.find", Persoon.class);
        q.setParameter("email", email);
        if (q.getResultList().size() > 0) {
            return false; // er is al een persoon met deze mail geregistreerd.
        }
        Email mail = new Email(email, password, lang);
        mail.mail();

        /*if (!mail.mail()) {
         return false;
         }*/

        if (!em.getTransaction().isActive()) {
            em.getTransaction().begin();
        }
        em.persist(p);
        em.flush();
        em.getTransaction().commit();

        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("INSERT INTO Klant (Email) VALUES (?);");
            st.setString(1, email);
            return st.executeUpdate() > 0;
        }
    }

    /**
     * @param fotoNummer
     * @param prijs
     * @return
     * @throws SQLException
     */
    public static boolean setPrijs(int fotoNummer, double prijs) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("UPDATE Foto SET Prijs = ? WHERE FOTONUMMER = ? LIMIT 1;");
            st.setDouble(1, prijs);
            st.setInt(2, fotoNummer);
            return st.executeUpdate() > 0;
        }
    }

    /**
     * @param fotoNummer
     * @return
     * @throws SQLException
     */
    public static FotoDetails getFotoDetails(int fotoNummer) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT EMAIL, PRIJS, DATUM, RATING FROM FOTO WHERE FOTONUMMER = ? LIMIT 1;");
            st.setInt(1, fotoNummer);
            ResultSet rs = st.executeQuery();
            if (!rs.next()) {
                // geen foto gevonden met id
                return null;
            }
            String email = rs.getString("EMAIL");
            double prijs = rs.getDouble("PRIJS");
            Date datum = rs.getDate("DATUM");
            int rating = rs.getInt("RATING");
            st = client.prepareStatement("SELECT NAAM FROM PERSOON WHERE EMAIL = ? LIMIT 1;");
            st.setString(1, email);
            rs = st.executeQuery();
            String naam = "Onbekend";
            if (rs.next()) {
                naam = rs.getString("NAAM");
            }
            rs.close();
            return new FotoDetails(naam, prijs, datum, rating);
        }
    }

    /**
     * @param email
     * @param foto
     * @return
     * @throws SQLException
     */
    //Datum als string in "dd,mm,yyyy" format!
    public static int fotoToevoegen(String email, Foto foto) throws SQLException {

        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("INSERT INTO Foto (EMAIL, PRIJS, DATUM, FOTO_BESTAND) VALUES (?, ?, NOW(), ?);", Statement.RETURN_GENERATED_KEYS);
            st.setString(1, email);
            st.setDouble(2, 1); // prijs
            ByteArrayInputStream in = new ByteArrayInputStream(foto.getBytes());
            st.setBinaryStream(3, in, in.available());

            int autoIncValue = -1;
            if (st.executeUpdate() > 0) {
                ResultSet rs = st.getGeneratedKeys();
                if (rs.next()) {
                    autoIncValue = rs.getInt(1);
                }
                rs.close();
            }
            return autoIncValue;
        }
    }

    /**
     *
     * @param email
     * @param fotonummer
     * @return
     * @throws SQLException
     */
    public static boolean fotoKoppelen(String email, int fotonummer) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("INSERT INTO Foto_Klant (EMAIL, FotoNummer) VALUES (?, ?);");
            st.setString(1, email);
            st.setInt(2, fotonummer);
            return st.executeUpdate() > 0;
        }
    }

    /**
     *
     * @param email
     * @param fotonummer
     * @param type
     * @return
     * @throws SQLException
     */
    public static boolean bewerkteFotoKoppelen(String email, int fotonummer, EffectType type, int x1, int y1, int x2, int y2) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("INSERT INTO Foto_Bewerkt (Email, FotoNummer, Type, Datum, Linksbovenx, Linksboveny, Rechtsonderx, Rechtsondery) VALUES (?, ?, '" + type + "', NOW(), ?, ?, ?, ?);");
            st.setString(1, email);
            st.setInt(2, fotonummer);
            st.setInt(3, x1);
            st.setInt(4, y1);
            st.setInt(5, x2);
            st.setInt(6, y2);
            return st.executeUpdate() > 0;
        }
    }

    /**
     *
     * @param email
     * @return
     * @throws SQLException
     */
    public static ArrayList<Foto> getGekoppeldeFotos(String email, int dagenTerug) throws SQLException {
        ArrayList<Foto> fotos = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT F.FOTO_BESTAND, F.FOTONUMMER FROM FOTO F, FOTO_KLANT K WHERE (F.FOTONUMMER = K.FOTONUMMER AND K.EMAIL = ?) AND `datum` >= DATE_SUB(CURDATE(), INTERVAL ? DAY) ORDER BY RATING DESC;");
            st.setString(1, email);
            st.setInt(2, dagenTerug);
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                Blob blob = rs.getBlob("F.FOTO_BESTAND");
                int fotoNummer = rs.getInt("F.FOTONUMMER");

                Foto foto = new Foto(fotoNummer);
                byte[] bytes = blob.getBytes(1, (int) blob.length());
                foto.setBytes(bytes);
                fotos.add(foto);
            }
            rs.close();
            return fotos;
        }
    }

    public static ArrayList<BewerkteFoto> getBewerkteFotos(String email, int dagenTerug) throws SQLException {
        // TODO - Dagen terug
        ArrayList<BewerkteFoto> fotos = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT * FROM Foto_Bewerkt WHERE EMAIL = ?;");
            st.setString(1, email);
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                int fotoNummer = rs.getInt("FOTONUMMER");
                int foto_bewerktNummer = rs.getInt("FOTO_BEWERKTNUMMER");
                int x1 = rs.getInt("LINKSBOVENX");
                int y1 = rs.getInt("LINKSBOVENY");
                int x2 = rs.getInt("RECHTSONDERX");
                int y2 = rs.getInt("RECHTSONDERY");
                EffectType type = EffectType.valueOf(rs.getString("TYPE"));
                Date datum = rs.getDate("DATUM");

                BewerkteFoto foto = new BewerkteFoto(fotoNummer, foto_bewerktNummer, x1, y1, x2, y2, type, datum);

                st = client.prepareStatement("SELECT FOTO_BESTAND FROM FOTO WHERE FOTONUMMER = ?;");
                st.setInt(1, fotoNummer);
                ResultSet rs2 = st.executeQuery();
                if (rs2.next()) {
                    Blob blob = rs2.getBlob("FOTO_BESTAND");

                    byte[] bytes = blob.getBytes(1, (int) blob.length());
                    foto.setBytes(bytes);
                }
                rs2.close();

                fotos.add(foto);
            }
            rs.close();
            return fotos;
        }
    }

    public static ArrayList<Foto> getMijnFotos(String email, int dagenTerug) throws SQLException {
        ArrayList<Foto> fotos = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT F.FOTO_BESTAND, F.FOTONUMMER FROM FOTO F WHERE (F.EMAIL = ?) AND `datum` >= DATE_SUB(CURDATE(), INTERVAL ? DAY) ORDER BY RATING DESC;");
            st.setString(1, email);
            st.setInt(2, dagenTerug);
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                Blob blob = rs.getBlob("F.FOTO_BESTAND");
                int fotoNummer = rs.getInt("F.FOTONUMMER");

                Foto foto = new Foto(fotoNummer);
                byte[] bytes = blob.getBytes(1, (int) blob.length());
                foto.setBytes(bytes);
                fotos.add(foto);
            }
            rs.close();
            return fotos;
        }
    }

    public static ArrayList<Foto> getPublicFotos(int dagenTerug) throws SQLException {
        ArrayList<Foto> fotos = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT F.FOTO_BESTAND, F.FOTONUMMER FROM FOTO F WHERE OPENBAAR ='TRUE' AND `datum` >= DATE_SUB(CURDATE(), INTERVAL ? DAY) ORDER BY RATING DESC;");
            st.setInt(1, dagenTerug);
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                Blob blob = rs.getBlob("F.FOTO_BESTAND");
                int fotoNummer = rs.getInt("F.FOTONUMMER");

                Foto foto = new Foto(fotoNummer);
                byte[] bytes = blob.getBytes(1, (int) blob.length());
                foto.setBytes(bytes);
                fotos.add(foto);
            }
            rs.close();
            return fotos;
        }
    }

    /**
     *
     * @return @throws SQLException
     * @throws SQLException
     */
    public static int getLastPhotoNumber() throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT FOTONUMMER FROM FOTO ORDER BY FOTONUMMER DESC LIMIT 1;");
            ResultSet rs = st.executeQuery();
            int nr = rs.getInt("Fotonummer") + 1;
            rs.close();
            return nr;
        }
    }

    /**
     * @param naam
     * @param beschrijving
     * @param voorraad
     * @param prijs
     * @param bytes
     * @return
     * @throws SQLException
     */
    public static boolean productToevoegen(String naam, String beschrijving, int voorraad, double prijs, byte[] bytes) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("INSERT INTO PRODUCT (NAAM, BESCHRIJVING, VOORRAAD, PRIJS, FOTO_BESTAND) VALUES (?, ?, ?, ?, ?);");
            st.setString(1, naam);
            st.setString(2, beschrijving);
            st.setInt(3, voorraad);
            st.setDouble(4, prijs);

            ByteArrayInputStream in = new ByteArrayInputStream(bytes);
            st.setBinaryStream(5, in, in.available());
            return st.executeUpdate() > 0;
        }
    }

    /**
     *
     * @return @throws SQLException
     * @throws SQLException
     */
    public static int getLastProductNumber() throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT PRODUCTNUMMER FROM PRODUCT ORDER BY PRODUCTNUMMER DESC LIMIT 1;");
            ResultSet rs = st.executeQuery();
            int nr = rs.getInt("PRODUCTNUMMER") + 1;
            rs.close();
            return nr;
        }
    }

    /**
     * @return @throws SQLException
     * @throws SQLException
     */
    public static ArrayList<Product> getProducten() throws SQLException {
        ArrayList<Product> producten = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT PRODUCTNUMMER, NAAM, BESCHRIJVING, PRIJS, VOORRAAD, FOTO_BESTAND FROM PRODUCT;");
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                int productnummer = rs.getInt("PRODUCTNUMMER");
                String naam = rs.getString("NAAM");
                String beschrijving = rs.getString("BESCHRIJVING");
                double prijs = rs.getDouble("PRIJS");
                int voorraad = rs.getInt("VOORRAAD");
                Blob blob = rs.getBlob("FOTO_BESTAND");
                byte[] bytes = blob.getBytes(1, (int) blob.length());

                producten.add(new Product(productnummer, naam, beschrijving, voorraad, prijs, bytes));
            }
            rs.close();
            return producten;
        }
    }

    /**
     * @param productnummer
     * @return
     * @throws SQLException
     */
    public static ProductDetails getProductDetails(int productnummer) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT * FROM PRODUCT WHERE PRODUCTNUMMER = ? LIMIT 1;");
            st.setInt(1, productnummer);
            ResultSet rs = st.executeQuery();
            if (!rs.next()) {
                // geen PRODUCT gevonden met id
                return null;
            }
            String productnaam = rs.getString("NAAM");
            String productbeschrijving = rs.getString("BESCHRIJVING");
            double productprijs = rs.getDouble("PRIJS");
            int voorraad = rs.getInt("VOORRAAD");

            rs.close();
            return new ProductDetails(productnaam, productbeschrijving, voorraad, productprijs);
        }
    }

    /**
     *
     * @return @throws SQLException
     * @throws SQLException
     */
    public static ArrayList<Foto> getProductFotos() throws SQLException {
        ArrayList<Foto> productFotos = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT PRODUCTNUMMER, FOTO_BESTAND FROM PRODUCT");

            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                Blob blob = rs.getBlob("FOTO_BESTAND");
                int productNummer = rs.getInt("PRODUCTNUMMER");
                Foto foto = new Foto(productNummer);
                byte[] bytes = blob.getBytes(1, (int) blob.length());
                foto.setBytes(bytes);
                productFotos.add(foto);
            }
            rs.close();
            return productFotos;
        }
    }

    /**
     *
     * @param productnaam
     * @param productbeschrijving
     * @param voorraad
     * @param productprijs
     * @param bytes
     * @param productNummer
     * @return
     * @throws SQLException
     */
    public static boolean wijzigProduct(String productnaam, String productbeschrijving, int voorraad, double productprijs, byte[] bytes, int productNummer) throws SQLException {

        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st;
            if (bytes == null) {
                st = client.prepareStatement("UPDATE PRODUCT SET NAAM = ?, Prijs = ?,  VOORRAAD = ?,  BESCHRIJVING = ? WHERE PRODUCTNUMMER = ? LIMIT 1;");
                st.setString(1, productnaam);
                st.setString(4, productbeschrijving);
                st.setInt(3, voorraad);
                st.setDouble(2, productprijs);
                st.setInt(5, productNummer);
            } else {
                st = client.prepareStatement("UPDATE PRODUCT SET NAAM = ?, Prijs = ? , VOORRAAD = ? , BESCHRIJVING = ? , FOTO_BESTAND = ? WHERE PRODUCTNUMMER = ? LIMIT 1;");
                st.setString(1, productnaam);
                st.setString(4, productbeschrijving);
                st.setInt(3, voorraad);
                st.setDouble(2, productprijs);

                ByteArrayInputStream in = new ByteArrayInputStream(bytes);
                st.setBinaryStream(5, in, in.available());
                st.setInt(6, productNummer);
            }
            return st.executeUpdate() > 0;
        } catch (Exception ex) {
            Logger.getLogger(SqlDatabaseMethods.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    /**
     *
     * @param productnummer
     * @return
     * @throws SQLException
     */
    public static boolean deleteProduct(int productnummer) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("DELETE FROM PRODUCT  WHERE PRODUCTNUMMER = ?  LIMIT 1;");
            st.setInt(1, productnummer);
            return st.executeUpdate() > 0;
        }
    }

    /**
     *
     * @param productnaam
     * @return
     * @throws SQLException
     */
    public static int getProductNummer(String productnaam) throws SQLException {
        int productnummer = 0;
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT PRODUCTNUMMER FROM PRODUCT WHERE NAAM = ?;");
            st.setString(1, productnaam);
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                productnummer = rs.getInt("PRODUCTNUMMER");
            }
            rs.close();
            return productnummer;
        }
    }

    /**
     * @param fotonummer
     * @return
     * @throws SQLException
     */
    public static boolean fotoOpenbaren(int fotonummer) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("UPDATE Foto SET OPENBAAR = 'TRUE' WHERE FOTONUMMER = ? LIMIT 1;");
            st.setInt(1, fotonummer);
            return st.executeUpdate() > 0;
        }
    }

    /**
     *
     * @param email
     * @param type
     * @param fotonummer
     * @return
     * @throws SQLException
     */
    public static int rateFoto(String email, FotograafType type, int fotonummer) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT RATING FROM foto WHERE FOTONUMMER = ? LIMIT 1;");
            st.setInt(1, fotonummer);
            ResultSet rs = st.executeQuery();
            if (rs.next()) {
                int rating = rs.getInt("RATING");
                rs.close();
                if (type == FotograafType.A) {
                    rating += 3;
                } else if (type == FotograafType.B) {
                    rating += 1;
                } else {
                    rating += 1;
                }

                st = client.prepareStatement("SELECT email FROM Rating WHERE fotonummer = ? AND email = ? LIMIT 1;");
                st.setInt(1, fotonummer);
                st.setString(2, email);
                rs = st.executeQuery();

                if (!rs.next()) {
                    rs.close();
                    st = client.prepareStatement("INSERT INTO Rating VALUES (?, ?, NOW(), ?);");
                    st.setString(1, email);
                    st.setInt(2, fotonummer);
                    st.setInt(3, type == FotograafType.A ? 3 : 1);
                    st.executeUpdate();

                    st = client.prepareStatement("UPDATE foto SET RATING = ? WHERE fotonummer = ? LIMIT 1;");
                    st.setInt(1, rating);
                    st.setInt(2, fotonummer);
                    st.executeUpdate();
                    return rating;
                } else {
                    return -1;
                }
            }
        }
        return 0;
    }

    /**
     * @return @throws SQLException
     */
    public static ArrayList<Persoon> getPersonen() throws SQLException {
        ArrayList<Persoon> personen = new ArrayList<>();
        CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
        cq.select(cq.from(Persoon.class));
        personen.addAll(em.createQuery(cq).getResultList());
        return personen;
    }

    public static Persoon GetPersoonGegevens(String email) throws SQLException {
        try {
            Query q = em.createNamedQuery("Persoon.find", Persoon.class);
            q.setParameter("email", email);
            return (Persoon) q.getSingleResult();
        } catch (NoResultException ex) {
            return null;
        }
    }

    public static boolean wijzigPersoonEnWachtwoord(String email, String naam, String wachtwoord, PersoonType type, String adres) throws SQLException {
        Persoon p = null;
        try {
            Query q = em.createNamedQuery("Persoon.find", Persoon.class);
            q.setParameter("email", email);
            p = (Persoon) q.getSingleResult();
        } catch (NoResultException ex) {
            return false;
        }

        p.setEmail(email);
        p.setNaam(naam);
        p.setWachtwoord(wachtwoord);
        p.setType(type.toString());
        p.setAdres(adres);

        if (type == PersoonType.FOTOGRAAF) {
            try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
                PreparedStatement st = client.prepareStatement("DELETE FROM Klant WHERE email=? LIMIT 1;");
                st.setString(1, email);
                st.executeUpdate();

                st = client.prepareStatement("INSERT INTO Fotograaf VALUES (?, 'B');");
                st.setString(1, email);
                st.executeUpdate();
            }
        }
        if (!em.getTransaction().isActive()) {
            em.getTransaction().begin();
        }
        em.merge(p);
        em.getTransaction().commit();
        return true;
    }

    public static boolean wijzigPersoon(String email, String naam, PersoonType type, String adres) throws SQLException {
        Persoon p = null;
        try {
            Query q = em.createNamedQuery("Persoon.find", Persoon.class);
            q.setParameter("email", email);
            p = (Persoon) q.getSingleResult();
        } catch (NoResultException ex) {
            return false;
        }

        p.setEmail(email);
        p.setNaam(naam);
        p.setType(type.toString());
        p.setAdres(adres);

        if (type == PersoonType.FOTOGRAAF) {
            try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
                PreparedStatement st = client.prepareStatement("DELETE FROM Klant WHERE email=? LIMIT 1;");
                st.setString(1, email);
                st.executeUpdate();

                st = client.prepareStatement("INSERT INTO Fotograaf VALUES (?, 'B');");
                st.setString(1, email);
                st.executeUpdate();
            }
        }
        if (!em.getTransaction().isActive()) {
            em.getTransaction().begin();
        }
        em.merge(p);
        em.getTransaction().commit();
        return true;
    }

    public static boolean checkWachtwoord(String email, String wachtwoord) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("Select wachtwoord from PERSOON WHERE email =? AND wachtwoord =? LIMIT 1;");
            st.setString(1, email);
            st.setString(2, wachtwoord);
            ResultSet rs = st.executeQuery();
            return rs.next();
        }
    }
    
    public static ArrayList<OrderRegel> getOrderRegels(int factuurnummer) throws SQLException {
        ArrayList<OrderRegel> orderregels = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT PRODUCTNUMMER, FOTO_KLANTNUMMER, FOTO_BEWERKTNUMMER, AANTAL, PRIJS, ORDER_REGELNUMMER FROM order_regel WHERE FACTUURNUMMER = ?;");
            st.setInt(1, factuurnummer);
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                int productnummer = rs.getInt("PRODUCTNUMMER");
		int aantal = rs.getInt("AANTAL");
		double prijs = rs.getDouble("PRIJS");
                int fotoklantnummer = rs.getInt("FOTO_KLANTNUMMER");
                int fotobewerktnummer = rs.getInt("FOTO_BEWERKTNUMMER");
                int orderregelnummer = rs.getInt("ORDER_REGELNUMMER");
                orderregels.add(new OrderRegel(factuurnummer, fotoklantnummer, productnummer, fotobewerktnummer, orderregelnummer, aantal, prijs));
            }
            rs.close();
            return orderregels;
        }
    }
	
public static ArrayList<Factuur> getAlleFacturen() throws SQLException {
        ArrayList<Factuur> facturen = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT FACTUURNUMMER, EMAIL, DATUM FROM Factuur;");
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                int factuurnummer = rs.getInt("FACTUURNUMMER");
                String email = rs.getString("EMAIL");
		Date datum = rs.getDate("DATUM");
                facturen.add(new Factuur(factuurnummer, email, datum));
            }
            rs.close();
            return facturen;
        }
    }
	
public static ArrayList<Factuur> getKlantFacturen(String email) throws SQLException {
        ArrayList<Factuur> facturen = new ArrayList<>();
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("SELECT FACTUURNUMMER, DATUM FROM Factuur WHERE EMAIL = ?;");
            st.setString(1, email);
            ResultSet rs = st.executeQuery();
            while (rs.next()) {
                int factuurnummer = rs.getInt("FACTUURNUMMER");
		Date datum = rs.getDate("DATUM");
                facturen.add(new Factuur(factuurnummer, email, datum));
            }
            rs.close();
            return facturen;
        }
    }

public static int factuurToevoegen(String email) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("INSERT INTO FACTUUR (EMAIL, DATUM) VALUES (?, NOW());", Statement.RETURN_GENERATED_KEYS);
            st.setString(1, email);
            
            

            st.executeUpdate();
            ResultSet rs = st.getGeneratedKeys();
            if (rs.next()) {
                return rs.getInt(1);
            }
        }
        return 0;
    }
	
public static boolean orderRegelToevoegen(int factuurnummer, int productnummer, int fotoklantnummer, int fotobewerktnummer, int aantal, double prijs) throws SQLException {
        try (SqlDatabaseClient client = Server.getDatabase().getClient()) {
            PreparedStatement st = client.prepareStatement("INSERT INTO ORDER_REGEL (FACTUURNUMMER, PRODUCTNUMMER, FOTO_KLANTNUMMER, FOTO_BEWERKTNUMMER, AANTAL, PRIJS) VALUES (?, ?, ?, ?, ?, ?);");
            st.setInt(1, factuurnummer);
            st.setInt(2, productnummer);
            st.setInt(3, fotoklantnummer);
            st.setInt(4, fotobewerktnummer);
            st.setInt(5, aantal);
            st.setDouble(6, prijs);
			
            return st.executeUpdate() > 0;
        }
    }
}
