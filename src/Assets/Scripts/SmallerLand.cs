using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerLand : MonoBehaviour
{
    [SerializeField] float shrinkSpeed;
    private Vector3 shrinkVector;
    [SerializeField] GameManager gameManager;
    Camera mainCamera;
    [SerializeField] float zoomSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        shrinkSpeed *= Time.deltaTime;
        shrinkVector = new Vector3(shrinkSpeed, 0f, shrinkSpeed);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.start)
        {
            if (gameObject.transform.localScale.x > 5f || gameObject.transform.localScale.z > 5f)
            {
                gameObject.transform.localScale -= shrinkVector;
            }
        }      
    }
    private void LateUpdate()
    {
        if (gameManager.start)
        {
            if (gameObject.transform.localScale.x > 5f || gameObject.transform.localScale.z > 5f)
            {
                mainCamera.fieldOfView -= Time.deltaTime * zoomSpeed;
            }
        }
    }
}