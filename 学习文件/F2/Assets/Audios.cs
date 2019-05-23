using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public static Audios Instance;
    public AudioClip Bomb;
    public AudioClip Bi;
    private AudioSource player;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        player = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playersi()
    {
        player.Pause();
    }
    public void PlayBomb()
    {

        player.PlayOneShot(Bomb);

    }
    public void PlayBi()
    {
        player.PlayOneShot(Bi);
            }
}
