//
//  City.m
//  HelloGlow
//
//  Created by Luc on 8/31/12.
//  Copyright (c) 2012 Luc. All rights reserved.
//

#import "City.h"
#import "GlowAct.h"

@implementation City
@synthesize name;
@synthesize population;
@synthesize glowActs;

-(id)init
{
    if (self ==[super init])
    {
        glowActs =[[NSMutableArray alloc] init];
    }
    return self;
}


-(void)showInfo
{
    NSUInteger count = glowActs.count;
    NSLog(@"naam stad %@, populatie %ld, totaal aantal acts: %ld" , name, population, count);
    for(GlowAct* g in glowActs)
    {
        [g showInfo];
    }
    
    
}

@end
