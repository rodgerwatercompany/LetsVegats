//
//  RTMPLib.m
//  RTMPLib
//
//  Created by Wang Hsin Wei on 19/09/14.
//  Copyright (c) 2014 Wang Hsin Wei. All rights reserved.
//

#import "RTMPLib.h"
#import "BinaryCodec.h"
#import "DEBUG.h"

extern void UnitySendMessage(const char *, const char *, const char *);

@implementation RTMPLib

-(void)result:(id)result {
    
}

-(void)execOnLogin :(NSString *)_method withSid:(NSString *)_sid withType:(NSString *)_type{
    printf(" SEND ----> loginBySid\n");
    NSMutableArray *args = [NSMutableArray array];
    // set call parameters
    
    //NSString *method = @"loginBySid";
    NSString *method = _method;
    
    
    //NSMutableArray *param1 = [NSMutableArray array];
    //[param1 addObject:@"SIDSIDSIDSIDSID"];
    //[param1 addObject:@"5402"];
    
    //[args addObject:@"ef95aa09zgmegnf9z2gff6jez806122z2142"];
    //[args addObject:@"5402"];
    [args addObject:_sid];
    [args addObject:_type];
    
    // send invoke
    [socket invoke:method withArgs:args responder:[AsynCall call:self method:@selector(result:)]];
}

-(void)sendMsgFMS:(NSString *)_method withArgs:(NSArray *)_args{
    if(_method!=nil&&_args!=nil){
        NSMutableArray *args = [NSMutableArray array];
        NSString *method = _method;
        for(NSString *para : _args){
            [args addObject:para];
        }
        //[args addObject:@"ef95aa09zgmegnf9z2gff6jez806122z2142"];
        //[args addObject:@"5402"];
        [socket invoke:method withArgs:args responder:[AsynCall call:self method:@selector(result:)]];
    }
}

#pragma mark -
#pragma mark IRTMPClientDelegate Methods

-(void)connectedEvent {
    
    NSString * connected=@"CONNECTED";
    NSLog(@" $$$$$$ <IRTMPClientDelegate>> connectedEvent\n");
    
 UnitySendMessage("Main Camera","reciveMessageFromIOS",[connected cStringUsingEncoding:[NSString defaultCStringEncoding]]);
    
}

-(void)disconnectedEvent {
    NSLog(@" $$$$$$ <IRTMPClientDelegate>> disconnectedEvent\n");
}

-(void)connectFailedEvent:(int)code description:(NSString *)description {
    NSLog(@" $$$$$$ <IRTMPClientDelegate>> connectFailedEvent: %d = '%@'\n", code, description);
}

-(void)resultReceived:(id <IServiceCall>)call {
    int status = [call getStatus];
    NSString *method = [call getServiceMethodName];
    
    NSArray *args = [call getArguments];
    int invokeId = [call getInvokeId];
    id result = (args.count) ? [args objectAtIndex:0] : nil;
    
    NSLog(@"<FMS ResultReceived> status=%d, invokeID=%d, method='%@' arguments=%@\n", status, invokeId, method, result);
    //UnitySendMessage("Main Camera","reciveMessageFromIOS",[[NSString stringWithFormat:@"%@", result] cStringUsingEncoding:[NSString defaultCStringEncoding]]);
}


-(NSData *)bigData {
    
    int len = 100000;
    char* buf = (char*)malloc(len);
    
    for (int i = 0; i < len; i++)
        buf[i] = (char)i%256;
    
    NSData *data = [NSData dataWithBytes:buf length:len];
    
    free(buf);
    
    return data;
}

-(void)disConnectFMS{
    [socket disconnect];
    socket=nil;
}

-(void)connectFMS:(NSString *)_host withAppName:(NSString *)_app{
    
    NSLog(@"Start connectFMS");
    
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
-(void)sendMsgtoUnityforDebug//:(NSString *)msgToUnity{
{
    
    
    NSLog(@"Start sendMsg, and convert NSString to string");
    
    //NSString *testString=@"test Nsstring convert to string";
    //[NSString stringWithUTF8String:testString];
    UnitySendMessage("Main Camera", "reciveMessageFromIOS", "testDebug");
   // UnitySendMessage("Main Camera","reciveMessageFromIOS",[msgToUnity cStringUsingEncoding:[NSString defaultCStringEncoding]]);

}

-(void)showAlert:(NSString *)message {
    UIAlertView *av = [[UIAlertView alloc] initWithTitle:@"Receive" message:message delegate:self cancelButtonTitle:@"Ok" otherButtonTitles:nil];
	alerts++;
	av.tag = alerts;
    [av show];
}

@end

static RTMPLib* myStringObj = nil;
static RTMPLib *FMSRtmp = nil;
static id test;


UIAlertView *av2=nil;

void showAlertBox(const char* message){

    av2=[[UIAlertView alloc] initWithTitle:@"Receive" message:@"iOS alert" delegate:nil cancelButtonTitle:@"Ok" otherButtonTitles:nil];

    [av2 setMessage:[NSString stringWithUTF8String:message]];
    [av2 show];
    
    UnitySendMessage("Main Camera","reciveMessageFromIOS","KKK");
    //UnitySendMessage(<#const char *#>, <#const char *#>, <#const char *#>)

}

void sendMsgtoUnityforDebug2(){
    
    UnitySendMessage("Main Camera","reciveMessageFromIOS","msg from iOS");
    
}

char* MakeStringCopy(const char* string){

    if(string==NULL) return NULL;
    
    char* res=(char*)malloc(strlen(string)+1);
    strcpy(res, string);
    return res;

}


void connect(const char * _host,const char * _app){
    
    NSLog(@"(connect)");

        NSString *host= [NSString stringWithUTF8String:_host];
        NSString *app = [NSString stringWithUTF8String:_app];
        if(host!=nil&& app!=nil){
            NSLog(@"Start connect function's if control, and prepare FMSRTMP connect!!");
            NSLog(@"prepare host= %@  app= %@",host,app);
            
            FMSRtmp=[RTMPLib new];
            [FMSRtmp connectFMS:host withAppName:app];
            //RTMPLib * mytest = [RTMPLib new];
            myStringObj=[RTMPLib new];
            
           // [myStringObj sendMsgtoUnityforDebug:@"this is test NSstring from iOS in C function, connect."];
            
            
        }
    
    NSLog(@"host = %s  app=%s ",_host, _app);
    
}

extern "C"
{
    
    void _showAlertBox(){
        NSLog(@"(_showAlertBox)");
        showAlertBox("ALERT FORM IOS EXTERN C");
       // char * testChar=MakeStringCopy("1233211234567");
       // showAlertBox(testChar);
        
        
    }
    
    void _testConnect(char testHOST[], char testAPP[]){
        
        connect(testHOST, testAPP);
        
        //char [] convert to NSString
        NSString* hostString=[NSString stringWithFormat:@"%s",testHOST];
        NSString* appString=[NSString stringWithFormat:@"%s",testAPP];
        NSLog(@"_testConnect ");
        NSLog(@"host string = %@  app string = %@",hostString,appString);
        
        [FMSRtmp connectFMS:hostString withAppName:appString];
        
        
        
        UnitySendMessage("Main Camera","reciveMessageFromIOS","_testConnect From iOS");
       // [FMSRtmp sendMsgtoUnityforDebug:@"This is _testConnect in extern C"];
        
    
    }
    
    void sendMsg(const char* _method, const char* _sid, const char* _type){
        NSString *method = [NSString stringWithUTF8String:_method];
        NSString *sid = [NSString stringWithUTF8String:_sid];
        NSString *type = [NSString stringWithUTF8String:_type];
        
        [FMSRtmp execOnLogin:method withSid:sid withType:type];
    }
    
    void disConnect(const char* _host, const char* _app){
        [FMSRtmp disConnectFMS];
    }
}
