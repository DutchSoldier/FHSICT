//
//  Kleding.h
//  SMPT32
//
//  Created by Jeroen Pelt on 08-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Kleding : NSObject
@property (retain) NSString* name;
@property (retain) UIImage* image;
@property (retain) NSString* color;
@property (retain) NSString* occation;
@property (retain) NSString* fabric;
@property (retain) NSString* sort;
@property (retain) NSMutableArray* seasons;
@property (nonatomic) NSInteger* hotness;

//get
-(NSString*) getName;
-(UIImage*) getImage;
-(NSString*) getColor;
-(NSString*) getOccation;
-(NSString*) getFabric;
-(NSString*) getSort;
-(NSMutableArray*) getSeasons;
-(NSInteger) getHotness;

//set
-(void)setName:(NSString *)_name;
-(void)setImage:(UIImage *)_image;
-(void)setColor:(NSString *)_color;
-(void)setOccation:(NSString *)_occation;
-(void)setFabric:(NSString *)_fabric;
-(void)setSort:(NSString *)_sort;
-(void)setSeasons:(NSMutableArray*)_seasons;
-(void)setHotness:(NSInteger *)_hotness;


@end
