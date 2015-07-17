/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package gui;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;
import javax.swing.event.TreeModelListener;
import javax.swing.event.TreeSelectionEvent;
import javax.swing.event.TreeSelectionListener;
import javax.swing.tree.TreeModel;
import javax.swing.tree.TreePath;
import stamboom.Geslacht;
import stamboom.Persoon;
import stamboom.Relatie;

/**
 *
 * @author Remi_Arts
 */
public class Tree extends javax.swing.JFrame {

    private Persoon root;
    private String[] columnNames = {"Ouder",
                        "Voornaam",
                        "Achternaam",
                        "Geboortedatum",
                        "Geslacht"};
    private ArrayList<Persoon> personen;
    
    /**
     * Creates new form StamboomTree
     */
    public Tree(final Persoon root, final ArrayList<Persoon> personen) {
        initComponents();
        this.root = root;
        this.personen = personen;
        personen.remove(personen.size() - 1);
        
        // Override de treemodel omdat we een boom van Persoon objecten maken.
        this.tree.setModel(new TreeModel(){

            public Object getRoot() {
                return root;
            }

            
            /**
             * Verkrijg ouder 1 of ouder 2 van persoon parent, afhankelijk van index
             * Als index out of bounds: null
             * Als parent null: null
             */
            public Object getChild(Object parent, int index) {
                if(parent == null) return null;
                Persoon parentpersoon = (Persoon) parent;
                if(parentpersoon.getVoornamen().equalsIgnoreCase("root")) return personen.get(index);
                Relatie ouders = parentpersoon.getOuders();
                if(ouders == null) return null;
                if(index == 0 && ouders.getPartner1() != null) return ouders.getPartner1();
                else if(index == 0) return ouders.getPartner2();
                if(index == 1) return ouders.getPartner2();
                return null;
            }

            
            /**
             * Verkrijg het aantal ouder van persoon parent
             */
            public int getChildCount(Object parent) {
                if(parent == null) return 0;
                Persoon parentpersoon = (Persoon) parent;
                if(parentpersoon.getVoornamen().equalsIgnoreCase("root")) return personen.size();
                Relatie ouders = parentpersoon.getOuders();
                if(ouders == null) return 0;
                int ouderscount = 0;
                if(ouders.getPartner1()!= null) ouderscount++;
                if(ouders.getPartner2() != null) ouderscount++;
                return ouderscount;
            }

            
            /**
             * Als de persoon geen ouder heeft: true
             * Anders false
             */
            public boolean isLeaf(Object node) {
                if(node == null) return false;
                Persoon parentpersoon = (Persoon) node;
                if(parentpersoon.getVoornamen().equalsIgnoreCase("root")) return false;
                Relatie ouders = parentpersoon.getOuders();
                if(ouders == null || 
                        (ouders.getPartner1()== null && ouders.getPartner2() == null)) return true;
                return false;
            }

            public void valueForPathChanged(TreePath path, Object newValue) {
                throw new UnsupportedOperationException("Not supported yet.");
            }

            public int getIndexOfChild(Object parent, Object child) {
                throw new UnsupportedOperationException("Not supported yet.");
            }

            public void addTreeModelListener(TreeModelListener l) {
                
            }

            public void removeTreeModelListener(TreeModelListener l) {
                
            }
        });
        this.tree.setRootVisible(false);
        
        // Toon gegevens in de JTable als een item geselecteerd wordt in de JTree.
        this.tree.addTreeSelectionListener(new TreeSelectionListener(){
            public void valueChanged(TreeSelectionEvent e) {
                // Zoek het geselecteerde persoon
                Persoon persoon = (Persoon) tree.getLastSelectedPathComponent();
                if(persoon == null) return;
                
                ArrayList<Object[]> data_array = new ArrayList<Object[]>();
                Set<Relatie> gezinnen_array = new HashSet<Relatie>();
                
                Relatie ouders = persoon.getOuders();
                if(ouders != null) {
                    Persoon ouder1 = ouders.getPartner1();
                    Persoon ouder2 = ouders.getPartner2();
                    
                    if(ouder1 != null) {
                        printPersoon(data_array, ouder1, "Ouder");
                        gezinnen_array.addAll(getPersoonGezinnen(ouder1));
                    }
                    if(ouder2 != null) {
                        printPersoon(data_array, ouder2, "Ouder");
                        gezinnen_array.addAll(getPersoonGezinnen(ouder2));
                    }
                    
                    // Print kinderen van alle gezinnen
                    Iterator<Relatie> gezinit = gezinnen_array.iterator();
                    while(gezinit.hasNext()) {
                        Relatie g = gezinit.next();
                        printGezinKinderen(data_array, g);
                    }
                }
                
                table.setModel(new javax.swing.table.DefaultTableModel(
                    arrayListToObjectArray(data_array), columnNames));
            }
        });
        
    }
    
    
    /**
     * Converteer List<Object[]> naar Object[][]
     * @param data_array
     * @return Object[][] van data_array
     */
    private Object[][] arrayListToObjectArray(ArrayList<Object[]> data_array) {
        int arraysize = data_array.size();
        Object[][] data = new Object[arraysize][5];
        for(int i = 0; i < arraysize; i++) {
            data[i] = data_array.get(i);
        }
        return data;
    }
    
    
    /**
     * Verkrijg gezinnen van en persoon
     * @param persoon
     * @return 
     */
    private Set<Relatie> getPersoonGezinnen(Persoon persoon) {
        Set<Relatie> gezinnen_array = new HashSet<Relatie>();
        if(persoon == null) return gezinnen_array;
        
        Iterator<Relatie> gezinnen = persoon.getRelaties();
        while(gezinnen.hasNext()) {
            gezinnen_array.add(gezinnen.next());
        }
        
        return gezinnen_array;
    }
    
    
    /**
     * Print alle kinderen van een gezin
     * @param data_array
     * @param gezin 
     */
    private void printGezinKinderen(ArrayList<Object[]> data_array, Relatie gezin) {
        Iterator<Persoon> kinderen = gezin.getKinderen();
        while(kinderen.hasNext()) {
            Persoon kind = kinderen.next();
            printPersoon(data_array, kind, "Kind");
        }
    }
    
    
    /**
     * Print een persoon op een JTable lijst
     * @param data_array De JTable lijst
     * @param persoon
     * @param ouderOfKind De persoon is een "Ouder" of "Kind"
     */
    private void printPersoon(ArrayList<Object[]> data_array, Persoon persoon, String ouderOfKind) {
        data_array.add(new Object[]{ouderOfKind, persoon.getVoornamen(),
            persoon.getAchternaam(), persoon.getGebdat(), (persoon.getGeslacht() == Geslacht.MAN) ? "♂" : "♀"});
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        tree = new javax.swing.JTree();
        jScrollPane2 = new javax.swing.JScrollPane();
        table = new javax.swing.JTable();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        jScrollPane1.setViewportView(tree);

        table.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null},
                {null, null, null, null}
            },
            new String [] {
                "Title 1", "Title 2", "Title 3", "Title 4"
            }
        ));
        jScrollPane2.setViewportView(table);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 181, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 426, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 348, Short.MAX_VALUE)
            .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 0, Short.MAX_VALUE)
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JTable table;
    private javax.swing.JTree tree;
    // End of variables declaration//GEN-END:variables
}
