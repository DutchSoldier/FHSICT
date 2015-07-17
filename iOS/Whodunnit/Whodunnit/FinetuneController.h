//
//  FinetuneController.h
//  Whodunnit
//
//  Created by Remi on 10/24/12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>

@protocol FinetuneDoneDelegate <NSObject>

-(void) finetuneDone :(NSString*) finetuneResult;

@end

@interface FinetuneController : UIViewController
{
    id<FinetuneDoneDelegate> delegate;
}
@property (weak, nonatomic) IBOutlet UITextView *Textview;
@property (nonatomic, copy) NSString* fineTuneText;
@property (retain) id delegate;

@end
