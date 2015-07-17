package domein;

import java.util.List;

/**
 *
 * @author Simon
 */
public class HuffLeaf {
    private Character value;
    private int frequency;
    private HuffLeaf leftchild, rightchild;
    
    public HuffLeaf(HuffLeaf leftchild, HuffLeaf rightchild, int frequency, Character value) {
        this.value = value;
        this.frequency = frequency;
        this.leftchild = leftchild;
        this.rightchild = rightchild;
    }

    public Character getValue() {
        return value;
    }

    public int getFrequency() {
        return frequency;
    }

    public HuffLeaf getLeftchild() {
        return leftchild;
    }

    public HuffLeaf getRightchild() {
        return rightchild;
    }

    List<Boolean> seekCharacter(char letter, List<Boolean> currentsequence) {
        if(this.value != null && letter == this.value.charValue()) {
            return currentsequence;
        } else {
            if(this.leftchild != null) {
                if(this.leftchild != null) {
                    currentsequence.add(Boolean.FALSE);                    
                    List<Boolean> list = this.leftchild.seekCharacter(letter, currentsequence);
                    if(list != null) {
                        return list;
                    }else{
                        currentsequence.remove(currentsequence.size() - 1);
                    }
                }
            }
            if(this.rightchild != null) {
                if(this.rightchild != null) {
                    currentsequence.add(Boolean.TRUE);
                    List<Boolean> list = this.rightchild.seekCharacter(letter, currentsequence);
                    if(list != null) return list;
                    else{
                        currentsequence.remove(currentsequence.size() - 1);
                    }
                }
            }
        }
        return null;
    }
}
