using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int whoseTurn; //0 = x and 1 = o
    public int turnCount; // count nunber of turns played
    public GameObject[] turnIcons; //displays whose turn it is
    public Sprite[] playerIcons; // 0 = x and 1 = o
    public Button[] ticTacToeSpaces; // playable spaces
    public int[] markedSpaces; // IDs which space was marked by which player

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
        for(int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ticTacToeButton(int whichNumber)
    {
        //places x or o in clicked button
        ticTacToeSpaces[whichNumber].image.sprite = playerIcons[whoseTurn];
        //button cannot change once clicked
        ticTacToeSpaces[whichNumber].interactable = false;

        //IDs which space is marked by which player x = 0 and o = 1;
        markedSpaces[whichNumber] = whoseTurn;
        turnCount++;

        if(whoseTurn == 0)
        {
            whoseTurn = 1;
            //the following lines display whose turn via the arrows
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            //the following lines display whose turn via the arrows
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }
}