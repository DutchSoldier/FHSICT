//
//  City.h
//  HelloGlow
//
//  Created by Luc on 8/31/12.
//  Copyright (c) 2012 Luc. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface City : NSObject
@property NSString* name;
@property NSInteger population;
@property NSMutableArray* glowActs;

-(id)init;
-(void)showInfo;

@end
