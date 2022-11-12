using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    public int whoseTurn; //0 = x and 1 = o
    public int turnCount; //count nunber of turns played
    public GameObject[] turnIcons; //displays whose turn it is
    public Sprite[] playerIcons; // 0 = x and 1 = o
    public Button[] ticTacToeSpaces; // playable spaces
    public int[] markedSpaces; //ids which space was marked by each player

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
        instructionText.text = "select a player or Start Game";
        whoseTurn = 0;
        turnCount = 0;
        //shows x will start
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        //grid buttons can be clicked
        for(int i = 0; i < ticTacToeSpaces.Length; i++)
        {
            ticTacToeSpaces[i].interactable = true;
            ticTacToeSpaces[i].GetComponent<Image>().sprite = null;
        }
        //sets all grid spaces to unmarked
        for(int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100; 
        }
    }

    public void ticTacToeButton(int whichNumber)
    {
        //player cannot change character mid game and instructions disappear
        xPlayersButton.interactable = false;
        oPlayersButton.interactable = false;
        instructionText.text = "";

        //places x or o on button that was clicked; cannot change x or o after click
        ticTacToeSpaces[whichNumber].image.sprite = playerIcons[whoseTurn];
        ticTacToeSpaces[whichNumber].interactable = false;

        markedSpaces[whichNumber] = whoseTurn+1;
        turnCount++;

        if(turnCount > 8)
        {
            winnerCheck();
        }

        if(whoseTurn == 0)
        {
            whoseTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }

    bool winnerCheck()
    {
        //horizontal wins
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2] + markedSpaces[3] + markedSpaces[4];
        int s2 = markedSpaces[5] + markedSpaces[6] + markedSpaces[7] + markedSpaces[8] + markedSpaces[9];
        int s3 = markedSpaces[10] + markedSpaces[11] + markedSpaces[12] + markedSpaces[13] + markedSpaces[14];
        int s4 = markedSpaces[15] + markedSpaces[16] + markedSpaces[17] + markedSpaces[18] + markedSpaces[19];
        int s5 = markedSpaces[20] + markedSpaces[21] + markedSpaces[22] + markedSpaces[23] + markedSpaces[24];

        //vertical wins
        int s6 = markedSpaces[0] + markedSpaces[5] + markedSpaces[10] + markedSpaces[15] + markedSpaces[20];
        int s7 = markedSpaces[1] + markedSpaces[6] + markedSpaces[11] + markedSpaces[16] + markedSpaces[21];
        int s8 = markedSpaces[2] + markedSpaces[7] + markedSpaces[12] + markedSpaces[17] + markedSpaces[22];
        int s9 = markedSpaces[3] + markedSpaces[8] + markedSpaces[13] + markedSpaces[18] + markedSpaces[23];
        int s10 = markedSpaces[4] + markedSpaces[9] + markedSpaces[14] + markedSpaces[19] + markedSpaces[24];

        //diagonal wins
        int s11 = markedSpaces[0] + markedSpaces[6] + markedSpaces[12] + markedSpaces[18] + markedSpaces[24];
        int s12 = markedSpaces[4] + markedSpaces[8] + markedSpaces[12] + markedSpaces[16] + markedSpaces[20];

        var solutions = new int[] {s1,s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12};

        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 5 * (whoseTurn+1))
            {
                winnerDisplay(i);
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
            oScoreText.text = xPlayersScore.ToString();
            winnerText.text = "Player O wins!!!";
        }
        winningLines[indexIn].SetActive(true);
    }

    void draw()
    {
        winnerPanel.SetActive(true);
        winnerText.text = "It's a DRAW!";
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

    public void switchPlayer(int whichPlayer)
    {
        if(whichPlayer == 0)
        {
            whoseTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
        else if(whichPlayer == 1)
        {
            whoseTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
    }

    public void goToModeScreen()
    {
        homeScreen.gameObject.SetActive(false);
        modeScreen.gameObject.SetActive(true);
    }

    public void playMediumMode()
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