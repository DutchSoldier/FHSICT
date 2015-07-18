//
//  ClothingInfoViewController.m
//  SMPT32
//
//  Created by Remi on 12/12/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "ClothingInfoViewController.h"
#import "Outfit.h"
#import "EditClothingViewController.h"

@interface ClothingInfoViewController ()

@end

@implementation ClothingInfoViewController
@synthesize kleding;
@synthesize NameLabel;
@synthesize TypeLabel;
@synthesize OccasionLabel;
@synthesize FabricLabel;
@synthesize ColorLabel;
@synthesize bt_Delete;
@synthesize ClothingImage;
@synthesize Handler;
@synthesize kledingId;

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
    Handler = [KledingHandeler singletonKH];
    if(kledingId > -1)
    {
        kleding = [Handler.getKleding objectAtIndex:kledingId];
        ClothingImage.image = kleding.getImage;
        NameLabel.text = kleding.getName;
        TypeLabel.text = kleding.getSort;
        OccasionLabel.text = kleding.occation;
        FabricLabel.text = kleding.fabric;
        ColorLabel.text = kleding.color;
        
        self.navigationItem.title = NameLabel.text;
    }
    else
    {
        
        //-1 geen info
        NameLabel.text = @"";
        TypeLabel.text = @"";
        OccasionLabel.text = @"";
        FabricLabel.text = @"";
        ColorLabel.text = @"";
        
        kleding = nil;
        
        self.navigationItem.title = NameLabel.text;
    }
}

-(void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    
    ClothingImage.image = kleding.getImage;
    NameLabel.text = kleding.getName;
    TypeLabel.text = kleding.getSort;
    OccasionLabel.text = kleding.occation;
    FabricLabel.text = kleding.fabric;
    ColorLabel.text = kleding.color;
    
    self.navigationItem.title = NameLabel.text;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

//Button Edit
- (IBAction)bt_Edit:(id)sender {
    
}

//Button Delete
- (IBAction)bt_Delete:(id)sender {
    if(kleding != nil)
    {
        [Handler removeKledingObject:kleding];
        UIAlertView* view = [[UIAlertView alloc]initWithTitle:@"Deleted" message:@"Clothes removed." delegate:nil cancelButtonTitle:@"Close" otherButtonTitles:nil, nil];
        view.show;
        //[self dismissViewControllerAnimated:true completion:nil];
        [self.navigationController popViewControllerAnimated:true]; //go 1 back
    }
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if([segue.identifier isEqualToString:@"edit"])
    {
        EditClothingViewController* ecvc = segue.destinationViewController;
        ecvc.kleding = kleding;
    }
}

@end
