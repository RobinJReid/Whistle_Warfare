using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    Animator anim;
    public LayerMask encounter_allowed;
    public LayerMask Interactions;
    public Vector2 playerLocation;
    GameObject GameState;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        GameState = GameObject.FindWithTag("GameManager");
    }
    void Update()
    {
        ProcessInputs();
        CheckForInteracts();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //adapted from BMO., 2020. 2D Top Down Movement UNITY Tutorial. [online video]. May 31. Available from: https://www.youtube.com/watch?v=u8tot-X_RBI [Accessed 30 October 2023].
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        
        anim.SetBool("moving", true);

        if (moveY != 0 || moveX != 0)
        {
            CheckForEncounters();
        }
        if (moveY == 0 || moveX == 0)
        {
        }
    }

    //adapted from BMO., 2020. 2D Top Down Movement UNITY Tutorial. [online video]. May 31. Available from: https://www.youtube.com/watch?v=u8tot-X_RBI [Accessed 30 October 2023].
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        playerLocation = gameObject.transform.position;

    }

    //adapted from GAME DEV EXPERIMENTS., 2020. Make A Game Like Pokemon in Unity | #4 - Adding Long Grass and Random Encounters Logic. [online video]. May 31. Available from: https://www.youtube.com/watch?v=x8B_eXfcj6U [Accessed 5 November 2023].
    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, encounter_allowed) != null) 
        {
            if (Random.Range(1,2001) == 1)
            {
                Debug.Log("Encountered");
                GameState.GetComponent<GameStateManager>().playerplace(playerLocation);
                loadLevel();

            }
        }
    }
    void CheckForInteracts()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, Interactions) != null)
        {
            Debug.Log("can interact");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("space key was pressed");
            }
        }
    }

    public void loadLevel()
    {
        SceneManager.LoadScene("Encounter");
    }
}
