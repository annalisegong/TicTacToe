using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController3 : MonoBehaviour
{
    public int position;
    public int num;
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
        if(turnCount > 1)
        {
            bool possibleWin = canWin();
            if(possibleWin == true)
            {
                num = position;
            }
            else
            {
                int num = Random.Range(0,63);
            }
        }
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

    bool canWin()
    {
        //holds individual board values (-100, 1, or 2) in each array
        int[] a1 = new int[] {markedSpaces[0], markedSpaces[1], markedSpaces[2]};
        int[] a2 = new int[] {markedSpaces[1], markedSpaces[2], markedSpaces[3]};
        int[] a3 = new int[] {markedSpaces[2], markedSpaces[3], markedSpaces[4]};
        int[] a4 = new int[] {markedSpaces[3], markedSpaces[4], markedSpaces[5]};
        int[] a5 = new int[] {markedSpaces[4], markedSpaces[5], markedSpaces[6]};
        int[] a6 = new int[] {markedSpaces[5], markedSpaces[6], markedSpaces[7]};
        int[] a7 = new int[] {markedSpaces[8], markedSpaces[9], markedSpaces[10]};
        int[] a8 = new int[] {markedSpaces[9], markedSpaces[10], markedSpaces[11]};
        int[] a9 = new int[] {markedSpaces[10], markedSpaces[11], markedSpaces[12]};
        int[] a10 = new int[] {markedSpaces[11], markedSpaces[12], markedSpaces[13]};
        int[] a11 = new int[] {markedSpaces[12], markedSpaces[13], markedSpaces[14]};
        int[] a12 = new int[] {markedSpaces[13], markedSpaces[14], markedSpaces[15]};
        int[] a13 = new int[] {markedSpaces[16], markedSpaces[17], markedSpaces[18]};
        int[] a14 = new int[] {markedSpaces[17], markedSpaces[18], markedSpaces[19]};
        int[] a15 = new int[] {markedSpaces[18], markedSpaces[19], markedSpaces[20]};
        int[] a16 = new int[] {markedSpaces[19], markedSpaces[20], markedSpaces[21]};
        int[] a17 = new int[] {markedSpaces[20], markedSpaces[21], markedSpaces[22]};
        int[] a18 = new int[] {markedSpaces[21], markedSpaces[22], markedSpaces[23]};
        int[] a19 = new int[] {markedSpaces[24], markedSpaces[25], markedSpaces[26]};
        int[] a20 = new int[] {markedSpaces[25], markedSpaces[26], markedSpaces[27]};
        int[] a21 = new int[] {markedSpaces[26], markedSpaces[27], markedSpaces[28]};
        int[] a22 = new int[] {markedSpaces[27], markedSpaces[28], markedSpaces[29]};
        int[] a23 = new int[] {markedSpaces[28], markedSpaces[29], markedSpaces[30]};
        int[] a24 = new int[] {markedSpaces[29], markedSpaces[30], markedSpaces[31]};
        int[] a25 = new int[] {markedSpaces[32], markedSpaces[33], markedSpaces[34]};
        int[] a26 = new int[] {markedSpaces[33], markedSpaces[34], markedSpaces[35]};
        int[] a27 = new int[] {markedSpaces[34], markedSpaces[35], markedSpaces[36]};
        int[] a28 = new int[] {markedSpaces[35], markedSpaces[36], markedSpaces[37]};
        int[] a29 = new int[] {markedSpaces[36], markedSpaces[37], markedSpaces[38]};
        int[] a30 = new int[] {markedSpaces[37], markedSpaces[38], markedSpaces[39]};
        int[] a31 = new int[] {markedSpaces[40], markedSpaces[41], markedSpaces[42]};
        int[] a32 = new int[] {markedSpaces[41], markedSpaces[42], markedSpaces[43]};
        int[] a33 = new int[] {markedSpaces[42], markedSpaces[43], markedSpaces[44]};  
        int[] a34 = new int[] {markedSpaces[43], markedSpaces[44], markedSpaces[45]};   
        int[] a35 = new int[] {markedSpaces[44], markedSpaces[45], markedSpaces[46]};
        int[] a36 = new int[] {markedSpaces[45], markedSpaces[46], markedSpaces[47]};
        int[] a37 = new int[] {markedSpaces[48], markedSpaces[49], markedSpaces[50]};
        int[] a38 = new int[] {markedSpaces[49], markedSpaces[50], markedSpaces[51]};
        int[] a39 = new int[] {markedSpaces[50], markedSpaces[51], markedSpaces[52]};        
        int[] a40 = new int[] {markedSpaces[51], markedSpaces[52], markedSpaces[53]};
        int[] a41 = new int[] {markedSpaces[52], markedSpaces[53], markedSpaces[54]};
        int[] a42 = new int[] {markedSpaces[53], markedSpaces[54], markedSpaces[55]};
        int[] a43 = new int[] {markedSpaces[56], markedSpaces[57], markedSpaces[58]};
        int[] a44 = new int[] {markedSpaces[57], markedSpaces[58], markedSpaces[59]};
        int[] a45 = new int[] {markedSpaces[58], markedSpaces[59], markedSpaces[60]};   
        int[] a46 = new int[] {markedSpaces[59], markedSpaces[60], markedSpaces[61]};
        int[] a47 = new int[] {markedSpaces[60], markedSpaces[61], markedSpaces[62]};
        int[] a48 = new int[] {markedSpaces[61], markedSpaces[62], markedSpaces[63]};
        int[] a49 = new int[] {markedSpaces[0], markedSpaces[8], markedSpaces[16]};
        int[] a50 = new int[] {markedSpaces[8], markedSpaces[16], markedSpaces[24]};
        int[] a51 = new int[] {markedSpaces[16], markedSpaces[24], markedSpaces[32]};
        int[] a52 = new int[] {markedSpaces[24], markedSpaces[32], markedSpaces[40]};
        int[] a53 = new int[] {markedSpaces[32], markedSpaces[40], markedSpaces[48]};
        int[] a54 = new int[] {markedSpaces[40], markedSpaces[48], markedSpaces[56]};
        int[] a55 = new int[] {markedSpaces[1], markedSpaces[9], markedSpaces[17]};
        int[] a56 = new int[] {markedSpaces[9], markedSpaces[17], markedSpaces[25]};
        int[] a57 = new int[] {markedSpaces[17], markedSpaces[25], markedSpaces[33]};
        int[] a58 = new int[] {markedSpaces[25], markedSpaces[33], markedSpaces[41]};
        int[] a59 = new int[] {markedSpaces[33], markedSpaces[41], markedSpaces[49]};
        int[] a60 = new int[] {markedSpaces[41], markedSpaces[49], markedSpaces[57]};
        int[] a61 = new int[] {markedSpaces[2], markedSpaces[10], markedSpaces[18]};
        int[] a62 = new int[] {markedSpaces[10], markedSpaces[18], markedSpaces[26]};
        int[] a63 = new int[] {markedSpaces[18], markedSpaces[26], markedSpaces[34]};
        int[] a64 = new int[] {markedSpaces[26], markedSpaces[34], markedSpaces[42]};
        int[] a65 = new int[] {markedSpaces[34], markedSpaces[42], markedSpaces[50]};
        int[] a66 = new int[] {markedSpaces[42], markedSpaces[50], markedSpaces[58]};
        int[] a67 = new int[] {markedSpaces[3], markedSpaces[11], markedSpaces[19]};
        int[] a68 = new int[] {markedSpaces[11], markedSpaces[19], markedSpaces[27]};
        int[] a69 = new int[] {markedSpaces[19], markedSpaces[27], markedSpaces[35]};
        int[] a70 = new int[] {markedSpaces[27], markedSpaces[35], markedSpaces[43]};
        int[] a71 = new int[] {markedSpaces[35], markedSpaces[43], markedSpaces[51]};
        int[] a72 = new int[] {markedSpaces[43], markedSpaces[51], markedSpaces[59]};
        int[] a73 = new int[] {markedSpaces[4], markedSpaces[12], markedSpaces[20]};
        int[] a74 = new int[] {markedSpaces[12], markedSpaces[20], markedSpaces[28]};
        int[] a75 = new int[] {markedSpaces[20], markedSpaces[28], markedSpaces[36]};
        int[] a76 = new int[] {markedSpaces[28], markedSpaces[36], markedSpaces[44]};
        int[] a77 = new int[] {markedSpaces[36], markedSpaces[44], markedSpaces[52]};
        int[] a78 = new int[] {markedSpaces[44], markedSpaces[52], markedSpaces[60]};
        int[] a79 = new int[] {markedSpaces[5], markedSpaces[13], markedSpaces[21]};
        int[] a80 = new int[] {markedSpaces[13], markedSpaces[21], markedSpaces[29]};
        int[] a81 = new int[] {markedSpaces[21], markedSpaces[29], markedSpaces[37]};        
        int[] a82 = new int[] {markedSpaces[29], markedSpaces[37], markedSpaces[45]};
        int[] a83 = new int[] {markedSpaces[37], markedSpaces[45], markedSpaces[53]};
        int[] a84 = new int[] {markedSpaces[45], markedSpaces[53], markedSpaces[61]};
        int[] a85 = new int[] {markedSpaces[6], markedSpaces[14], markedSpaces[22]};
        int[] a86 = new int[] {markedSpaces[14], markedSpaces[22], markedSpaces[30]};        
        int[] a87 = new int[] {markedSpaces[22], markedSpaces[30], markedSpaces[38]};
        int[] a88 = new int[] {markedSpaces[30], markedSpaces[38], markedSpaces[46]};
        int[] a89 = new int[] {markedSpaces[38], markedSpaces[46], markedSpaces[54]};
        int[] a90 = new int[] {markedSpaces[46], markedSpaces[54], markedSpaces[62]};
        int[] a91 = new int[] {markedSpaces[7], markedSpaces[15], markedSpaces[23]};
        int[] a92 = new int[] {markedSpaces[15], markedSpaces[23], markedSpaces[31]};   
        int[] a93 = new int[] {markedSpaces[23], markedSpaces[31], markedSpaces[39]};
        int[] a94 = new int[] {markedSpaces[31], markedSpaces[39], markedSpaces[37]};
        int[] a95 = new int[] {markedSpaces[39], markedSpaces[47], markedSpaces[55]};
        int[] a96 = new int[] {markedSpaces[47], markedSpaces[55], markedSpaces[63]};
        int[] a97 = new int[] {markedSpaces[40], markedSpaces[49], markedSpaces[58]};
        int[] a98 = new int[] {markedSpaces[32], markedSpaces[41], markedSpaces[50]};
        int[] a99 = new int[] {markedSpaces[41], markedSpaces[50], markedSpaces[59]};
        int[] a100 = new int[] {markedSpaces[24], markedSpaces[33], markedSpaces[42]};
        int[] a101 = new int[] {markedSpaces[33], markedSpaces[42], markedSpaces[51]};
        int[] a102 = new int[] {markedSpaces[42], markedSpaces[51], markedSpaces[60]};
        int[] a103 = new int[] {markedSpaces[16], markedSpaces[25], markedSpaces[34]};
        int[] a104 = new int[] {markedSpaces[25], markedSpaces[34], markedSpaces[43]};
        int[] a105 = new int[] {markedSpaces[34], markedSpaces[43], markedSpaces[52]};
        int[] a106 = new int[] {markedSpaces[43], markedSpaces[52], markedSpaces[61]};
        int[] a107 = new int[] {markedSpaces[8], markedSpaces[17], markedSpaces[26]};
        int[] a108 = new int[] {markedSpaces[17], markedSpaces[26], markedSpaces[35]};
        int[] a109 = new int[] {markedSpaces[26], markedSpaces[35], markedSpaces[44]};
        int[] a110 = new int[] {markedSpaces[35], markedSpaces[44], markedSpaces[53]};
        int[] a111 = new int[] {markedSpaces[44], markedSpaces[53], markedSpaces[62]};
        int[] a112 = new int[] {markedSpaces[0], markedSpaces[9], markedSpaces[18]};
        int[] a113 = new int[] {markedSpaces[9], markedSpaces[18], markedSpaces[27]};
        int[] a114 = new int[] {markedSpaces[18], markedSpaces[27], markedSpaces[36]};
        int[] a115 = new int[] {markedSpaces[27], markedSpaces[36], markedSpaces[45]};
        int[] a116 = new int[] {markedSpaces[36], markedSpaces[45], markedSpaces[54]};
        int[] a117 = new int[] {markedSpaces[45], markedSpaces[54], markedSpaces[63]};
        int[] a118 = new int[] {markedSpaces[1], markedSpaces[10], markedSpaces[19]};
        int[] a119 = new int[] {markedSpaces[10], markedSpaces[19], markedSpaces[28]};
        int[] a120 = new int[] {markedSpaces[19], markedSpaces[28], markedSpaces[37]};
        int[] a121 = new int[] {markedSpaces[28], markedSpaces[37], markedSpaces[46]};
        int[] a122 = new int[] {markedSpaces[37], markedSpaces[46], markedSpaces[55]};
        int[] a123 = new int[] {markedSpaces[2], markedSpaces[11], markedSpaces[20]};
        int[] a124 = new int[] {markedSpaces[11], markedSpaces[20], markedSpaces[29]};
        int[] a125 = new int[] {markedSpaces[20], markedSpaces[29], markedSpaces[38]};
        int[] a126 = new int[] {markedSpaces[29], markedSpaces[38], markedSpaces[47]};
        int[] a127 = new int[] {markedSpaces[3], markedSpaces[12], markedSpaces[21]};
        int[] a128 = new int[] {markedSpaces[12], markedSpaces[21], markedSpaces[30]};
        int[] a129 = new int[] {markedSpaces[21], markedSpaces[30], markedSpaces[39]};
        int[] a130 = new int[] {markedSpaces[4], markedSpaces[13], markedSpaces[22]};
        int[] a131 = new int[] {markedSpaces[13], markedSpaces[22], markedSpaces[31]};
        int[] a132 = new int[] {markedSpaces[5], markedSpaces[14], markedSpaces[23]};
        int[] a133 = new int[] {markedSpaces[2], markedSpaces[9], markedSpaces[16]};
        int[] a134 = new int[] {markedSpaces[3], markedSpaces[10], markedSpaces[17]};
        int[] a135 = new int[] {markedSpaces[10], markedSpaces[17], markedSpaces[24]};
        int[] a136 = new int[] {markedSpaces[4], markedSpaces[11], markedSpaces[18]};
        int[] a137 = new int[] {markedSpaces[11], markedSpaces[18], markedSpaces[25]};
        int[] a138 = new int[] {markedSpaces[18], markedSpaces[25], markedSpaces[32]};
        int[] a139 = new int[] {markedSpaces[5], markedSpaces[12], markedSpaces[19]};
        int[] a140 = new int[] {markedSpaces[12], markedSpaces[19], markedSpaces[26]};
        int[] a141 = new int[] {markedSpaces[19], markedSpaces[26], markedSpaces[32]};
        int[] a142 = new int[] {markedSpaces[26], markedSpaces[32], markedSpaces[40]};
        int[] a143 = new int[] {markedSpaces[6], markedSpaces[13], markedSpaces[20]};
        int[] a144 = new int[] {markedSpaces[13], markedSpaces[20], markedSpaces[27]};
        int[] a145 = new int[] {markedSpaces[20], markedSpaces[27], markedSpaces[34]};
        int[] a146 = new int[] {markedSpaces[27], markedSpaces[34], markedSpaces[41]};
        int[] a147 = new int[] {markedSpaces[34], markedSpaces[41], markedSpaces[48]};
        int[] a148 = new int[] {markedSpaces[7], markedSpaces[14], markedSpaces[21]};
        int[] a149 = new int[] {markedSpaces[14], markedSpaces[21], markedSpaces[28]};
        int[] a150 = new int[] {markedSpaces[21], markedSpaces[28], markedSpaces[35]};
        int[] a151 = new int[] {markedSpaces[28], markedSpaces[35], markedSpaces[42]};
        int[] a152 = new int[] {markedSpaces[35], markedSpaces[42], markedSpaces[49]};
        int[] a153 = new int[] {markedSpaces[42], markedSpaces[49], markedSpaces[56]};
        int[] a154 = new int[] {markedSpaces[15], markedSpaces[22], markedSpaces[29]};
        int[] a155 = new int[] {markedSpaces[22], markedSpaces[29], markedSpaces[36]};
        int[] a156 = new int[] {markedSpaces[29], markedSpaces[36], markedSpaces[43]};
        int[] a157 = new int[] {markedSpaces[36], markedSpaces[43], markedSpaces[50]};
        int[] a158 = new int[] {markedSpaces[43], markedSpaces[50], markedSpaces[57]};
        int[] a159 = new int[] {markedSpaces[23], markedSpaces[30], markedSpaces[37]};
        int[] a160 = new int[] {markedSpaces[30], markedSpaces[37], markedSpaces[44]};
        int[] a161 = new int[] {markedSpaces[37], markedSpaces[44], markedSpaces[51]};
        int[] a162 = new int[] {markedSpaces[44], markedSpaces[51], markedSpaces[58]};
        int[] a163 = new int[] {markedSpaces[31], markedSpaces[38], markedSpaces[52]};
        int[] a164 = new int[] {markedSpaces[38], markedSpaces[45], markedSpaces[52]};
        int[] a165 = new int[] {markedSpaces[45], markedSpaces[52], markedSpaces[59]};
        int[] a166 = new int[] {markedSpaces[39], markedSpaces[46], markedSpaces[53]};
        int[] a167 = new int[] {markedSpaces[46], markedSpaces[53], markedSpaces[60]};
        int[] a168 = new int[] {markedSpaces[47], markedSpaces[54], markedSpaces[61]};

        //holds board button numbers
        int[] b1 = new int[] {0,1,2};
        int[] b2 = new int[] {1,2,3};
        int[] b3 = new int[] {2,3,4};
        int[] b4 = new int[] {3,4,5};
        int[] b5 = new int[] {4,5,6};
        int[] b6 = new int[] {5,6,7};
        int[] b7 = new int[] {8,9,10};
        int[] b8 = new int[] {9,10,11};
        int[] b9 = new int[] {10,11,12};
        int[] b10 = new int[] {11,12,13};
        int[] b11 = new int[] {12,13,14};
        int[] b12 = new int[] {13,14,15};
        int[] b13 = new int[] {16,17,18};
        int[] b14 = new int[] {17,18,19};
        int[] b15 = new int[] {18,19,20};
        int[] b16 = new int[] {19,20,21};
        int[] b17 = new int[] {20,21,22};
        int[] b18 = new int[] {21,22,23};
        int[] b19 = new int[] {24,25,26};
        int[] b20 = new int[] {25,26,27};
        int[] b21 = new int[] {26,27,28};
        int[] b22 = new int[] {27,28,29};
        int[] b23 = new int[] {28,29,30};
        int[] b24 = new int[] {29,30,31};
        int[] b25 = new int[] {32,33,34};
        int[] b26 = new int[] {33,34,35};
        int[] b27 = new int[] {34,35,36};
        int[] b28 = new int[] {35,36,37};
        int[] b29 = new int[] {36,37,38};
        int[] b30 = new int[] {37,38,39};
        int[] b31 = new int[] {40,41,42};
        int[] b32 = new int[] {41,42,43};
        int[] b33 = new int[] {42,43,44};  
        int[] b34 = new int[] {43,44,45};   
        int[] b35 = new int[] {44,45,46};
        int[] b36 = new int[] {45,46,47};
        int[] b37 = new int[] {48,49,50};
        int[] b38 = new int[] {49,50,51};
        int[] b39 = new int[] {50,51,52};        
        int[] b40 = new int[] {51,52,53};
        int[] b41 = new int[] {52,53,54};
        int[] b42 = new int[] {53,54,55};
        int[] b43 = new int[] {56,57,58};
        int[] b44 = new int[] {57,58,59};
        int[] b45 = new int[] {58,59,60};   
        int[] b46 = new int[] {59,60,61};
        int[] b47 = new int[] {60,61,62};
        int[] b48 = new int[] {61,62,63};
        int[] b49 = new int[] {0,8,16};
        int[] b50 = new int[] {8,16,24};
        int[] b51 = new int[] {16,24,32};
        int[] b52 = new int[] {24,32,40};
        int[] b53 = new int[] {32,40,48};
        int[] b54 = new int[] {40,48,56};
        int[] b55 = new int[] {1,9,17};
        int[] b56 = new int[] {9,17,25};
        int[] b57 = new int[] {17,25,33};
        int[] b58 = new int[] {25,33,41};
        int[] b59 = new int[] {33,41,49};
        int[] b60 = new int[] {41,49,57};
        int[] b61 = new int[] {2,10,18};
        int[] b62 = new int[] {10,18,26};
        int[] b63 = new int[] {18,26,34};
        int[] b64 = new int[] {26,34,42};
        int[] b65 = new int[] {34,42,50};
        int[] b66 = new int[] {42,50,58};
        int[] b67 = new int[] {3,11,19};
        int[] b68 = new int[] {11,19,27};
        int[] b69 = new int[] {19,27,35};
        int[] b70 = new int[] {27,35,43};
        int[] b71 = new int[] {35,43,51};
        int[] b72 = new int[] {43,51,59};
        int[] b73 = new int[] {4,12,20};
        int[] b74 = new int[] {12,20,28};
        int[] b75 = new int[] {20,28,36};
        int[] b76 = new int[] {28,36,44};
        int[] b77 = new int[] {36,44,52};
        int[] b78 = new int[] {44,52,60};
        int[] b79 = new int[] {5,13,21};
        int[] b80 = new int[] {13,21,29};
        int[] b81 = new int[] {21,29,37};        
        int[] b82 = new int[] {29,37,45};
        int[] b83 = new int[] {37,45,53};
        int[] b84 = new int[] {45,53,61};
        int[] b85 = new int[] {6,14,22};
        int[] b86 = new int[] {14,22,30};        
        int[] b87 = new int[] {22,30,38};
        int[] b88 = new int[] {30,38,46};
        int[] b89 = new int[] {38,46,54};
        int[] b90 = new int[] {46,54,62};
        int[] b91 = new int[] {7,15,23};
        int[] b92 = new int[] {15,23,31};   
        int[] b93 = new int[] {23,31,39};
        int[] b94 = new int[] {31,39,37};
        int[] b95 = new int[] {39,47,55};
        int[] b96 = new int[] {47,55,63};
        int[] b97 = new int[] {40,49,58};
        int[] b98 = new int[] {32,41,50};
        int[] b99 = new int[] {41,50,59};
        int[] b100 = new int[] {24,33,42};
        int[] b101 = new int[] {33,42,51};
        int[] b102 = new int[] {42,51,60};
        int[] b103 = new int[] {16,25,34};
        int[] b104 = new int[] {25,34,43};
        int[] b105 = new int[] {34,43,52};
        int[] b106 = new int[] {43,52,61};
        int[] b107 = new int[] {8,17,26};
        int[] b108 = new int[] {17,26,35};
        int[] b109 = new int[] {26,35,44};
        int[] b110 = new int[] {35,44,53};
        int[] b111 = new int[] {44,53,62};
        int[] b112 = new int[] {0,9,18};
        int[] b113 = new int[] {9,18,27};
        int[] b114 = new int[] {18,27,36};
        int[] b115 = new int[] {27,36,45};
        int[] b116 = new int[] {36,45,54};
        int[] b117 = new int[] {45,54,63};
        int[] b118 = new int[] {1,10,19};
        int[] b119 = new int[] {10,19,28};
        int[] b120 = new int[] {19,28,37};
        int[] b121 = new int[] {28,37,46};
        int[] b122 = new int[] {37,46,55};
        int[] b123 = new int[] {2,11,20};
        int[] b124 = new int[] {11,20,29};
        int[] b125 = new int[] {20,29,38};
        int[] b126 = new int[] {29,38,47};
        int[] b127 = new int[] {3,12,21};
        int[] b128 = new int[] {12,21,30};
        int[] b129 = new int[] {21,30,39};
        int[] b130 = new int[] {4,13,22};
        int[] b131 = new int[] {13,22,31};
        int[] b132 = new int[] {5,14,23};
        int[] b133 = new int[] {2,9,16};
        int[] b134 = new int[] {3,10,17};
        int[] b135 = new int[] {10,17,24};
        int[] b136 = new int[] {4,11,18};
        int[] b137 = new int[] {11,18,25};
        int[] b138 = new int[] {18,25,32};
        int[] b139 = new int[] {5,12,19};
        int[] b140 = new int[] {12,19,26};
        int[] b141 = new int[] {19,26,32};
        int[] b142 = new int[] {26,32,40};
        int[] b143 = new int[] {6,13,20};
        int[] b144 = new int[] {13,20,27};
        int[] b145 = new int[] {20,27,34};
        int[] b146 = new int[] {27,34,41};
        int[] b147 = new int[] {34,41,48};
        int[] b148 = new int[] {7,14,21};
        int[] b149 = new int[] {14,21,28};
        int[] b150 = new int[] {21,28,35};
        int[] b151 = new int[] {28,35,42};
        int[] b152 = new int[] {35,42,49};
        int[] b153 = new int[] {42,49,56};
        int[] b154 = new int[] {15,22,29};
        int[] b155 = new int[] {22,29,36};
        int[] b156 = new int[] {29,36,43};
        int[] b157 = new int[] {36,43,50};
        int[] b158 = new int[] {43,50,57};
        int[] b159 = new int[] {23,30,37};
        int[] b160 = new int[] {30,37,44};
        int[] b161 = new int[] {37,44,51};
        int[] b162 = new int[] {44,51,58};
        int[] b163 = new int[] {31,38,52};
        int[] b164 = new int[] {38,45,52};
        int[] b165 = new int[] {45,52,59};
        int[] b166 = new int[] {39,46,53};
        int[] b167 = new int[] {46,53,60};
        int[] b168 = new int[] {47,54,61};

        //holds sum of three board values
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

        var values = new int[][] {a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15,a16,a17,a18,
        a19,a20,a21,a22,a23,a24,a25,a26,a27,a28,a29,a30,a31,a32,a33,a34,a35,a36,a37,a38,a39,a40,a41,
        a42,a43,a44,a45,a46,a47,a48,a49,a50,a51,a52,a53,a54,a55,a56,a57,a58,a59,a60,a61,a62,a63,a64,
        a65,a66,a67,a68,a69,a70,a71,a72,a73,a74,a75,a76,a77,a78,a79,a80,a81,a82,a83,a84,a85,a86,a87,
        a88,a89,a90,a91,a92,a93,a94,a95,a96,a97,a98,a99,a100,a101,a102,a103,a104,a105,a106,a107,a108,
        a109,a110,a111,a112,a113,a114,a115,a116,a117,a118,a119,a120,a121,a122,a123,a124,a125,a126,a127,
        a128,a129,a130,a131,a132,a133,a134,a135,a136,a137,a138,a139,a140,a141,a142,a143,a144,a145,a146,
        a147,a148,a149,a150,a151,a152,a152,a153,a154,a155,a156,a157,a158,a159,a160,a161,a162,a163,a164,
        a165,a166,a167,a168};

        var boardNums = new int[][] {b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b11,b12,b13,b14,b15,b16,b17,b18,
        b19,b20,b21,b22,b23,b24,b25,b26,b27,b28,b29,b30,b31,b32,b33,b34,b35,b36,b37,b38,b39,b40,b41,
        b42,b43,b44,b45,b46,b47,b48,b49,b50,b51,b52,b53,b54,b55,b56,b57,b58,b59,b60,b61,b62,b63,b64,
        b65,b66,b67,b68,b69,b70,b71,b72,b73,b74,b75,b76,b77,b78,b79,b80,b81,b82,b83,b84,b85,b86,b87,
        b88,b89,b90,b91,b92,b93,b94,b95,b96,b97,b98,b99,b100,b101,b102,b103,b104,b105,b106,b107,b108,
        b109,b110,b111,b112,b113,b114,b115,b116,b117,b118,b119,b120,b121,b122,b123,b124,b125,b126,b127,
        b128,b129,b130,b131,b132,b133,b134,b135,b136,b137,b138,b139,b140,b141,b142,b143,b144,b145,b146,
        b147,b148,b149,b150,b151,b152,b152,b153,b154,b155,b156,b157,b158,b159,b160,b161,b162,b163,b164,
        b165,b166,b167,b168};

        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == (-98) || solutions[i] == (-96)) //if s# == 2 for x or 4 for o
            {
                //searches through values
                for(int j = 0; j < 3; j++)
                {
                    //searches for empty space in possible winning line
                    if(values[i][j] == (-100))
                    {
                        position = boardNums[i][j];
                        return true;
                    }
                }
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
        instructionText.text = "Game Over!";
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
