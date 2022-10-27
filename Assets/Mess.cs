using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mess : MonoBehaviour
{
    public Image Icon;
    public Text tili;
    public Image ziyuan;
    public Sprite[] icons;


    public void SetIcon(int index) {
        Icon.sprite = icons[index];
    
    }

    public void SetTili(int data)
    {
        tili.text = "体力:" + data;


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
