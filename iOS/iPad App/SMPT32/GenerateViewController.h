//
//  GenerateViewController.h
//  SMPT32
//
//  Created by Remi on 12/12/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "KledingHandeler.h"

@interface GenerateViewController : UIViewController
@property (weak, nonatomic) IBOutlet UIImageView *img_top;
@property (weak, nonatomic) IBOutlet UIImageView *img_bot;
@property (weak, nonatomic) IBOutlet UIImageView *img_sho;
- (IBAction)btn_regen:(id)sender;
- (IBAction)btn_facebook:(id)sender;

@property KledingHandeler* kh;
@end
