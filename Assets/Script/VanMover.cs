using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VanMover : MonoBehaviour
{
    private float speed = 8.0f;
    private int score = 0;
    private string strScore;
    // Start is called before the first frame update
    void Start()
    {
        strScore = "Score: " + score;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // This if stops the van driving off the road.
            if (transform.position.x > -3.5f)
            {
                transform.Translate(-Vector3.left * speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // This if stops the van driving off the road.
            if (transform.position.x < 3.5f)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter!!!");
        if (collision.gameObject.tag.Equals("Crate"))
        {
            score--;
        }
        if (collision.gameObject.tag.Equals("Pizza"))
        {
            score++;
        }
        strScore = "Score: " + score;
    }
    private void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(10, 10, Screen.width, Screen.height), strScore);
    }
}