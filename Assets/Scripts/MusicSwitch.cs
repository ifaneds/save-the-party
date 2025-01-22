using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    GameObject lookingAt;
    public GameObject interactText;
    public GameObject[] speakers;
    public List<AudioSource> audioComponents = new List<AudioSource>();
    public AudioClip[] audioClips;

    public Animator[] anims;
    public Animator DJanim;
    GameObject Dancers;
    GameObject fuseBox;
    bool powered;
    public int audioIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Dancers = GameObject.Find("Dancers");
        interactText.SetActive(false);
        Camera = GameObject.Find("MainCamera");
        
        speakers = GameObject.FindGameObjectsWithTag("Speakers");
        
        foreach (GameObject speaker in speakers)
        {
            audioComponents.Add(speaker.GetComponent<AudioSource>());
        }
        fuseBox = GameObject.FindWithTag("Fuse Box");

        anims = Dancers.GetComponentsInChildren<Animator>();

        DJanim = GameObject.Find("DJ").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        powered = fuseBox.GetComponent<FuseBox>().isPowerOn();
        playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;
        if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)          
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (powered){
                audioIndex = audioIndex+1;
                if (audioIndex>3)
                {
                    audioIndex = 0;
                }
                foreach (Animator anim in anims)
                {
                    anim.SetFloat("Dance", audioIndex);
                }
                DJanim.SetFloat("Dance",audioIndex);

                    foreach (AudioSource audioSource in audioComponents)
                    {
                        audioSource.clip = audioClips[audioIndex];
                        audioSource.Play();
                    }
                }
                
            }
        } else
        {
            interactText.SetActive(false);
        }
           
    }
}
