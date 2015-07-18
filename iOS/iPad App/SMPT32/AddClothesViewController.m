//
//  AddClothesViewController.m
//  SMPT32
//
//  Created by Jeroen Pelt on 09-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "AddClothesViewController.h"
#import "CameraViewController.h"

@interface AddClothesViewController ()

@end

@implementation AddClothesViewController
@synthesize pv_prop;
@synthesize kledingHand;
@synthesize btn_Save;
@synthesize image;
@synthesize type;
@synthesize occasion;
@synthesize color;
@synthesize fabric;

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
    kledingHand = [KledingHandeler singletonKH];
    self.navigationItem.title = @"Add clothes";
    type = @"Shirts Long Sleeve";
    occasion = @"Casual";
    color = @"Red";
    fabric = @"Silk";
    }

-(void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    image = nil;
    [[self navigationController] setNavigationBarHidden:NO animated:YES];//hide bar
}

- (void)applicationDidFinishLaunching:(UIApplication *)application {
    pv_prop = [[AddClothesViewController alloc] initWithNibName:@"pv_prop" bundle:[NSBundle mainBundle]];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)btn_Foto:(id)sender {
    
}

- (IBAction)btn_Save:(id)sender {
    if([self.tf_Name.text length]>0 && self.demoview.image != NULL)
    {
        Kleding* k = [[Kleding alloc]init];
        [k setColor:color];
        [k setFabric:fabric];
        [k setSort:type];
        [k setOccation:occasion];
        [k setName:self.tf_Name.text];
        [k setImage:self.demoview.image];
        [kledingHand addKledingObject:k];
        
        UIAlertView* alert = [[UIAlertView alloc]initWithTitle:@"Saved" message:@"Clothes added and saved." delegate:nil cancelButtonTitle:@"Close" otherButtonTitles:nil, nil];
        alert.show;
        
        [self.navigationController popViewControllerAnimated:true];
    }
    else
    {
        UIAlertView* alert = [[UIAlertView alloc]initWithTitle:@"Warning" message:@"Please fill in all empty fields." delegate:nil cancelButtonTitle:@"Close" otherButtonTitles:nil, nil];
        alert.show;
    }
}


//Occasion Picker
-(NSInteger)numberOfComponentsInPickerView:(UIPickerView *)OccasionPicker
{
    return 2;
}

-(NSInteger)pickerView:(UIPickerView *)OccasionPicker numberOfRowsInComponent:(NSInteger)component
{
    if(component == 1)
    {
        if(OccasionPicker.tag == 1)
        {
            return [kledingHand.getOccasions count];
        }
        else
        {
            return [kledingHand.getFabric count];
        }
    }
    else
    {
        
        if(OccasionPicker.tag == 1)
        {
            return [kledingHand.getSort count];
        }
        else
        {
            return [kledingHand.getColor count];
        }
    }
}

-(NSString*)pickerView:(UIPickerView *)OccasionPicker titleForRow:(NSInteger)row forComponent:(NSInteger)component
{
    if(component == 1)
    {
        if(OccasionPicker.tag == 1)
        {
            return [kledingHand.getOccasions objectAtIndex:row];
        }
        else
        {
            return [kledingHand.getFabric objectAtIndex:row];
        }
    }
    else
    {
        
        if(OccasionPicker.tag == 1)
        {
            return [kledingHand.getSort objectAtIndex:row];
        }
        else
        {
            return [kledingHand.getColor objectAtIndex:row];
        }
    }
}

- (void)pickerView:(UIPickerView *)OccasionPicker didSelectRow:(NSInteger)row inComponent:(NSInteger)component
{
    if(component == 1)
    {
        if(OccasionPicker.tag == 1)
        {
            occasion = [kledingHand.getOccasions objectAtIndex:row];
        }
        else
        {
            fabric = [kledingHand.getFabric objectAtIndex:row];
        }
    }
    else
    {
        
        if(OccasionPicker.tag == 1)
        {
            type = [kledingHand.getSort objectAtIndex:row];
        }
        else
        {
            color = [kledingHand.getColor objectAtIndex:row];
        }
    }
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    NSLog(segue.identifier);
    if([segue.identifier isEqualToString:@"camera"])
    {
        CameraViewController* cvc = segue.destinationViewController;
        cvc.parrent = self;
    }
}


-(void)setFoto:(UIImage*)foto
{
    self.image = foto;
}
@end
