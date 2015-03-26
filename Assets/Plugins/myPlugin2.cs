using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
//using System.Text;

public class myPlugin2 : MonoBehaviour
{
	[DllImport("__Internal")]	private static extern void _cDisconnect();
	public static void myDisconnect2(){

		_cDisconnect ();
	}
	[DllImport("__Internal")] private static extern void _cConnect(string host, string app);
	public static void myConnect2(string myHost, string myApp)
	{ _cConnect (myHost,myApp); }
	[DllImport("__Internal")]	private static extern void _cCallFmsApiWith1P(string apiName, string para1);
	public static void myCallFmsApiWith1P(string myApiName, string myPara1){

		_cCallFmsApiWith1P(myApiName,myPara1);

	}
	[DllImport("__Internal")]	private static extern void _cCallFmsApiWith1int(string apiName, int numberp);
	public static void myCallFmsApiWith1int(string myApiName, int myNumber){

		_cCallFmsApiWith1int (myApiName,myNumber);

	}
	[DllImport("__Internal")]	private static extern void _cCallFmsApiWithNoP(string apiName);
	public static void myCallFmsApiWithNoP(string myApiName){
		_cCallFmsApiWithNoP (myApiName);
	}
	[DllImport("__Internal")]	private static extern void _cCallFmsApiWith2P(string apiName,string para1,string para2);
	public static void myCallFmsApiWith2P(string myApiName,string myPara1,string myPara2){

		_cCallFmsApiWith2P (myApiName,myPara1,myPara2);

	}
	[DllImport("__Internal")]	private static extern void _cCallFmsApiWith3P(string apiName, string para1, string para2, string para3);
	public static void myCallFmsApiWith3P(string myApiName,string myPara1,string myPara2, string myPara3){
		
		_cCallFmsApiWith3P (myApiName,myPara1,myPara2,myPara3);
		
	}  
	[DllImport("__Internal")]	private static extern void connect (string _host, string _app);
	[DllImport("__Internal")]	private static extern void disConnect (string _host, string _app);    
	public static void myDisConnect(string _host, string _app){
		disConnect (_host,_app);
	}
    public static void Test()
    {
        Debug.Log("Test !");
    }
}
