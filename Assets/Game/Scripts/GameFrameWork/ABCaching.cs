using UnityEngine;
using System;
using System.IO;
using System.Xml;


public class ABCaching
{

    public static bool IsVersionCached(string url, int version)
    {


        string path = Application.persistentDataPath + "/AssetBundles";

        string xmlpath = "urlfindfilename.xml";
        XmlDocument xmlDoc = new XmlDocument();


        if (!File.Exists(path + "/" + xmlpath))
        {
            return false;
        }
        else
        {

            xmlDoc.Load(path + "/" + xmlpath);

            XmlNode root = xmlDoc.SelectSingleNode("Object");

            XmlNode find = root.SelectSingleNode("Property[@url='" + url + ".ver_" + version + "']");

            if (find == null)
                return false;
            else
                return true;

        }
    }
    public static void Save(byte[] bytes, string url, int version)
    {

        string path = Application.persistentDataPath + "/AssetBundles";


        // Check Directory paht or Create Directory.
        if (!System.IO.Directory.Exists(path))
        {

            Debug.Log("not exists");

            System.IO.Directory.CreateDirectory(path);

            if (!System.IO.Directory.Exists(path))
                Debug.Log("CreateDirectory Failed.");
            else
                Debug.Log("CreateDirectory Success.");
        }
        else
            Debug.Log("exists");

        // Check urlfindfilename.json.txt.
        string xmlpath = "urlfindfilename.xml";
        XmlDocument xmlDoc = new XmlDocument();




        if (!File.Exists(path + "/" + xmlpath))
        {

            XmlElement elmObj = xmlDoc.CreateElement("Object");

            xmlDoc.AppendChild(elmObj);
            xmlDoc.Save(path + "/" + xmlpath);
        }
        else
            xmlDoc.Load(path + "/" + xmlpath);



        string filename = "assetbundle_" + DateTime.Now.ToString("yyyyMMddHHmmsstt") + ".unity3d";

        Debug.Log("save path " + path);
        FileInfo t = new FileInfo(path + "/" + filename);

        if (t.Exists)
            t.Delete();

        using (FileStream fs = t.Create())
        {

            fs.Write(bytes, 0, bytes.Length);

            XmlNode root = xmlDoc.SelectSingleNode("Object");
            XmlElement elm = xmlDoc.CreateElement("Property");
            elm.SetAttribute("url", url + ".ver_" + version);
            elm.SetAttribute("filename", filename);

            root.AppendChild(elm);
            xmlDoc.Save(path + "/" + xmlpath);
        }
    }
    public static void Delete(string url, int version)
    {

        string path = Application.persistentDataPath + "/AssetBundles";

        string xmlpath = "urlfindfilename.xml";
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.Load(path + "/" + xmlpath);

        XmlNode root = xmlDoc.SelectSingleNode("Object");

        XmlNode find = root.SelectSingleNode("Property[@url='" + url + ".ver_" + version + "']");

        string filename = ((XmlElement)find).GetAttribute("filename");

        root.RemoveChild(find);

        xmlDoc.Save(path + "/" + xmlpath);


        // delete .unity3d
        FileInfo file = new FileInfo(path + "/" + filename);
        if (file.Exists)
            file.Delete();
    }
    public static string getPath(string url, int version)
    {

        string path = Application.persistentDataPath + "/AssetBundles";

        string xmlpath = "urlfindfilename.xml";
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.Load(path + "/" + xmlpath);

        string filename = "";

        if (!File.Exists(path + "/" + xmlpath))
        {

            Debug.LogError("Can't Found urlfindfilename.xml");
        }
        else
        {

            XmlNode root = xmlDoc.SelectSingleNode("Object");

            XmlNode find = root.SelectSingleNode("Property[@url='" + url + ".ver_" + version + "']");

            if (find == null)
                Debug.LogError("find is null");
            else
            {

                filename = ((XmlElement)find).GetAttribute("filename");

                Debug.Log("filename is " + filename);
            }
        }


        return "file:///" + path + "/" + filename;

    }
    public static void ShowABCaching()
    {

        // 檢查有無.urlfindfilename.xml
        string path = Application.persistentDataPath + "/AssetBundles";

        string xmlpath = "urlfindfilename.xml";
        XmlDocument xmlDoc = new XmlDocument();


        if (!File.Exists(path + "/" + xmlpath))
        {

            Debug.LogError("Can't Found urlfindfilename.xml");
            return;
        }

        xmlDoc.Load(path + "/" + xmlpath);

        // 顯示內容
        XmlNode root = xmlDoc.SelectSingleNode("Object");

        XmlNodeList xnodelist = root.ChildNodes;

        foreach (XmlNode node in xnodelist)
        {

            Debug.Log("*************");
            Debug.Log(((XmlElement)node).GetAttribute("url"));
            Debug.Log(((XmlElement)node).GetAttribute("filename"));
            Debug.Log("*************");
        }
    }
    public static void DeleteALL()
    {

        string path = Application.persistentDataPath + "/AssetBundles";

        DirectoryInfo di = new DirectoryInfo(path);

        if (di.Exists)
        {
            di.Delete(true);
            Debug.Log("Delete ALL");
        }
    }
}
