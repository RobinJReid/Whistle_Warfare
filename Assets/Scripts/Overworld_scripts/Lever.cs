using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public GameObject Door;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // from arcanePanda how to make a keydoor system tutorial
        if (collision.CompareTag("Player"))
        {
            Door.SetActive(false);
        }
    }

}
