//
//  PlotPickerController.h
//  Whodunnit
//
//  Created by Remi on 10/24/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FinetuneController.h"

@interface PlotPickerController : UIViewController<UIPickerViewDataSource, UIPickerViewDelegate, FinetuneDoneDelegate>{
}

@property (weak, nonatomic) IBOutlet UITextView *TextView;
@property (weak, nonatomic) IBOutlet UIPickerView *Picker;
@property (nonatomic, retain) NSMutableArray* columns;
@property (nonatomic, retain) NSMutableArray* Suspects;
@property (nonatomic, retain) NSMutableArray* Victims;
@property (nonatomic, retain) NSMutableArray* Murderweapons;
@property (nonatomic, retain) NSMutableArray* Locations;
@property (nonatomic, retain) NSMutableArray* Motives;
@property (nonatomic, retain) NSMutableArray* wordsToRemember;

@end
