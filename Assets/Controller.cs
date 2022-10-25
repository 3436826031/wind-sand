using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Controller : MonoBehaviour
{
    public GameObject seleObj;
    public GameObject ControlUI;
    public GameObject controlUInew;


    public static Controller instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


          

            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down);


        

            if (seleObj != null)
            {
                Vector3 v3 = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        

                seleObj.gameObject.transform.DOMove(v3, 0.5f);
                seleObj.gameObject.GetComponent<PlayerItem>().CancelSelect();
                seleObj = null;
                ControlUI.gameObject.SetActive(false);
                return;
            }

            if (hit.collider)
            {
             
                //do something
                print(hit.collider.transform.name);

                hit.collider.gameObject.GetComponent<PlayerItem>().SetSelect();
                seleObj = hit.collider.gameObject;
                opneCtrl();
                ControlUI.gameObject.SetActive(true);
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

    }




}

