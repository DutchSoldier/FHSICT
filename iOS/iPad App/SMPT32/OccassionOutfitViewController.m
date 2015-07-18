//
//  OccassionOutfitViewController.m
//  SMPT32
//
//  Created by Jeroen Pelt on 09-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "OccassionOutfitViewController.h"

@interface OccassionOutfitViewController ()

@end

@implementation OccassionOutfitViewController
@synthesize kh;

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
    kh = [KledingHandeler singletonKH];
}

-(void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    [[self navigationController] setNavigationBarHidden:NO animated:YES];//hide bar
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)btn_gen:(id)sender {
    NSLog([kh.getOccasions objectAtIndex:[self.picker selectedRowInComponent:0]]);
    //TODO send occasions to next screen
}

//pickerstuf
-(NSInteger)numberOfComponentsInPickerView:(UIPickerView *)pickerView
{
    return 1;
}

-(NSInteger)pickerView:(UIPickerView *)pickerView numberOfRowsInComponent:(NSInteger)component
{
    return [kh.getOccasions count];
}

-(NSString*)pickerView:(UIPickerView *)pickerView titleForRow:(NSInteger)row forComponent:(NSInteger)component
{
    return [kh.getOccasions objectAtIndex:row];
}
@end
