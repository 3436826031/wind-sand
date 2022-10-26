using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class PlayerItem : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if (collision.tag == "Water")
        { 
            //打开操控界面 添加取水按钮
            
        
        }
    }


}
