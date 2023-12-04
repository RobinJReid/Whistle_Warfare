using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    //adapted from Night Run Studio., 2022. Enemy Health System #3: Dealing Damage to Enemies (Unity Tutorial) [online video]. May 10. Available from: https://www.youtube.com/watch?v=W6cGir65XwI [Accessed 30 October 2023].
    public int maxHealth = 10000;
    public int currentHealth;
    private ParticleSystem myPart;
    private bool PartOn;
    public GameObject Health;

 
    void Start()
    {
        currentHealth = maxHealth;
        myPart = this.GetComponent<ParticleSystem>();
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (PartOn == false)
        {
            PartOn = true;
            myPart.Play();
            Debug.Log(" Playing");
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Overworld-1");
        }
        Debug.Log(currentHealth);
        Health = GameObject.FindWithTag("EnemyHealth");
        Health.GetComponent<Health>().SetHealth(currentHealth);
        Debug.Log("Damage has been taken");
    }

    public void NoDamage()
    {
        if (PartOn == true)
        {
            myPart.Stop();
            PartOn = false;
        }
    }
}

