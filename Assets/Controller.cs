using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Controller : MonoBehaviour
{
    public GameObject SeleObj;
    public GameObject ControlUI;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(myRay.origin.x, myRay.origin.y), Vector2.down);



            if (SeleObj != null)
            {
                Vector3 v3 = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
                SeleObj.gameObject.transform.DOMove(v3, 0.5f);
                SeleObj.gameObject.GetComponent<PlayerItem>().CancelSelect();
                SeleObj = null;
                ControlUI.gameObject.SetActive(false);
                return;
            }

            if (hit.collider)
            {
                //do something
                print(hit.collider.transform.name);

                hit.collider.gameObject.GetComponent<PlayerItem>().SetSelect();
                SeleObj = hit.collider.gameObject;
                ControlUI.gameObject.SetActive(true);
            }

           



        }
    }
}

