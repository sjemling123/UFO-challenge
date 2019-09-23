using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Vector2 pos1;
    private Vector2 pos2;
    public Vector3 posDiff = new Vector2(0, 0);
    public float speed = 1.0f;

    void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position + posDiff;
    }

    void Update()
    {
        transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        transform.Rotate(Vector2.up * 10f * Time.deltaTime);
    }

}