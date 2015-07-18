/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.resources.language;

import java.util.ListResourceBundle;

/**
 *
 * @author KASPER
 */
public class Language_en_GB extends ListResourceBundle{
    
    static final Object[][] contents = {{"OK", "Ok"},
        //Currency
                                        {"CURRENCY", "£"},
                                        
        //WinkelwagenPanel Text
                                        { "DELETE", "Delete" },
                                        { "BACK", "Back" },
                                        { "ORDER", "Order" },
                                        { "ORDERS", "Orders:" },   
                                        { "SELECTORDER", "Please select a product first" }, 
                                        
        //AddPhotoPanel Text
                                        { "SELECTEDPHOTOS", "Selected picture(s)"},
                                        { "BACK", "Back"},
                                        { "SELECTNEW", "Select new picture(s)"},
                                        { "UPLOAD", "Upload selected picture(s)"},
                                        { "ONEORMORE", "Select one or more pictures" },
                                        { "SELECT", "Select" },
                                        { "SELECTMINIMUM", "Select at least one picture" },
        //MailLijstPanel Text
                                        { "CHOOSEPERSON", "Choose" },
                                        { "CHOOSEAPERSON", "Choose a person:"},
                                        { "CANCEL", "Cancel"},
                                        { "CHOOSE", "First choose a person!"},
                                        
        //FotograafHolderPanel Text
                                        { "EMAIL", "Email" },
                                        { "LINKCUSTOMER", "Link customer"},
                                        { "CUSTOMERLIST", "Customerlist"},
                                        { "ADDPHOTO", "Add picture(s)"},
                                        { "PRICE", "Price"},
                                        { "EDIT", "Edit"},
                                        { "LINKEDFORMAL", "Customer has been linked to the picture" },
                                        { "LINKED", "Customer linked" },
                                        { "VALIDEMAIL", "Enter a valid email" },
                                        { "ERROR", "Error" },
                                        { "PICTUREFIRST", "Select a picture first" },
                                        { "PRICEEDITEDFORMAL", "The price has been updated" },
                                        { "PRICEEDITED", "Price updated" },
                                        { "ONLYNUMBERS", "Only numbers are allowed" },
                                        { "OPENBAAR", "Publish" },
                                        { "EMAIL_ERROR", "Invalid e-mail address"},
                                        { "EMAIL_ERRORTEXT","Please enter a valid e-mail address"},
                                        { "PUBLISHED", "Picture published" },
                                        { "PUBLISHEDFORMAL", "The picture has been published" },
                                        { "CUSTOMERMAIL", "Customer e-mail:" },
        //FotoproducentHolderPanel Text
                                        { "ADDPRODUCT", "Add product" },
                                        { "REMOVEPRODUCT", "Remove product"},
                                        { "ADDPHOTOGRAPHER", "Add photographer"},
                                        { "EDITPRODUCT", "Edit product" },
                                        { "ORDERHISTORY", "Order history" },
        //HoofdPanel Text
                                        { "PHOTOGRAPHER", "Photographer" },
                                        { "WIJZIGGEGEVENS", "Change personal data" },
                                        { "PRICEIN", "Price in"},
                                        { "DATE", "Date"},
                                        { "PREVIEW", "Preview picture" },
                                        { "HEADPANEL", "Main panel" },
                                        { "LIKE_MESSAGE", "You already liked this picture" },
                                        { "LOGOUT", "Logout" },
                                        { "SORT_LASTWEEK", "Last week" },
                                        { "SORT_LASTMONTH", "Last month" },
                                        { "SORT_ALL", "Beginning of times" },
                                        { "SORT_MYPICTURES", "My pictures" },
                                        { "SORT_LINKED", "Linked pictures" },
                                        { "SORT_PUBLIC", "Public pictures" },
                                        { "EDIT_PHOTO", "Edit selected photo" },
                                        { "PHOTO_DETAILS", "Photo details" },
                                        { "LIKEBUTTON", "Like" },
        //KlantHolderPanel Text
                                        { "CHOOSEPRODUCTPHOTO", "Choose product picture"},
                                        { "PHOTOPLACEMENT", "Place picture on product"},
                                        { "EDITPHOTO", "Alter picture"},
                                        { "SHOPPINGCART", "Shopping cart"},
        //LoginPanel Text
                                        { "LOGINHELP", "Please log in using your username and password"},
                                        { "PASSWORD", "Password"},
                                        { "LOGIN", "Log in"},
                                        { "REGISTER", "Register" },
                                        { "INVALIDLOG", "Invalid email or password" },
                                        { "USERNAME", "Username" },
                                        { "LOGINPANEL", "Login panel" },
        //PrijsBepalingPanel Text
                                        { "PATH", "Filepath"},
                                        { "SELECTPHOTO", "Select picture"},
                                        { "NEWPRICE", "New price"},
                                        { "CONFIRMPRICE", "Confirm" },
        //ProductMiniaturenPanel Text
                                        { "PREVIOUS", "Previous"},
                                        { "NEXT", "Next"},
                                        { "COMPLETE", "Complete" },
                                        { "SELECTPROD", "Please select a product first"},
                                        
        //ProductPanel Text
                                        { "ADDPRODUCTHELP", "Add a new product here"},
                                        { "NAME", "Name" },
                                        { "INFORMATION", "Information"},
                                        { "STOCK", "Stock"},
                                        { "SAVE", "Save"},
                                        { "ADDPRODUCT", "Add product" },
        //RegisterPanel Text
                                        { "REGISTERHELP", "Register a photographer here" },
                                        { "ADDRESS", "Address" },
                                        { "REGISTER", "Register" },
                                        { "ENTERALL", "Enter all details" },
                                        { "CANCEL", "Cancel" },
        //WijzigGegevensPanel Text
                                        { "OLDPASSWORD", "Old password:" },
                                        { "BFOTOGRAAF", "Become a photographer!" },
                                        { "NEWPASSWORD", "New password:" },
                                        { "WRONGOLDPASSWORD", "Old password is incorrect"},
                                        { "WRONGNEWPASSWORD", "Passwords do not match"},
            
        //FotoBewerkPanel Text          
                                        { "CHOOSE_EFFECT", "Select an effect to apply it" },
                                        { "EFFECT_NONE", "None" },
                                        { "EFFECT_GRAY", "Grayscale" },
                                        { "EFFECT_SEPIA", "Sepia" },
                                        { "EDITED_SAVED_TITLE", "Photo saved" },
                                        { "EDITED_SAVED", "The edited photo has been saved." },
                                        { "RESET", "Reset" },
        //BestelGeschiedenisPanel Text 
                                        { "PRODUCTS", "Products" }
    };
    
    @Override
    protected Object[][] getContents() {
        return contents;
    }
}
