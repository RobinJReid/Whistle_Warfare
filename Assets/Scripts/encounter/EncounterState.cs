using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EncounterState : MonoBehaviour
{
    public GameObject[] prefab;
    public GameObject EncounterMenu;
    public GameObject RhythmBase;
    [SerializeField] public string IsClicking;

    void Start()
    {

        int which = Random.Range(0,2);

        GameObject copy = Instantiate<GameObject>(prefab[which] );

        EncounterMenu.SetActive(false);
        RhythmBase.SetActive(false);

        Debug.Log("Started");

    }

    private void Update()
    {

    }
}
