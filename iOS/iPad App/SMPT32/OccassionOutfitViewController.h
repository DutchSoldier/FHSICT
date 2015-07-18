//
//  OccassionOutfitViewController.h
//  SMPT32
//
//  Created by Jeroen Pelt on 09-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "KledingHandeler.h"

@interface OccassionOutfitViewController : UIViewController <UIPickerViewDelegate, UIPickerViewDataSource>
@property KledingHandeler* kh;
@property (weak, nonatomic) IBOutlet UIPickerView *picker;
- (IBAction)btn_gen:(id)sender;

@end
