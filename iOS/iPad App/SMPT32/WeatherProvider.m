//
//  WeatherProvider.m
//  SMPT32
//
//  Created by Jeroen Pelt on 09-01-13.
//  Copyright (c) 2013 Remi. All rights reserved.
//

#import "WeatherProvider.h"
#import "ASIHTTPRequest.h"
#import "ASIFormDataRequest.h"
#import "WeatherUpdateObject.h"

@implementation WeatherProvider

@synthesize season;
@synthesize weather;
@synthesize temperature;
@synthesize objectsToUpdate;


+(WeatherProvider*)singletonWP
{
    static WeatherProvider* wp = nil;
    @synchronized(self)
    {
        if(wp == nil)
        {
            wp = [[WeatherProvider alloc] init];
            wp.objectsToUpdate = [[NSMutableArray alloc]init];
            wp.season = @"NOT LOADED";
            wp.weather = @"NOT LOADED";
            wp.temperature = 0;
            [wp startWeatherUpdate];
        }
    }
    return wp;
}

-(void)startWeatherUpdate
{
    NSString* web_url = @"http://athena.fhict.nl/users/i265987/weather/";
    NSURL* url = [NSURL URLWithString:web_url];
    
    ASIHTTPRequest* request = [ASIFormDataRequest requestWithURL:url];
    [request setTag:101];
    [request setRequestMethod:@"GET"];
    [request setDelegate:self];
    [request startAsynchronous];
    NSLog(@"Start download");
    //[request startSynchronous];
}

-(void)requestFinished:(ASIHTTPRequest*)request
{ //commit error
    NSError* error = nil;
    NSData* responseData = [request responseData];
    NSDictionary* JSON = [NSJSONSerialization JSONObjectWithData:responseData options:NSJSONReadingMutableContainers error:&error];
    //NSLog(request.responseString);
    if(request.tag = 101)
    {
        weather = [JSON objectForKey:@"Weather"];
        season = [JSON objectForKey:@"Season"];
        temperature = [JSON objectForKey:@"Temperature"];

        if([objectsToUpdate count] > 0)
        {
            //NSLog(@"UPDATING ADDED OBJECTS");
            for(NSObject* o in objectsToUpdate)
            {
                //foute cast, hopelijk goede uitkomst :) (Jeroen)
                WeatherUpdateObject* wuo = (WeatherUpdateObject*)o;
            
                //NSLog(@"Weather update service:Sending data to object...");
                //verstuur weer data
                [wuo updateWeather:temperature :season :weather];
            }
        }
        
        //Jeroen's Object en JSON inhoud verklikker
        //NSMutableArray* keys = [JSON allKeys];
        //for(NSString* k in keys)
        //{
        //    NSString* sClass = NSStringFromClass([[JSON objectForKey:k]class]);
        //    NSLog([NSString stringWithFormat:@"(Key:%@) Object_Class:%@",k,sClass]);
        //}
    }
}

-(void)applyForWeatherUpdates:(NSObject*)objectToUpdate
{
    //NSLog(@"Weather update service:OBJECT ADDED");
    [objectsToUpdate addObject:objectToUpdate];
    
    if([season length]>0)
    {
        WeatherUpdateObject* wuo = (WeatherUpdateObject*)objectToUpdate;
        //verstuur weer data
        [wuo updateWeather:temperature :season :weather];
    }
    else
    {
        [self startWeatherUpdate];
    }
}


-(void)noMoreWeatherUpdates:(NSObject*)objectToRemove
{
    //NSLog(@"Weather update service:OBJECT REMOVED");
    [objectsToUpdate removeObject:objectToRemove];
}
@end
