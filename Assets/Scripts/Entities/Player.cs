﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float startSize = 1f;
    public float startSpeed = 5f;
    public float sizeModifier = .1f;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If colliding with Food
        if (other.name.Contains("Food"))
        {
            // Grow a little bit
            Grow();
            // Destroy Food
            Destroy(other.gameObject);
        }
    }
    private void Move()
    {
        // Get Positions
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Apply Velocity
        Vector3 movement = Vector2.MoveTowards(transform.position, mousePos,
                                               startSpeed * Time.deltaTime);
        rigid.MovePosition(movement);
        // Filter the Position of Player to stay within Background
        transform.position = Game.Instance.GetAdjustedPosition(transform.position);
    }

    public void Grow()
    {
        // Increase Player scale
        transform.localScale += new Vector3(sizeModifier, sizeModifier, sizeModifier);

        // Increase Camera Size with Player scale
        Game.Instance.cam.orthographicSize += sizeModifier * 5f;
    }
    public void Scale(float size)
    {
        transform.localScale = new Vector3(size, size, size);
    }
}

