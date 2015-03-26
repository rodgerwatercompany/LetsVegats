using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using LitJson;

public class JsonManager
{
    public static Dictionary<string, JsonData> dic_jsons = new Dictionary<string, JsonData>();
    
    public static void Init(string objectname, string str)
    {
        JsonData jd = JsonMapper.ToObject(str);

        if (dic_jsons.ContainsKey(objectname))
        {
            //Debug.Log("Unity update Event : " + objectname);
            dic_jsons[objectname] = jd;
        }
        else
        {
            //Debug.Log("Unity First Event : " + objectname);
            dic_jsons.Add(objectname, jd);
        }
        /*
        JsonData name = jd["name"];

        Debug.Log("name " + name);
        return name;
        */
    }
    public static void Show(LuaInterface.LuaTable keynames)
    {
        ICollection vals = keynames.Values;
        foreach (string str in vals)
            Debug.Log("str is [" + str + "]");
    }
    //public static JsonData GetJD(string objectname, string[] keynames)
    public static JsonData GetJD(string objectname, LuaInterface.LuaTable keynames)
    {
        JsonData jd_obj = dic_jsons[objectname];
        JsonData jd_temp = jd_obj;

        ICollection vals = keynames.Values;
        foreach (object obj in vals)
        {
            if (jd_temp != null)
                jd_temp = GetJsonData(jd_temp, obj);
            else
            {
                jd_temp = null;
                break;
            }
        }
        /*
        for (int i = 0; i < vals.Count; i++)
        {
            
            if (jd_temp != null)
                jd_temp = GetJsonData(jd_temp, vals[i]);
            else
            {
                jd_temp = null;
                break;
            }
        }*/
        /*
        Debug.Log("jd_temp type " + jd_temp.GetJsonType());
        Debug.Log("jd_temp count " + jd_temp.Count);*/
        return jd_temp;
    }
    private static JsonData GetJsonData<T>(JsonData jsondata, T keyname)
    {
        try
        {
            JsonData jd_return;
            if (keyname is string)
            {
                string name = Convert.ToString(keyname);
                jd_return = jsondata[name];

            }
            else
            {
                int idx = Convert.ToInt32(keyname);
                jd_return = jsondata[idx];
            }

            return jd_return;
        }
        catch(Exception EX)
        {
            Debug.Log("keyname is " + keyname);
            Debug.LogException(EX);
            return null;
        }

    }

    public static JsonData GetJD(string objectname, string[] keynames)
    {
        foreach (string str in keynames)
            Debug.Log("str is [" + str + "]");

        JsonData jd_obj = dic_jsons[objectname];
        JsonData jd_temp = jd_obj;

        for (int i = 0; i < keynames.Length; i++)
        {
            if (jd_temp != null)
                jd_temp = GetJsonData(jd_temp, keynames[i]);
            else
            {
                jd_temp = null;
                break;
            }
        }

        return jd_temp;
    }

    private static JsonData GetJsonData(JsonData jsondata, string keyname)
    {
        try
        {
            JsonData jd_return = jsondata[keyname];
            return jd_return;
        }
        catch (Exception EX)
        {
            Debug.Log("keyname is " + keyname);
            Debug.LogException(EX);
            return null;
        }

    }

}
