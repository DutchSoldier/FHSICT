//
//  ClothingInfoViewController.h
//  SMPT32
//
//  Created by Remi on 12/12/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "KledingHandeler.h"
#import "Kleding.h"

@interface ClothingInfoViewController : UIViewController
@property KledingHandeler* Handler;
@property Kleding* kleding;
@property (weak, nonatomic) IBOutlet UIImageView *ClothingImage;
@property (weak, nonatomic) IBOutlet UIButton *bt_Edit;
@property (weak, nonatomic) IBOutlet UILabel *NameLabel;
@property (weak, nonatomic) IBOutlet UILabel *OccasionLabel;
@property (weak, nonatomic) IBOutlet UILabel *TypeLabel;
@property (weak, nonatomic) IBOutlet UILabel *ColorLabel;
@property (weak, nonatomic) IBOutlet UILabel *FabricLabel;
@property (weak, nonatomic) IBOutlet UIButton *bt_Delete;
@property (nonatomic, readwrite) NSInteger kledingId;

@end
