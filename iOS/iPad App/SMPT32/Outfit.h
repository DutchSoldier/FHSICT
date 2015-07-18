//
//  Outfit.h
//  SMPT32
//
//  Created by Jeroen Pelt on 08-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Kleding.h"

@interface Outfit : NSObject
@property (retain) Kleding* top;
@property (retain) Kleding* bottom;
@property (retain) Kleding* shoes;

//get
-(Kleding*)getTop;
-(Kleding*)getBottom;
-(Kleding*)getShoes;

//set
-(void)setTop:(Kleding *)_top;
-(void)setBottom:(Kleding *)_bottom;
-(void)setShoes:(Kleding *)_shoes;
@end
