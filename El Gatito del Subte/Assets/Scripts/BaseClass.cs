using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass : MonoBehaviour
{
    public GlobalScript globalScript;
    private void Start()
    {
        globalScript = GameObject.Find("GlobalObject").GetComponent<GlobalScript>();
    }
}
