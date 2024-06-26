using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Game Objects
    public GameObject playerOne;
    public GameObject playerTwo;
    private Collider2D p1Collider;
    private Collider2D p2Collider;
    private Rigidbody2D p1RigidBody;
    private Rigidbody2D p2RigidBody;
    private Collider2D floorCollider;
    private Collider2D roofCollider;
    private Collider2D rightWallCollider;
    private Collider2D leftWallCollider;
    private Collider2D challengeCollider1;
    private Collider2D challengeCollider2;
    private Collider2D challengeCollider3;
    #endregion

    #region Variables
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    public float maxDistance;
    private bool p1OnFloor;
    private bool p2OnFloor;
    public bool p1OnWall;
    public bool p2OnWall;
    #endregion

    private void Start()
    {
        p1RigidBody = playerOne.GetComponent<Rigidbody2D>();
        p2RigidBody = playerTwo.GetComponent<Rigidbody2D>();

        p1Collider = playerOne.GetComponent<Collider2D>();
        p2Collider = playerTwo.GetComponent<Collider2D>();

        floorCollider = GameObject.Find("Floor").GetComponent<Collider2D>();
        rightWallCollider = GameObject.Find("Right Wall").GetComponent<Collider2D>();
        leftWallCollider = GameObject.Find("Left Wall").GetComponent<Collider2D>();
        challengeCollider1 = GameObject.Find("Challenge Wall1").GetComponent<Collider2D>();
        challengeCollider2 = GameObject.Find("Challenge Wall2").GetComponent<Collider2D>();
        challengeCollider3 = GameObject.Find("Challenge Wall3").GetComponent<Collider2D>();
        roofCollider = GameObject.Find("Roof").GetComponent<Collider2D>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerChekcs();
        PlayerJumps();
        PlayerBoundaries();
        PlayerGrabbing();
    }

    private void FixedUpdate()
    {
        var distance1 = Vector2.Distance(playerOne.transform.position, playerTwo.transform.position);
        if (distance1 < maxDistance)
        {
            playerOne.GetComponent<SpringJoint2D>().enabled = false;
        }
        else if (distance1 > maxDistance)
        {
            playerOne.GetComponent<SpringJoint2D>().enabled = true;
        }
    }

    private void PlayerMovement()
    {
        //P1 Move
        if (Input.GetKey(KeyCode.D))
        {
            if (p1OnFloor == true)
            {
                playerOne.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                playerOne.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed, ForceMode2D.Force);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (p1OnFloor == true)
            {            
                playerOne.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                playerOne.GetComponent<Rigidbody2D>().AddForce(Vector3.left * speed, ForceMode2D.Force);
            }
        }

        //P2 Move
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            if (p2OnFloor == true)
            {
                playerTwo.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                playerTwo.GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed, ForceMode2D.Force);
            }
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            if (p2OnFloor == true)
            {
                playerTwo.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                playerTwo.GetComponent<Rigidbody2D>().AddForce(Vector3.left * speed, ForceMode2D.Force);
            }            
        }
    }

    private void PlayerChekcs()
    {
        //Player 1
        if (p1Collider.IsTouching(floorCollider))
        {
            p1OnFloor = true;
        }
        else if (p1Collider.IsTouching(p2Collider) || p1Collider.IsTouching(rightWallCollider) || p1Collider.IsTouching(leftWallCollider) || p1Collider.IsTouching(challengeCollider1) || p1Collider.IsTouching(challengeCollider2) || p1Collider.IsTouching(challengeCollider3))
        {
            p1OnFloor = true;
        }
        else
        {
            p1OnFloor = false;
        }

        if (p1Collider.IsTouching(rightWallCollider) || p1Collider.IsTouching(leftWallCollider) || p1Collider.IsTouching(challengeCollider1) || p1Collider.IsTouching(challengeCollider2) || p1Collider.IsTouching(challengeCollider3) || p1Collider.IsTouching(roofCollider))
        {
            p1OnWall = true;
        }
        else
        {
            p1OnWall = false;
        }

        //Player 2
        if (p2Collider.IsTouching(floorCollider))
        {
            p2OnFloor = true;
        }
        else if (p2Collider.IsTouching(p1Collider) || p2Collider.IsTouching(rightWallCollider) || p2Collider.IsTouching(leftWallCollider) || p2Collider.IsTouching(challengeCollider1) || p2Collider.IsTouching(challengeCollider2) || p2Collider.IsTouching(challengeCollider3))
        {
            p2OnFloor = true;
        }
        else
        {
            p2OnFloor = false;
        }

        if (p2Collider.IsTouching(rightWallCollider) || p2Collider.IsTouching(leftWallCollider) || p2Collider.IsTouching(challengeCollider1) || p2Collider.IsTouching(challengeCollider2) || p2Collider.IsTouching(challengeCollider3) || p2Collider.IsTouching(roofCollider))
        {
            p2OnWall = true;
        }
        else
        {
            p2OnWall = false;
        }
    }

    private void PlayerJumps()
    {
        //P1 Jump
        if (Input.GetKeyDown(KeyCode.W) && p1OnFloor)
        {
            p1RigidBody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        //P2 Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && p2OnFloor)
        {
            p2RigidBody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void PlayerBoundaries()
    {
        //P1 Constraints
        if (playerOne.transform.position.x > 7.985f)
        {
            playerOne.transform.position = new Vector2(7.985f, playerOne.transform.position.y);
        }
        else if (playerOne.transform.position.x < -7.985f)
        {
            playerOne.transform.position = new Vector2(-7.985f, playerOne.transform.position.y);
        }

        //P2 Constraints
        if (playerTwo.transform.position.x > 7.985f)
        {
            playerTwo.transform.position = new Vector2(7.985f, playerTwo.transform.position.y);
        }
        else if (playerTwo.transform.position.x < -7.985f)
        {
            playerTwo.transform.position = new Vector2(-7.985f, playerTwo.transform.position.y);
        }
    }

    private void PlayerGrabbing()
    {
        //P1 Grabbing
        if (Input.GetKey(KeyCode.Q) && p1OnWall)
        {
            playerOne.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            playerOne.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

        //P2 Grabbing
        if (Input.GetKey(KeyCode.PageUp) && p2OnWall)
        {
            playerTwo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            playerTwo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
}
