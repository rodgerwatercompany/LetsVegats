//
//  libTest.m
//  libTest
//
//  Created by Hank on 2014/9/11.
//  Copyright (c) 2014年 tester. All rights reserved.
//

#import "libTest.h"

@implementation libTest

-(int)testEcho
{
    //NSLog(@"Hello, this is testEcho, an iOS calling.");
    return 2;
}

@end


UIAlertView* alertView=nil;

void C_ShowAlertBox(const char* title, const char* message){
    
    if (alertView == nil) {
        alertView = [[UIAlertView alloc] initWithTitle:@"Alert" message:@"HIHI" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil];
        
    }

    [alertView setTitle:[NSString stringWithUTF8String:title]];
    [alertView setMessage:[NSString stringWithUTF8String:message]];
    [alertView show];
}

extern "C"
{
    int _testEcho()
    {
        return 3;
    }
}