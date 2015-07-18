//
//  CameraViewController.m
//  SMPT32
//
//  Created by Jeroen Pelt on 13-12-12.
//  Copyright (c) 2012 Remi. All rights reserved.
//

#import "CameraViewController.h"
#import "AddClothesViewController.h"

@interface CameraViewController ()

    


@end

@implementation CameraViewController
@synthesize imageView, popoverController, toolbar, choosePhotoBtn, takePhotoBtn, SaveBtn;
@synthesize parrent;

- (IBAction) useCamera: (id)sender
{
    if ([UIImagePickerController isSourceTypeAvailable:
         UIImagePickerControllerSourceTypeCamera])
    {
        UIImagePickerController *imagePicker = [[UIImagePickerController alloc] init];
        imagePicker.delegate = self;
        imagePicker.sourceType = UIImagePickerControllerSourceTypeCamera;
        imagePicker.mediaTypes = [NSArray arrayWithObjects:(NSString *) kUTTypeImage,nil];
        imagePicker.allowsEditing = NO;
        [self presentModalViewController:imagePicker animated:YES];
        newMedia = YES;
    }
}

- (IBAction) useCameraRoll: (id)sender
{
    if ([self.popoverController isPopoverVisible]) {
        [self.popoverController dismissPopoverAnimated:YES];
    } else {
        if ([UIImagePickerController isSourceTypeAvailable:
             UIImagePickerControllerSourceTypeSavedPhotosAlbum])
        {
            UIImagePickerController *imagePicker =
            [[UIImagePickerController alloc] init];
            imagePicker.delegate = self;
            imagePicker.sourceType =
            UIImagePickerControllerSourceTypePhotoLibrary;
            imagePicker.mediaTypes = [NSArray arrayWithObjects:
                                      (NSString *) kUTTypeImage,
                                      nil];
            imagePicker.allowsEditing = NO;
            
            self.popoverController = [[UIPopoverController alloc]
                                      initWithContentViewController:imagePicker];
            
            popoverController.delegate = self;
            
            [self.popoverController
             presentPopoverFromBarButtonItem:sender
             permittedArrowDirections:UIPopoverArrowDirectionUp
             animated:YES];
            
            newMedia = NO;
        }
    }
}
- (IBAction)takePhotoBtn:(id)sender {
}
- (IBAction)choosePhotoBtn:(id)sender {
}
- (IBAction)SaveBtn:(id)sender {
}
- (IBAction)FilterBtn:(id)sender {
}

/*-(void)imagePickerController:(UIImagePickerController *)picker
didFinishPickingMediaWithInfo:(NSDictionary *)info
{
    [self.popoverController dismissPopoverAnimated:true];
    
    NSString *mediaType = [info
                           objectForKey:UIImagePickerControllerMediaType];
    [self dismissModalViewControllerAnimated:YES];
    if ([mediaType isEqualToString:(NSString *)kUTTypeImage]) {
        UIImage *image = [info
                          objectForKey:UIImagePickerControllerOriginalImage];
        
        imageView.image = image;
        if (newMedia)
            UIImageWriteToSavedPhotosAlbum(image,
                                           self,
                                           @selector(image:finishedSavingWithError:contextInfo:),
                                           nil);
    }
    else if ([mediaType isEqualToString:(NSString *)kUTTypeMovie])
    {
        // Code here to support video if enabled
    }
}*/
-(void)image:(UIImage *)image
finishedSavingWithError:(NSError *)error
 contextInfo:(void *)contextInfo
{
    if (error) {
        UIAlertView *alert = [[UIAlertView alloc]
                              initWithTitle: @"Save failed"
                              message: @"Failed to save image"\
                              delegate: nil
                              cancelButtonTitle:@"OK"
                              otherButtonTitles:nil];
        [alert show];
    }
}

-(void)imagePickerControllerDidCancel:(UIImagePickerController *)picker
{
    [self dismissModalViewControllerAnimated:YES];
}

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
    
    self.navigationItem.title = @"Camera";
    UIBarButtonItem *cameraButton = [[UIBarButtonItem alloc]
                                     initWithTitle:@"Camera"
                                     style:UIBarButtonItemStyleBordered
                                     target:self
                                     action:@selector(useCamera:)];
    UIBarButtonItem *cameraRollButton = [[UIBarButtonItem alloc]
                                         initWithTitle:@"Camera Roll"
                                         style:UIBarButtonItemStyleBordered
                                         target:self
                                         action:@selector(useCameraRoll:)];
    NSArray *items = [NSArray arrayWithObjects: cameraButton,
                      cameraRollButton, SaveBtn, nil];
    [toolbar setItems:items animated:NO];
    [super viewDidLoad];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


- (IBAction)photoFromAlbum
{
    UIImagePickerController *photoPicker = [[UIImagePickerController alloc] init];
    photoPicker.delegate = self;
    photoPicker.sourceType = UIImagePickerControllerSourceTypePhotoLibrary;
    [self presentViewController:photoPicker animated:YES completion:NULL];
}

- (IBAction)photoFromCamera
{
    UIImagePickerController *photoPicker = [[UIImagePickerController alloc] init];
    photoPicker.delegate = self;
    photoPicker.sourceType = UIImagePickerControllerSourceTypeCamera;
    [self presentViewController:photoPicker animated:YES completion:NULL];
}

/*- (void)imagePickerController:(UIImagePickerController *)photoPicker didFinishPickingMediaWithInfo:(NSDictionary *)info
{
    self.SaveBtn.enabled = YES;
    self.FilterBtn.enabled = YES;
    UIImage *selectedImage = [info valueForKey:UIImagePickerControllerOriginalImage];
    [self.imageView setImage:selectedImage];
    [photoPicker dismissModalViewControllerAnimated:YES];
}*/

- (void)imagePickerController:(UIImagePickerController *)photoPicker didFinishPickingMediaWithInfo:(NSDictionary *)info
{
    self.SaveBtn.enabled = YES;
    originalImage = [info valueForKey:UIImagePickerControllerOriginalImage];
    [self.imageView setImage:originalImage];
    [photoPicker dismissModalViewControllerAnimated:YES];
}

- (IBAction)saveImageToAlbum
{
    UIImageWriteToSavedPhotosAlbum(self.imageView.image, self, @selector(image:didFinishSavingWithError:contextInfo:), nil);
}

- (void)image:(UIImage *)image didFinishSavingWithError:(NSError *)error contextInfo:(void *)contextInfo
{
    NSString *alertTitle;
    NSString *alertMessage;
    if(!error)
    {
        alertTitle   = @"Image Saved";
        alertMessage = @"Image saved to photo album successfully.";
    }
    else
    {
        alertTitle   = @"Error";
        alertMessage = @"Unable to save to photo album.";
    }
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:alertTitle
                                                    message:alertMessage
                                                   delegate:self
                                          cancelButtonTitle:@"Okay"
                                          otherButtonTitles:nil];
    [alert show];
}

-(IBAction)UseFoto:(id)sender
{
    AddClothesViewController* p = self.parrent;
    [p setImage:self.imageView.image];
    p.demoview.image = self.imageView.image;
    [self dismissModalViewControllerAnimated:YES];
}

@end
