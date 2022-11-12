using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController3 : MonoBehaviour
{
    public int whoseTurn;
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;
    public Button[] ticTacToeSpaces;
    public int[] markedSpaces;

    public Text winnerText;
    public GameObject[] winningLines;
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

        if(turnCount > 14)
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
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2] + markedSpaces[3] + markedSpaces[4] + markedSpaces[5] + markedSpaces[6] + markedSpaces[7];
        int s2 = markedSpaces[8] + markedSpaces[9] + markedSpaces[10] + markedSpaces[11] + markedSpaces[12] + markedSpaces[13] + markedSpaces[14] + markedSpaces[15];
        int s3 = markedSpaces[16] + markedSpaces[17] + markedSpaces[18] + markedSpaces[19] + markedSpaces[20] + markedSpaces[21] + markedSpaces[22] + markedSpaces[23];
        int s4 = markedSpaces[24] + markedSpaces[25] + markedSpaces[26] + markedSpaces[27] + markedSpaces[28] + markedSpaces[29] + markedSpaces[30] + markedSpaces[31];
        int s5 = markedSpaces[32] + markedSpaces[33] + markedSpaces[34] + markedSpaces[35] + markedSpaces[36] + markedSpaces[37] + markedSpaces[38] + markedSpaces[39];
        int s6 = markedSpaces[40] + markedSpaces[41] + markedSpaces[42] + markedSpaces[43] + markedSpaces[44] + markedSpaces[45] + markedSpaces[46] + markedSpaces[47];
        int s7 = markedSpaces[48] + markedSpaces[49] + markedSpaces[50] + markedSpaces[51] + markedSpaces[52] + markedSpaces[53] + markedSpaces[54] + markedSpaces[55];
        int s8 = markedSpaces[56] + markedSpaces[57] + markedSpaces[58] + markedSpaces[59] + markedSpaces[60] + markedSpaces[61] + markedSpaces[62] + markedSpaces[63];

        //vertical wins
        int s9 = markedSpaces[0] + markedSpaces[8] + markedSpaces[16] + markedSpaces[24] + markedSpaces[32] + markedSpaces[40] + markedSpaces[48] + markedSpaces[56];
        int s10 = markedSpaces[1] + markedSpaces[9] + markedSpaces[17] + markedSpaces[25] + markedSpaces[33] + markedSpaces[41] + markedSpaces[49] + markedSpaces[57];
        int s11 = markedSpaces[2] + markedSpaces[10] + markedSpaces[18] + markedSpaces[26] + markedSpaces[34] + markedSpaces[42] + markedSpaces[50] + markedSpaces[58];
        int s12 = markedSpaces[3] + markedSpaces[11] + markedSpaces[19] + markedSpaces[27] + markedSpaces[35] + markedSpaces[43] + markedSpaces[51] + markedSpaces[59];
        int s13 = markedSpaces[4] + markedSpaces[12] + markedSpaces[20] + markedSpaces[28] + markedSpaces[36] + markedSpaces[44] + markedSpaces[52] + markedSpaces[60];
        int s14 = markedSpaces[5] + markedSpaces[13] + markedSpaces[21] + markedSpaces[29] + markedSpaces[37] + markedSpaces[45] + markedSpaces[53] + markedSpaces[61];
        int s15 = markedSpaces[6] + markedSpaces[14] + markedSpaces[22] + markedSpaces[30] + markedSpaces[38] + markedSpaces[46] + markedSpaces[54] + markedSpaces[62];
        int s16 = markedSpaces[7] + markedSpaces[15] + markedSpaces[23] + markedSpaces[31] + markedSpaces[39] + markedSpaces[47] + markedSpaces[55] + markedSpaces[63];      

        //diagonal wins
        int s17 = markedSpaces[0] + markedSpaces[9] + markedSpaces[18] + markedSpaces[27] + markedSpaces[36] + markedSpaces[45] + markedSpaces[54] + markedSpaces[63];
        int s18 = markedSpaces[7] + markedSpaces[14] + markedSpaces[21] + markedSpaces[28] + markedSpaces[35] + markedSpaces[42] + markedSpaces[49] + markedSpaces[56];  

        var solutions = new int[] {s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18};  
        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 8 * (whoseTurn+1))
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

    public void playDifficultMode()
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
