//
//  PlotPickerController.m
//  Whodunnit
//
//  Created by Remi on 10/24/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "PlotPickerController.h"
#import "FinetuneController.h"

@interface PlotPickerController ()

@end

@implementation PlotPickerController
@synthesize TextView;
@synthesize Picker;

-(void)finetuneDone:(NSString *)finetuneResult{
    self.TextView.text = finetuneResult;
}

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
    self.Suspects = [[NSMutableArray alloc] initWithObjects: @"Big Bird", @"Ernie", nil];
    self.Victims = [[NSMutableArray alloc] initWithObjects: @"Ernie", @"Bert", nil];
    self.Murderweapons = [[NSMutableArray alloc] initWithObjects: @"gun", @"knife", nil];
    self.Locations = [[NSMutableArray alloc] initWithObjects: @"at home", @"in a dark alley", nil];
    self.Motives = [[NSMutableArray alloc] initWithObjects: @"money", @"revenge", nil];
    self.columns = [[NSMutableArray alloc] initWithObjects: self.Suspects, self.Victims, self.Murderweapons, self.Locations, self.Motives ,nil];
    self.wordsToRemember = [[NSMutableArray alloc] initWithObjects: @"Ernie", @"Bert", @"gun", @"at home", @"revenge", nil];
    self.TextView.text = @"";
}

- (void)viewDidUnload
{
    [self setTextView:nil];
    [self setPicker:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
	return YES;
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([segue.identifier isEqualToString: @"segueFinetune"]){
        FinetuneController* destination = segue.destinationViewController;
        destination.delegate = self;
        destination.fineTuneText = TextView.text;
    }
}

- (NSInteger) numberOfComponentsInPickerView:(UIPickerView *)pickerView
{
    return [self.columns count];
}

- (NSInteger) pickerView:(UIPickerView *)pickerView numberOfRowsInComponent:(NSInteger)component
{
    return 2;
}

- (NSString *)pickerView:(UIPickerView *)thePickerView titleForRow:(NSInteger)row forComponent:(NSInteger)component {
        return [[self.columns objectAtIndex:component] objectAtIndex:row];
}


- (void)pickerView:(UIPickerView *)pickerView didSelectRow:(NSInteger)row inComponent:(NSInteger)component
{
    [self.wordsToRemember removeObjectAtIndex:component];
    [self.wordsToRemember insertObject:[[self.columns objectAtIndex:component]objectAtIndex:row] atIndex:component];
    
     if ([self.wordsToRemember count] == 5){
        NSString* chosenWords =
        [NSString stringWithFormat :
         @"%@ has murdered %@ with %@. The body was found %@. The murderer's motive was %@.",
         [self.wordsToRemember objectAtIndex:0],
         [self.wordsToRemember objectAtIndex:1],
         [self.wordsToRemember objectAtIndex:2],
         [self.wordsToRemember objectAtIndex:3],
         [self.wordsToRemember objectAtIndex:4]];
    
         TextView.text = chosenWords;
    }
}

@end
