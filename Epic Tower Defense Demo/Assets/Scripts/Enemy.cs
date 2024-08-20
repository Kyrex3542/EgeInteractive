using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 stopPos;
    private void Start()
    {
        
    }
    private void Update()
    {
        //transform.position=Vector2.MoveTowards(startPos, stopPos, speed*Time.deltaTime);

        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
    }
}
