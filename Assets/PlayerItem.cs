using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public class PlayerItem : MonoBehaviour
{
    public Animator animator;
    public int id;
    public Image[] ziyuan; //携带的资源
    private SpriteRenderer spriteRenderer;
    public bool yijingcaozuo = false;
    public Color color;
    public int Tili = 3;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetYijingcaozuo() {
        yijingcaozuo = true;
        spriteRenderer.color = color;
    }
    public void CancelYijingccaozuo() {
        yijingcaozuo = false;
        spriteRenderer.color = Color.white;

    }

    public void SetSelect() {
        animator.SetBool("select", true);
    }

    public void CancelSelect()
    {
        animator.SetBool("select", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

      
        if (collision.tag.Equals("plant")) {
            //出现采集指示灯
            
            Controller.instance.type = 1;
            //Controller.instance.upControllerUI( "采集");
            Controller.instance.nowItem = collision.gameObject;
        
        }


        if (collision.tag.Equals("water")) {

            Controller.instance.type = 2;
            //Controller.instance.upControllerUI("采水");
            Controller.instance.nowItem = collision.gameObject;
        }


    }


    


}
