//
//  test03RTMPlib.h
//  test03RTMPlib
//
//  Created by Hank on 2014/9/30.
//  Copyright (c) 2014年 tester. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "RTMPClient.h"
#import "UIKit/UIKit.h"

@interface test03RTMPlib : NSObject<IRTMPClientDelegate, UITextFieldDelegate, UIAlertViewDelegate>
{

    RTMPClient *myRTMPClient;
    RTMPClient *socket;
    
    NSArray *arg2;
    
    int state;
    int alerts;
    BOOL isRTMPS;

}



@end
