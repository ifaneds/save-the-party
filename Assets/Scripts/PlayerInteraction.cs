using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject lookingAt;
    Vector3 playerPosition;
    public Vector3 forwardDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractRaycast();
    }

    void InteractRaycast()
    {
        playerPosition = transform.position;
        forwardDirection = transform.forward;

        Ray interactionRay = new Ray(playerPosition, forwardDirection);
        RaycastHit interactionRayHit;
        float interactionRayLength = 20.0f;

        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);
        if (hitFound)
        {
            lookingAt = interactionRayHit.transform.gameObject;
        }
    }
}
