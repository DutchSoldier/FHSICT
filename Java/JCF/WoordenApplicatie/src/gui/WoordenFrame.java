package gui;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.SortedSet;
import java.util.TreeSet;
import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.WindowConstants;
import javax.swing.SwingUtilities;

/**
 * This code was edited or generated using CloudGarden's Jigloo SWT/Swing GUI
 * Builder, which is free for non-commercial use. If Jigloo is being used
 * commercially (ie, by a corporation, company or business for any purpose
 * whatever) then you should purchase a license for each developer using Jigloo.
 * Please visit www.cloudgarden.com for details. Use of Jigloo implies
 * acceptance of these licensing terms. A COMMERCIAL LICENSE HAS NOT BEEN
 * PURCHASED FOR THIS MACHINE, SO JIGLOO OR THIS CODE CANNOT BE USED LEGALLY FOR
 * ANY CORPORATE OR COMMERCIAL PURPOSE.
 */
public class WoordenFrame extends javax.swing.JFrame {

    private static final long serialVersionUID = 1L;
    private JPanel pnInput;
    private JPanel pnOutput;
    private JButton btConcordantie;
    private JButton btFrequentie;
    private JButton btSorteer;
    private JButton btAantal;
    private JScrollPane spInput;
    private JTextArea taOutput;
    private JTextArea taInput;
    private JScrollPane spOutput;

    /**
     * Auto-generated main method to display this JFrame
     */
    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                WoordenFrame inst = new WoordenFrame();
                inst.setLocationRelativeTo(null);
                inst.setVisible(true);
            }
        });
    }

    public WoordenFrame() {
        super();
        initGUI();
    }

    private void initGUI() {
        try {
            setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
            this.setTitle("Woorden");
            getContentPane().setLayout(null);
            {
                pnInput = new JPanel();
                getContentPane().add(pnInput);
                pnInput.setLayout(null);
                pnInput.setBounds(12, 12, 368, 124);
                pnInput.setBorder(BorderFactory.createTitledBorder("Input"));
                pnInput.setLayout(null);
                {
                    btAantal = new JButton();
                    pnInput.add(btAantal);
                    btAantal.setText("Aantal");
                    btAantal.setBounds(243, 20, 114, 21);
                    btAantal.addActionListener(new ActionListener() {
                        public void actionPerformed(ActionEvent evt) {
                            btAantalActionPerformed(evt);
                        }
                    });
                }
                {
                    btSorteer = new JButton();
                    pnInput.add(btSorteer);
                    btSorteer.setText("Sorteer");
                    btSorteer.setBounds(243, 44, 114, 21);
                    btSorteer.addActionListener(new ActionListener() {
                        public void actionPerformed(ActionEvent evt) {
                            btSorteerActionPerformed(evt);
                        }
                    });
                }
                {
                    btFrequentie = new JButton();
                    pnInput.add(btFrequentie);
                    btFrequentie.setText("Frequentie");
                    btFrequentie.setBounds(243, 68, 114, 21);
                    btFrequentie.addActionListener(new ActionListener() {
                        public void actionPerformed(ActionEvent evt) {
                            btFrequentieActionPerformed(evt);
                        }
                    });
                }
                {
                    btConcordantie = new JButton();
                    pnInput.add(btConcordantie);
                    btConcordantie.setText("Concordantie");
                    btConcordantie.setBounds(243, 93, 114, 21);
                    btConcordantie.addActionListener(new ActionListener() {
                        public void actionPerformed(ActionEvent evt) {
                            btConcordantieActionPerformed(evt);
                        }
                    });
                }
                {
                    spInput = new JScrollPane();
                    pnInput.add(spInput);
                    spInput.setBounds(12, 19, 219, 95);
                    {
                        taInput = new JTextArea();
                        spInput.setViewportView(taInput);
                    }
                }
            }
            {
                pnOutput = new JPanel();
                getContentPane().add(pnOutput);
                pnOutput.setBorder(BorderFactory.createTitledBorder("Output"));
                pnOutput.setBounds(11, 142, 367, 121);
                pnOutput.setLayout(null);
                {
                    spOutput = new JScrollPane();
                    pnOutput.add(spOutput);
                    spOutput.setBounds(12, 19, 344, 89);
                    {
                        taOutput = new JTextArea();
                        spOutput.setViewportView(taOutput);
                    }
                }
            }
            pack();
            setSize(400, 300);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void btAantalActionPerformed(ActionEvent evt) {
        //Haal de woorden op uit het input veld
        String[] words = this.getWords();
        //Zet de woorden in een hashset zodat alleen de unieke woorden erin komen
        Set<String> uniqueWords = new HashSet<String>();
        for (String s : words) {
            uniqueWords.add(s);
        }
        taOutput.append("Totaal aantal woorden: " + words.length);
        taOutput.append("\nAantal verschillende woorden: " + uniqueWords.size());
    }

    private void btSorteerActionPerformed(ActionEvent evt) {
        //Zet de woorden in een treeset. deze wordt automatisch geordend.
        String[] words = this.getWords();
        TreeSet<String> sortedWords = new TreeSet<String>();
        sortedWords.addAll(Arrays.asList(words));

        //Laat de woorden in omgekeerde volgorde uit de lijst zien, deze worden dan in omgekeerde alfabetische volgorde weergegeven
        Iterator iterator;
        iterator = sortedWords.descendingIterator();
        while (iterator.hasNext()) {
            taOutput.append((String)iterator.next() + "\n");
        }
    }

    private void btFrequentieActionPerformed(ActionEvent evt) {
        //Haal de woorden op en maak een hashset met unieke woorden aan
        String[] words = this.getWords();
        ArrayList<String> wordList = new ArrayList<String>();
        Set<String> uniqueWords = new HashSet<String>();
        //Maak een map aan om de frequentie per woord duidelijk te laten zien
        Map<String, Integer> wordFrequency = new HashMap<String, Integer>();
        
        wordList.addAll(Arrays.asList(words));
        uniqueWords.addAll(Arrays.asList(words));
        
        //Bepaal de frequentie van elk woord en zet deze in de map
        for (String word : uniqueWords) {
            Integer frequency = Collections.frequency(wordList, word);
            wordFrequency.put(word, frequency);
        }
        
        //Sorteer de map op frequentie en laat deze zien in het output veld
        for (Entry<String, Integer> entry  : entriesSortedByValues(wordFrequency)) {
            taOutput.append(entry.getKey() + " : " + entry.getValue() + "\n");
        }
    }

    private void btConcordantieActionPerformed(ActionEvent evt) {
        taOutput.setText("");
        //Maak een array met de input gesplitsd per regel en per woord
        String[] lines = taInput.getText().split("\\n");
        String[] words = this.getWords();
        
        //Maak een hashset aan met unieke woorden
        Set<String> uniqueWords = new HashSet<String>();
        uniqueWords.addAll(Arrays.asList(words));
        
        //Maak een map aan en zet hier ieder uniek woord in en een arraylist voor de regel nummers waar het woord voorkomt
        Map<String, ArrayList<Integer>> wordMap = new HashMap<String, ArrayList<Integer>>();
        
        //Zet de woorden in de map
        for (String word : uniqueWords) {
            wordMap.put(word, new ArrayList<Integer>());
        }
        
        //Check via de array met regels tekst waar het woord voorkomt en zet dit in de arraylist in de map
        for (String word : uniqueWords) {
            for (int i = 0; i < lines.length; i++) {
                if (lines[i].contains(word)) {
                    wordMap.get(word).add(i+1);
                }
            }
        }
        
        //Laat in het output veld voor ieder woord zien op welke regels het voorkomt
        for (String key : wordMap.keySet()) {
            String lineString = "";
            for (Integer i : wordMap.get(key)) {
                lineString += i;
                int last = wordMap.get(key).size() -1;
                if (!wordMap.get(key).get(last).equals(i)) {
                    lineString += ", ";
                }
            }
            taOutput.append(key + " : [" + lineString + "]\n");
        }
    }
    
    private String[] getWords() {
        //Haal de text uit het input veld en split deze string in woorden
        taOutput.setText("");
        String inputText = taInput.getText();
        String[] words = inputText.split("\\W+");
        return words;
    }
    
    //Haal de entries uit de map met woorden en frequenties. 
    //Deze worden op frequentie gesorteerd via een comparator en worden in een treeset teruggegeven
    <K,V extends Comparable<? super V>> SortedSet<Map.Entry<K,V>> entriesSortedByValues(Map<K,V> map) {
        SortedSet<Map.Entry<K,V>> sortedEntries = new TreeSet<Map.Entry<K,V>>(
            new Comparator<Map.Entry<K,V>>() {
                @Override public int compare(Map.Entry<K,V> e1, Map.Entry<K,V> e2) {
                    int res = e1.getValue().compareTo(e2.getValue());
                    return res != 0 ? res : 1;
                }
            }
        );
        sortedEntries.addAll(map.entrySet());
        return sortedEntries;
    }
}
