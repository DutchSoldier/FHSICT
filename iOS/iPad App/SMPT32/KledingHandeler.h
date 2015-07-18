//
//  KledingHandeler.h
//  SMPT32
//
//  Created by Jeroen Pelt on 08-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Kleding.h"
#import "Outfit.h"
#import "WeatherProvider.h"

@interface KledingHandeler : NSObject
@property (nonatomic, strong) NSMutableArray* kleding;
@property (nonatomic, strong) NSMutableArray* occasions;
@property (nonatomic, strong) NSMutableArray* color;
@property (nonatomic, strong) NSMutableArray* fabric;
@property (retain) WeatherProvider* wp;

@property (nonatomic, strong) NSMutableArray* sortTop;
@property (nonatomic, strong) NSMutableArray* sortBotton;
@property (nonatomic, strong) NSMutableArray* sortShoe;

+(KledingHandeler*)singletonKH;

-(NSMutableArray*) getKleding;
-(NSMutableArray*) getKledingWithOccasion:(NSString*) occasion;
-(NSMutableArray*) getKledingWithSort:(NSString*) sort;
-(NSMutableArray*) getKledingWithOccasion:(NSString*) occasion WithSort:(NSString*) sort;
-(NSMutableArray*) getFabric;
-(NSMutableArray*) getColor;
-(NSMutableArray*) getOccasions;
-(NSMutableArray*) getSort;

-(void)addKledingObject:(Kleding*) kledingstuk;
-(void)removeKledingObject:(Kleding *)kledingstuk;
-(Outfit*)generateOutfit:(NSString*) occasion;
@end
