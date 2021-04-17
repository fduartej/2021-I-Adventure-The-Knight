using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Button buttonEnter, buttonExit;

    // Start is called before the first frame update
    void Start()
    {
         buttonEnter.onClick.AddListener(onClickEnter);
         buttonEnter.onClick.AddListener(onClickExit);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickEnter(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void onClickExit(){
        
    }


}
