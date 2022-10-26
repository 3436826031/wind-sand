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


    public GameObject nowItem;

    public static Controller instance;




    // Use this for initialization
    void Start()
    {
        instance = this;
    }


     public void upControllerUI(string txt) {


        ctrlChoose.text = txt;
        controlUI.GetComponent<Animator>().SetBool("up", true);
        controlUI.GetComponent<Animator>().SetBool("down", false);
    }



    public void downControllerUI()
    {

        controlUI.GetComponent<Animator>().SetBool("up", false);
        controlUI.GetComponent<Animator>().SetBool("down", true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&commond!=0)
        {


          

            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down);


        

            if (hit.collider && hit.collider.tag.Equals("Player"))
            {
             
                //do something
                print(hit.collider.transform.name);

                hit.collider.gameObject.GetComponent<PlayerItem>().SetSelect();
                seleObj = hit.collider.gameObject;
                opneCtrl();
               // controlUI.gameObject.SetActive(true);
            }



            if (commond == 1) {



                Vector3 v3 = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
                seleObj.gameObject.transform.DOMove(v3, 0.5f);
                seleObj.gameObject.GetComponent<PlayerItem>().CancelSelect();
                seleObj = null;
               // controlUI.gameObject.SetActive(false);

                        
                commond = 0;

            }


        }
    }




    public void  opneCtrl() {
        //世界坐标转换为屏幕坐标


        Vector3 vector31 = Camera.main.WorldToViewportPoint(seleObj.transform.position);


        Vector3 vector32 = seleObj.transform.TransformPoint(seleObj.transform.position);

        Vector3 vector3 = Camera.main.WorldToScreenPoint(seleObj.transform.position);
     //   controlUInew.transform.position = vector3;

      
        print("坐标："+vector3+"坐标2："+ vector31);


        controlUInew.GetComponent<Animator>().SetBool("open",true);
        controlUInew.GetComponent<Animator>().SetBool("close", false);
    }





    public  void move() {
        print("进入指令");

        //进入指令了
        commond = 1;

        controlUInew.GetComponent<Animator>().SetBool("open", false);
        controlUInew.GetComponent<Animator>().SetBool("close", true);




    }


    public int type;




    public void plant() {








        //消灭物体
        if (nowItem != null) {


            if (type == 1)
            {
                showDiText("");

                downControllerUI();

                nowItem.SetActive(false);
                //弹个窗

              
               


            }
            else if (type == 2)
            {

                print("采集水资源完毕");


            }
            else if (type == 3) { 
            
            
            
            
            }

            RoundManger.instance.jianshao();
            commond = -1;





        }
    
    
    
    }






    public void showDiText(string text)
    {

        showText.text = text;

        Invoke("sideShowDiText", 3f);
    }



    public void sideShowDiText() {

        showText.text = "";
    
    }


}

