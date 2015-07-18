//
//  SeeClothesViewController.m
//  SMPT32
//
//  Created by Jeroen Pelt on 09-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "SeeClothesViewController.h"
#import "ClothingInfoViewController.h"

@interface SeeClothesViewController ()

@end

@implementation SeeClothesViewController
@synthesize ClothingTable;
@synthesize bt_Show;
@synthesize OccasionPicker;
@synthesize Han;
@synthesize selectedSort;
@synthesize selectedKledingId;

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
    Han = [KledingHandeler singletonKH];
    self.navigationItem.title = @"See clothes";
    selectedSort = @"All";
}

-(void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    [ClothingTable reloadData];
    [[self navigationController] setNavigationBarHidden:NO animated:YES];//hide bar
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


//Occasion Picker
-(NSInteger)numberOfComponentsInPickerView:(UIPickerView *)OccasionPicker
{
    return 1;
}

-(NSInteger)pickerView:(UIPickerView *)OccasionPicker numberOfRowsInComponent:(NSInteger)component
{
    return [Han.getOccasions count]+1;
}

-(NSString*)pickerView:(UIPickerView *)OccasionPicker titleForRow:(NSInteger)row forComponent:(NSInteger)component
{
    if(row>0)
    {
        return [Han.getOccasions objectAtIndex:row-1];
    }
    else
    {
        return @"All";
    }
}

- (void)pickerView:(UIPickerView *)OccasionPicker didSelectRow:(NSInteger)row inComponent:(NSInteger)component
{
    if(row == 0)
    {
        selectedSort = @"All";
    }
    else
    {
        selectedSort = [Han.getOccasions objectAtIndex:row-1];
    }
    
    selectedKledingId = -1;
//NSLog(selectedSort);
    ClothingTable.reloadData;
}

//List
#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
#warning Potentially incomplete method implementation.
    // Return the number of sections.
    return [Han.getSort count];
}

- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section
{
    return [Han.getSort objectAtIndex:section];
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
#warning Incomplete method implementation.
    // Return the number of rows in the section.
    if([selectedSort isEqualToString:@"All"])
    {
        return [[Han getKledingWithSort:[Han.getSort objectAtIndex:section]] count];
    }
    else
    {
        return [[Han getKledingWithOccasion:selectedSort WithSort:[Han.getSort objectAtIndex:section]] count];
    }
}
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *CellIdentifier = @"Cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier forIndexPath:indexPath];
    
    // Configure the cell...
    if(cell == nil)
    {
        cell=[[UITableViewCell alloc]initWithStyle:UITableViewCellStyleValue2 reuseIdentifier:CellIdentifier];
    }
    Kleding* k = NULL;
    if([selectedSort isEqualToString:@"All"])
    {
        k = [[Han getKledingWithSort:[Han.getSort objectAtIndex:indexPath.section]] objectAtIndex:indexPath.row];
    }
    else
    {
        k = [[Han getKledingWithOccasion:selectedSort WithSort:[Han.getSort objectAtIndex:indexPath.section]] objectAtIndex:indexPath.row];
    }
    
    cell.textLabel.text = [k getName];
    cell.detailTextLabel.text = [k getSort];
    cell.imageView.image = [k getImage];
    
    return cell;
}


//Button Show
- (IBAction)bt_Show:(id)sender {
    if([ClothingTable indexPathForSelectedRow])
    {
        NSIndexPath* ip = [ClothingTable indexPathForSelectedRow];
        Kleding* k = NULL;
        if([selectedSort isEqualToString:@"All"])
        {
            k = [[Han getKledingWithSort:[Han.getSort objectAtIndex:ip.section]] objectAtIndex:ip.row];
        }
        else
        {
            k = [[Han getKledingWithOccasion:selectedSort WithSort:[Han.getSort objectAtIndex:ip.section]] objectAtIndex:ip.row];

        }
        //NSLog(k.getName); Dit is fail safe! (Jeroen)
        if(k != NULL)
        {
            selectedKledingId = [Han.getKleding indexOfObject:k];
        }
        else
        {
            selectedKledingId = -1;
        }
        
    }
    else
    {
        //todo
    }
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    NSLog(segue.identifier);
    if([segue.identifier isEqualToString:@"Detail"])
    {
        ClothingInfoViewController* civc = segue.destinationViewController;
        NSLog([NSString stringWithFormat:@">>>>>SEGUE>%d",selectedKledingId ]);
        
        civc.kledingId = selectedKledingId;
    }
}

@end
