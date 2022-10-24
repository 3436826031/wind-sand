using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class PlayerItem : MonoBehaviour, IPointerDownHandler
{
    public Animator animator;
    //当鼠标点击，即鼠标按下与松开均在该物体上时，触发以下函数
    public void OnPointerClick(PointerEventData eventData)
    {
        
        //你要触发的代码
    }

    //当检测到鼠标在该物体上有“按下”操作时，触发以下函数
    public void OnPointerDown(PointerEventData eventData)
    {
        //你要触发的代码

        print("点击该物体了");
        animator.SetBool("select", true);
    }

  

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
