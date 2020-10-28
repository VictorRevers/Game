using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public Scene scene;
    public string restartKey = "";
    public static GameController _instance;

    public bool gameOver = false;
    public bool sm1Wins = false;

    public VectorMovement player1;
    public VectorMovement player2;

    public Text winnerPlayerText;
    public GameObject winnerPlayerGOText;
    public Text pressRText; 
    //public string VectorMovement leftKey;
    //public string VectorMovement rightKey;
    //public string VectorMovement upKey;
    //public string VectorMovement downKey;

    private void Awake () {
        if (_instance == null) {
            _instance = this;
        } else if (_instance != this) {
            Destroy (gameObject);
        }
    }

    // Start is called before the first frame update

    void Start () {
        scene = SceneManager.GetActiveScene ();
    }

    // Update is called once per frame
    void Update () {
        if (sm1Wins && Input.GetKeyDown (restartKey)) {
            Debug.Log ("restart");
            SceneManager.LoadScene (scene.name);
        }
        // if (gameOver == true) 
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }

    }

    //public void ChickenDied(VectorMovement playerDied){
    //if(gameOver == true)
    //return;

    // string textDied = " died ";
    // if(playerDied.playerName == player1.playerName){
    // textDied += player1.playerName;
    //}else{
    // textDied += player2.playerName;
    //}
    //
    //winnerPlayerGOText.SetActive(true);
    // gameOver = true;
    //}
    public void ChickenWin (VectorMovement playerWin) {

        sm1Wins = true;
        string textWin = "Parabéns a galinha ";
        string textRestart = " aperte R para reiniciar";
        if (playerWin.playerName == player1.playerName) {
            textWin += player1.playerName + textRestart;
        } else {
            textWin += player2.playerName + textRestart;
        }
        winnerPlayerText.text = textWin;
        winnerPlayerGOText.SetActive (true);
        pressRText.text = textRestart;
    }

}