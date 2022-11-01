using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int whoseTurn; //0 = x and 1 = o
    public int turnCount; // count nunber of turns played
    public GameObject[] turnIcons; //displays whose turn it is
    public Sprite[] playIcons; // 0 = x and 1 = y
    public Button[] ticTacToeSpaces; // playable spaces

    // Start is called before the first frame update
    void Start()
    {
        gameSetUp();
        
    }

    void gameSetUp()
    {
        whoseTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for(int i = 0; i < ticTacToeSpaces.Length; i++)
        {
            ticTacToeSpaces[i].interactable =true;
            ticTacToeSpaces[i].GetComponent<Image>().sprite = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
