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
    private Collider2D rightWallCollider;
    private Collider2D leftWallCollider;
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
        if (distance1 < 2)
        {
            playerOne.GetComponent<SpringJoint2D>().enabled = false;
        }
        else if (distance1 > 2)
        {
            playerOne.GetComponent<SpringJoint2D>().enabled = true;
        }
    }

    private void PlayerMovement()
    {
        //P1 Move
        if (Input.GetKey(KeyCode.D)) // && playerOne.transform.position.x < playerTwo.transform.position.x + maxDistance)
        {
            playerOne.transform.position += Vector3.right * speed * Time.deltaTime;

            //var distance1 = Vector2.Distance(playerOne.transform.position, playerTwo.transform.position);
            //if (distance1 > maxDistance)
            //{
            //    playerOne.transform.position = (playerOne.transform.position - playerTwo.transform.position).normalized * maxDistance + playerTwo.transform.position;
            //}
        }
        else if (Input.GetKey(KeyCode.A)) // && playerOne.transform.position.x > playerTwo.transform.position.x - maxDistance)
        {
            playerOne.transform.position += Vector3.left * speed * Time.deltaTime;

            //var distance1 = Vector2.Distance(playerOne.transform.position, playerTwo.transform.position);
            //if (distance1 > maxDistance)
            //{
            //    playerOne.transform.position = (playerOne.transform.position - playerTwo.transform.position).normalized * maxDistance + playerTwo.transform.position;
            //}
        }

        //P2 Move
        if (Input.GetKey(KeyCode.RightArrow)) // && playerTwo.transform.position.x < playerOne.transform.position.x + maxDistance)
        {
            playerTwo.transform.position += Vector3.right * speed * Time.deltaTime;

            //var distance2 = Vector2.Distance(playerTwo.transform.position, playerOne.transform.position);
            //if (distance2 > maxDistance)
            //{
            //    playerTwo.transform.position = (playerTwo.transform.position - playerOne.transform.position).normalized * maxDistance + playerOne.transform.position;
            //}
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) // && playerTwo.transform.position.x > playerOne.transform.position.x - maxDistance)
        {
            playerTwo.transform.position += Vector3.left * speed * Time.deltaTime;

            //var distance2 = Vector2.Distance(playerTwo.transform.position, playerOne.transform.position);
            //if (distance2 > maxDistance)
            //{
            //    playerTwo.transform.position = (playerTwo.transform.position - playerOne.transform.position).normalized * maxDistance + playerOne.transform.position;
            //}
        }
    }

    private void PlayerChekcs()
    {
        //Player 1
        if (p1Collider.IsTouching(floorCollider))
        {
            p1OnFloor = true;
        }
        else if (p1Collider.IsTouching(p2Collider))
        {
            p1OnFloor = true;
        }
        else
        {
            p1OnFloor = false;
        }

        if (p1Collider.IsTouching(rightWallCollider) || p1Collider.IsTouching(leftWallCollider))
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
        else if (p2Collider.IsTouching(p1Collider))
        {
            p2OnFloor = true;
        }
        else
        {
            p2OnFloor = false;
        }

        if (p2Collider.IsTouching(rightWallCollider) || p2Collider.IsTouching(leftWallCollider))
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
