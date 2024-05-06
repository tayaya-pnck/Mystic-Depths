using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rbody;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float JumpHeight = 3f;
    private bool _onTheGround = false;
    private float _horizontalmovement;
    public float HorizontalMovement{
        private set{
            _horizontalmovement = value;
        }
        get { return _horizontalmovement; }
    }


    private void Awake() {
        _rbody = GetComponent<Rigidbody2D> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
       HorizontalMovement =  Input.GetAxis("Horizontal");
       jump();
       
    }

    private void FixedUpdate(){
        move();

    }

    private void move(){
        _rbody.velocity = new Vector2( movementSpeed * HorizontalMovement, _rbody.velocity.y);
    }

    private void jump(){
        if (_onTheGround && Input.GetButtonDown("Jump"))
        {
         _rbody.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }
    }
    private void GroundCheck(){
        RaycastHit2D [] hits = new RaycastHit2D[5];
        int numhits = _rbody.Cast(Vector2.down, hits, 0.5f);
        _onTheGround = numhits > 0 ;

    }



}
