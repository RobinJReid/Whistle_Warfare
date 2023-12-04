using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private float CurserHeight;
    public LayerMask note;
    private ParticleSystem myPart;
    public AudioSource audioSource;
    private float slidepitch;
    public float startTime = 0f;
    private bool PartRunning;
    private bool PartOn;
    private bool audioRunning;
    private bool audioon;
    public GameObject Song;
    GameObject Monster;

    private void Start()
    {
        myPart = this.GetComponent<ParticleSystem>();
        startTime = Time.timeSinceLevelLoad;
    }
    void Update()
    {
        Vector2 curserPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CurserHeight = Mathf.Clamp(curserPos.y, -4, 2);
        transform.position = new Vector2(-5f, CurserHeight);
        slidepitch = ((CurserHeight +5)/5)+0.8f;
        audioSource.pitch = slidepitch;

        if (audioRunning == true)
        {
            if (audioon == false)
            {
                audioon = true;
                audioSource.Play();
            }
            
        }
        if (audioRunning == false)
        {
            if (audioon == true)
            {
                audioon = false;
                audioSource.Stop();
            }

        }

        if (Input.GetMouseButton(0))
        {
            if (audioRunning == false)
            {
                audioRunning = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (audioRunning == true)
            {
                audioRunning = false;
            }
        }

        if (Input.GetMouseButton(0) && Physics2D.OverlapCircle(transform.position, 0.2f, note) != null)
        {
            Song.GetComponent<songTime>().ScoreAdd(1);
            Debug.Log("Colided");

            if (PartRunning == false)
            {
                PartRunning = true;
            }
        }

        if (Input.GetMouseButtonUp(0) || Physics2D.OverlapCircle(transform.position, 0.2f, note) == null || Input.GetMouseButton(1))
        {
            if (PartRunning == true)
            {
                PartRunning= false;
            }
            myPart.Stop();
        }

        if (PartRunning == true) 
        {
            if (PartOn == false)
            {
                myPart.Play();
                PartOn = true;
            }
        }
        if (PartRunning == false)
        {
            if (PartOn == true)
            {
                myPart.Stop();
                PartOn = false;
            }
        }



    }


}
