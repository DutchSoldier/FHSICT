//
//  SendPlotController.m
//  Whodunnit
//
//  Created by Remi on 10/24/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "SendPlotController.h"
#import <MessageUI/MessageUI.h>
#import <MessageUI/MFMessageComposeViewController.h>

@interface SendPlotController ()


@end

@implementation SendPlotController
@synthesize ButtonSend;
@synthesize TextviewPlot;
@synthesize text;
@synthesize messageComposeDelegate;
@synthesize navigationDelegate;


- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
    [self setView:[[UIView alloc] initWithFrame:[[UIScreen mainScreen] applicationFrame]]];
    
    ButtonSend = [UIButton buttonWithType:UIButtonTypeRoundedRect];
    [ButtonSend setFrame:CGRectMake(0, 0, 180, 40)];
    [ButtonSend setCenter:CGPointMake(160, 208)];
    [ButtonSend setTitle:@"Send SMS" forState:UIControlStateNormal];
    [ButtonSend addTarget:self action:@selector(buttonPressed:) forControlEvents:UIControlEventTouchUpInside];
    [[self view] addSubview:ButtonSend];
}

- (IBAction)ButtonSend:(id)sender {
    

}

- (void)buttonPressed: (UIButton*)button
{
    if (button == ButtonSend) {
        [self sendSMS:@"Body of SMS..." recipientList:[NSArray arrayWithObjects:@"+1-111-222-3333", @"111-333-4444", nil]];
    }
}

- (void)viewDidUnload
{
    [self setTextviewPlot:nil];
    [self setButtonSend:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
	return YES;
}

-(void)viewDidAppear:(BOOL)animated{
    TextviewPlot.text = self.text;
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    SendPlotController* destination = segue.destinationViewController;
    destination.text = @"";
}

- (void)sendSMS:(NSString *)bodyOfMessage recipientList:(NSArray *)recipients
{
    MFMessageComposeViewController *controller = [[MFMessageComposeViewController alloc] init];
    if([MFMessageComposeViewController canSendText])
    {
        controller.body = bodyOfMessage;
        controller.recipients = recipients;
        controller.messageComposeDelegate = self;
        [self presentModalViewController:controller animated:YES];
    }    
}

- (void) messageComposeViewController: (MFMessageComposeViewController*) controller didFinishWithResult:(MessageComposeResult)result
{
    [self dismissModalViewControllerAnimated:YES];
    
    if (result == MessageComposeResultCancelled)
    {
        NSLog(@"Message cancelled");
    }
    else if(result == MessageComposeResultFailed)
    {
        NSLog(@"Message failed");
    }
    else
    {
        NSLog(@"Message sent");
    }
}

@end
