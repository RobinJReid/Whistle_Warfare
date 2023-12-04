using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class run : MonoBehaviour
{
    public GameObject GameState;
    public void RunAway()
    {
        if (Random.Range(1, 4) == 1)
        {
            SceneManager.LoadScene("Overworld-1");
        }
        else
        {
            GameState = GameObject.FindWithTag("GameManager");
            GameState.GetComponent<GameStateManager>().TakeDamage(25);
        }
    }
}
