using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textConrtoller : MonoBehaviour
{
    int klikit=0;
    TMPro.TextMeshProUGUI teksti;
    // Start is called before the first frame update
    void Start()
    {
        //teksti = 
        //transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            klikit += 1;
        if(klikit ==1) transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "I NEED TO GET \n BACK HOME \n TO MY ROOTS!!";
        if (klikit ==2) transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "USE MOUSE TO \n MAKE ME JUMP \n AROUND!!!!";
        if (klikit > 2) Destroy(gameObject);
        }
    }

    void OnMouseDown(){
        Debug.Log("Hallo");
        klikit += 1;
        if(klikit ==1) transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "I NEED TO GET \n BACK HOME \n TO MY ROOTS!!";
        if (klikit ==2) transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "USE MOUSE TO \n MAKE ME JUMP \n AROUND!!!!";
        if (klikit > 2) Destroy(gameObject);
    }
}
