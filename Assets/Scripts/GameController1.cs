using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController1 : MonoBehaviour
{
    public int chosenPlayer; // holds value for x or o depending on who user chose
    public int whoseTurn; //1 = x and 2 = o
    public int turnCount; // count nunber of turns played
    public GameObject[] turnIcons; //displays whose turn it is
    public Sprite[] playerIcons; // 0 = x and 1 = o
    public Button[] ticTacToeSpaces; // playable spaces
    public int[] markedSpaces; // IDs which space was marked by which player
   
    public Text winnerText; //holds winner text
    public GameObject[] winningLines; //holds different winning lines to show winner
    public GameObject winnerPanel;

    public int xPlayersScore;
    public int oPlayersScore;
    public Text xScoreText;
    public Text oScoreText;
    public Text instructionText;

    public Button xPlayersButton;
    public Button oPlayersButton;

    public GameObject homeScreen;
    public GameObject modeScreen;
    public GameObject gameScreen;

    // Start is called before the first frame update
    void Start()
    {
        startGame();
    }

    public void startGame()
    {
        homeScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gameSetUp()
    {
        instructionText.text = "Click on the X or O to select player";
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

    public void ticTacToeButton(int whichNumber)
    {
        //player cannot change character mid game
        xPlayersButton.interactable = false;
        oPlayersButton.interactable = false;
        instructionText.text = "3 in a row in any direction wins!";

        if(turnCount > 4)
        {
            bool isWinner = winnerCheck();
            if(isWinner == true)
            {
                return;
            }
            else if(turnCount == 9 && isWinner == false)
            {
                draw();
            }
        }

        if(whoseTurn == chosenPlayer)
        {
            //places x or o in clicked button
            ticTacToeSpaces[whichNumber].image.sprite = playerIcons[whoseTurn];
            //button cannot change once clicked
            ticTacToeSpaces[whichNumber].interactable = false;
            //IDs which space is marked by chosenplayer x = 1 and o = 2;
            markedSpaces[whichNumber] = whoseTurn+1;
            turnCount++;
        }

        if(turnCount > 4)
        {
            bool isWinner = winnerCheck();
            if(isWinner == true)
            {
                return;
            }
            else if(turnCount == 9 && isWinner == false)
            {
                draw();
            }
        }

        changeTurn();
        int low = 0;
        int high = 8;
        if(whichNumber != 0 && whichNumber != 8)
        {
            low = whichNumber -1;
            high = whichNumber+1;
        }
        int num = Random.Range(low,high);
        bool marked = false;
        while(marked == false)
        {
            if(markedSpaces[num] == -100)
            {
                ticTacToeSpaces[num].image.sprite = playerIcons[whoseTurn];
                ticTacToeSpaces[num].interactable = false;
                marked = true;  
            }   
            else
            {
                if(low != 0)
                {
                    low = low - 1;
                }
                else
                {
                    low = 0;
                }
                if(high != 8)
                {
                    high = high + 1;
                }
                else
                {
                    high = 8;
                }
                num = Random.Range(low,high);
            }
        }
        //IDs which space is marked by chosenplayer x = 1 and o = 2;
        markedSpaces[num] = whoseTurn+1;
        turnCount++;
        changeTurn();
    }

    void changeTurn()
    {
        if(whoseTurn == 0)
        {
            whoseTurn = 1;
            //the following lines display whose turn via the arrows
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else if(whoseTurn == 1)
        {
            whoseTurn = 0;
            //the following lines display whose turn via the arrows
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }

    bool winnerCheck()
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
               winnerDisplay(i);
               instructionText.text = "Game Over!";
               return true;
           }
        }
        return false;
    }

    void winnerDisplay(int indexIn)
    {
        winnerPanel.gameObject.SetActive(true);
        if(whoseTurn == 0)
        {
            xPlayersScore++;
            xScoreText.text = xPlayersScore.ToString();
            winnerText.text = "Player X wins!!!";
        }
        else if(whoseTurn == 1)
        {
            oPlayersScore++;
            oScoreText.text = oPlayersScore.ToString();
            winnerText.text = "Player O wins!!!";
        }
        winningLines[indexIn].SetActive(true);
    }

    void draw()
    {
        winnerPanel.SetActive(true);
        winnerText.text = "It's a DRAW!";
    }

    public void switchPlayer(int whichPlayer)
    {
        if(whichPlayer == 0)
        {
            whoseTurn = 0;
            chosenPlayer = whoseTurn;
            instructionText.text = "you are player X - Start Game";
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
        else if(whichPlayer == 1)
        {
            whoseTurn = 1;
            chosenPlayer = whoseTurn;
            instructionText.text = "you are player O - Start Game";
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
    }

    public void rematch()
    {
        gameSetUp();
        for(int i = 0; i < winningLines.Length; i++)
        {
            winningLines[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
        xPlayersButton.interactable = true;
        oPlayersButton.interactable = true;
    }

    public void restart()
    {
        rematch();
        xPlayersScore = 0;
        oPlayersScore = 0;
        xScoreText.text = "0";
        oScoreText.text = "0";
    }

    public void goToModeScreen()
    {
        homeScreen.gameObject.SetActive(false);
        modeScreen.gameObject.SetActive(true);
    }

    public void playEasyMode()
    {
        modeScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);

        gameSetUp();
    }

    public void returnToMode()
    {
        gameScreen.gameObject.SetActive(false);
        modeScreen.gameObject.SetActive(true);
    }
}
