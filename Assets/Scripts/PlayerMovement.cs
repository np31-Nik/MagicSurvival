using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 5f;

    private float pHeight;
    private float pWidth;
    private Vector2 screenBounds;

    private void Start()
    {
        getBounds();
    }
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 tempPos = transform.position;

        tempPos.y += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if ((tempPos.y + pHeight < screenBounds.y) && (tempPos.y - pHeight > (screenBounds.y * -1)))
        {
            pos.y = tempPos.y;
        }

        tempPos.x += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if ((tempPos.x + pWidth < screenBounds.x) && (tempPos.x - pWidth > (screenBounds.x * -1)))
        {
            pos.x = tempPos.x;
        }

        transform.position = pos;

    }

    void getBounds()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        pWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        pHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
}
