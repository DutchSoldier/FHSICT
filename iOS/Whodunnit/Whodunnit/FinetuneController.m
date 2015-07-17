//
//  FinetuneController.m
//  Whodunnit
//
//  Created by Remi on 10/24/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "FinetuneController.h"

@interface FinetuneController ()



@end

@implementation FinetuneController
@synthesize Textview;
@synthesize fineTuneText;
@synthesize delegate;

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
	UITapGestureRecognizer* tapRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(TapDetected:)];
    tapRecognizer.numberOfTapsRequired = 1;
    [self.view addGestureRecognizer:tapRecognizer];
    self.Textview.text = self.fineTuneText;
}

- (void)viewDidUnload
{
    [self setTextview:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
	return YES;
}

- (void) viewDidAppear:(BOOL)animated{
    self.Textview.text = self.fineTuneText;
}

- (void) TapDetected: (UITapGestureRecognizer*) recognizer{
    [Textview resignFirstResponder];
}

- (IBAction)doneButtonTapped:(id)sender {
    [[self delegate] finetuneDone:Textview.text];
    
}

@end
