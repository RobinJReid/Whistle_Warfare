using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType(this.GetType()).Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
