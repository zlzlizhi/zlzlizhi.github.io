using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    public Slider expSlider;
    public float speed = 0.1f;
    public float playerExps;
    public static PlayerPanel Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Players._instance.isDie)// GameObject.Find("player").GetComponent<player>().isDie
                return;
           // if (int.Parse(Players._instance.text.text) <= 100)
            
                expSlider.value -= speed * Time.deltaTime;
               
           
            
            if (expSlider.value <= 0)
            {

                // GameObject.Find("player").SendMessage("Playdie") ;
                Players._instance.Playdie();
            }
        }
        catch (Exception e)
        {

        }

    }

    public void getExp(int value)
    {
        expSlider.value += 0.1f * value;
    }
}
