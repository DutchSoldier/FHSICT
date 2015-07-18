//
//  EditClothingViewController.m
//  SMPT32
//
//  Created by Remi on 12/12/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "EditClothingViewController.h"


@interface EditClothingViewController ()


@end

@implementation EditClothingViewController
@synthesize Handler;
@synthesize pv_col_fab;
@synthesize pv_typ_occ;
@synthesize pv_prop;
@synthesize btn_Save;
@synthesize NameTexField;
@synthesize kleding;
@synthesize fabric,color,occasion,type;

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
    Handler = [KledingHandeler singletonKH];
    self.navigationItem.title = @"Edit clothes";
    
    if(kleding != nil)
    {
        NameTexField.text = kleding.name;
        type = [kleding getSort];
        occasion = [kleding getOccation];
        color = [kleding getColor];
        fabric = [kleding getFabric];
        
        [pv_typ_occ selectRow:[Handler.getSort indexOfObject:kleding.sort] inComponent:0 animated:true];
        
        [pv_typ_occ selectRow:[Handler.getOccasions indexOfObject:kleding.occation] inComponent:1 animated:true];
        [pv_col_fab selectRow:[Handler.getColor indexOfObject:kleding.getColor] inComponent:0 animated:true];
        [pv_col_fab selectRow:[Handler.fabric indexOfObject:kleding.getFabric] inComponent:1 animated:true];
    
    }
}

-(void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    [[self navigationController] setNavigationBarHidden:NO animated:YES];//hide bar
}

- (void)applicationDidFinishLaunching:(UIApplication *)application {
    pv_prop = [[EditClothingViewController alloc] initWithNibName:@"pv_prop" bundle:[NSBundle mainBundle]];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

//Type and Occasion Picker
- (NSInteger) numberOfComponentsInPickerView:(UIPickerView *)TypeOccasionPicker
{
    return 2;
}

- (NSInteger) pickerView:(UIPickerView *)OccasionPicker numberOfRowsInComponent:(NSInteger)component
{
    if(component == 1)
    {
        if(OccasionPicker.tag == 1)
        {
            return [Handler.getOccasions count];
        }
        else
        {
            return [Handler.getFabric count];
        }
    }
    else
    {
        
        if(OccasionPicker.tag == 1)
        {
            return [Handler.getSort count];
        }
        else
        {
            return [Handler.getColor count];
        }
    }
}

- (NSString *)pickerView:(UIPickerView *)OccasionPicker titleForRow:(NSInteger)row forComponent:(NSInteger)component {
    if(component == 1)
    {
        if(OccasionPicker.tag == 1)
        {
            return [Handler.getOccasions objectAtIndex:row];
        }
        else
        {
            return [Handler.getFabric objectAtIndex:row];
        }
    }
    else
    {
        
        if(OccasionPicker.tag == 1)
        {
            return [Handler.getSort objectAtIndex:row];
        }
        else
        {
            return [Handler.getColor objectAtIndex:row];
        }
    }
}


- (void)pickerView:(UIPickerView *)OccasionPicker didSelectRow:(NSInteger)row inComponent:(NSInteger)component
{
    if(component == 1)
    {
        if(OccasionPicker.tag == 1)
        {
            occasion = [Handler.getOccasions objectAtIndex:row];
        }
        else
        {
            fabric = [Handler.getFabric objectAtIndex:row];
        }
    }
    else
    {
        
        if(OccasionPicker.tag == 1)
        {
            type = [Handler.getSort objectAtIndex:row];
        }
        else
        {
            color = [Handler.getColor objectAtIndex:row];
        }
    }
}

//Button Save
- (IBAction)btn_Save:(id)sender {
    [kleding setName:NameTexField.text];
    [kleding setColor:color];
    [kleding setFabric:fabric];
    [kleding setOccation:occasion];
    [kleding setSort:type];
    
    [self.navigationController popViewControllerAnimated:true];
}


@end
