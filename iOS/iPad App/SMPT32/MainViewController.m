//
//  MainViewController.m
//  SMPT32
//
//  Created by Jeroen Pelt on 09-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "MainViewController.h"
#import "WeatherProvider.h"

@interface MainViewController ()

@end

@implementation MainViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    //load weather beta
    WeatherProvider* wp = [WeatherProvider singletonWP];
    [wp applyForWeatherUpdates:self];
    [wp startWeatherUpdate];
   }

-(void)viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    [[self navigationController] setNavigationBarHidden:YES animated:YES];//hide bar
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

//weer update regel (Jeroen)
-(void)updateWeather:(NSNumber*)temperature:(NSString*)season:(NSString*)weather
{
    NSLog([NSString stringWithFormat:@"Weather today is %@ and the tamperature wil be %@ C",weather,[temperature stringValue]]);

}
@end
