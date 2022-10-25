using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mood : MonoBehaviour
{



    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        




    
    }


    public bool isUp=true;
    public bool isDown=false;

    // Update is called once per frame
    void Update()
    {



        if (isUp) {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 1.2f;
            Invoke("endUp", 0.5f);
        }



        if (isDown) {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 1.2f;
            Invoke("endDown", 0.5f);

        }

       


    }




    void endUp() {
        isUp = false;
        Invoke("startDown", 1f);
    }



    void startDown() {
        isDown = true;
    
    }

    void endDown() {
        isDown = false;
    
    }





}
