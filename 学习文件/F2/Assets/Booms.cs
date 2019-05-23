using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booms : MonoBehaviour
{
   // public GameObject bombfect;//爆炸特效

    public float bombFuhuo = 10f;

    public bool bombPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        bombBreak();
        if (other.tag == "Player" && bombPlayer)
        {
            other.GetComponent<Players>().Playdie();
        }
        if (other.tag == "Dis")
        {
            other.GetComponent<Diss>().dissdie();
            Players._instance.playerlevelup();
        }
    }
    public void bombBreak()
    {
        Audios.Instance.PlayBomb();
        // Instantiate(bombfect, transform.position, Quaternion.identity);       
        gameObject.SetActive(false);
        if (bombPlayer)
            Invoke("bombbb", bombFuhuo);
    }

    public void bombbb()
    {
        gameObject.SetActive(true);
    }
}
