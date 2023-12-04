using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songTime : MonoBehaviour
{
    public float SongTime;
    public GameObject Menu;
    public GameObject SongBase;
    public GameObject GameState;
    public GameObject CurrentSong;
    public Vector2 startpos;
    private int Damage;
    GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("this function has in fact started");
        
    }
    IEnumerator playSong()
    {
        Debug.Log("It is now playing the song");
        yield return new WaitForSeconds(SongTime);
        Debug.Log("songs done :D");
        Menu.SetActive(true);
        SongBase.SetActive(false);
        Debug.Log(Damage);
        Monster = GameObject.FindWithTag("Monster");
        Monster.GetComponent<EnemyHealth>().TakeDamage(Damage);
        yield return new WaitForSeconds(5);
        GameState = GameObject.FindWithTag("GameManager");
        GameState.GetComponent<GameStateManager>().TakeDamage(25);
        Monster.GetComponent<EnemyHealth>().NoDamage();

        transform.position = startpos;
        CurrentSong.SetActive(false);
    }

    public void PlayTheSong()
    {
        StartCoroutine(playSong());
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ScoreAdd(int amount)
    {
        Damage += amount;
    }
}
