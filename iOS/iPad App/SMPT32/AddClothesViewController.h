//
//  AddClothesViewController.h
//  SMPT32
//
//  Created by Jeroen Pelt on 09-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "KledingHandeler.h"
#import "CameraViewController.h"

@interface AddClothesViewController : UIViewController <UIPickerViewDataSource, UIPickerViewDelegate>
@property KledingHandeler* kledingHand;
@property (retain) UIImage* image;
@property (retain) NSString* type;
@property (retain) NSString* occasion;
@property (retain) NSString* color;
@property (retain) NSString* fabric;
@property (weak, nonatomic) IBOutlet UITextField *tf_Name;
@property (weak, nonatomic) IBOutlet UIPickerView *pv_prop;
@property (weak, nonatomic) IBOutlet UIPickerView *pv_col;
@property (weak, nonatomic) IBOutlet UIBarButtonItem *btn_Save;
@property (weak, nonatomic) IBOutlet UIImageView *demoview;
- (IBAction)btn_Foto:(id)sender;
- (IBAction)btn_Save:(id)sender;

-(void)setFoto:(UIImage*)foto;

@end
