using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    public int position;
    public  int num;
    public int chosenPlayer; // holds value for x or o depending on which one the user chose
    public int whoseTurn; //0 = x and 1 = o
    public int turnCount; //count nunber of turns played
    public GameObject[] turnIcons; //arrows which display whose turn it is
    public Sprite[] playerIcons; // 0 = x and 1 = o
    public Button[] ticTacToeSpaces; // playable/empty spaces
    public int[] markedSpaces; //identifies which space was marked by each player

    public Text winnerText; //holds winner text
    public GameObject[] winningLines; //holds different winning lines to show winner
    public GameObject winnerPanel;  //displays winner text and makes game board unplayable

    public int xPlayersScore;
    public int oPlayersScore;
    public Text xScoreText; //winner textbox text displays x score
    public Text oScoreText; //winner textbox text displays o score
    public Text instructionText; // displays instructions for user

    public Button xPlayersButton; //allows user to play as x
    public Button oPlayersButton; //allows user to play as o

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
        //enable grid buttons to be clicked
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
        //next two lines prevent player from changing character mid game
        xPlayersButton.interactable = false;
        oPlayersButton.interactable = false;
        instructionText.text = "3 in a row in any direction wins!";

        if(whoseTurn == chosenPlayer)
        {
            //places x or o in clicked button
            ticTacToeSpaces[whichNumber].image.sprite = playerIcons[whoseTurn];
            //button cannot change once clicked
            ticTacToeSpaces[whichNumber].interactable = false;
            //IDs which space is marked by chosenplayer x = 1 and o = 4;
            markedSpaces[whichNumber] = whoseTurn+1;
            turnCount++;
        }

        if(turnCount > 4) //checks if there's a win before AI plays turn
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

        if(turnCount > 1)
        {
            bool possibleWin = canWin();
            if(possibleWin == true)
            {
                num = position;
            }
            else
            {
                //instructionText.text = "false";
                num = Random.Range(0,24);
            }
        }
        bool marked = false;
        while(marked == false)
        {
            if(markedSpaces[num] == (-100))
            {
                ticTacToeSpaces[num].image.sprite = playerIcons[whoseTurn];
                ticTacToeSpaces[num].interactable = false;
                marked = true;  
            }   
            else
            {
                num = Random.Range(0,24);
            }
        }
        //IDs which space is marked by AI x = 1 and o = 2;
        markedSpaces[num] = whoseTurn+1;
        turnCount++;

        if(turnCount > 4) //checks if there's a win before user plays
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

    bool winnerCheck() //3 in a row will win
    {
        //horizontal wins
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[1] + markedSpaces[2] + markedSpaces[3];
        int s3 = markedSpaces[2] + markedSpaces[3] + markedSpaces[4];
        int s4 = markedSpaces[5] + markedSpaces[6] + markedSpaces[7];
        int s5 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s6 = markedSpaces[7] + markedSpaces[8] + markedSpaces[9];
        int s7 = markedSpaces[10] + markedSpaces[11] + markedSpaces[12];
        int s8 = markedSpaces[11] + markedSpaces[12] + markedSpaces[13];
        int s9 = markedSpaces[12] + markedSpaces[13] + markedSpaces[14];
        int s10 = markedSpaces[15] + markedSpaces[16] + markedSpaces[17];
        int s11 = markedSpaces[16] + markedSpaces[17] + markedSpaces[18];
        int s12 = markedSpaces[17] + markedSpaces[18] + markedSpaces[19];
        int s13 = markedSpaces[20] + markedSpaces[21] + markedSpaces[22];
        int s14 = markedSpaces[21] + markedSpaces[22] + markedSpaces[23];
        int s15 = markedSpaces[22] + markedSpaces[23] + markedSpaces[24];

        //vertical wins
        int s16 = markedSpaces[0] + markedSpaces[5] + markedSpaces[10];
        int s17 = markedSpaces[5] + markedSpaces[10] + markedSpaces[15];
        int s18 = markedSpaces[10] + markedSpaces[15] + markedSpaces[20];
        int s19 = markedSpaces[1] + markedSpaces[6] + markedSpaces[11];
        int s20 = markedSpaces[6] + markedSpaces[11] + markedSpaces[16];
        int s21 = markedSpaces[11] + markedSpaces[16] + markedSpaces[21];
        int s22 = markedSpaces[2] + markedSpaces[7] + markedSpaces[12];
        int s23 = markedSpaces[7] + markedSpaces[12] + markedSpaces[17];
        int s24 = markedSpaces[12] + markedSpaces[17] + markedSpaces[22];
        int s25 = markedSpaces[3] + markedSpaces[8] + markedSpaces[13];
        int s26 = markedSpaces[8] + markedSpaces[13] + markedSpaces[18];
        int s27 = markedSpaces[13] + markedSpaces[18] + markedSpaces[23];
        int s28 = markedSpaces[4] + markedSpaces[9] + markedSpaces[14];
        int s29 = markedSpaces[9] + markedSpaces[14] + markedSpaces[19];
        int s30 = markedSpaces[14] + markedSpaces[19] + markedSpaces[24];

        //diagonal wins
        int s31 = markedSpaces[0] + markedSpaces[6] + markedSpaces[12];
        int s32 = markedSpaces[6] + markedSpaces[12] + markedSpaces[18];
        int s33 = markedSpaces[12] + markedSpaces[18] + markedSpaces[24];
        int s34 = markedSpaces[4] + markedSpaces[8] + markedSpaces[12];
        int s35 = markedSpaces[8] + markedSpaces[12] + markedSpaces[16];
        int s36 = markedSpaces[12] + markedSpaces[16] + markedSpaces[20];
        int s37 = markedSpaces[5] + markedSpaces[11] + markedSpaces[17];
        int s38 = markedSpaces[11] + markedSpaces[17] + markedSpaces[23];
        int s39 = markedSpaces[10] + markedSpaces[16] + markedSpaces[22];
        int s40 = markedSpaces[3] + markedSpaces[7] + markedSpaces[11];
        int s41 = markedSpaces[7] + markedSpaces[11] + markedSpaces[15];
        int s42 = markedSpaces[2] + markedSpaces[6] + markedSpaces[10];
        int s43 = markedSpaces[1] + markedSpaces[7] + markedSpaces[13];
        int s44 = markedSpaces[7] + markedSpaces[13] + markedSpaces[19];
        int s45 = markedSpaces[2] + markedSpaces[8] + markedSpaces[14];
        int s46 = markedSpaces[9] + markedSpaces[13] + markedSpaces[17];
        int s47 = markedSpaces[13] + markedSpaces[17] + markedSpaces[21];
        int s48 = markedSpaces[14] + markedSpaces[18] + markedSpaces[22];

        var solutions = new int[] {s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,
        s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,
        s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,
        s44,s45,s46,s47,s48};

        //traverse through solutions[] to check if any 3 in a row are all x or o
        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 3 * (whoseTurn+1)) //solution[i] = 3 or 6
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
        int[] a4 = new int[] {markedSpaces[5], markedSpaces[6], markedSpaces[7]};
        int[] a5 = new int[] {markedSpaces[6], markedSpaces[7], markedSpaces[8]};
        int[] a6 = new int[] {markedSpaces[7], markedSpaces[8], markedSpaces[9]};
        int[] a7 = new int[] {markedSpaces[10], markedSpaces[11], markedSpaces[12]};
        int[] a8 = new int[] {markedSpaces[11], markedSpaces[12], markedSpaces[13]};
        int[] a9 = new int[] {markedSpaces[12], markedSpaces[13], markedSpaces[14]};
        int[] a10 = new int[] {markedSpaces[15], markedSpaces[16], markedSpaces[17]};
        int[] a11 = new int[] {markedSpaces[16], markedSpaces[17], markedSpaces[18]};
        int[] a12 = new int[] {markedSpaces[17], markedSpaces[18], markedSpaces[19]};
        int[] a13 = new int[] {markedSpaces[20], markedSpaces[21], markedSpaces[22]};
        int[] a14 = new int[] {markedSpaces[21], markedSpaces[22], markedSpaces[23]};
        int[] a15 = new int[] {markedSpaces[22], markedSpaces[23], markedSpaces[24]};
        int[] a16 = new int[] {markedSpaces[0],markedSpaces[5], markedSpaces[10]};
        int[] a17 = new int[] {markedSpaces[5], markedSpaces[10], markedSpaces[15]};
        int[] a18 = new int[] {markedSpaces[10], markedSpaces[15], markedSpaces[20]};
        int[] a19 = new int[] {markedSpaces[1], markedSpaces[6], markedSpaces[11]};
        int[] a20 = new int[] {markedSpaces[6], markedSpaces[11], markedSpaces[16]};
        int[] a21 = new int[] {markedSpaces[11], markedSpaces[16], markedSpaces[21]};
        int[] a22 = new int[] {markedSpaces[2], markedSpaces[7], markedSpaces[12]};
        int[] a23 = new int[] {markedSpaces[7], markedSpaces[12], markedSpaces[17]};
        int[] a24 = new int[] {markedSpaces[12], markedSpaces[17], markedSpaces[22]};
        int[] a25 = new int[] {markedSpaces[3], markedSpaces[8], markedSpaces[13]};
        int[] a26 = new int[] {markedSpaces[8], markedSpaces[13], markedSpaces[18]};
        int[] a27 = new int[] {markedSpaces[13], markedSpaces[18], markedSpaces[23]};
        int[] a28 = new int[] {markedSpaces[4], markedSpaces[9], markedSpaces[14]};
        int[] a29 = new int[] {markedSpaces[9], markedSpaces[14], markedSpaces[19]};
        int[] a30 = new int[] {markedSpaces[14], markedSpaces[19], markedSpaces[24]};
        int[] a31 = new int[] {markedSpaces[0], markedSpaces[6], markedSpaces[12]};
        int[] a32 = new int[] {markedSpaces[6], markedSpaces[12], markedSpaces[18]};
        int[] a33 = new int[] {markedSpaces[12], markedSpaces[18], markedSpaces[24]};
        int[] a34 = new int[] {markedSpaces[4], markedSpaces[8], markedSpaces[12]};
        int[] a35 = new int[] {markedSpaces[8], markedSpaces[12], markedSpaces[16]};
        int[] a36 = new int[] {markedSpaces[12], markedSpaces[16], markedSpaces[20]};
        int[] a37 = new int[] {markedSpaces[5], markedSpaces[11], markedSpaces[17]};
        int[] a38 = new int[] {markedSpaces[11], markedSpaces[17], markedSpaces[23]};
        int[] a39 = new int[] {markedSpaces[10], markedSpaces[16], markedSpaces[22]};
        int[] a40 = new int[] {markedSpaces[3], markedSpaces[7], markedSpaces[11]};
        int[] a41 = new int[] {markedSpaces[7], markedSpaces[11], markedSpaces[15]};
        int[] a42 = new int[] {markedSpaces[2], markedSpaces[6], markedSpaces[10]};
        int[] a43 = new int[] {markedSpaces[1],markedSpaces[7], markedSpaces[13]};
        int[] a44 = new int[] {markedSpaces[7], markedSpaces[13], markedSpaces[19]};
        int[] a45 = new int[] {markedSpaces[2], markedSpaces[8], markedSpaces[14]};
        int[] a46 = new int[] {markedSpaces[9], markedSpaces[13], markedSpaces[17]};
        int[] a47 = new int[] {markedSpaces[13], markedSpaces[17], markedSpaces[21]};
        int[] a48 = new int[] {markedSpaces[14], markedSpaces[18], markedSpaces[22]};
       
        //holds board button numbers
        int[] b1 = new int[] {0,1,2};
        int[] b2 = new int[] {1,2,3};
        int[] b3 = new int[] {2,3,4};
        int[] b4 = new int[] {5,6,7};
        int[] b5 = new int[] {6,7,8};
        int[] b6 = new int[] {7,8,9};
        int[] b7 = new int[] {10,11,12};
        int[] b8 = new int[] {11,12,13};
        int[] b9 = new int[] {12,13,14};
        int[] b10 = new int[] {15,16,17};
        int[] b11 = new int[] {16,17,18};
        int[] b12 = new int[] {17,18,19};
        int[] b13 = new int[] {20,21,22};
        int[] b14 = new int[] {21,22,23};
        int[] b15 = new int[] {22,23,24};
        int[] b16 = new int[] {0,5,10};
        int[] b17 = new int[] {5,10,15};
        int[] b18 = new int[] {10,15,20};
        int[] b19 = new int[] {1,6,11};
        int[] b20 = new int[] {6,11,16};
        int[] b21 = new int[] {11,16,21};
        int[] b22 = new int[] {2,7,12};
        int[] b23 = new int[] {7,12,17};
        int[] b24 = new int[] {12,17,22};
        int[] b25 = new int[] {3,8,13};
        int[] b26 = new int[] {8,13,18};
        int[] b27 = new int[] {13,18,23};
        int[] b28 = new int[] {4,9,14};
        int[] b29 = new int[] {9,14,19};
        int[] b30 = new int[] {14,19,24};
        int[] b31 = new int[] {0,6,12};
        int[] b32 = new int[] {6,12,18};
        int[] b33 = new int[] {12,18,24};
        int[] b34 = new int[] {4,8,12};
        int[] b35 = new int[] {8,12,16};
        int[] b36 = new int[] {12,16,20};
        int[] b37 = new int[] {5,11,17};
        int[] b38 = new int[] {11,17,23};
        int[] b39 = new int[] {10,16,22};
        int[] b40 = new int[] {3,7,11};
        int[] b41 = new int[] {7,11,15};
        int[] b42 = new int[] {2,6,10};
        int[] b43 = new int[] {1,7,13};
        int[] b44 = new int[] {7,13,19};
        int[] b45 = new int[] {2,8,14};
        int[] b46 = new int[] {9,13,17};
        int[] b47 = new int[] {13,17,21};
        int[] b48 = new int[] {14,18,22};

        //holds sum of three board values
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[1] + markedSpaces[2] + markedSpaces[3];
        int s3 = markedSpaces[2] + markedSpaces[3] + markedSpaces[4];
        int s4 = markedSpaces[5] + markedSpaces[6] + markedSpaces[7];
        int s5 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s6 = markedSpaces[7] + markedSpaces[8] + markedSpaces[9];
        int s7 = markedSpaces[10] + markedSpaces[11] + markedSpaces[12];
        int s8 = markedSpaces[11] + markedSpaces[12] + markedSpaces[13];
        int s9 = markedSpaces[12] + markedSpaces[13] + markedSpaces[14];
        int s10 = markedSpaces[15] + markedSpaces[16] + markedSpaces[17];
        int s11 = markedSpaces[16] + markedSpaces[17] + markedSpaces[18];
        int s12 = markedSpaces[17] + markedSpaces[18] + markedSpaces[19];
        int s13 = markedSpaces[20] + markedSpaces[21] + markedSpaces[22];
        int s14 = markedSpaces[21] + markedSpaces[22] + markedSpaces[23];
        int s15 = markedSpaces[22] + markedSpaces[23] + markedSpaces[24];
        int s16 = markedSpaces[0] + markedSpaces[5] + markedSpaces[10];
        int s17 = markedSpaces[5] + markedSpaces[10] + markedSpaces[15];
        int s18 = markedSpaces[10] + markedSpaces[15] + markedSpaces[20];
        int s19 = markedSpaces[1] + markedSpaces[6] + markedSpaces[11];
        int s20 = markedSpaces[6] + markedSpaces[11] + markedSpaces[16];
        int s21 = markedSpaces[11] + markedSpaces[16] + markedSpaces[21];
        int s22 = markedSpaces[2] + markedSpaces[7] + markedSpaces[12];
        int s23 = markedSpaces[7] + markedSpaces[12] + markedSpaces[17];
        int s24 = markedSpaces[12] + markedSpaces[17] + markedSpaces[22];
        int s25 = markedSpaces[3] + markedSpaces[8] + markedSpaces[13];
        int s26 = markedSpaces[8] + markedSpaces[13] + markedSpaces[18];
        int s27 = markedSpaces[13] + markedSpaces[18] + markedSpaces[23];
        int s28 = markedSpaces[4] + markedSpaces[9] + markedSpaces[14];
        int s29 = markedSpaces[9] + markedSpaces[14] + markedSpaces[19];
        int s30 = markedSpaces[14] + markedSpaces[19] + markedSpaces[24];
        int s31 = markedSpaces[0] + markedSpaces[6] + markedSpaces[12];
        int s32 = markedSpaces[6] + markedSpaces[12] + markedSpaces[18];
        int s33 = markedSpaces[12] + markedSpaces[18] + markedSpaces[24];
        int s34 = markedSpaces[4] + markedSpaces[8] + markedSpaces[12];
        int s35 = markedSpaces[8] + markedSpaces[12] + markedSpaces[16];
        int s36 = markedSpaces[12] + markedSpaces[16] + markedSpaces[20];
        int s37 = markedSpaces[5] + markedSpaces[11] + markedSpaces[17];
        int s38 = markedSpaces[11] + markedSpaces[17] + markedSpaces[23];
        int s39 = markedSpaces[10] + markedSpaces[16] + markedSpaces[22];
        int s40 = markedSpaces[3] + markedSpaces[7] + markedSpaces[11];
        int s41 = markedSpaces[7] + markedSpaces[11] + markedSpaces[15];
        int s42 = markedSpaces[2] + markedSpaces[6] + markedSpaces[10];
        int s43 = markedSpaces[1] + markedSpaces[7] + markedSpaces[13];
        int s44 = markedSpaces[7] + markedSpaces[13] + markedSpaces[19];
        int s45 = markedSpaces[2] + markedSpaces[8] + markedSpaces[14];
        int s46 = markedSpaces[9] + markedSpaces[13] + markedSpaces[17];
        int s47 = markedSpaces[13] + markedSpaces[17] + markedSpaces[21];
        int s48 = markedSpaces[14] + markedSpaces[18] + markedSpaces[22];

        var solutions = new int[] {s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,
            s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,
            s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48};
        var values = new int[][] {a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14,
            a15,a16,a17,a18,a19,a20,a21,a22,a23,a24,a25,a26,a27,a28,a29,a30,a31,
            a32,a33,a34,a35,a36,a37,a38,a39,a40,a41,a42,a43,a44,a45,a46,a47,a48};
        var boardNums = new int[][] {b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b11,b12,b13,b14,
            b15,b16,b17,b18,b19,b20,b21,b22,b23,b24,b25,b26,b27,b28,b29,b30,b31,
            b32,b33,b34,b35,b36,b37,b38,b39,b40,b41,b42,b43,b44,b45,b46,b47,b48};

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
        //activates winnerPanel which contains winner message textbox
        winnerPanel.gameObject.SetActive(true);
        if(whoseTurn == 0)
        {
            xPlayersScore++; //updates score on game screen
            xScoreText.text = xPlayersScore.ToString();
            winnerText.text = "Player X wins!!!";
        }
        else if(whoseTurn == 1)
        {
            oPlayersScore++; //updates score on game screen
            oScoreText.text = oPlayersScore.ToString();
            winnerText.text = "Player O wins!!!";
        }
        winningLines[indexIn].SetActive(true); //activates winningLine over 3 in a row
    }

    void draw()
    {
        //activates winnerPanel which contains winner message textbox
        winnerPanel.SetActive(true);
        instructionText.text = "Game Over!";
        winnerText.text = "It's a DRAW!";
    }

    //allows user to choose their player - x or o
    public void switchPlayer(int whichPlayer)
    {
        if(whichPlayer == 0)
        {
            whoseTurn = 0;
            chosenPlayer = whoseTurn; //chosenPlayer = user and not AI
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

    //resets game board but keeps score
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

    //resets game board and scores
    public void restart()
    {
        rematch();
        xPlayersScore = 0;
        oPlayersScore = 0;
        xScoreText.text = "0";
        oScoreText.text = "0";
    }

    //allows transition from home screen to mode screen
    public void goToModeScreen()
    {
        homeScreen.gameObject.SetActive(false);
        modeScreen.gameObject.SetActive(true);
    }

    //allows transition frmo mode screen to medium game board
    public void playMediumMode()
    {
        modeScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        gameSetUp();
    }

    //allows transition from medium game board to mode screen
    public void returnToMode()
    {
        gameScreen.gameObject.SetActive(false);
        modeScreen.gameObject.SetActive(true);
    }
}