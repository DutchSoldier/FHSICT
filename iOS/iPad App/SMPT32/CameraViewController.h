//
//  CameraViewController.h
//  SMPT32
//
//  Created by Jeroen Pelt on 13-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <MobileCoreServices/MobileCoreServices.h>
#import "AddClothesViewController.h"
//#import "GPUImage.h"

@interface CameraViewController : UIViewController <UIImagePickerControllerDelegate,UINavigationControllerDelegate, UIPopoverControllerDelegate>
{
    UIToolbar *toolbar;
    UIPopoverController *popoverController;
    UIImageView *imageView;
    BOOL newMedia;
    UIImage *originalImage;
}
@property (retain) UIViewController* parrent;

@property (weak, nonatomic) IBOutlet UIBarButtonItem *SaveBtn;
@property (weak, nonatomic) IBOutlet UIButton *takePhotoBtn;
@property (weak, nonatomic) IBOutlet UIButton *choosePhotoBtn;
@property (nonatomic, retain) IBOutlet UIImageView *imageView;
@property (nonatomic, retain) UIPopoverController *popoverController;
@property (nonatomic, retain) IBOutlet UIToolbar *toolbar;

- (IBAction)useCamera: (id)sender;
- (IBAction)useCameraRoll: (id)sender;
- (IBAction)photoFromAlbum;
- (IBAction)photoFromCamera;

- (IBAction)saveImageToAlbum;
-(IBAction)UseFoto:(id)sender;

@end
