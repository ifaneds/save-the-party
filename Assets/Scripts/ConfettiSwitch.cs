using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiSwitch : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    public GameObject lookingAt;
    public GameObject interactText;
    public GameObject[] confetti;
    public List<Material> materialComponents = new List<Material>();
    public Color[] colors;
    public int colorIndex = 0;
    public float time = 0.0f;
    float interpolationPeriod = 12f;
    GameObject fuseBox;
    bool powered;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        Camera = GameObject.Find("MainCamera");
        
        confetti = GameObject.FindGameObjectsWithTag("Confetti");
        
        foreach (GameObject confetti in confetti)
        {
            materialComponents.Add(confetti.GetComponent<Renderer>().material);
        }

        foreach (GameObject confetti in confetti)
        {
            ParticleSystem particles = confetti.GetComponent<ParticleSystem>();
            particles.Stop();
        }
        fuseBox = GameObject.FindWithTag("Fuse Box");
    }

    // Update is called once per frame
    void Update()
    {
        powered = fuseBox.GetComponent<FuseBox>().isPowerOn();
         time += Time.deltaTime;
        playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;
        if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)          
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (powered){
                if (time >= interpolationPeriod) {
                    foreach (GameObject confetti in confetti)
                    {
                        ParticleSystem particles = confetti.GetComponent<ParticleSystem>();
                        particles.Play();
                    }
                time = 0;
                colorIndex = colorIndex+1;
                if (colorIndex>3)
                {
                    colorIndex = 0;
                }
                foreach (Material Material in materialComponents)
                {
                    Material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                }
                }
                }
                
            }
        } else
        {
            interactText.SetActive(false);
        }        
    }
}
