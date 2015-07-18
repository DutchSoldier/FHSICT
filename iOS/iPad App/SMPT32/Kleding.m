//
//  Kleding.m
//  SMPT32
//
//  Created by Jeroen Pelt on 08-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "Kleding.h"

@implementation Kleding
@synthesize name;
@synthesize image;
@synthesize color;
@synthesize occation;
@synthesize fabric;
@synthesize sort;
@synthesize seasons;
@synthesize hotness;

//gets
-(NSString*) getName
{
    return name;
}
-(UIImage*) getImage
{
    return image;
}
-(NSString*) getColor
{
    return color;
}
-(NSString*) getOccation
{
    return occation;
}
-(NSString*) getFabric
{
    return fabric;
}
-(NSString*) getSort
{
    return sort;
}
-(NSMutableArray *)getSeasons
{
    return seasons;
}
-(NSInteger) getHotness
{
    return *(hotness);
}

//set
-(void)setName:(NSString *)_name
{
    seasons = [[NSMutableArray alloc]init];
    name = _name;
}
-(void)setImage:(UIImage *)_image
{
    image = _image;
}
-(void)setColor:(NSString *)_color
{
    color = _color;
}
-(void)setOccation:(NSString *)_occation
{
    occation = _occation;
}
//[skh.fabric addObject:@"Silk"]; //summer , spring
//[skh.fabric addObject:@"Wool"]; //winter,fall
//[skh.fabric addObject:@"Nylon"]; //fall,spring
//[skh.fabric addObject:@"Polyester"]; //spring , summer ,fall
//[skh.fabric addObject:@"Acrylic"]; //spring summer fall
//[skh.fabric addObject:@"Spandex"]; //fall,spring
//[skh.fabric addObject:@"Lycra"]; //summer,fall
//[skh.fabric addObject:@"Lurex"]; //special (all year)
//[skh.fabric addObject:@"Denim"]; //all year
//[skh.fabric addObject:@"Cotton"]; //summer
//[skh.fabric addObject:@"Leather"]; //spring, summer, fall
//[skh.fabric addObject:@"Twaron"]; //allyear
//[skh.fabric addObject:@"Fur"]; //fall,winter
-(void)setFabric:(NSString *)_fabric
{
    fabric = _fabric;

   if([_fabric isEqualToString:@"Silk"] ||[_fabric isEqualToString:@"Nylon"] ||[_fabric isEqualToString:@"Polyester"] ||[_fabric isEqualToString:@"Acrylic"] ||[_fabric isEqualToString:@"Spandex"] ||[_fabric isEqualToString:@"Lurex"] ||[_fabric isEqualToString:@"Denim"] ||[_fabric isEqualToString:@"Leather"]||[_fabric isEqualToString:@"Twaron"])
   {
       [seasons addObject:@"Spring"];
   }
    if([_fabric isEqualToString:@"Silk"] ||[_fabric isEqualToString:@"Polyester"] ||[_fabric isEqualToString:@"Acrylic"] ||[_fabric isEqualToString:@"Lycra"] ||[_fabric isEqualToString:@"Lurex"] ||[_fabric isEqualToString:@"Denim"] ||[_fabric isEqualToString:@"Leather"]||[_fabric isEqualToString:@"Twaron"]||[_fabric isEqualToString:@"Cotton"])
    {
        [seasons addObject:@"Summer"];
    }
    if([_fabric isEqualToString:@"Wool"] ||[_fabric isEqualToString:@"Polyester"] ||[_fabric isEqualToString:@"Acrylic"]||[_fabric isEqualToString:@"Lurex"] ||[_fabric isEqualToString:@"Denim"] ||[_fabric isEqualToString:@"Leather"]||[_fabric isEqualToString:@"Twaron"]||[_fabric isEqualToString:@"Fur"])
    {
        [seasons addObject:@"Fall"];
    }
    if([_fabric isEqualToString:@"Wool"] ||[_fabric isEqualToString:@"Lurex"] ||[_fabric isEqualToString:@"Denim"] ||[_fabric isEqualToString:@"Leather"]||[_fabric isEqualToString:@"Twaron"]||[_fabric isEqualToString:@"Fur"])
    {
        [seasons addObject:@"Winter"];
    }
    
    //test
    [seasons addObject:@"Winter"];
    
}
-(void)setSort:(NSString *)_sort
{
    sort = _sort;
}
-(void)setSeasons:(NSMutableArray *)_seasons
{
    seasons = _seasons;
}
-(void)setHotness:(NSInteger *)_hotness
{
    hotness = _hotness;
}
@end
