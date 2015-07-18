//
//  Outfit.m
//  SMPT32
//
//  Created by Jeroen Pelt on 08-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "Outfit.h"

@implementation Outfit
@synthesize top;
@synthesize bottom;
@synthesize shoes;

//get
-(Kleding*)getTop
{
    return top;
}
-(Kleding*)getBottom
{
    return bottom;
}
-(Kleding*)getShoes
{
    return shoes;
}

//set
-(void)setTop:(Kleding *)_top
{
    top = _top;
}
-(void)setBottom:(Kleding *)_bottom
{
    bottom = _bottom;
}
-(void)setShoes:(Kleding *)_shoes
{
    shoes = _shoes;
}
@end
