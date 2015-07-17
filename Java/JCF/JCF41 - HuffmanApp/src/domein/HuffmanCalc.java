package domein;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.TreeMap;

/**
 *
 * @author Simon
 */
public class HuffmanCalc {
    
    /**
     * Count all different characters in data
     * @param data
     * @return Map with characters and their frequency
     */
    public Map<Character, Integer> count_characters(String data) {
        Map<Character, Integer> characters = new HashMap<Character, Integer>();
        
        for(int i = 0; i < data.length(); i++) {
            char c = data.charAt(i);
            Integer entry = characters.get(c);
            if(entry == null) {
                characters.put(c, 1);
            }else{
                characters.put(c, entry + 1);                
            }
        }
        return characters;
    }
    
    
    /**
     * Sort characters by frequency ascending
     * @param characters
     * @return Treemap with characters en frequency sorted ascending
     */
    public TreeMap<Character, Integer> sort_characters(Map<Character, Integer> characters) {
        ValueComparator bvc = new ValueComparator(characters);
        TreeMap<Character, Integer> characters_sorted_counted = new TreeMap<Character, Integer>(bvc);
        characters_sorted_counted.putAll(characters);
        
        return characters_sorted_counted;
    }
    
    
    /**
     * Comparator sorts by character frequency
     */
    private class ValueComparator implements Comparator<Character> {

        Map<Character, Integer> base;
        public ValueComparator(Map<Character, Integer> base) {
            this.base = base;
        }

        @Override
        public int compare(Character a, Character b) {
            if (base.get(a) >= base.get(b)) {
                return 1;
            } else {
                return -1;
            }
        }
    }
    

    /**
     * Create Huffman tree with a list of sorted characters
     * @param characters_sorted_counted
     * @return 
     */
    public HuffLeaf createTree(TreeMap<Character, Integer> characters_sorted_counted) {
        if(characters_sorted_counted.size() == 0) return null;
        // Create first element of the tree
        Entry<Character, Integer> firstEntry = characters_sorted_counted.firstEntry();
        char firstchar = firstEntry.getKey();
        int firstvalue = firstEntry.getValue();
        HuffLeaf tree = new HuffLeaf(null, null, firstvalue, firstchar);
        
        for (Map.Entry<Character, Integer> entry : characters_sorted_counted.entrySet())
        {
            Character lowest = entry.getKey();
            if(lowest == firstchar) continue;
            int leafvalue = entry.getValue();
            HuffLeaf treeleaf = new HuffLeaf(null, null, leafvalue, lowest);
            
            // decide which leaf goes to which side by comparing the treeroot with the leaf frequency
            int newfreq = treeleaf.getFrequency() + tree.getFrequency();
            if(tree.getFrequency() == treeleaf.getFrequency() && tree.getValue() != null && treeleaf.getValue() != null) {
                // index alphabetically
                if(tree.getValue() > treeleaf.getValue()) {
                    tree = new HuffLeaf(treeleaf, tree, newfreq, null);
                }else{
                    tree = new HuffLeaf(tree, treeleaf, newfreq, null);
                }
            }else{
                if(tree.getFrequency() > treeleaf.getFrequency()) {
                    tree = new HuffLeaf(treeleaf, tree, newfreq, null);
                }else{
                    tree = new HuffLeaf(tree, treeleaf, newfreq, null);
                }
            }
            
            System.out.println("Added to tree: "+entry.getKey() + "=" + entry.getValue());
        }
        
        return tree;
    }
    
    
    /**
     * Encode String with huffman tree
     * @param text
     * @param tree
     * @return encoded binary text
     */
    public List<Boolean> encodeTree(String text, HuffLeaf tree) {
        List<Boolean> out = new ArrayList<Boolean>();
        if(tree == null) return out;
        
        // encodes text one character at a time
        char[] characters = text.toCharArray();
        for(char letter : characters) {
            // search the tree for the character
            List<Boolean> code = tree.seekCharacter(letter, new ArrayList<Boolean>());
            out.addAll(code);
        }
        
        return out;
    }
    
    
    /**
     * Decode the text with huffman tree
     * @param text
     * @param tree
     * @return original String
     */
    public String decodeText(List<Boolean> data, HuffLeaf tree) {
        if(tree == null) return "";
        StringBuilder sb = new StringBuilder();
        
        // Encode String one character at a time
        HuffLeaf root = tree;
        for(Boolean bit : data) {
            if(bit == null) continue;
            
            // search the tree for the character
            HuffLeaf h;
            if(bit == Boolean.FALSE) {
                h = root.getLeftchild();
            } else {
                h = root.getRightchild();
            }
            
            Character c = h.getValue();
            if(c != null) {
                sb.append(c);
                root = tree;
            } else {
                root = h;
            }
            
        }
        
        return sb.toString();
    }
}
