//
//  KledingHandeler.m
//  SMPT32
//
//  Created by Jeroen Pelt on 08-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "KledingHandeler.h"
#import "WeatherProvider.h"

@implementation KledingHandeler
@synthesize kleding;
@synthesize occasions;
@synthesize fabric;
@synthesize color;
@synthesize sortTop;
@synthesize sortBotton;
@synthesize sortShoe;
@synthesize wp;

+(KledingHandeler*)singletonKH
{
    static KledingHandeler* skh = nil;
    @synchronized(self)
    {
        if(!skh)
        {
            skh = [[KledingHandeler alloc] init];
            skh.wp = [WeatherProvider singletonWP];
            skh.kleding = [[NSMutableArray alloc] init];
            skh.occasions = [[NSMutableArray alloc]init];
            [skh.occasions addObject:@"Casual"];
            [skh.occasions addObject:@"Working"];
            [skh.occasions addObject:@"Going out"];
            [skh.occasions addObject:@"Sports"];
            
            skh.color = [[NSMutableArray alloc]init];
            [skh.color addObject:@"Red"];
            [skh.color addObject:@"Orange"];
            [skh.color addObject:@"Green"];
            [skh.color addObject:@"Blue"];
            [skh.color addObject:@"Pink"];
            [skh.color addObject:@"Purple"];
            [skh.color addObject:@"Yellow"];
            [skh.color addObject:@"Gray"];
            [skh.color addObject:@"Black"];
            [skh.color addObject:@"White"];
            [skh.color addObject:@"Brown"];
            
            skh.fabric = [[NSMutableArray alloc]init];
            [skh.fabric addObject:@"Silk"]; //summer , spring
            [skh.fabric addObject:@"Wool"]; //winter,fall
            [skh.fabric addObject:@"Nylon"]; //fall,spring
            [skh.fabric addObject:@"Polyester"]; //spring , summer ,fall
            [skh.fabric addObject:@"Acrylic"]; //spring summer fall
            [skh.fabric addObject:@"Spandex"]; //fall,spring
            [skh.fabric addObject:@"Lycra"]; //summer,fall
            [skh.fabric addObject:@"Lurex"]; //special (all year)
            [skh.fabric addObject:@"Denim"]; //all year
            [skh.fabric addObject:@"Cotton"]; //summer
            [skh.fabric addObject:@"Leather"]; //spring, summer, fall
            [skh.fabric addObject:@"Twaron"]; //allyear
            [skh.fabric addObject:@"Fur"]; //fall,winter
            
            skh.sortTop = [[NSMutableArray alloc]init];
            skh.sortBotton = [[NSMutableArray alloc]init];
            skh.sortShoe = [[NSMutableArray alloc]init];
            
            //top
            [skh.sortTop addObject:@"Shirts Long sleeve"];
            [skh.sortTop addObject:@"Shirts Short sleeve"];
            [skh.sortTop addObject:@"Sweaters"];
            [skh.sortTop addObject:@"Blouses"];
            [skh.sortTop addObject:@"Dresses"];
            [skh.sortTop addObject:@"Coats"];
            //bottom
            [skh.sortBotton addObject:@"Jeans"];
            [skh.sortBotton addObject:@"Shorts"];
            [skh.sortBotton addObject:@"Skirt"];
            //shoes
            [skh.sortShoe addObject:@"Shoes"];
            //[skh.sortShoe addObject:@"Boots"];
            
            //demo
            Kleding* top_1 = [[Kleding alloc]init];
            [top_1 setName:@"Jema Wit"];
            [top_1 setColor:@"White"];
            [top_1 setFabric:@"Wool"];
            [top_1 setSort:@"Shirts Short sleeve"];
            [top_1 setOccation:@"Casual"];
            UIImage* top1 = [UIImage imageNamed:@"top_1.png"];
            [top_1 setImage:top1];
            [skh.kleding addObject:top_1];
            
            Kleding* top_2 = [[Kleding alloc]init];
            [top_2 setName:@"FEMA shirt"];
            [top_2 setColor:@"Brown"];
            [top_2 setFabric:@"Cotton"];
            [top_2 setSort:@"Shirts Long sleeve"];
            [top_2 setOccation:@"Casual"];
            UIImage* top2 = [UIImage imageNamed:@"top_2.png"];
            [top_2 setImage:top2];
            [skh.kleding addObject:top_2];
            
            Kleding* top_3 = [[Kleding alloc]init];
            [top_3 setName:@"Barcia Orange shirt"];
            [top_3 setColor:@"Orange"];
            [top_3 setFabric:@"Cotton"];
            [top_3 setSort:@"Shirts Long sleeve"];
            [top_3 setOccation:@"Going out"];
            UIImage* top3 = [UIImage imageNamed:@"top_3.png"];
            [top_3 setImage:top3];
            [skh.kleding addObject:top_3];
            
            Kleding* top_4 = [[Kleding alloc]init];
            [top_4 setName:@"Red Selected shirt"];
            [top_4 setColor:@"Red"];
            [top_4 setFabric:@"Cotton"];
            [top_4 setSort:@"Sweaters"];
            [top_4 setOccation:@"Going out"];
            UIImage* top4 = [UIImage imageNamed:@"top_4.png"];
            [top_4 setImage:top4];
            [skh.kleding addObject:top_4];
            
            Kleding* top_5 = [[Kleding alloc]init];
            [top_5 setName:@"Target winters blue"];
            [top_5 setColor:@"Blue"];
            [top_5 setFabric:@"Nylon"];
            [top_5 setSort:@"Coats"];
            [top_5 setOccation:@"Casual"];
            UIImage* top5 = [UIImage imageNamed:@"top_5.png"];
            [top_5 setImage:top5];
            [skh.kleding addObject:top_5];
            
            Kleding* top_6 = [[Kleding alloc]init];
            [top_6 setName:@"Micros Black"];
            [top_6 setColor:@"Black"];
            [top_6 setFabric:@"Nylon"];
            [top_6 setSort:@"Shirts Long sleeve"];
            [top_6 setOccation:@"Casual"];
            UIImage* top6 = [UIImage imageNamed:@"top_6.png"];
            [top_6 setImage:top6];
            [skh.kleding addObject:top_6];
            
            Kleding* top_7 = [[Kleding alloc]init];
            [top_7 setName:@"O shirt"];
            [top_7 setColor:@"Orange"];
            [top_7 setFabric:@"Wool"];
            [top_7 setSort:@"Shirts Long sleeve"];
            [top_7 setOccation:@"Casual"];
            UIImage* top7 = [UIImage imageNamed:@"top_7.png"];
            [top_7 setImage:top7];
            [skh.kleding addObject:top_7];
            
            Kleding* top_11 = [[Kleding alloc]init];
            [top_11 setName:@"O shirt"];
            [top_11 setColor:@"Blue"];
            [top_11 setFabric:@"Nylon"];
            [top_11 setSort:@"Shirts Long sleeve"];
            [top_11 setOccation:@"Sports"];
            UIImage* top11 = [UIImage imageNamed:@"top_11.png"];
            [top_11 setImage:top11];
            [skh.kleding addObject:top_11];
            
            Kleding* bot_1 = [[Kleding alloc]init];
            [bot_1 setName:@"RTO Pants"];
            [bot_1 setColor:@"Black"];
            [bot_1 setFabric:@"Cotton"];
            [bot_1 setSort:@"Jeans"];
            [bot_1 setOccation:@"Casual"];
            UIImage* bot1 = [UIImage imageNamed:@"bot_1.png"];
            [bot_1 setImage:bot1];
            [skh.kleding addObject:bot_1];
            
            Kleding* bot_2 = [[Kleding alloc]init];
            [bot_2 setName:@"Greenway Pants"];
            [bot_2 setColor:@"Black"];
            [bot_2 setFabric:@"Cotton"];
            [bot_2 setSort:@"Jeans"];
            [bot_2 setOccation:@"Casual"];
            UIImage* bot2 = [UIImage imageNamed:@"bot_2.png"];
            [bot_2 setImage:bot2];
            [skh.kleding addObject:bot_2];
            
            Kleding* bot_3 = [[Kleding alloc]init];
            [bot_3 setName:@"Urban Wear Jeans"];
            [bot_3 setColor:@"Purple"];
            [bot_3 setFabric:@"Cotton"];
            [bot_3 setSort:@"Jeans"];
            [bot_3 setOccation:@"Going out"];
            UIImage* bot3 = [UIImage imageNamed:@"bot_3.png"];
            [bot_3 setImage:bot3];
            [skh.kleding addObject:bot_3];
            
            Kleding* bot_4 = [[Kleding alloc]init];
            [bot_4 setName:@"Flamengo Pink Jeans"];
            [bot_4 setColor:@"Pink"];
            [bot_4 setFabric:@"Cotton"];
            [bot_4 setSort:@"Jeans"];
            [bot_4 setOccation:@"Going out"];
            UIImage* bot4 = [UIImage imageNamed:@"bot_4.png"];
            [bot_4 setImage:bot4];
            [skh.kleding addObject:bot_4];
            
            Kleding* bot_5 = [[Kleding alloc]init];
            [bot_5 setName:@"WinterWear red Pants"];
            [bot_5 setColor:@"Red"];
            [bot_5 setFabric:@"Cotton"];
            [bot_5 setSort:@"Jeans"];
            [bot_5 setOccation:@"Casual"];
            UIImage* bot5 = [UIImage imageNamed:@"bot_5.png"];
            [bot_5 setImage:bot5];
            [skh.kleding addObject:bot_5];
            
            Kleding* bot_11 = [[Kleding alloc]init];
            [bot_11 setName:@"EuroSportWear Pants"];
            [bot_11 setColor:@"Black"];
            [bot_11 setFabric:@"Cotton"];
            [bot_11 setSort:@"Jeans"];
            [bot_11 setOccation:@"Sports"];
            UIImage* bot11 = [UIImage imageNamed:@"bot_11.png"];
            [bot_11 setImage:bot11];
            [skh.kleding addObject:bot_11];
             
            Kleding* sho_1 = [[Kleding alloc]init];
            [sho_1 setName:@"C&A Casual shoes"];
            [sho_1 setColor:@"Black"];
            [sho_1 setFabric:@"Leather"];
            [sho_1 setSort:@"Shoes"];
            [sho_1 setOccation:@"Casual"];
            UIImage* sho1 = [UIImage imageNamed:@"shoe_1.png"];
            [sho_1 setImage:sho1];
             [skh.kleding addObject:sho_1];
             
             Kleding* sho_2 = [[Kleding alloc]init];
             [sho_2 setName:@"Pine black shoes"];
             [sho_2 setColor:@"Black"];
             [sho_2 setFabric:@"Leather"];
             [sho_2 setSort:@"Shoes"];
             [sho_2 setOccation:@"Casual"];
             UIImage* sho2 = [UIImage imageNamed:@"shoe_2.png"];
             [sho_2 setImage:sho2];
            [skh.kleding addObject:sho_2];
            
            Kleding* sho_3 = [[Kleding alloc]init];
            [sho_3 setName:@"Olang gym shoes"];
            [sho_3 setColor:@"Brown"];
            [sho_3 setFabric:@"Leather"];
            [sho_3 setSort:@"Shoes"];
            [sho_3 setOccation:@"Sports"];
            UIImage* sho3 = [UIImage imageNamed:@"Shoe_3.png"];
            [sho_3 setImage:sho3];
            [skh.kleding addObject:sho_3];
            
            Kleding* sho_4 = [[Kleding alloc]init];
            [sho_4 setName:@"ONike Sprint-ware"];
            [sho_4 setColor:@"Black"];
            [sho_4 setFabric:@"Leather"];
            [sho_4 setSort:@"Shoes"];
            [sho_4 setOccation:@"Going out"];
            UIImage* sho4 = [UIImage imageNamed:@"shoe_4.png"];
            [sho_4 setImage:sho4];
            [skh.kleding addObject:sho_4];
            
            Kleding* sho_5 = [[Kleding alloc]init];
            [sho_5 setName:@"Suprime blacky"];
            [sho_5 setColor:@"Black"];
            [sho_5 setFabric:@"Leather"];
            [sho_5 setSort:@"Shoes"];
            [sho_5 setOccation:@"Sports"];
            UIImage* sho5 = [UIImage imageNamed:@"shoe_5.png"];
            [sho_5 setImage:sho5];
            [skh.kleding addObject:sho_5];
            
        }
    }
    return skh;
}

-(NSMutableArray*) getKleding
{
    return kleding;
}
-(NSMutableArray*) getKledingWithOccasion:(NSString*) occasion
{
    NSMutableArray* kledingWithOccasion = [[NSMutableArray alloc]init];
    
    for (Kleding* k in kleding) {
        if([k.getOccation isEqualToString:occasion])
        {
            [kledingWithOccasion addObject:k];
        }
    }
    return kledingWithOccasion;
}
-(NSMutableArray*) getKledingWithSort:(NSString*) sort
{
    NSMutableArray* kledingWithSort = [[NSMutableArray alloc]init];
    
    for (Kleding* k in kleding) {
        if([k.getSort isEqualToString:sort])
        {
            [kledingWithSort addObject:k];
        }
    }
    return kledingWithSort;
}
-(NSMutableArray*) getKledingWithOccasion:(NSString*) occasion WithSort:(NSString*) sort
{
    NSMutableArray* kledingWithSortandOccasion = [[NSMutableArray alloc]init];
    
    for (Kleding* k in kleding) {
        if([k.getOccation isEqualToString:occasion])
        {
            if([k.getSort isEqualToString:sort])
            {
                [kledingWithSortandOccasion addObject:k];
            }
        }
    }
    return kledingWithSortandOccasion;
}
-(NSMutableArray*) getOccasions
{
    return occasions;
}
-(NSMutableArray*) getSort
{
    NSMutableArray* sort = [[NSMutableArray alloc]init];
    for (NSString* t in sortTop) {
        [sort addObject:t];
    }
    for (NSString* b in sortBotton) {
        [sort addObject:b];
    }
    for (NSString* s in sortShoe) {
        [sort addObject:s];
    }
    return sort;
}
-(NSMutableArray*)getFabric
{
    return fabric;
}
-(NSMutableArray*)getColor
{
    return color;
}

-(void)addKledingObject:(Kleding*) kledingstuk
{
    [kleding addObject:kledingstuk];
}
-(void)removeKledingObject:(Kleding *)kledingstuk
{
    [kleding removeObject:kledingstuk];
}
-(Outfit*)generateOutfit:(NSString*) occasion
{
    //int randNum = rand() % ([max intValue] - [min intValue]+1) + [min intValue];
    //TODO Weer
    Outfit* o = [[Outfit alloc]init];
    WeatherProvider* wp = [WeatherProvider singletonWP];
    
    NSMutableArray* topKleding = [[NSMutableArray alloc]init];
    NSMutableArray* bottonKleding = [[NSMutableArray alloc]init];
    NSMutableArray* shoeKleding = [[NSMutableArray alloc]init];
    
    //sort kleding in groeps
    //lente en zomer temp > 15
    //kleuren:
    //sort: Shirt
    //Herft en Winter  temp <= 15
    //kleuren:
    //sort: Trui,
    
    //[wp temperature];
    //Spring,Summer,Fall,Winter
    //Sports = all season

    
    for (Kleding* k in kleding) {
        for (NSString* t in sortTop) {
            if([k.getSort isEqualToString:t])
            {
                for(NSString* season in k.getSeasons)
                {
                    if([wp.season isEqualToString:season])
                    {
                        [topKleding addObject:k];
                    }
                }
            }
        }
        for (NSString* t in sortBotton) {
            if([k.getSort isEqualToString:t])
            {
                for(NSString* season in k.getSeasons)
                {
                    if([wp.season isEqualToString:season])
                    {
                        [bottonKleding addObject:k];
                    }
                }
            }
        }
        for (NSString* t in sortShoe) {
            if([k.getSort isEqualToString:t])
            {
                [shoeKleding addObject:k];
            }
        }
    }
    
    //start random generation :) 
    NSInteger topN = rand() % ([topKleding count] - 0) + 0;
    NSInteger botN = rand() % ([bottonKleding count] - 0) + 0;
    NSInteger shoN = rand() % ([shoeKleding count] - 0) + 0;
    
    o.top = [topKleding objectAtIndex:topN];
    o.bottom = [bottonKleding objectAtIndex:botN];
    o.shoes = [shoeKleding objectAtIndex:shoN];
    
    return o;
}

@end
