//
//  WeatherUpdateObject.h
//  SMPT32
//
//  Created by Jeroen Pelt on 09-01-13.
//  Copyright (c) 2013 Remi. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface WeatherUpdateObject : NSObject
//note to self: maak castable naar ander views

-(void)updateWeather:(NSNumber*)temperature:(NSString*)season:(NSString*)weather;
@end
