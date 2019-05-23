using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(90,0,0) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Audios.Instance.PlayBi();
            other.GetComponent<Players>().PlayerGetGold(1);
            gameObject.SetActive(false);
            Invoke("relive", 30f);
        }
    }

    private void relive()
    {
        gameObject.SetActive(true);
    }
}
