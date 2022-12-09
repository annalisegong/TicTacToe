using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
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
        int num = Random.Range(0,24);
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
                num = Random.Range(0,24);
            }
        }
        //IDs which space is marked by AI x = 1 and o = 2;
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
        int s41 = markedSpaces[7] + markedSpaces[11] + markedSpaces[20];
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