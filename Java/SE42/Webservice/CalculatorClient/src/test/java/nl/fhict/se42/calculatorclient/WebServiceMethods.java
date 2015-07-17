package nl.fhict.se42.calculatorclient;


import client.NegativeNumberException_Exception;
import client.WebCalculator;
import client.WebCalculatorService;

public class WebServiceMethods {


    private static final WebCalculatorService service = new WebCalculatorService();

    public static int add(int x, int y) throws NegativeNumberException_Exception {
        WebCalculator port = service.getWebCalculatorPort();
        return port.add(x, y);
    }

    public static int minus(int x, int y) throws NegativeNumberException_Exception {
        WebCalculator port = service.getWebCalculatorPort();
        return port.minus(x, y);
    }

    public static int times(int x, int y) throws NegativeNumberException_Exception {
        WebCalculator port = service.getWebCalculatorPort();
        return port.times(x, y);
    }
}
