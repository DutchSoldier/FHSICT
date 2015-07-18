//
//  GenerateViewController.m
//  SMPT32
//
//  Created by Remi on 12/12/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "GenerateViewController.h"
#import "Outfit.h"

@interface GenerateViewController ()

@end

@implementation GenerateViewController
@synthesize kh;
@synthesize img_top;
@synthesize img_bot;
@synthesize img_sho;
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
    self.navigationItem.title = @"Generate outfit";
    kh = [KledingHandeler singletonKH];
    Outfit* o = [kh generateOutfit:@"Casual"];
    img_top.image = o.top.getImage;
    img_bot.image = o.bottom.getImage;
    img_sho.image = o.shoes.getImage;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)btn_regen:(id)sender {
    
    kh = [KledingHandeler singletonKH];
    Outfit* o = [kh generateOutfit:@"Casual"];
    img_top.image = o.top.getImage;
    img_bot.image = o.bottom.getImage;
    img_sho.image = o.shoes.getImage;
}

- (IBAction)btn_facebook:(id)sender {
    NSLog(@"Facebook!!!");
}
@end
