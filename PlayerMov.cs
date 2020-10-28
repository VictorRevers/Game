using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour {
    float lerpTime;
    float currentLerpTime;
    float perc = 1;
    Vector3 startPos;
    public Vector3 endPos;
    bool firstInput;
    public bool justJump;

    public string rightButton;
    public string leftButton;
    public string upButton;
    public string downButton;

    //Meio do personagem para disparar o raio de deteccao de colisao
    public Vector3 centerChar;
    //Comprimento de deteccao de colisao
    public float hitDetectionLength;
    //A layer dos jogadores, para detectar apenas jogadores
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start () {
        endPos = transform.position;
    }

    // Update is called once per frame
    void Update () {
        if ((Input.GetButtonDown (upButton)) ||
            (Input.GetButtonDown (downButton)) ||
            (Input.GetButtonDown (leftButton)) ||
            (Input.GetButtonDown (rightButton))) {
            if (perc == 1) {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
            }
        }

        startPos = transform.position;

        Vector3 collisionDirection = new Vector3 ();
        Vector3 direction = new Vector3 ();
        if (Input.GetButtonDown (rightButton) && transform.position == endPos) {
            endPos = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);
            //Salvar a direcaao que o jogador esta indo
            direction = Vector3.right;
            //Salva o vetor direcao
            collisionDirection = transform.TransformDirection (Vector3.right) * hitDetectionLength;
        }
        if (Input.GetButtonDown (leftButton) && transform.position == endPos) {
            endPos = new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z);
            direction = Vector3.left;
            collisionDirection = transform.TransformDirection (Vector3.left) * hitDetectionLength;
        }
        if (Input.GetButtonDown (upButton) && transform.position == endPos) {
            endPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1);
            direction = Vector3.forward;
            collisionDirection = transform.TransformDirection (Vector3.forward) * hitDetectionLength;
        }
        if (Input.GetButtonDown (downButton) && transform.position == endPos) {
            endPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1);
            direction = Vector3.back;
            collisionDirection = transform.TransformDirection (Vector3.back) * hitDetectionLength;
        }

        RaycastHit hit;
        //Verificacao de raio de colisao na direcao que o jogador esta indo        
        if (Physics.Raycast (transform.position + centerChar, collisionDirection, out hit, hitDetectionLength)) {
            PlayerMov otherPlayer = hit.collider.gameObject.GetComponent<PlayerMov> ();
            if (otherPlayer != null) {
                //Caso o raio tenha atingido outro jogador, empurramos ele
                otherPlayer.Move (direction);
            }
        }

        if (firstInput == true) {

            currentLerpTime += Time.fixedDeltaTime * 5;
            perc = currentLerpTime / lerpTime;
            var newPosition = Vector3.Lerp (startPos, endPos, perc);

            transform.position = newPosition;

            if (perc > 0.8) {
                perc = 1;
            }
            if (Mathf.Round (perc) == 1) {
                justJump = false;
            }
        }

    }

    //Metodo para mover o jogador de fora da classe
    public void Move (Vector3 newPosition) {
        endPos = new Vector3 (transform.position.x + newPosition.x, transform.position.y, transform.position.z + newPosition.z);
        firstInput = true;
    }
}