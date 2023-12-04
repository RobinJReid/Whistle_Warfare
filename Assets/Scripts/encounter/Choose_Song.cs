using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Song : MonoBehaviour
{
    public void ChooseSong()
    {
        GameObject.FindGameObjectWithTag("Monster").transform.position = new Vector3(4, 4, 0);
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-4, 4, 0);
    }
}
