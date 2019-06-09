using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private readonly float speed = 2f;
    private float tempspeed;
    private Scene scene;
    private Vector2 jumpHeight;
    private int jumpCount;
    private int sceneNum;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        var sceneNumStr = scene.name.Substring(5);
        sceneNum = System.Convert.ToInt32(sceneNumStr);
        jumpHeight = new Vector2(2, 5);
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        tempspeed = 1f;

        //Check if he's dead
        if (transform.position.y <= -6)
        {
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKey(KeyCode.X))
        {
            tempspeed *= 5;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += move * speed * tempspeed * Time.deltaTime;
            jumpHeight = new Vector3(move.x, 5);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += move * speed * tempspeed * Time.deltaTime;
            jumpHeight = new Vector3(move.x, 5);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 2)
        {
            if(sceneNum == 0)
            {
                SceneManager.LoadScene("Scene1");
            }
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            jumpCount++;
        }
        
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        scene = SceneManager.GetActiveScene();
        // Checking if the overlapped collider is an enemy
        if (trig.CompareTag("Fly"))
        {
            // This scene HAS TO BE IN THE BUILD SETTINGS!!!
            sceneNum += 1;
            SceneManager.LoadScene($"Scene{sceneNum}");
        }
        if (trig.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(scene.name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
