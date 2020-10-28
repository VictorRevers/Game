using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
  Animator anim;
  public GameObject thePlayer;
  // Start is called before the first frame update
  void Start () {
    anim = this.GetComponent<Animator> ();
  }

  // Update is called once per frame
  void Update () {
    PlayerMov PlayerMovscript = thePlayer.GetComponent<PlayerMov> ();

    if (PlayerMovscript.justJump == true) {
      anim.SetBool ("Jump", true);
    } else {
      anim.SetBool ("Jump", false);
    }
    if (Input.GetButtonDown (PlayerMovscript.rightButton)) {
      transform.rotation = Quaternion.Euler (0, 90, 0);
    }
    if (Input.GetButtonDown (PlayerMovscript.leftButton)) {
      transform.rotation = Quaternion.Euler (0, -90, 0);
    }
    if (Input.GetButtonDown (PlayerMovscript.upButton)) {
      transform.rotation = Quaternion.Euler (0, 0, 0);
    }
    if (Input.GetButtonDown (PlayerMovscript.downButton)) {
      transform.rotation = Quaternion.Euler (0, 180, 0);
    }
  }
}