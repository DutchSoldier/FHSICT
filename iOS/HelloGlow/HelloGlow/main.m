//
//  main.m
//  HelloGlow
//
//  Created by Luc on 8/31/12.
//  Copyright (c) 2012 Luc. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "GlowAct.h"
#import "City.h"


int main(int argc, const char * argv[])
{

    @autoreleasepool
    {
        GlowAct* blueLightAct = [GlowAct alloc];
        blueLightAct.name = @"Blue Light Act";
        blueLightAct.startTime = @"22:00";
        blueLightAct.rating = 8;
        
        GlowAct* redLightAct = [GlowAct alloc];
        redLightAct.name = @"Red Light Act";
        redLightAct.startTime = @"23:00";
        redLightAct.rating = 6;
        
        
        City* eindhoven = [[City alloc] init];
        eindhoven.name = @"Eindoven";
        eindhoven.population = 220000;
        [eindhoven.glowActs addObject:(GlowAct*)blueLightAct];
        [eindhoven.glowActs addObject:(GlowAct*)redLightAct];
        [eindhoven showInfo];
    }
    return 0;
}

