using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
public class Controller : MonoBehaviour
{
    public GameObject seleObj;
    public GameObject controlUI;
    public GameObject controlUInew;

    public Text showText;
    public Text ctrlChoose;

    public int commond=-1;

    public static int CanControl = 1;  //可以操作的人数

    public GameObject nowItem;

    public static Controller instance;
    public PlayerItem playerItem = null;

    public GameObject ControlUI;

    public CtrlMenu ctrlMenu;


    public bool canPlayeritem = true;
    public Text ShengyuText;

    public PlayerItem[] playerItems;

    public GameObject zimuText;


    public Text tip;
    // Use this for initialization
    void Start()
    {
        instance = this;
    
    
    }



    public void zimuStart() {
        zimuText.GetComponent<Animator>().SetBool("zimu",true);
    
    }



    public void zimuEnd() {
        zimuText.GetComponent<Animator>().SetBool("zimu", true);

    }


     public void upControllerUI(string txt) {

        ControlUI.gameObject.transform.DOLocalMoveY(411.93f,0.5f);
        ctrlMenu.Menu1.gameObject.SetActive(true);

        //ctrlChoose.gameObject.SetActive(true);
        ctrlChoose.text = txt;
        //controlUI.GetComponent<Animator>().SetBool("up", true);
        //controlUI.GetComponent<Animator>().SetBool("down", false);
    }


    public void upControllerUI()
    {

        if (RoundManger.instance.diansu >= 1) {

            ctrlMenu.Menu3.SetActive(true);
        }

        ctrlMenu.Menu1.gameObject.SetActive(false);
        canPlayeritem = false;
        if (type == 1)
        {
            ctrlMenu.Menu1.gameObject.SetActive(true);
            ctrlChoose.text = "采集";
            
        }
        else if (type == 2)
        {
            ctrlMenu.Menu1.gameObject.SetActive(true);
            //ctrlChoose.gameObject.SetActive(true);
            ctrlChoose.text = "采水";
            
        }
       
        ControlUI.gameObject.transform.DOLocalMoveY(411.93f, 0.5f);
      
        //ctrlChoose.text = txt;
        //controlUI.GetComponent<Animator>().SetBool("up", true);
        //controlUI.GetComponent<Animator>().SetBool("down", false);
    }



    public void downControllerUI()
    {
        
        ControlUI.gameObject.transform.DOLocalMoveY(130f, 0.5f);

      /*  controlUI.GetComponent<Animator>().SetBool("up", false);
        controlUI.GetComponent<Animator>().SetBool("down", true);*/
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down);
            
            if (seleObj == null)
            {
                if (!canPlayeritem)
                    return;
                
                if (hit.collider && hit.collider.tag.Equals("Player"))
                {
                    var data = hit.collider.GetComponent<PlayerItem>();
                    if (data.yijingcaozuo)
                        return;

                    //do something
                    print(hit.collider.transform.name);
                   
                    var id = hit.collider.GetComponent<PlayerItem>().id;
                    hit.collider.gameObject.GetComponent<PlayerItem>().SetSelect();
                    seleObj = hit.collider.gameObject;
                    opneCtrl();
                    ShowMess(id,data.Tili);
                    // controlUI.gameObject.SetActive(true);
                }

            }
            else {
                if (commond == 1)
                {
                    Vector3 v3 = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
                    seleObj.gameObject.transform.DOMove(v3, 0.5f).OnComplete(delegate { upControllerUI(); });
                    seleObj.gameObject.GetComponent<PlayerItem>().CancelSelect();
                    //seleObj = null;
                    commond = 0;
                }

            }
         


/*
            if (commond == 1) {
                Vector3 v3 = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
                seleObj.gameObject.transform.DOMove(v3, 0.5f);
                seleObj.gameObject.GetComponent<PlayerItem>().CancelSelect();
                seleObj = null;
               // controlUI.gameObject.SetActive(false);         
               commond = 0;

            }

*/
        }
    }


    public void CreatTip(string text,Color color) {


        Vector3 vector3 = Camera.main.WorldToScreenPoint(seleObj.transform.position);
        tip.gameObject.SetActive(true);
        tip.DOFade(0, 0);
        tip.DOFade(1, 0.3f).OnComplete(delegate
        {

            tip.DOFade(1, 0.3f).OnComplete(delegate
            {
                tip.DOFade(0, 0.2f).OnComplete(delegate { tip.gameObject.SetActive(false); });
            });
        });
       
        tip.transform.position = vector3 + new Vector3(0, 0, 0);
        tip.transform.DOMoveY(tip.transform.position.y+10,0.5f);
        tip.text = text;
        tip.color = color;
    }


    public void  opneCtrl() {
        //世界坐标转换为屏幕坐标


        Vector3 vector31 = Camera.main.WorldToViewportPoint(seleObj.transform.position);


        Vector3 vector32 = seleObj.transform.TransformPoint(seleObj.transform.position);

        Vector3 vector3 = Camera.main.WorldToScreenPoint(seleObj.transform.position);
        //   controlUInew.transform.position = vector3;

        controlUInew.transform.position = vector3+new Vector3(-60,50,0);
        print("坐标："+vector3+"坐标2："+ vector31);


        controlUInew.GetComponent<Animator>().SetBool("open",true);
        controlUInew.GetComponent<Animator>().SetBool("close", false);
    }




    /** 移动   */
    public  void move() {
        print("进入指令");

        //进入指令了
        commond = 1;
        controlUInew.GetComponent<Animator>().SetBool("open", false);        controlUInew.GetComponent<Animator>().SetBool("close", true);


    }






    /**  种植 */
    public void grow() {

        commond = 2;

        print("开始种植");

        //生成一个预制体





    }


    public int type;




    public void plant() {

        //消灭物体
        if (nowItem != null) {


            if (type == 1)
            {
                CreatTip("体力-1",Color.red);
                showDiText("");
                var item = seleObj.GetComponent<PlayerItem>();
                item.Tili--;
                item.SetYijingcaozuo();
                downControllerUI();
                seleObj = null;
                //弹个窗
                nowItem.SetActive(false);
             
            }
            else if (type == 2)
            {
                CreatTip("体力-1", Color.red);
                var item = seleObj.GetComponent<PlayerItem>();
                item.Tili--;
                item.SetYijingcaozuo();
                downControllerUI();
                print("采集水资源完毕");
                seleObj = null;


            }
            else if (type == 3) {
                CreatTip("体力-1", Color.red);
                var item = seleObj.GetComponent<PlayerItem>();
                item.Tili--;
                item.SetYijingcaozuo();
                downControllerUI();
                seleObj = null;

            }
           
            ShengyuText.text = (3 - CanControl)+"";
            CanControl++;
            type = 0;
            canPlayeritem = true;
            HideMess();
            seleObj = null;

            if (CanControl > 3)
            {
                RoundManger.instance.jianshao();
                commond = -1;
                CanControl = 1;
                ShengyuText.text = (3 ) + "";
                foreach (var item in playerItems)
                {
                    item.CancelYijingccaozuo();
                }

            }
         

        }
    
    
    
    }


    /// <summary>
    /// 休息
    /// </summary>
    public void Xiuxi() {

        ShengyuText.text = (3 - CanControl) + "";
        CanControl++;
        CreatTip("体力+1", Color.green);
        var item = seleObj.GetComponent<PlayerItem>();
        item.SetYijingcaozuo();
        item.Tili++;
        if (CanControl > 3)
        {
            RoundManger.instance.jianshao();
            commond = -1;
            CanControl = 1;
            ShengyuText.text = (3 ) + "";
            foreach (var item2 in playerItems)
            {
                item2.CancelYijingccaozuo();
            }
        }
        seleObj = null;
        HideMess();
        downControllerUI();
        type = 0;
        canPlayeritem = true;
    }


    public void showDiText(string text)
    {

        showText.text = text;
       
        Invoke("sideShowDiText", 3f);
    }


    public GameObject Mess;
    public void ShowMess(int id,int tili) {
        Mess.gameObject.transform.DOLocalMoveX(0,0.3f);
        Mess.GetComponent<Mess>().SetIcon(id);
        Mess.GetComponent<Mess>().SetTili(tili);
    }

    public void HideMess()
    {
        Mess.gameObject.transform.DOLocalMoveX(70, 0.3f);

    }


    public void sideShowDiText() {

        showText.text = "";
    
    }


    public Text startA;
    public Text startB;

    public void StartGame() {

        startA.gameObject.SetActive(false);
        startB.gameObject.SetActive(false);

        //Camera.main.DORect(5.5f,0.8f);
       // Camera.main.DOFieldOfView(5.5f, 0.8f);
    
    
    }


}

