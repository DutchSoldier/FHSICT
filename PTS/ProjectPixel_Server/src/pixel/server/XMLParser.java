/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server;

import java.io.IOException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;
import pixel.shared.classes.Cube;

/**
 *
 * @author Bas
 */
public class XMLParser extends DefaultHandler {
    private Cube cube;
    private String temp;
    /**
     *
     */
    public static ArrayList<Cube> cubeList = new ArrayList<>();

    /**
     *
     * @throws IOException
     * @throws SAXException
     * @throws ParserConfigurationException
     */
    public static void parseXML() throws IOException, SAXException,
            ParserConfigurationException {

        //Create a "parser factory" for creating SAX parsers
        SAXParserFactory spfac = SAXParserFactory.newInstance();

        //Now use the parser factory to create a SAXParser object
        SAXParser sp = spfac.newSAXParser();

        //Create an instance of this class; it defines all the handler methods
        XMLParser handler = new XMLParser();

        URL url = new URL("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
        URLConnection uc = url.openConnection();

        //Finally, tell the parser to parse the input and notify the handler
        cubeList.clear();
        sp.parse(uc.getInputStream(), handler);
    }


    /*
     * When the parser encounters plain text (not XML elements),
     * it calls(this method, which accumulates them in a string buffer
     */
    @Override
    public void characters(char[] buffer, int start, int length) {
        temp = new String(buffer, start, length);
    }


    /*
     * Every time the parser encounters the beginning of a new element,
     * it calls this method, which resets the string buffer
     */
    @Override
    public void startElement(String uri, String localName,
            String qName, Attributes attributes) throws SAXException {
        temp = "";
        if (qName.equalsIgnoreCase("Cube")) {
            cube = new Cube();
            if (attributes.getValue("currency") != null) {
                cube.setCurrency(attributes.getValue("currency"));
                cube.setRate(Double.parseDouble(attributes.getValue("rate")));
            }
        }
    }

    /*
     * When the parser encounters the end of an element, it calls this method
     */
    @Override
    public void endElement(String uri, String localName, String qName)
            throws SAXException {

        if (qName.equalsIgnoreCase("Cube")) {
            // add it to the list
            cubeList.add(cube);
        } else if (qName.equalsIgnoreCase("currency")) {
            cube.setCurrency(temp);
        } else if (qName.equalsIgnoreCase("rate")) {
            cube.setRate(Double.parseDouble(temp));
        }
    }
    
    /*
     * Retrieve the currency list
     */
    /**
     *
     * @return
     */
    public static ArrayList<Cube> getCurrencyList() {
        return cubeList;
    }
}
