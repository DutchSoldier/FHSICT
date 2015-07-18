//
//  SeeClothesViewController.h
//  SMPT32
//
//  Created by Jeroen Pelt on 09-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "KledingHandeler.h"

@interface SeeClothesViewController : UIViewController
@property (weak, nonatomic) IBOutlet UIPickerView *OccasionPicker;
@property (weak, nonatomic) IBOutlet UITableView *ClothingTable;
@property (weak, nonatomic) IBOutlet UIButton *bt_Show;
@property NSString* selectedSort;
@property KledingHandeler* Han;
@property NSInteger selectedKledingId;

@end
