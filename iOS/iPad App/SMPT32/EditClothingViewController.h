//
//  EditClothingViewController.h
//  SMPT32
//
//  Created by Remi on 12/12/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "KledingHandeler.h"

@interface EditClothingViewController : UIViewController  <UIPickerViewDataSource, UIPickerViewDelegate>
@property KledingHandeler* Handler;
@property Kleding* kleding;
@property (retain) NSString* type;
@property (retain) NSString* occasion;
@property (retain) NSString* color;
@property (retain) NSString* fabric;
@property (weak, nonatomic) IBOutlet UIPickerView *pv_prop;
@property (weak, nonatomic) IBOutlet UITextField *NameTexField;
@property (weak, nonatomic) IBOutlet UIBarButtonItem *btn_Save;
@property (weak, nonatomic) IBOutlet UIPickerView *pv_typ_occ;
@property (weak, nonatomic) IBOutlet UIPickerView *pv_col_fab;

@end
