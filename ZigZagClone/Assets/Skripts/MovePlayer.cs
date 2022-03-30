using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform rayStart;
    //public float speed = 2f;
    private bool WalkR = true;
    public GameObject CrystalEffect;
    private Rigidbody Player;
    private Animator anim;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
        int speed;

        speed = 3;
        if (!gameManager.GameStarted)
            return;
        else
            anim.SetTrigger("IsStarted");
        if (gameManager.score > 10)
            speed++;
        Player.transform.position = Player.transform.position + transform.forward * speed * Time.deltaTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }
        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anim.SetTrigger("IsFall");
        }
        if (transform.position.y < -10)
        {
            gameManager.EndGame();
        }

    }

    private void Switch()
    {
        if (!gameManager.GameStarted)
        {
            return;
        }
        WalkR = !WalkR;
        if (WalkR)
            transform.rotation = Quaternion.Euler(0, 225, 0);
        else
            transform.rotation = Quaternion.Euler(0, 135 ,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            Destroy(other.gameObject);
            gameManager.IncreaseScore();
            GameObject g = Instantiate(CrystalEffect, transform.position, Quaternion.identity);
            Destroy(g, 2.0f);
        }
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    float VertMove = Input.GetAxis("Vertical");
    //    float HorMove = Input.GetAxis("Horizontal");
    //    Vector3 move = new Vector3(HorMove, 0, VertMove);
    //    Player.AddForce(move * speed);
    //}
}
