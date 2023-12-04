using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //GATSBY., 2023. Simple Health Bar Unity Tutorial [online video]. June 22. Available from: https://www.youtube.com/watch?v=lYZayXViTN8 [Accessed 28 November 2023].
    [SerializeField] private RectTransform Healthbar;
    public float HealthAmmount;
    public float MaxHealth;
    public float Width;
    public float Height;

    public void Update()
    {

    }

    public void SetHealth(float health)
    {
        HealthAmmount = health;
        Debug.Log("HealthAmmount:" + HealthAmmount);
        Debug.Log("Health:" + health);
        float newWidth = (HealthAmmount/MaxHealth)*Width;
        Healthbar.sizeDelta = new Vector2 (newWidth, Height);
    }
}
