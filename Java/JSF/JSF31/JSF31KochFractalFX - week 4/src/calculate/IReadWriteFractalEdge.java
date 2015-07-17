/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package calculate;

import java.util.List;

/**
 *
 * @author me
 */
public interface IReadWriteFractalEdge {
    KochFractal readFractal();
    
    void writeFractal(KochFractal fractal);
    
}
