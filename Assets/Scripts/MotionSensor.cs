using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
     float distanceToPlayer;
    public float activationDistance;
    public GameObject interactText;
    float time = 0.0f;
    float interpolationPeriod = 5f;
     bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activated){
        time += Time.deltaTime;
        }
        playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        if (distanceToPlayer < activationDistance&&!activated)
        {
            interactText.SetActive(true);
            activated = true;
            time = 0;
        }
        if (time >= interpolationPeriod) 
        {
            interactText.SetActive(false);
        }

    }
}
