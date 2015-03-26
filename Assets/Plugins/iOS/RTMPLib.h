//
//  RTMPLib.h
//  RTMPLib
//
//  Created by Wang Hsin Wei on 19/09/14.
//  Copyright (c) 2014 Wang Hsin Wei. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


#import "RTMPClient.h"

@interface RTMPLib : NSObject<IRTMPClientDelegate, UITextFieldDelegate, UIAlertViewDelegate>
{
    RTMPClient *rtmpClient;
    
    RTMPClient	*socket;
	int			state;
	int			alerts;
    BOOL        isRTMPS;
}

-(void)connectFMS:(NSString *)_host withAppName:(NSString *)_app;
-(void)disConnectFMS;
-(void)sendMsgFMS:(NSString *)_method withArgs:(NSArray *)_args;
@end
