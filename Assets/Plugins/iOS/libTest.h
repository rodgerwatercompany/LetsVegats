//
//  libTest.h
//  libTest
//
//  Created by Hank on 2014/9/11.
//  Copyright (c) 2014年 tester. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface libTest : NSObject

-(int)testEcho;

@end

@interface NSString(JRStringAdditions)

-(BOOL)containsString:(NSString *)string;
-(BOOL)containsString:(NSString *)string options:(NSStringCompareOptions)options;
@end
