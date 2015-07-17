/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package enums;

/**
 *
 * @author Remi_Arts
 */
public enum ConnState {
    Connected,
    Disconnected,
    Error,
    AwaitingCommand,
    ProcessingCommand,
    CommandDone
}
