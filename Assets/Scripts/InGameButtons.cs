using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtons : MonoBehaviour
{
    public GameObject button;
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;

    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;

    public int level = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (level == 1)
        {
            block2.SetActive(false);
            block3.SetActive(false);
            block1.transform.position = new Vector2(2.505569f, 0.5138423f);
            button.transform.position = new Vector2(2.230569f, 0.4939697f);
            button.transform.rotation = Quaternion.Euler(0, 0, 90);

            Text1.SetActive(true);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text4.SetActive(false);
            Text5.SetActive(false);
            Text6.SetActive(false);

        }
        
        if (level == 2)
        {
            block2.SetActive(true);
            block3.SetActive(false);
            block1.transform.position = new Vector2(-1.14f, 0.71f);
            button.transform.position = new Vector2(1.942f, 1.41f);
            block2.transform.position = new Vector2(1.94f, 1.67f);
            button.transform.rotation = Quaternion.Euler(0, 0, 0);

            Text1.SetActive(false);
            Text2.SetActive(true);
            Text3.SetActive(false);
            Text4.SetActive(false);
            Text5.SetActive(false);
            Text6.SetActive(false);
        }

        if (level == 3)
        {
            block3.SetActive(false);
            block1.transform.position = new Vector2(-4.71f, 0.78f);
            block2.transform.position = new Vector2(-1.85f, 2.34f);            
            button.transform.position = new Vector2(-2.12f, 2.337f);
            button.transform.rotation = Quaternion.Euler(0, 0, 90);

            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(true);
            Text4.SetActive(false);
            Text5.SetActive(false);
            Text6.SetActive(false);
        }

        if (level == 4)
        {
            block1.SetActive(false);
            block2.SetActive(false);
            block3.SetActive(true);
            block3.transform.position = new Vector2(0.03f, 0.51f);
            block3.transform.rotation = Quaternion.Euler(0, 0, 0);
            button.transform.position = new Vector2(-0.09f, 4.7f);
            button.transform.rotation = Quaternion.Euler(0, 0, 0);

            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text4.SetActive(true);
            Text5.SetActive(false);
            Text6.SetActive(false);
        }

        if (level == 5)
        {
            block1.SetActive(true);
            block2.SetActive(true);
            block3.SetActive(true);
            block1.transform.position = new Vector2(-5.96f, -2.45f);
            block2.transform.position = new Vector2(-3.37f, -0.31f);
            block3.transform.position = new Vector2(0.88f, 3.28f);
            block3.transform.rotation = Quaternion.Euler(0, 0, 90);
            button.transform.position = new Vector2(3.05f, 4.68f);
            button.transform.rotation = Quaternion.Euler(0, 0, 0);

            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text4.SetActive(false);
            Text5.SetActive(true);
            Text6.SetActive(false);
        }

        if (level >= 6)
        {
            block3.SetActive(true);
            block3.transform.position = new Vector2(0.03f, 0.51f);
            block3.transform.rotation = Quaternion.Euler(0, 0, 0);
            button.SetActive(false);
            block1.SetActive(false);
            block2.SetActive(false);

            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text4.SetActive(false);
            Text5.SetActive(false);
            Text6.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("Enter");
            level += 1;
        }
    }
}
