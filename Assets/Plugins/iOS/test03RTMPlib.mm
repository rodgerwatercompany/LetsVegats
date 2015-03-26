//
//  test03RTMPlib.m
//  test03RTMPlib
//
//  Created by Hank on 2014/9/30.
//  Copyright (c) 2014年 tester. All rights reserved.
//

#import "test03RTMPlib.h"
#import "BinaryCodec.h"
#import "DEBUG.h"

extern void UnitySendMessage(const char *, const char *, const char *);

@implementation test03RTMPlib


-(void)connectFMS:(NSString *)_host withAppName:(NSString *)_app{
    
    NSLog(@"Start connectFMS, object C processing......");
    
    if(_host!=nil&&_app!=nil){
        NSString *url = [NSString stringWithFormat:@"%@/%@", _host, _app];
        if(url!=nil){
            socket = [RTMPClient new];
            socket.delegate=self;
            NSLog(@"(connectToFMS) URL: %@", url);
            [socket connect:url];
        }
    }
}


-(void)onDoNothing:(id)call{}

-(void)callFMSAPI:(NSString *)APIname andParameter:(NSString *) para{
    
    NSString *method= APIname;
    NSMutableArray * args=[NSMutableArray array];
    
    NSLog(@"Start call the function --- %@, and setting the parameter ---%@",APIname,para);
    
    
    [args addObject:para];
    [socket invoke:method withArgs:args responder:[AsynCall call:self method:@selector(onDoNothing:)]];
}

-(void)callFMSAPI:(NSString *)APIname{
    
    NSString *method= APIname;
    
    NSLog(@"Start call the function --- %@, and none parameter ",APIname);
    
    
    
    [socket invoke:method withArgs:nil responder:[AsynCall call:self method:@selector(onDoNothing:)]];
}

-(void)callFMSAPI:(NSString *)APIname andParameter1:(NSString *)para1 andParameter2:(NSString *)para2{

    NSString *method= APIname;
    NSMutableArray * args=[NSMutableArray array];
    NSLog(@"Start call the function --- %@, and setting the parameter ---%@---%@",APIname,para1,para2);
    [args addObject:para1];
    [args addObject:para2];
    [socket invoke:method withArgs:args responder:[AsynCall call:self method:@selector(onDoNothing:)]];

}

-(void)callFMSAPI:(NSString *)APIname andParameter1:(NSString *)para1 andParameter2:(NSString *)para2 andParameter3:(NSString *)para3{
    
    NSString *method= APIname;
    NSMutableArray * args=[NSMutableArray array];
    NSLog(@"Start call the function --- %@, and setting the parameter ---%@---%@-----%@",APIname,para1,para2,para3);
    [args addObject:para1];
    [args addObject:para2];
    [args addObject:para3];
    [socket invoke:method withArgs:args responder:[AsynCall call:self method:@selector(onDoNothing:)]];
    
}

-(void)callFMSAPIint:(NSString *)APIname andParameter1: (id) numberp{
    
    NSString *method= APIname;
    NSMutableArray * args=[NSMutableArray array];
    NSLog(@"Start call the function --- %@, and setting the parameter %@---",APIname,numberp);
    //[args addObject:numberp];
    
    [socket invoke:method withArgs:numberp responder:[AsynCall call:self method:@selector(onDoNothing:)]];
    
}


//RTMP connect status event, need to implement
-(void)connectedEvent {
    
    NSString * connected=@"OnConnect[{""data"":""Connected to RTMP server, waiting the order from Unity.""}]";
    NSLog(@" $$$$$$ <IRTMPClientDelegate>> connectedEvent\n");
    NSLog(@"RTMP connected, waiting the order from Unity!");
    
    UnitySendMessage("ServerToClientObject","OnServerMSG",[connected cStringUsingEncoding:[NSString defaultCStringEncoding]]);
    //const char* xstring = [connected cStringUsingEncoding:[NSString defaultCStringEncoding]];
    
    /*NSMutableArray *args=[NSMutableArray array];
    NSString *method=@"loginBySid";
    NSLog(@"START DO LOGIN, prepare setting ssid and 5402!!!");
    [args addObject:@"p7da23b7z1qn80c9z9s1x4lz17ho13z2142"];
    [args addObject:@"5402"];
    [socket invoke:method withArgs:args responder:[AsynCall call:self method:@selector(onDoNothing:)]];*/
    
    
}

-(void)disconnectedEvent {
    NSLog(@" $$$$$$ <IRTMPClientDelegate>> disconnectedEvent\n");
    
    NSString * disconnected=@"OnDisconnedted[{""data"":""""}]";
    UnitySendMessage("ServerToClientObject", "OnServerMSG", [disconnected cStringUsingEncoding:[NSString defaultCStringEncoding]]);
}

-(void)connectFailedEvent:(int)code description:(NSString *)description {
    NSLog(@" $$$$$$ <IRTMPClientDelegate>> connectFailedEvent: %d = '%@'\n", code, description);
    
    NSString *connectFailed=@"OnConnectFailed[{""data"":""""}]";
    UnitySendMessage("ServerToClientObject", "OnServerMSG", [connectFailed cStringUsingEncoding:[NSString defaultCStringEncoding]]);
}

-(void)Disconnect{

    [socket disconnect];
}

-(void)resultReceived:(id <IServiceCall>)call {
    
    NSLog(@"Start receive data from server");
    int status = [call getStatus];
    NSString *method = [call getServiceMethodName];
    
    NSArray *args = [call getArguments];
    int invokeId = [call getInvokeId];
    //NSDictionary *result = (args.count) ? [args objectAtIndex:0] : nil;
    
    //NSLog(@"<FMS ResultReceived> status=%d, invokeID=%d, method='%@' arguments=%@\n", status, invokeId, method, result);
    //NSLog(@"%@",result);
    NSData * data=[NSJSONSerialization dataWithJSONObject:args  options:1 error:nil];
    NSString *result2string = [[NSString alloc]initWithData:data encoding:4];
    //NSLog(@"RESULT = %@",result2string);
    
    NSString *str_sum = [[NSString alloc] init];
    str_sum = [method stringByAppendingString:result2string];
    
    NSLog(@"str_sum :%@",str_sum);
    
    //NSLog(@"%@",result2string);
    //NSString *onLogin=@"onLogin";
    
    //const char * testString= [result2string cStringUsingEncoding:[NSString defaultCStringEncoding]];
    
    
    UnitySendMessage("ServerToClientObject", "OnServerMSG", [str_sum cStringUsingEncoding:[NSString defaultCStringEncoding]]);
    
    
    
}

@end

static test03RTMPlib *myRTMPobj=[test03RTMPlib new];

extern "C"
{
    void _cConnect(char cConnectHost[], char cConnectApp[]){
        
        
        //myRTMPobj =[test03RTMPlib new];
        NSLog(@"Start _cConnect......");
        NSString* hostNSString=[NSString stringWithFormat:@"%s",cConnectHost];
        NSString* appNSString=[NSString stringWithFormat:@"%s",cConnectApp];
        [myRTMPobj connectFMS:hostNSString withAppName:appNSString];
        NSLog(@"Finish _cConnect......");
        //[myRTMPobj doLogin];
        
    
    }
    
    void _cDisconnect(){
    
        [myRTMPobj Disconnect];
    }
    
    void _cCallFmsApiWith1P(char cApiName[], char cPara[]){
        
        NSString* apiName=[NSString stringWithFormat:@"%s",cApiName];
        NSString* para=[NSString stringWithFormat:@"%s",cPara];
        NSLog(@"Start call fms api with one parameter...");
       // myRTMPobj=[test03RTMPlib new];
        [myRTMPobj callFMSAPI:apiName andParameter:para];
    
    }
    
    void _cCallFmsApiWith1int(char cApiName[], id cPara){
        
        NSString* apiName=[NSString stringWithFormat:@"%s",cApiName];
        //NSString* para=[NSString stringWithFormat:@"%s",cPara];
        NSLog(@"Start call fms api with one parameter...");
        // myRTMPobj=[test03RTMPlib new];
        [myRTMPobj callFMSAPIint:apiName andParameter1:cPara];
        
    }
    
    void _cCallFmsApiWithNoP(char cApiName[]){
        
        NSString* apiName=[NSString stringWithFormat:@"%s",cApiName];
                NSLog(@"Start call fms api with No parameter...");
        // myRTMPobj=[test03RTMPlib new];
        [myRTMPobj callFMSAPI:apiName ];
        
    }
    
    void _cCallFmsApiWith2P(char cApiName[], char cPara1[], char cPara2[]){
    
        NSString* apiName=[NSString stringWithFormat:@"%s",cApiName];
        NSString* para1=[NSString stringWithFormat:@"%s",cPara1];
        NSString* para2=[NSString stringWithFormat:@"%s",cPara2];
        NSLog(@"This is _cCallFmsApiWith2P, prepare to call callFMSAPI...");
        NSLog(@"prepare to call function:%@...and para1=%@...and para2=%@",apiName,para1,para2);
        //myRTMPobj =[test03RTMPlib new];
        [myRTMPobj callFMSAPI:apiName andParameter1:para1 andParameter2:para2];
        
    }
    
    void _cCallFmsApiWith3P(char cApiName[], char cPara1[], char cPara2[],char cPara3[]){
        
        NSString* apiName=[NSString stringWithFormat:@"%s",cApiName];
        NSString* para1=[NSString stringWithFormat:@"%s",cPara1];
        NSString* para2=[NSString stringWithFormat:@"%s",cPara2];
        NSString* para3=[NSString stringWithFormat:@"%s",cPara3];
        NSLog(@"This is _cCallFmsApiWith2P, prepare to call callFMSAPI...");
        NSLog(@"prepare to call function:%@...and para1=%@...and para2=%@",apiName,para1,para2);
        //myRTMPobj =[test03RTMPlib new];
        [myRTMPobj callFMSAPI:apiName andParameter1:para1 andParameter2:para2 andParameter3:para3];
        
    }    

}
