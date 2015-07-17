package gui;

import domein.HuffLeaf;
import domein.HuffmanCalc;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.TreeMap;
import javax.swing.BorderFactory;
import javax.swing.JButton;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.WindowConstants;
import javax.swing.SwingUtilities;

public class HufFrame extends javax.swing.JFrame {
    /** Counts frequency of each character **/
    private TreeMap<Character, Integer> character_frequency;
    /** An instance of the HuffmanCalc, which does all calculations **/
    private HuffmanCalc calc;
    /** The Huffman tree which is made of all characters en frequency **/
    private HuffLeaf tree;
    
    private static final long serialVersionUID = 1L;
    private JPanel pnl_input;
    private JPanel pnl_output;
    private JButton btn_decode;
    private JButton btn_encode;
    private JButton btn_createTree;
    private JButton btn_frequency;
    private JScrollPane spn_input;
    private JTextArea taOutput;
    private JTextArea taInput;
    private JScrollPane spn_output;
    
    /**
     * Auto-generated main method to display this JFrame
     */
    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                HufFrame inst = new HufFrame();
                inst.setLocationRelativeTo(null);
                inst.setVisible(true);
            }
        });
    }

    public HufFrame() {
        super();
        initGUI();
    }

    private void initGUI() {
        calc = new HuffmanCalc();
        try {
            setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
            this.setTitle("Words");
            getContentPane().setLayout(null);
            {
                pnl_input = new JPanel();
                getContentPane().add(pnl_input);
                pnl_input.setLayout(null);
                pnl_input.setBounds(12, 12, 468, 148);
                pnl_input.setBorder(BorderFactory.createTitledBorder("Input"));
                pnl_input.setLayout(null);
                {
                    btn_frequency = new JButton();
                    pnl_input.add(btn_frequency);
                    btn_frequency.setText("Calculate frequencies");
                    btn_frequency.setBounds(243, 20, 214, 21);
                    btn_frequency.addActionListener(new ActionListener() {
                        @Override
                        public void actionPerformed(ActionEvent evt) {
                            btn_frequencyActionPerformed(evt);
                        }
                    });
                }
   
                {
                    btn_createTree = new JButton();
                    pnl_input.add(btn_createTree);
                    btn_createTree.setText("Create tree");
                    btn_createTree.setBounds(243, 44, 214, 21);
                    btn_createTree.addActionListener(new ActionListener() {
                        @Override
                        public void actionPerformed(ActionEvent evt) {
                            btn_createTreeActionPerformed(evt);
                        }
                    });
                }
                {
                    btn_encode = new JButton();
                    pnl_input.add(btn_encode);
                    btn_encode.setText("Encode");
                    btn_encode.setBounds(243, 68, 214, 21);
                    btn_encode.addActionListener(new ActionListener() {
                        @Override
                        public void actionPerformed(ActionEvent evt) {
                            btn_encodeActionPerformed(evt);
                        }
                    });
                }
                {
                    btn_decode = new JButton();
                    pnl_input.add(btn_decode);
                    btn_decode.setText("Decode");
                    btn_decode.setBounds(243, 92, 214, 21);
                    btn_decode.addActionListener(new ActionListener() {
                        @Override
                        public void actionPerformed(ActionEvent evt) {
                            btn_decodeActionPerformed(evt);
                        }
                    });
                }
                {
                    spn_input = new JScrollPane();
                    pnl_input.add(spn_input);
                    spn_input.setBounds(12, 19, 219, 95);
                    {
                        taInput = new JTextArea();
                        spn_input.setViewportView(taInput);
                        taInput.setText("teststring");
                    }
                }
            }
            {
                pnl_output = new JPanel();
                getContentPane().add(pnl_output);
                pnl_output.setBorder(BorderFactory.createTitledBorder("Output"));
                pnl_output.setBounds(11, 168, 467, 221);
                pnl_output.setLayout(null);
                {
                    spn_output = new JScrollPane();
                    pnl_output.add(spn_output);
                    spn_output.setBounds(12, 19, 344, 89);
                    {
                        taOutput = new JTextArea();
                        taOutput.setText("otherteststring");
                        spn_output.setViewportView(taOutput);
                    }
                }
            }
            pack();
            setSize(500, 330);
        } 
        catch (Exception e) {
        }
    }

    
    /**
     * Calculate frequency of each character 
     * @param evt 
     */
    private void btn_frequencyActionPerformed(ActionEvent evt) {
        String input = taInput.getText();
        Map<Character, Integer> character_frequency_unsorted = calc.count_characters(input);
        character_frequency = calc.sort_characters(character_frequency_unsorted);
        
        StringBuilder sb = new StringBuilder();
        for(Entry<Character, Integer> entry : character_frequency.entrySet()) {
            sb.append(entry.getKey()).append(" = ").append(entry.getValue()).append("\n");
        }
        taOutput.setText(sb.toString());
    }
    
    /**
     * Create huffman tree from characters en frequencies
     * @param evt 
     */
    private void btn_createTreeActionPerformed(ActionEvent evt) {
        if(character_frequency == null) {
            return;
        }
        tree = calc.createTree(character_frequency);
        taOutput.setText("Huffman tree created");
    }

    /**
     * Encode input String with Huffman tree
     * @param evt 
     */
    private void btn_encodeActionPerformed(ActionEvent evt) {
        if(tree == null) {
            JOptionPane.showMessageDialog(rootPane, "Create Huffman tree first to encode text");
            return;
        }
        String input = taInput.getText();
        List<Boolean> binary = calc.encodeTree(input, tree);
        
        StringBuilder sb = new StringBuilder();
        for(boolean b : binary) {
            sb.append(b ? '1':'0');
        }
        taOutput.setText(sb.toString());    
    } 

    
    /**
     * Decode input text with Huffman tree
     * @param evt 
     */
    private void btn_decodeActionPerformed(ActionEvent evt) {
        if(tree == null) {
            JOptionPane.showMessageDialog(rootPane, "Create Huffman tree first to decode text");
            return;
        }
        String input = taInput.getText();
        char[] input_data = input.toCharArray();
        List<Boolean> data = new ArrayList<Boolean>();
        for(char c : input_data) {
            if(c == '0')    data.add(false);
            else            data.add(true);
        }
        String result = calc.decodeText(data, tree);
        taOutput.setText(result);
    }
}
