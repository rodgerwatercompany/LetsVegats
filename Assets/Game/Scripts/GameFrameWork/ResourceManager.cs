using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    public GameObject[] gas_resource;

    public GameObject Instantiate(GameObject ga_parent ,int idx,Vector3 pos)
    {

        GameObject ga = Instantiate(gas_resource[idx], Vector3.zero, Quaternion.Euler(0.0f, 0.0f, 0.0f)) as GameObject;

        ga.transform.parent = ga_parent.transform;
        ga.transform.localPosition = pos;
        ga.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        return ga;
    }

}
