using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diss : MonoBehaviour
{
    private Rigidbody rbody;
    private Animation ani;
      private Transform ta;
    public static Diss diss;

    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        diss = this;
        rbody = GetComponent<Rigidbody>();
        ani = GetComponent<Animation>();
        //ta = Players._instance.transform;
    }

    // Update is called once per frame
    private float dis = 10;
    void Update()
    {
        ta = Players._instance.transform;
      
      //ta = GameObject.FindWithTag("Player").transform;
        if (ta == null)
        {
            return;
        }

       // float dis = Vector3.Distance(transform.position, ta.position);

        dis = Vector3.Distance(transform.position, ta.position);
        if (dis < 2f)
        {
            if (!ta.GetComponent<Players>().isDie)//判断isdie的bool值；
            {
                ta.GetComponent<Players>().Playdie();
            }
            ani.Play("idle");
        }
        else if (dis < 6f)
        {
            Debug.Log("1111");
            //先朝向玩家
            transform.LookAt(ta.position);
            //再追击玩家
            rbody.velocity = transform.forward * 2;
            ani.Play("move");
          
        }
        else
        {
            ani.Play("idle");
        }
    }
    public void dissdie()
    {
        gameObject.SetActive(false);
        Players._instance.PlayerGetGold(10);
       
        Invoke("dissfuhuo", 30f);
    }

    public void dissfuhuo()
    {
        gameObject.transform.position = pos.position;//复活点
        gameObject.SetActive(true);
    }
}
