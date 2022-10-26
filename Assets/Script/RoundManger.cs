using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class RoundManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static RoundManger instance;

    public GameObject[] shuzi;


    public Transform[] sunDisn;

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }


    public GameObject backRound;


    int diansu = 0;

    public void jianshao() {


        if (diansu < 3) {
            shuzi[diansu].GetComponent<Image>().DOFade(0.3f, 1.2f);

            backRound.transform.DOLocalMoveX(sunDisn[diansu+1].position.x,0.9f);

            diansu++;
        
        }
    
    
    
    }



}
