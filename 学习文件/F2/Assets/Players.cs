using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
    public static Players _instance;
    private Rigidbody rbody;
    private Animation anim;
    private int score = 0;
    public Text text;
    public Text Destext;
    public Text Wintext;
    public Image WinImage;
    public Text LevelUptext;
    public bool isDie = false;

    public GameObject overPanel;
   // public PlayerPanel playerPanel;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
    }
    public void playerlevelup()
    {
        Color c = new Color();
        float temp = LevelUptext.GetComponent<Text>().color.a;
        c.b = LevelUptext.GetComponent<Text>().color.b;
        c.g = LevelUptext.GetComponent<Text>().color.g;
        c.r = LevelUptext.GetComponent<Text>().color.r;
        c.a = 1;
        LevelUptext.GetComponent<Text>().color = c;
        StartCoroutine("jianbian", LevelUptext.GetComponent<Text>());
    }
    // Update is called once per frame
    void Update()
    {
        if (isDie)
            return;
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, v);
        //  dir = transform.TransformDirection(dir); 
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);

            rbody.velocity = dir * 4;

            anim.Play("run");
        }

       
        //if (Input.GetKeyDown(KeyCode.Space))
        // {
        //    rbody.AddForce(Vector3.up * 170);
        // }
        else
        {
            anim.Play("idle");
        }
        






    }
    #region 玩家死亡
    public void Playdie()
    {
       Destext.enabled = true;//SetActive(true)
        isDie = true;
        Audios.Instance.Playersi();
        anim.Play("die");
        Invoke("destroyPlayer", anim.GetClip("die").length);
    }
    private void destroyPlayer()
    {
        gameObject.SetActive(false);
       // 显示最后得分
        overPanel.transform.GetChild(2).GetComponent<Text>().text = text.text;
        overPanel.SetActive(true);
        // overPanel.enabled = true;
    }
    #endregion
     IEnumerator jianbian()
     {

         while (Wintext.GetComponent<Text>().color.a > 0)
         {
             Color c = new Color();
             float temp = Wintext.GetComponent<Text>().color.a;
             c.b = Wintext.GetComponent<Text>().color.b;
             c.g = Wintext.GetComponent<Text>().color.g;
             c.r = Wintext.GetComponent<Text>().color.r;
             c.a = temp - 0.05f;
             Color c2 = new Color();
             float temp2 = WinImage.GetComponent<Image>().color.a;
             c2.b = WinImage.GetComponent<Image>().color.b;
             c2.g = WinImage.GetComponent<Image>().color.g;
             c2.r = WinImage.GetComponent<Image>().color.r;
             c2.a = temp2 - 0.05f;
             Wintext.GetComponent<Text>().color = c;
             WinImage.GetComponent<Image>().color = c2;
             yield return new WaitForSeconds(0.02f);
         }
     }
    public void PlayerGetGold(int value)
    {
        getScore(value);
        getExp(value);
    }
    //得分
    public void getScore(int value)
    {
        score += value;
        text.text = score.ToString();
    }
    //得到能量
    public void getExp(int value)
    {
        PlayerPanel.Instance.getExp(value);
    }
    //进入新游戏
    public void OkClick()
    {
        SceneManager.LoadScene("gameing");
    }
    public void NoClick()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
}
