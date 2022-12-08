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
        instructionText.text = "Click on the X or O to select player";
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
        instructionText.text = "3 in a row in any direction wins!";

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

    bool winnerCheck() // 3 in a row wins
    {
        //horizontal wins
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[1] + markedSpaces[2] + markedSpaces[3];
        int s3 = markedSpaces[2] + markedSpaces[3] + markedSpaces[4];
        int s4 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s5 = markedSpaces[4] + markedSpaces[5] + markedSpaces[6];
        int s6 = markedSpaces[5] + markedSpaces[6] + markedSpaces[7];
        int s7 = markedSpaces[8] + markedSpaces[9] + markedSpaces[10];
        int s8 = markedSpaces[9] + markedSpaces[10] + markedSpaces[11];
        int s9 = markedSpaces[10] + markedSpaces[11] + markedSpaces[12];
        int s10 = markedSpaces[11] + markedSpaces[12] + markedSpaces[13];
        int s11 = markedSpaces[12] + markedSpaces[13] + markedSpaces[14];
        int s12 = markedSpaces[13] + markedSpaces[14] + markedSpaces[15];
        int s13 = markedSpaces[16] + markedSpaces[17] + markedSpaces[18];
        int s14 = markedSpaces[17] + markedSpaces[18] + markedSpaces[19];
        int s15 = markedSpaces[18] + markedSpaces[19] + markedSpaces[20];
        int s16 = markedSpaces[19] + markedSpaces[20] + markedSpaces[21];
        int s17 = markedSpaces[20] + markedSpaces[21] + markedSpaces[22];
        int s18 = markedSpaces[21] + markedSpaces[22] + markedSpaces[23];
        int s19 = markedSpaces[24] + markedSpaces[25] + markedSpaces[26];
        int s20 = markedSpaces[25] + markedSpaces[26] + markedSpaces[27];
        int s21 = markedSpaces[26] + markedSpaces[27] + markedSpaces[28];
        int s22 = markedSpaces[27] + markedSpaces[28] + markedSpaces[29];
        int s23 = markedSpaces[28] + markedSpaces[29] + markedSpaces[30];
        int s24 = markedSpaces[29] + markedSpaces[30] + markedSpaces[31];
        int s25 = markedSpaces[32] + markedSpaces[33] + markedSpaces[34];
        int s26 = markedSpaces[33] + markedSpaces[34] + markedSpaces[35];
        int s27 = markedSpaces[34] + markedSpaces[35] + markedSpaces[36];
        int s28 = markedSpaces[35] + markedSpaces[36] + markedSpaces[37];
        int s29 = markedSpaces[36] + markedSpaces[37] + markedSpaces[38];
        int s30 = markedSpaces[37] + markedSpaces[38] + markedSpaces[39];
        int s31 = markedSpaces[40] + markedSpaces[41] + markedSpaces[42];
        int s32 = markedSpaces[41] + markedSpaces[42] + markedSpaces[43];
        int s33 = markedSpaces[42] + markedSpaces[43] + markedSpaces[44];  
        int s34 = markedSpaces[43] + markedSpaces[44] + markedSpaces[45];   
        int s35 = markedSpaces[44] + markedSpaces[45] + markedSpaces[46];
        int s36 = markedSpaces[45] + markedSpaces[46] + markedSpaces[47];
        int s37 = markedSpaces[48] + markedSpaces[49] + markedSpaces[50];
        int s38 = markedSpaces[49] + markedSpaces[50] + markedSpaces[51];
        int s39 = markedSpaces[50] + markedSpaces[51] + markedSpaces[52];        
        int s40 = markedSpaces[51] + markedSpaces[52] + markedSpaces[53];
        int s41 = markedSpaces[52] + markedSpaces[53] + markedSpaces[54];
        int s42 = markedSpaces[53] + markedSpaces[54] + markedSpaces[55];
        int s43 = markedSpaces[56] + markedSpaces[57] + markedSpaces[58];
        int s44 = markedSpaces[57] + markedSpaces[58] + markedSpaces[59];
        int s45 = markedSpaces[58] + markedSpaces[59] + markedSpaces[60];   
        int s46 = markedSpaces[59] + markedSpaces[60] + markedSpaces[61];
        int s47 = markedSpaces[60] + markedSpaces[61] + markedSpaces[62];
        int s48 = markedSpaces[61] + markedSpaces[62] + markedSpaces[63];

        //vertical wins
        int s49 = markedSpaces[0] + markedSpaces[8] + markedSpaces[16];
        int s50 = markedSpaces[8] + markedSpaces[16] + markedSpaces[24];
        int s51 = markedSpaces[16] + markedSpaces[24] + markedSpaces[32];
        int s52 = markedSpaces[24] + markedSpaces[32] + markedSpaces[40];
        int s53 = markedSpaces[32] + markedSpaces[40] + markedSpaces[48];
        int s54 = markedSpaces[40] + markedSpaces[48] + markedSpaces[56];
        int s55 = markedSpaces[1] + markedSpaces[9] + markedSpaces[17];
        int s56 = markedSpaces[9] + markedSpaces[17] + markedSpaces[25];
        int s57 = markedSpaces[17] + markedSpaces[25] + markedSpaces[33];
        int s58 = markedSpaces[25] + markedSpaces[33] + markedSpaces[41];
        int s59 = markedSpaces[33] + markedSpaces[41] + markedSpaces[49];
        int s60 = markedSpaces[41] + markedSpaces[49] + markedSpaces[57];
        int s61 = markedSpaces[2] + markedSpaces[10] + markedSpaces[18];
        int s62 = markedSpaces[10] + markedSpaces[18] + markedSpaces[26];
        int s63 = markedSpaces[18] + markedSpaces[26] + markedSpaces[34];
        int s64 = markedSpaces[26] + markedSpaces[34] + markedSpaces[42];
        int s65 = markedSpaces[34] + markedSpaces[42] + markedSpaces[50];
        int s66 = markedSpaces[42] + markedSpaces[50] + markedSpaces[58];
        int s67 = markedSpaces[3] + markedSpaces[11] + markedSpaces[19];
        int s68 = markedSpaces[11] + markedSpaces[19] + markedSpaces[27];
        int s69 = markedSpaces[19] + markedSpaces[27] + markedSpaces[35];
        int s70 = markedSpaces[27] + markedSpaces[35] + markedSpaces[43];
        int s71 = markedSpaces[35] + markedSpaces[43] + markedSpaces[51];
        int s72 = markedSpaces[43] + markedSpaces[51] + markedSpaces[59];
        int s73 = markedSpaces[4] + markedSpaces[12] + markedSpaces[20];
        int s74 = markedSpaces[12] + markedSpaces[20] + markedSpaces[28];
        int s75 = markedSpaces[20] + markedSpaces[28] + markedSpaces[36];
        int s76 = markedSpaces[28] + markedSpaces[36] + markedSpaces[44];
        int s77 = markedSpaces[36] + markedSpaces[44] + markedSpaces[52];
        int s78 = markedSpaces[44] + markedSpaces[52] + markedSpaces[60];
        int s79 = markedSpaces[5] + markedSpaces[13] + markedSpaces[21];
        int s80 = markedSpaces[13] + markedSpaces[21] + markedSpaces[29];
        int s81 = markedSpaces[21] + markedSpaces[29] + markedSpaces[37];        
        int s82 = markedSpaces[29] + markedSpaces[37] + markedSpaces[45];
        int s83 = markedSpaces[37] + markedSpaces[45] + markedSpaces[53];
        int s84 = markedSpaces[45] + markedSpaces[53] + markedSpaces[61];
        int s85 = markedSpaces[6] + markedSpaces[14] + markedSpaces[22];
        int s86 = markedSpaces[14] + markedSpaces[22] + markedSpaces[30];        
        int s87 = markedSpaces[22] + markedSpaces[30] + markedSpaces[38];
        int s88 = markedSpaces[30] + markedSpaces[38] + markedSpaces[46];
        int s89 = markedSpaces[38] + markedSpaces[46] + markedSpaces[54];
        int s90 = markedSpaces[46] + markedSpaces[54] + markedSpaces[62];
        int s91 = markedSpaces[7] + markedSpaces[15] + markedSpaces[23];
        int s92 = markedSpaces[15] + markedSpaces[23] + markedSpaces[31];   
        int s93 = markedSpaces[23] + markedSpaces[31] + markedSpaces[39];
        int s94 = markedSpaces[31] + markedSpaces[39] + markedSpaces[37];
        int s95 = markedSpaces[39] + markedSpaces[47] + markedSpaces[55];
        int s96 = markedSpaces[47] + markedSpaces[55] + markedSpaces[63];

        //diagonal wins
        int s97 = markedSpaces[40] + markedSpaces[49] + markedSpaces[58];
        int s98 = markedSpaces[32] + markedSpaces[41] + markedSpaces[50];
        int s99 = markedSpaces[41] + markedSpaces[50] + markedSpaces[59];
        int s100 = markedSpaces[24] + markedSpaces[33] + markedSpaces[42];
        int s101 = markedSpaces[33] + markedSpaces[42] + markedSpaces[51];
        int s102 = markedSpaces[42] + markedSpaces[51] + markedSpaces[60];
        int s103 = markedSpaces[16] + markedSpaces[25] + markedSpaces[34];
        int s104 = markedSpaces[25] + markedSpaces[34] + markedSpaces[43];
        int s105 = markedSpaces[34] + markedSpaces[43] + markedSpaces[52];
        int s106 = markedSpaces[43] + markedSpaces[52] + markedSpaces[61];
        int s107 = markedSpaces[8] + markedSpaces[17] + markedSpaces[26];
        int s108 = markedSpaces[17] + markedSpaces[26] + markedSpaces[35];
        int s109 = markedSpaces[26] + markedSpaces[35] + markedSpaces[44];
        int s110 = markedSpaces[35] + markedSpaces[44] + markedSpaces[53];
        int s111 = markedSpaces[44] + markedSpaces[53] + markedSpaces[62];
        int s112 = markedSpaces[0] + markedSpaces[9] + markedSpaces[18];
        int s113 = markedSpaces[9] + markedSpaces[18] + markedSpaces[27];
        int s114 = markedSpaces[18] + markedSpaces[27] + markedSpaces[36];
        int s115 = markedSpaces[27] + markedSpaces[36] + markedSpaces[45];
        int s116 = markedSpaces[36] + markedSpaces[45] + markedSpaces[54];
        int s117 = markedSpaces[45] + markedSpaces[54] + markedSpaces[63];
        int s118 = markedSpaces[1] + markedSpaces[10] + markedSpaces[19];
        int s119 = markedSpaces[10] + markedSpaces[19] + markedSpaces[28];
        int s120 = markedSpaces[19] + markedSpaces[28] + markedSpaces[37];
        int s121 = markedSpaces[28] + markedSpaces[37] + markedSpaces[46];
        int s122 = markedSpaces[37] + markedSpaces[46] + markedSpaces[55];
        int s123 = markedSpaces[2] + markedSpaces[11] + markedSpaces[20];
        int s124 = markedSpaces[11] + markedSpaces[20] + markedSpaces[29];
        int s125 = markedSpaces[20] + markedSpaces[29] + markedSpaces[38];
        int s126 = markedSpaces[29] + markedSpaces[38] + markedSpaces[47];
        int s127 = markedSpaces[3] + markedSpaces[12] + markedSpaces[21];
        int s128 = markedSpaces[12] + markedSpaces[21] + markedSpaces[30];
        int s129 = markedSpaces[21] + markedSpaces[30] + markedSpaces[39];
        int s130 = markedSpaces[4] + markedSpaces[13] + markedSpaces[22];
        int s131 = markedSpaces[13] + markedSpaces[22] + markedSpaces[31];
        int s132 = markedSpaces[5] + markedSpaces[14] + markedSpaces[23];
        int s133 = markedSpaces[2] + markedSpaces[9] + markedSpaces[16];
        int s134 = markedSpaces[3] + markedSpaces[10] + markedSpaces[17];
        int s135 = markedSpaces[10] + markedSpaces[17] + markedSpaces[24];
        int s136 = markedSpaces[4] + markedSpaces[11] + markedSpaces[18];
        int s137 = markedSpaces[11] + markedSpaces[18] + markedSpaces[25];
        int s138 = markedSpaces[18] + markedSpaces[25] + markedSpaces[32];
        int s139 = markedSpaces[5] + markedSpaces[12] + markedSpaces[19];
        int s140 = markedSpaces[12] + markedSpaces[19] + markedSpaces[26];
        int s141 = markedSpaces[19] + markedSpaces[26] + markedSpaces[32];
        int s142 = markedSpaces[26] + markedSpaces[32] + markedSpaces[40];
        int s143 = markedSpaces[6] + markedSpaces[13] + markedSpaces[20];
        int s144 = markedSpaces[13] + markedSpaces[20] + markedSpaces[27];
        int s145 = markedSpaces[20] + markedSpaces[27] + markedSpaces[34];
        int s146 = markedSpaces[27] + markedSpaces[34] + markedSpaces[41];
        int s147 = markedSpaces[34] + markedSpaces[41] + markedSpaces[48];
        int s148 = markedSpaces[7] + markedSpaces[14] + markedSpaces[21];
        int s149 = markedSpaces[14] + markedSpaces[21] + markedSpaces[28];
        int s150 = markedSpaces[21] + markedSpaces[28] + markedSpaces[35];
        int s151 = markedSpaces[28] + markedSpaces[35] + markedSpaces[42];
        int s152 = markedSpaces[35] + markedSpaces[42] + markedSpaces[49];
        int s153 = markedSpaces[42] + markedSpaces[49] + markedSpaces[56];
        int s154 = markedSpaces[15] + markedSpaces[22] + markedSpaces[29];
        int s155 = markedSpaces[22] + markedSpaces[29] + markedSpaces[36];
        int s156 = markedSpaces[29] + markedSpaces[36] + markedSpaces[43];
        int s157 = markedSpaces[36] + markedSpaces[43] + markedSpaces[50];
        int s158 = markedSpaces[43] + markedSpaces[50] + markedSpaces[57];
        int s159 = markedSpaces[23] + markedSpaces[30] + markedSpaces[37];
        int s160 = markedSpaces[30] + markedSpaces[37] + markedSpaces[44];
        int s161 = markedSpaces[37] + markedSpaces[44] + markedSpaces[51];
        int s162 = markedSpaces[44] + markedSpaces[51] + markedSpaces[58];
        int s163 = markedSpaces[31] + markedSpaces[38] + markedSpaces[52];
        int s164 = markedSpaces[38] + markedSpaces[45] + markedSpaces[52];
        int s165 = markedSpaces[45] + markedSpaces[52] + markedSpaces[59];
        int s166 = markedSpaces[39] + markedSpaces[46] + markedSpaces[53];
        int s167 = markedSpaces[46] + markedSpaces[53] + markedSpaces[60];
        int s168 = markedSpaces[47] + markedSpaces[54] + markedSpaces[61];

        var solutions = new int[] {s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,
        s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,
        s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60,s61,s62,s63,s64,
        s65,s66,s67,s68,s69,s70,s71,s72,s73,s74,s75,s76,s77,s78,s79,s80,s81,s82,s83,s84,s85,s86,s87,
        s88,s89,s90,s91,s92,s93,s94,s95,s96,s97,s98,s99,s100,s101,s102,s103,s104,s105,s106,s107,s108,
        s109,s110,s111,s112,s113,s114,s115,s116,s117,s118,s119,s120,s121,s122,s123,s124,s125,s126,s127,
        s128,s129,s130,s131,s132,s133,s134,s135,s136,s137,s138,s139,s140,s141,s142,s143,s144,s145,s146,
        s147,s148,s149,s150,s151,s152,s152,s153,s154,s155,s156,s157,s158,s159,s160,s161,s162,s163,s164,
        s165,s166,s167,s168};  

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
