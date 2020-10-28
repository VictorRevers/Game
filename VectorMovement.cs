using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VectorMovement : MonoBehaviour
{
    
    public static VectorMovement _instance; 
    public string playerName;
    public float speed = 12f;

    private Vector3 endPosition;
    private Vector3 startGamePosition;

    public Rigidbody rb;
    // public BoxCollider boxCollider;

    public string leftKey = "";
    public string rightKey = "";
    public string upKey = "";
    public string downKey = "";
  
    public Animator animator;
    public bool isDead = false;

    
    // Start is called before the first frame update
    void Start()
    {
        startGamePosition = this.transform.position;
        endPosition = this.transform.position;
        // boxCollider = this.GetComponent<BoxCollider>();
        rb = this.GetComponent<Rigidbody>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
      
        if (isDead && ((Input.GetKeyDown(rightKey))||(Input.GetKeyDown(leftKey)) ||(Input.GetKeyDown(upKey)) || (Input.GetKeyDown(downKey)))){
            Respawn();
        }

        if(isDead) return;
        
        if (Input.GetKeyDown(rightKey) && transform.position == endPosition)
        {
            endPosition += Vector3.right;
            
        }
        else if (Input.GetKeyDown(leftKey) && transform.position == endPosition)
        {
            endPosition += Vector3.left;
            
        }
        else if (Input.GetKeyDown(upKey) && transform.position == endPosition)
        {
            endPosition += Vector3.forward;
            
        }
        else if (Input.GetKeyDown(downKey) && transform.position == endPosition)
        {
            endPosition += Vector3.back;
            

  
        }
        RaycastHit hit;
      
        bool hasHitSomething = this.Move(endPosition, out hit);
        
        if(!hasHitSomething && transform.position != endPosition){
            animator.SetTrigger("Jump");
        }

        if (hit.transform != null)
        {
            VectorMovement otherPlayer = hit.collider.GetComponent<VectorMovement>();
            if (otherPlayer != null)
            {
                Vector3 dir = hit.point - transform.position; //Direção em que nós movemos
                Vector3 newPosition = hit.transform.position += dir.normalized; //Posicao que o outro jogador deve mover
                otherPlayer.Move(newPosition, out hit);
            }
        }


    }

    protected bool Move(Vector3 position, out RaycastHit hit)
    {
        endPosition = position;

        Vector3 newPosition = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);

        bool hasHitSomething = false;
        hasHitSomething = Physics.Linecast(transform.position, position, out hit);
        
        if(hasHitSomething){
            Debug.Log(hasHitSomething);
            Debug.Log(hit.transform.gameObject);
            //verificar se é algo que bloqueia o movimento
             if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
                this.endPosition = transform.position; //Reset end position to try again
                return true;
             }
        }

        rb.MovePosition(newPosition);

        return hasHitSomething ;
    }


     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Killer")){
            Debug.Log(other.name + "MATOU A GALINHA");
            animator.SetBool("Dead", true);
            isDead = true;
            // GameController._instance.ChickenDied(this);
        }
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Final")){
       GameController._instance.ChickenWin(this);
     
     }
    

     }
     
    

    void Respawn(){
        isDead = false;
        animator.SetBool("Dead", false);
        endPosition = startGamePosition;
        transform.position = endPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(endPosition, 0.5f);
        Gizmos.DrawLine(transform.position, endPosition);

    }
}
