using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(Rigidbody))]
public class PlayersControllers : MonoBehaviour
{
    public bool blue;
    Rigidbody playerRB;
    [SerializeField] float moveSpeed;
    float horizontalInput;
    float verticalInput;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.start)
        {
            if (blue)
            {
                horizontalInput = Input.GetAxis("Horizontal");
                verticalInput = Input.GetAxis("Vertical");
            }
            else
            {
                horizontalInput = Input.GetAxis("AD");
                verticalInput = Input.GetAxis("WS");
            }
            
            if (!gameManager.win)
            {
                Vector3 pos = new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * moveSpeed;
                playerRB.AddForce(pos * 2);
            }          
            if (transform.position.y < -3.5f && !gameManager.win)
            {
                if (blue)
                {
                    gameOverText.text = "Red Won!";
                }
                else
                {
                    gameOverText.text = "Blue Won!";
                }
                gameManager.win = true;
                Destroy(gameObject);
            }
            if (gameManager.win && transform.position.y < -3.5f)
            {
                Destroy(gameObject);
            }
        }       
    }
}