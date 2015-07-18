/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client.GUI;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;
import pixel.client.Client;
import pixel.shared.classes.Cube;
import pixel.shared.enums.PersoonType;
import static javax.swing.ScrollPaneConstants.*;
import pixel.shared.enums.FotograafType;

/**
 *
 * @author Remi_Arts
 */
public class HoofdPanel extends javax.swing.JPanel {

    ResourceBundle resBund;
    private ArrayList<Cube> currencies;
    static Double dollarKoers;
    static Double pondKoers;
    static Double levKoers;
    private int dagenTerug;

    /**
     * Creates new form HoofdPanel
     */
    public HoofdPanel() {
        initComponents();
        jScrollPane1.setHorizontalScrollBarPolicy(HORIZONTAL_SCROLLBAR_NEVER);
        UpdateLanguage();
        dagenTerug = 7;

        SortCB.removeAllItems();
        SortCB.addItem(resBund.getString("SORT_LASTWEEK"));
        SortCB.addItem(resBund.getString("SORT_LASTMONTH"));
        SortCB.addItem(resBund.getString("SORT_ALL"));

        SortCB.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if (SortCB.getSelectedItem().equals(resBund.getString("SORT_LASTWEEK"))) {
                    dagenTerug = 7;
                } else if (SortCB.getSelectedItem().equals(resBund.getString("SORT_LASTMONTH"))) {
                    dagenTerug = 30;
                } else if (SortCB.getSelectedItem().equals(resBund.getString("SORT_ALL"))) {
                    //nog geen nette oplossing
                    dagenTerug = 9999;
                }
                reloadFotos();
            }
        });

        PersoonType type = Client.getLoggedinAccount().getType();
        FotoTypeCB.removeAllItems();

        //nog niet vertaalvriendelijk
        if (type == PersoonType.FOTOGRAAF) {
            FotoTypeCB.addItem(resBund.getString("SORT_MYPICTURES"));
            FotoTypeCB.addItem(resBund.getString("SORT_LINKED"));
            FotoTypeCB.addItem(resBund.getString("SORT_PUBLIC"));
            miniatuurWeergaven1.LoadMijnFotos(dagenTerug);
        } else if (type == PersoonType.FOTOPRODUCENT) {
            FotoTypeCB.addItem(resBund.getString("SORT_PUBLIC"));
            miniatuurWeergaven1.LoadPublicFotos(dagenTerug);
        } else if (type == PersoonType.KLANT) {
            FotoTypeCB.addItem(resBund.getString("SORT_LINKED"));
            FotoTypeCB.addItem(resBund.getString("SORT_PUBLIC"));
            miniatuurWeergaven1.LoadGekoppeldeFotos(dagenTerug);
        }

        FotoTypeCB.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                reloadFotos();
            }
        });

        getCurrencies();
    }

    public void reloadFotos() {
        //nog niet vertaalvriendelijk
        if (FotoTypeCB.getSelectedItem().equals(resBund.getString("SORT_MYPICTURES"))) {
            miniatuurWeergaven1.LoadMijnFotos(dagenTerug);
        } else if (FotoTypeCB.getSelectedItem().equals(resBund.getString("SORT_LINKED"))) {
            miniatuurWeergaven1.LoadGekoppeldeFotos(dagenTerug);
        } else if (FotoTypeCB.getSelectedItem().equals(resBund.getString("SORT_PUBLIC"))) {
            miniatuurWeergaven1.LoadPublicFotos(dagenTerug);
        }
    }

    /**
     */
    public void getCurrencies() {
        try {
            currencies = Client.getServerConnection().getCurrencies();
            System.out.println(currencies.size() + " currencies retrieved.");
        } catch (RemoteException ex) {
            Logger.getLogger(HoofdPanel.class.getName()).log(Level.SEVERE, null, ex);
        }

        for (Cube curr : currencies) {
            switch (curr.getCurrency()) {
                case "USD":
                    dollarKoers = curr.getRate();
                    break;
                case "GBP":
                    pondKoers = curr.getRate();
                    break;
                case "BGN":
                    levKoers = curr.getRate();
                    break;
            }
        }
        System.out.println("Dollar: " + dollarKoers + "\nPond: " + pondKoers + "\nLev: " + levKoers);
    }

    private void UpdateLanguage() {
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        lbl_datum.setText(resBund.getString("DATE"));
        lbl_fotograaf.setText(resBund.getString("PHOTOGRAPHER"));
        lbl_prijs.setText(resBund.getString("PRICEIN") + " " + resBund.getString("CURRENCY"));
        //previewPhoto.setText(resBund.getString("PREVIEW"));
        this.setName(resBund.getString("HEADPANEL"));
        btn_wijzigGegevens.setText(resBund.getString("WIJZIGGEGEVENS"));
        btn_Uitloggen.setText(resBund.getString("LOGOUT"));
        jLabel1.setText(resBund.getString("EDIT_PHOTO"));
        jLabel2.setText(resBund.getString("PHOTO_DETAILS"));
        btn_like.setText(resBund.getString("LIKEBUTTON"));
    }

    /**
     *
     * @return
     */
    public MiniatuurWeergaven getMiniatuurWeergaven() {
        return this.miniatuurWeergaven1;
    }

    /**
     *
     * @return
     */
    public static Double getDollarKoers() {
        return dollarKoers;
    }

    /**
     *
     * @return
     */
    public static Double getPondKoers() {
        return pondKoers;
    }

    /**
     *
     * @return
     */
    public static Double getLevKoers() {
        return levKoers;
    }

    //setters voor labels fotodetails
    /**
     *
     * @param naam
     */
    public void setFotograafNaam(String naam) {
        this.lbl_fotograafNaam.setText(naam);
    }

    /**
     *
     * @param prijs
     */
    public void setHuidigePrijs(String prijs) {
        this.lbl_huidigePrijs.setText(prijs);
    }

    /**
     *
     * @param datum
     */
    public void setHuidigeDatum(String datum) {
        this.lbl_huidigeDatum.setText(datum);
    }

    /**
     *
     * @param rating
     */
    public void setRating(String rating) {
        this.lbl_rating.setText(rating);
    }

    /**
     *
     * @param enabled
     */
    public void setLikeButtonEnabled(boolean enabled) {
        this.btn_like.setEnabled(enabled);
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel2 = new javax.swing.JPanel();
        lbl_fotograaf = new javax.swing.JLabel();
        lbl_fotograafNaam = new javax.swing.JLabel();
        lbl_huidigePrijs = new javax.swing.JLabel();
        lbl_prijs = new javax.swing.JLabel();
        lbl_huidigeDatum = new javax.swing.JLabel();
        lbl_datum = new javax.swing.JLabel();
        activePanel = new javax.swing.JPanel();
        jScrollPane1 = new javax.swing.JScrollPane();
        miniatuurWeergaven1 = new pixel.client.GUI.MiniatuurWeergaven();
        jSeparator1 = new javax.swing.JSeparator();
        jLabel1 = new javax.swing.JLabel();
        lbl_ratingText = new javax.swing.JLabel();
        lbl_rating = new javax.swing.JLabel();
        btn_like = new javax.swing.JButton();
        jLabel2 = new javax.swing.JLabel();
        btn_wijzigGegevens = new javax.swing.JButton();
        btn_Uitloggen = new javax.swing.JButton();
        FotoTypeCB = new javax.swing.JComboBox();
        SortCB = new javax.swing.JComboBox();

        setName("Hoofd Paneel"); // NOI18N

        javax.swing.GroupLayout jPanel2Layout = new javax.swing.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 0, Short.MAX_VALUE)
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 295, Short.MAX_VALUE)
        );

        lbl_fotograaf.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        lbl_fotograaf.setText("Fotograaf:");
        lbl_fotograaf.setHorizontalTextPosition(javax.swing.SwingConstants.LEFT);

        lbl_fotograafNaam.setText("--");

        lbl_huidigePrijs.setText("--");

        lbl_prijs.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        lbl_prijs.setText("Prijs in €:");
        lbl_prijs.setHorizontalTextPosition(javax.swing.SwingConstants.LEFT);

        lbl_huidigeDatum.setText("--");

        lbl_datum.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        lbl_datum.setText("Datum:");
        lbl_datum.setHorizontalTextPosition(javax.swing.SwingConstants.LEFT);

        activePanel.setName(""); // NOI18N

        javax.swing.GroupLayout activePanelLayout = new javax.swing.GroupLayout(activePanel);
        activePanel.setLayout(activePanelLayout);
        activePanelLayout.setHorizontalGroup(
            activePanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 530, Short.MAX_VALUE)
        );
        activePanelLayout.setVerticalGroup(
            activePanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 124, Short.MAX_VALUE)
        );

        PersoonType type = Client.getLoggedinAccount().getType();
		FotograafType ftype = Client.getLoggedinAccount().getFtype();
        if (type == PersoonType.FOTOGRAAF) {
            if (ftype == FotograafType.A) {
                activePanel = new FotograafHolderPanel(this);
            }
            else {
                activePanel = new BFotograafHolderPanel(this);
            } 
        } else if (type == PersoonType.FOTOPRODUCENT) {
            activePanel = new FotoproducentHolderPanel(this);
        } else if (type == PersoonType.KLANT) {
            activePanel = new KlantHolderPanel(this);
        }

        miniatuurWeergaven1.setAutoscrolls(true);
        miniatuurWeergaven1.setName(""); // NOI18N

        javax.swing.GroupLayout miniatuurWeergaven1Layout = new javax.swing.GroupLayout(miniatuurWeergaven1);
        miniatuurWeergaven1.setLayout(miniatuurWeergaven1Layout);
        miniatuurWeergaven1Layout.setHorizontalGroup(
            miniatuurWeergaven1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 716, Short.MAX_VALUE)
        );
        miniatuurWeergaven1Layout.setVerticalGroup(
            miniatuurWeergaven1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 378, Short.MAX_VALUE)
        );

        jScrollPane1.setViewportView(miniatuurWeergaven1);

        jSeparator1.setOrientation(javax.swing.SwingConstants.VERTICAL);

        jLabel1.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel1.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabel1.setText("Bewerk geselecteerde foto:");

        lbl_ratingText.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
        lbl_ratingText.setText("Rating:");
        lbl_ratingText.setHorizontalTextPosition(javax.swing.SwingConstants.LEFT);

        lbl_rating.setText("--");

        btn_like.setText("Vind ik leuk");
        btn_like.setEnabled(false);
        btn_like.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_likeActionPerformed(evt);
            }
        });

        jLabel2.setFont(new java.awt.Font("Tahoma", 1, 11)); // NOI18N
        jLabel2.setText("Foto details:");

        btn_wijzigGegevens.setText("Wijzig persoonlijke gegevens");
        btn_wijzigGegevens.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_wijzigGegevensActionPerformed(evt);
            }
        });

        btn_Uitloggen.setText("Uitloggen");
        btn_Uitloggen.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_UitloggenActionPerformed(evt);
            }
        });

        FotoTypeCB.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Item 1", "Item 2", "Item 3", "Item 4" }));

        SortCB.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Item 1", "Item 2", "Item 3", "Item 4" }));

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(btn_wijzigGegevens)
                                .addGap(126, 126, 126)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(FotoTypeCB, javax.swing.GroupLayout.PREFERRED_SIZE, 181, javax.swing.GroupLayout.PREFERRED_SIZE)
                                    .addComponent(SortCB, javax.swing.GroupLayout.PREFERRED_SIZE, 181, javax.swing.GroupLayout.PREFERRED_SIZE))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addComponent(btn_Uitloggen, javax.swing.GroupLayout.PREFERRED_SIZE, 100, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 735, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(jPanel2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(activePanel, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(184, 184, 184)
                                .addComponent(jLabel1)))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, 19, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(30, 30, 30)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                                        .addComponent(lbl_prijs)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                        .addComponent(lbl_huidigePrijs, javax.swing.GroupLayout.PREFERRED_SIZE, 75, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                                        .addComponent(lbl_fotograaf)
                                        .addGap(18, 18, 18)
                                        .addComponent(lbl_fotograafNaam, javax.swing.GroupLayout.PREFERRED_SIZE, 75, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(lbl_datum)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                        .addComponent(lbl_huidigeDatum, javax.swing.GroupLayout.PREFERRED_SIZE, 75, javax.swing.GroupLayout.PREFERRED_SIZE))
                                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                                        .addComponent(lbl_ratingText)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                        .addComponent(lbl_rating, javax.swing.GroupLayout.PREFERRED_SIZE, 75, javax.swing.GroupLayout.PREFERRED_SIZE))))
                            .addGroup(layout.createSequentialGroup()
                                .addGap(65, 65, 65)
                                .addComponent(btn_like))
                            .addGroup(layout.createSequentialGroup()
                                .addGap(67, 67, 67)
                                .addComponent(jLabel2)))))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGap(5, 5, 5)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(12, 12, 12)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(btn_wijzigGegevens)
                                    .addComponent(btn_Uitloggen))
                                .addGap(19, 19, 19))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(FotoTypeCB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addComponent(SortCB, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)))
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 308, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addComponent(jPanel2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(4, 4, 4)
                                .addComponent(jLabel1))
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(jLabel2)))
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addGap(16, 16, 16)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(lbl_fotograaf)
                                    .addComponent(lbl_fotograafNaam))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(lbl_prijs)
                                    .addComponent(lbl_huidigePrijs))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(lbl_huidigeDatum)
                                    .addComponent(lbl_datum))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                                    .addComponent(lbl_ratingText)
                                    .addComponent(lbl_rating))
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(btn_like)
                                .addContainerGap(22, Short.MAX_VALUE))
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(activePanel, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addContainerGap())))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jSeparator1)
                        .addContainerGap())))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_wijzigGegevensActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_wijzigGegevensActionPerformed
        if (this.miniatuurWeergaven1.getPreviewFrame() != null) {
            this.miniatuurWeergaven1.getPreviewFrame().dispose();
        }
        Client.getFrame().loadPanel(new WijzigGegevensPanel());
    }//GEN-LAST:event_btn_wijzigGegevensActionPerformed

    private void btn_likeActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_likeActionPerformed
        try {
            int rating = Client.getServerConnection().rateFoto(Client.getLoggedinAccount().getEmail(), Client.getLoggedinAccount().getFtype(), (int) this.miniatuurWeergaven1.getGeselecteerdeFoto().getFotoNummer());
            if (rating != -1) {
                this.lbl_rating.setText("" + rating);
            } else {
                JOptionPane.showMessageDialog(this, resBund.getString("LIKE_MESSAGE"), resBund.getString("ERROR"), JOptionPane.INFORMATION_MESSAGE);
                btn_like.setEnabled(false);
            }
        } catch (RemoteException ex) {
            Logger.getLogger(HoofdPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_btn_likeActionPerformed

    private void btn_UitloggenActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_UitloggenActionPerformed
        try {
            if (getMiniatuurWeergaven().getPreviewFrame() != null) {
                this.getMiniatuurWeergaven().getPreviewFrame().dispose();
            }
            Client.getServerConnection().uitloggen(Client.getLoggedinAccount().getEmail());
            Client.setLoggedinAccount(null);
            Client.getFrame().loadPanel(new LoginPanel());
        } catch (RemoteException ex) {
            Logger.getLogger(HoofdPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_btn_UitloggenActionPerformed
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JComboBox FotoTypeCB;
    private javax.swing.JComboBox SortCB;
    private javax.swing.JPanel activePanel;
    private javax.swing.JButton btn_Uitloggen;
    private javax.swing.JButton btn_like;
    private javax.swing.JButton btn_wijzigGegevens;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JSeparator jSeparator1;
    private javax.swing.JLabel lbl_datum;
    private javax.swing.JLabel lbl_fotograaf;
    private javax.swing.JLabel lbl_fotograafNaam;
    private javax.swing.JLabel lbl_huidigeDatum;
    private javax.swing.JLabel lbl_huidigePrijs;
    private javax.swing.JLabel lbl_prijs;
    private javax.swing.JLabel lbl_rating;
    private javax.swing.JLabel lbl_ratingText;
    private pixel.client.GUI.MiniatuurWeergaven miniatuurWeergaven1;
    // End of variables declaration//GEN-END:variables
}
