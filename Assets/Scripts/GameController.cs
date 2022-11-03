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
    public Text winnerText; //holds winner text
    public GameObject[] winningLines; //holds different winning lines to show winner
    public GameObject winnerPanel;

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
            markedSpaces[i] = -100;
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
        markedSpaces[whichNumber] = whoseTurn+1;
        turnCount++;

        if(turnCount > 4)
        {
            winnerCheck();
        }

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

    void winnerCheck()
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];   
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];

        var solutions = new int[] {s1,s2, s3, s4, s5, s6, s7, s8};

        for(int i = 0; i < solutions.Length; i++)
        {
           if(solutions[i] == 3 * (whoseTurn+1))
           {
               //x wins
               winnerDisplay(i);
               return;
           }
        }
    }

    void winnerDisplay(int indexIn)
    {
        winnerPanel.gameObject.SetActive(true);
        if(whoseTurn == 0)
        {
            winnerText.text = "Player X wins!!!";
        }
        else if(whoseTurn == 1)
        {
            winnerText.text = "Player O wins!!!";
        }
        winningLines[indexIn].SetActive(true);
    }
}