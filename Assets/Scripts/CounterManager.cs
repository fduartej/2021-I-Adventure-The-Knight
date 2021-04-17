using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour
{
    public Text textTime;
    public Text textScore;
    public Text textLive;

    public int counterTime = 300;
    public int counterScore = 0;
    public int counterLive = 3;
   
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CounterTimeAwake", 1f, 1f);        
    }

    void CounterTimeAwake(){
        counterTime--;
        textTime.text = counterTime.ToString();
        if(counterTime<0){
            //Finaliza el juego
        }
    }

    public void addScore(){
        counterScore=+1;
        textScore.text = counterScore.ToString();
    }

    public void addLive(float live){
        counterLive=+1;
        textLive.text = counterLive.ToString();
    }

}
