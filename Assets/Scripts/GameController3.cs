using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController3 : MonoBehaviour
{
    public int chosenPlayer; // holds value for x or o depending on who user chose
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
        instructionText.text = "8 in a row in any direction wins!";

        if(turnCount > 4)
        {
            bool isWinner = winnerCheck();
            if(isWinner == true)
            {
                return;
            }
            else if(turnCount == 64 && isWinner == false)
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
            else if(turnCount == 64 && isWinner == false)
            {
                draw();
            }
        }

        changeTurn();
        int num = Random.Range(0,63);
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
                num = Random.Range(0,63);
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
        //horizontal 8 wins
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2] + markedSpaces[3] + markedSpaces[4] + markedSpaces[5] + markedSpaces[6] + markedSpaces[7];
        int s2 = markedSpaces[8] + markedSpaces[9] + markedSpaces[10] + markedSpaces[11] + markedSpaces[12] + markedSpaces[13] + markedSpaces[14] + markedSpaces[15];
        int s3 = markedSpaces[16] + markedSpaces[17] + markedSpaces[18] + markedSpaces[19] + markedSpaces[20] + markedSpaces[21] + markedSpaces[22] + markedSpaces[23];
        int s4 = markedSpaces[24] + markedSpaces[25] + markedSpaces[26] + markedSpaces[27] + markedSpaces[28] + markedSpaces[29] + markedSpaces[30] + markedSpaces[31];
        int s5 = markedSpaces[32] + markedSpaces[33] + markedSpaces[34] + markedSpaces[35] + markedSpaces[36] + markedSpaces[37] + markedSpaces[38] + markedSpaces[39];
        int s6 = markedSpaces[40] + markedSpaces[41] + markedSpaces[42] + markedSpaces[43] + markedSpaces[44] + markedSpaces[45] + markedSpaces[46] + markedSpaces[47];
        int s7 = markedSpaces[48] + markedSpaces[49] + markedSpaces[50] + markedSpaces[51] + markedSpaces[52] + markedSpaces[53] + markedSpaces[54] + markedSpaces[55];
        int s8 = markedSpaces[56] + markedSpaces[57] + markedSpaces[58] + markedSpaces[59] + markedSpaces[60] + markedSpaces[61] + markedSpaces[62] + markedSpaces[63];

        //vertical 8 wins
        int s9 = markedSpaces[0] + markedSpaces[8] + markedSpaces[16] + markedSpaces[24] + markedSpaces[32] + markedSpaces[40] + markedSpaces[48] + markedSpaces[56];
        int s10 = markedSpaces[1] + markedSpaces[9] + markedSpaces[17] + markedSpaces[25] + markedSpaces[33] + markedSpaces[41] + markedSpaces[49] + markedSpaces[57];
        int s11 = markedSpaces[2] + markedSpaces[10] + markedSpaces[18] + markedSpaces[26] + markedSpaces[34] + markedSpaces[42] + markedSpaces[50] + markedSpaces[58];
        int s12 = markedSpaces[3] + markedSpaces[11] + markedSpaces[19] + markedSpaces[27] + markedSpaces[35] + markedSpaces[43] + markedSpaces[51] + markedSpaces[59];
        int s13 = markedSpaces[4] + markedSpaces[12] + markedSpaces[20] + markedSpaces[28] + markedSpaces[36] + markedSpaces[44] + markedSpaces[52] + markedSpaces[60];
        int s14 = markedSpaces[5] + markedSpaces[13] + markedSpaces[21] + markedSpaces[29] + markedSpaces[37] + markedSpaces[45] + markedSpaces[53] + markedSpaces[61];
        int s15 = markedSpaces[6] + markedSpaces[14] + markedSpaces[22] + markedSpaces[30] + markedSpaces[38] + markedSpaces[46] + markedSpaces[54] + markedSpaces[62];
        int s16 = markedSpaces[7] + markedSpaces[15] + markedSpaces[23] + markedSpaces[31] + markedSpaces[39] + markedSpaces[47] + markedSpaces[55] + markedSpaces[63];      

        //diagonal 8 wins
        int s17 = markedSpaces[0] + markedSpaces[9] + markedSpaces[18] + markedSpaces[27] + markedSpaces[36] + markedSpaces[45] + markedSpaces[54] + markedSpaces[63];
        int s18 = markedSpaces[7] + markedSpaces[14] + markedSpaces[21] + markedSpaces[28] + markedSpaces[35] + markedSpaces[42] + markedSpaces[49] + markedSpaces[56]; 

        //horizontal 3 wins
        int s19 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s20 = markedSpaces[1] + markedSpaces[2] + markedSpaces[3];
        int s21 = markedSpaces[2] + markedSpaces[3] + markedSpaces[4];
        int s22 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s23 = markedSpaces[4] + markedSpaces[5] + markedSpaces[6];
        int s24 = markedSpaces[5] + markedSpaces[6] + markedSpaces[7];
        int s25 = markedSpaces[8] + markedSpaces[9] + markedSpaces[10];
        int s26 = markedSpaces[9] + markedSpaces[10] + markedSpaces[11];
        int s27 = markedSpaces[10] + markedSpaces[11] + markedSpaces[12];
        int s28 = markedSpaces[11] + markedSpaces[12] + markedSpaces[13];
        int s29 = markedSpaces[12] + markedSpaces[13] + markedSpaces[14];
        int s30 = markedSpaces[13] + markedSpaces[14] + markedSpaces[15];
        int s31 = markedSpaces[16] + markedSpaces[17] + markedSpaces[18];
        int s32 = markedSpaces[17] + markedSpaces[18] + markedSpaces[19];
        int s33 = markedSpaces[18] + markedSpaces[19] + markedSpaces[20];
        int s34 = markedSpaces[19] + markedSpaces[20] + markedSpaces[21];
        int s35 = markedSpaces[20] + markedSpaces[21] + markedSpaces[22];
        int s36 = markedSpaces[21] + markedSpaces[22] + markedSpaces[23];
        int s37 = markedSpaces[24] + markedSpaces[25] + markedSpaces[26];
        int s38 = markedSpaces[25] + markedSpaces[26] + markedSpaces[27];
        int s39 = markedSpaces[26] + markedSpaces[27] + markedSpaces[28];
        int s40 = markedSpaces[27] + markedSpaces[28] + markedSpaces[29];
        int s41 = markedSpaces[28] + markedSpaces[29] + markedSpaces[30];
        int s42 = markedSpaces[29] + markedSpaces[30] + markedSpaces[31];
        int s43 = markedSpaces[32] + markedSpaces[33] + markedSpaces[34];
        int s44 = markedSpaces[33] + markedSpaces[34] + markedSpaces[35];
        int s45 = markedSpaces[34] + markedSpaces[35] + markedSpaces[36];
        int s46 = markedSpaces[35] + markedSpaces[36] + markedSpaces[37];
        int s47 = markedSpaces[36] + markedSpaces[37] + markedSpaces[38];
        int s48 = markedSpaces[37] + markedSpaces[38] + markedSpaces[39];
        int s49 = markedSpaces[40] + markedSpaces[41] + markedSpaces[42];
        int s50 = markedSpaces[41] + markedSpaces[42] + markedSpaces[43];
        int s51 = markedSpaces[42] + markedSpaces[43] + markedSpaces[44];        
        int s53 = markedSpaces[44] + markedSpaces[45] + markedSpaces[46];
        int s54 = markedSpaces[45] + markedSpaces[47] + markedSpaces[47];
        int s55 = markedSpaces[48] + markedSpaces[49] + markedSpaces[50];
        int s56 = markedSpaces[49] + markedSpaces[50] + markedSpaces[51];
        int s57 = markedSpaces[50] + markedSpaces[51] + markedSpaces[52];        
        int s58 = markedSpaces[51] + markedSpaces[52] + markedSpaces[53];
        int s59 = markedSpaces[52] + markedSpaces[53] + markedSpaces[54];
        int s60 = markedSpaces[53] + markedSpaces[54] + markedSpaces[55];
        int s61 = markedSpaces[56] + markedSpaces[57] + markedSpaces[58];
        int s62 = markedSpaces[57] + markedSpaces[58] + markedSpaces[59];
        int s63 = markedSpaces[58] + markedSpaces[59] + markedSpaces[60];   
        int s64 = markedSpaces[59] + markedSpaces[60] + markedSpaces[61];
        int s65 = markedSpaces[60] + markedSpaces[61] + markedSpaces[62];
        int s66 = markedSpaces[61] + markedSpaces[62] + markedSpaces[63];

        //vertical 3 wins
        int s67 = markedSpaces[0] + markedSpaces[8] + markedSpaces[16];
        int s68 = markedSpaces[8] + markedSpaces[16] + markedSpaces[24];
        int s69 = markedSpaces[16] + markedSpaces[24] + markedSpaces[32];
        int s70 = markedSpaces[24] + markedSpaces[32] + markedSpaces[40];
        int s71 = markedSpaces[32] + markedSpaces[40] + markedSpaces[48];
        int s72 = markedSpaces[40] + markedSpaces[48] + markedSpaces[56];
        int s73 = markedSpaces[1] + markedSpaces[9] + markedSpaces[17];
        int s74 = markedSpaces[9] + markedSpaces[17] + markedSpaces[25];
        int s75 = markedSpaces[17] + markedSpaces[25] + markedSpaces[33];
        int s76 = markedSpaces[25] + markedSpaces[33] + markedSpaces[41];
        int s77 = markedSpaces[33] + markedSpaces[41] + markedSpaces[49];
        int s78 = markedSpaces[41] + markedSpaces[49] + markedSpaces[57];
        int s79 = markedSpaces[2] + markedSpaces[10] + markedSpaces[18];
        int s80 = markedSpaces[10] + markedSpaces[18] + markedSpaces[26];
        int s81 = markedSpaces[18] + markedSpaces[26] + markedSpaces[34];
        int s82 = markedSpaces[26] + markedSpaces[34] + markedSpaces[42];
        int s83 = markedSpaces[34] + markedSpaces[42] + markedSpaces[50];
        int s84 = markedSpaces[42] + markedSpaces[50] + markedSpaces[58];
        int s85 = markedSpaces[3] + markedSpaces[11] + markedSpaces[19];
        int s86 = markedSpaces[11] + markedSpaces[19] + markedSpaces[27];
        int s87 = markedSpaces[19] + markedSpaces[27] + markedSpaces[35];
        int s88 = markedSpaces[27] + markedSpaces[35] + markedSpaces[43];
        int s89 = markedSpaces[35] + markedSpaces[43] + markedSpaces[51];
        int s90 = markedSpaces[43] + markedSpaces[51] + markedSpaces[59];
        int s91 = markedSpaces[4] + markedSpaces[12] + markedSpaces[20];
        int s92 = markedSpaces[12] + markedSpaces[20] + markedSpaces[28];
        int s93 = markedSpaces[20] + markedSpaces[28] + markedSpaces[36];
        int s94 = markedSpaces[28] + markedSpaces[36] + markedSpaces[44];
        int s95 = markedSpaces[36] + markedSpaces[44] + markedSpaces[52];
        int s96 = markedSpaces[44] + markedSpaces[52] + markedSpaces[60];
        int s97 = markedSpaces[5] + markedSpaces[13] + markedSpaces[21];
        int s98 = markedSpaces[13] + markedSpaces[21] + markedSpaces[29];
        int s99 = markedSpaces[21] + markedSpaces[29] + markedSpaces[37];        
        int s100 = markedSpaces[29] + markedSpaces[37] + markedSpaces[45];
        int s101 = markedSpaces[37] + markedSpaces[45] + markedSpaces[53];
        int s102 = markedSpaces[45] + markedSpaces[53] + markedSpaces[61];
        int s103 = markedSpaces[6] + markedSpaces[14] + markedSpaces[22];
        int s104 = markedSpaces[14] + markedSpaces[22] + markedSpaces[30];        
        int s105 = markedSpaces[22] + markedSpaces[30] + markedSpaces[38];
        int s106 = markedSpaces[30] + markedSpaces[38] + markedSpaces[46];
        int s107 = markedSpaces[38] + markedSpaces[46] + markedSpaces[54];
        int s108 = markedSpaces[46] + markedSpaces[54] + markedSpaces[62];
        int s109 = markedSpaces[7] + markedSpaces[15] + markedSpaces[23];
        int s110 = markedSpaces[15] + markedSpaces[23] + markedSpaces[31];   
        int s111 = markedSpaces[23] + markedSpaces[31] + markedSpaces[39];
        int s112 = markedSpaces[31] + markedSpaces[39] + markedSpaces[37];
        int s113 = markedSpaces[39] + markedSpaces[47] + markedSpaces[55];
        int s114 = markedSpaces[47] + markedSpaces[55] + markedSpaces[63];

        //diagonal 3 wins

        var solutions = new int[] {s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18};  
        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 3 * (whoseTurn+1))
            {
                winnerDisplay(i);
                instructionText.text = "Game Over! Select: Rematch, Restart, or Return";
                return true;
            }
            if(solutions[i] == 8 * (whoseTurn+1))
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
