//
//  WeatherProvider.h
//  SMPT32
//
//  Created by Jeroen Pelt on 09-01-13.
//  Copyright (c) 2013 Remi. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface WeatherProvider : NSObject
@property (retain) NSNumber* temperature;
@property (retain) NSString* season;
@property (retain) NSString* weather;
@property (retain) NSMutableArray* objectsToUpdate;

+(WeatherProvider*)singletonWP;
-(void)startWeatherUpdate;


-(void)applyForWeatherUpdates:(NSObject*)objectToUpdate;
-(void)noMoreWeatherUpdates:(NSObject*)objectToRemove;
@end
