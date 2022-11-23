using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    public int chosenPlayer; // holds value for x or o depending on who user chose
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
        instructionText.text = "select a player by clicking on the X or O";
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
        //player cannot change character mid game
        xPlayersButton.interactable = false;
        oPlayersButton.interactable = false;
        instructionText.text = "5 in a row in any direction wins!";

        if(turnCount > 8)
        {
            bool isWinner = winnerCheck();
            if(isWinner == true)
            {
                return;
            }
            else if(turnCount == 25 && isWinner == false)
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

        if(turnCount > 8)
        {
            bool isWinner = winnerCheck();
            if(isWinner == true)
            {
                return;
            }
            else if(turnCount == 25 && isWinner == false)
            {
                draw();
            }
        }

        changeTurn();
        int num = Random.Range(0,14);
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
                num = Random.Range(0,14);
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

        //horizontal wins 3 in a row
        /*int s13 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s14 = markedSpaces[1] + markedSpaces[2] + markedSpaces[3];
        int s15 = markedSpaces[2] + markedSpaces[3] + markedSpaces[4];
        int s16 = markedSpaces[5] + markedSpaces[6] + markedSpaces[7];
        int s17 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s18 = markedSpaces[7] + markedSpaces[8] + markedSpaces[9];
        int s19 = markedSpaces[10] + markedSpaces[11] + markedSpaces[12];
        int s20 = markedSpaces[11] + markedSpaces[12] + markedSpaces[13];
        int s21 = markedSpaces[12] + markedSpaces[13] + markedSpaces[14];
        int s22 = markedSpaces[15] + markedSpaces[16] + markedSpaces[17];
        int s23 = markedSpaces[16] + markedSpaces[17] + markedSpaces[18];
        int s24 = markedSpaces[17] + markedSpaces[18] + markedSpaces[19];
        int s25 = markedSpaces[20] + markedSpaces[21] + markedSpaces[22];
        int s26 = markedSpaces[21] + markedSpaces[22] + markedSpaces[23];
        int s27 = markedSpaces[22] + markedSpaces[23] + markedSpaces[24];

        //vertical wins 3 in a row
        int s28 = markedSpaces[0] + markedSpaces[5] + markedSpaces[10];
        int s29 = markedSpaces[5] + markedSpaces[10] + markedSpaces[15];
        int s30 = markedSpaces[10] + markedSpaces[15] + markedSpaces[20];
        int s31 = markedSpaces[1] + markedSpaces[6] + markedSpaces[11];
        int s32 = markedSpaces[6] + markedSpaces[11] + markedSpaces[16];
        int s33 = markedSpaces[11] + markedSpaces[16] + markedSpaces[21];
        int s34 = markedSpaces[2] + markedSpaces[7] + markedSpaces[12];
        int s35 = markedSpaces[7] + markedSpaces[12] + markedSpaces[17];
        int s36 = markedSpaces[12] + markedSpaces[17] + markedSpaces[22];
        int s37 = markedSpaces[3] + markedSpaces[8] + markedSpaces[13];
        int s38 = markedSpaces[8] + markedSpaces[13] + markedSpaces[18];
        int s39 = markedSpaces[13] + markedSpaces[18] + markedSpaces[23];
        int s40 = markedSpaces[4] + markedSpaces[9] + markedSpaces[14];
        int s41 = markedSpaces[9] + markedSpaces[14] + markedSpaces[19];
        int s42 = markedSpaces[14] + markedSpaces[19] + markedSpaces[24];*/

        //horizontal wins 3 in a row

        var solutions = new int[] {s1,s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12};
        /*s13,s14,s15,s16,s17,s18,
        s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42};*/

        for(int i = 0; i < solutions.Length; i++)
        {
            /*if(solutions[i] == 3 * (whoseTurn+1))
            {
                winnerDisplay(i); //have to fix this line
                return true;
            }
            else if(solutions[i] == 4 * (whoseTurn + 1))
            {
                winnerDisplay(i);
                return true;
            }*/
            if(solutions[i] == 5 * (whoseTurn+1))
            {
                winnerDisplay(i);
                instructionText.text = "Game Over! Select: Rematch, Restart, or Return";
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