//
//  SendPlotController.h
//  Whodunnit
//
//  Created by Remi on 10/24/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <MessageUI/MessageUI.h>	
#import <MessageUI/MFMessageComposeViewController.h>

@interface SendPlotController : UIViewController <MFMessageComposeViewControllerDelegate>
{
    UIButton *buhtton;
}
@property (weak, nonatomic) IBOutlet UITextView *TextviewPlot;
@property NSString* text;
@property (weak, nonatomic) IBOutlet UIButton *ButtonSend;
@property (nonatomic, assign) id<MFMailComposeViewControllerDelegate> messageComposeDelegate;
@property (nonatomic, assign) id<UINavigationControllerDelegate> navigationDelegate;

@end
