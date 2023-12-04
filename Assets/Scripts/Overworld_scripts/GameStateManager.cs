using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public Vector2 playerLocationManager;
    public GameObject Player;
    public GameObject[] Players;
    public GameObject Health;
    public int maxHealth = 100;
    public int currentHealth;
    private int index;
    private int PlayerNum;
    public Vector3 PlayerSpawn;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (FindObjectsOfType(this.GetType()).Length > 1)
        {
            Destroy(this.gameObject);
        }
        PlayerSpawn = new Vector3(0,0,0);
        currentHealth = 100;
    }
    void OnLevelWasLoaded()
    {
        index = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "Encounter")
        {
            Instantiate(Player, playerLocationManager, Quaternion.identity);
            Player.transform.position = playerLocationManager;
            if (GameObject.FindGameObjectsWithTag(Player.tag).Length > 1)
            {
                Players = GameObject.FindGameObjectsWithTag("Player");
                PlayerNum = Players.Length;
                for (int i = 0; i < PlayerNum; i++)
                {
                    if (Players[index].transform.position == PlayerSpawn)
                    {
                        Destroy(Players[index]);
                    }
                    index = index + 1;
                }
            }
        }
        
    }
    public void playerplace(Vector2 localtion)
    {
        playerLocationManager = localtion;

    }
    // Update is called once per frame
    void Update()
    {
    }
    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Start");
            playerLocationManager = new Vector2(0, 0);
        }
        Debug.Log(currentHealth);
        Health = GameObject.FindWithTag("PlayerHealth");
        Health.GetComponent<Health>().SetHealth(currentHealth);
        Debug.Log("Damage has been taken");
    }
}
