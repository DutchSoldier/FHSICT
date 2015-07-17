//
//  GlowAct.m
//  HelloGlow
//
//  Created by Luc on 8/31/12.
//  Copyright (c) 2012 Luc. All rights reserved.
//
#import "GlowAct.h"
@implementation GlowAct
@synthesize  name;
@synthesize rating;
@synthesize startTime;

-(void)showInfo
{
    NSLog(@"naam %@, rating %ld, start tijd %@", name, rating, startTime);
}


@end
