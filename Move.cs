using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private Rigidbody2D rgb;
    public float speed = 5.0f;
    public float speedJump = 6.5f;
    private bool isJump;
    private bool isFacingRight = true;
    private float moveImput;
    void Start() {
        rgb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update() {
        moveImput = Input.GetAxis("Horizontal");
        Vector3 tempvector = Vector3.right * moveImput;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Backspace) && isJump) 
            rgb.AddForce(transform.up * speedJump, ForceMode2D.Impulse);
        

        if (isFacingRight == false && moveImput > 0)
            UnfoldSprite();
        else if(isFacingRight == true && moveImput < 0)
            UnfoldSprite();
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Ground")
            isJump = true;
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Ground")
            isJump = false;
    }

    void UnfoldSprite() {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.GetChild(0).transform.localScale;
        scale.x *= -1;
        transform.GetChild(0).transform.localScale = scale;
    }

    private void FixedUpdate() {
        //print(Time.deltaTime);
    }
}
