// Import necessary libraries

using System;
using UnityEngine;


// Base class for all enemy types
public class Enemy : MonoBehaviour
{
  public int speed;

  public GameObject player;

  public void Update()
  {
    chasePlayer();
    // signalClose();
  }

  public void chasePlayer()
  {
    // take players position and move towards it
    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
  }

  public bool isClose()
  {
    //if player is close, signal to the player by printing to console
    if (Vector3.Distance(transform.position, player.transform.position) < 7)
    {
      Debug.Log("Player is close");
      return true;
    }
    else
    {
      return false;
    }
  }

  public bool isTouching()
  {
    // if collider is touching player, signal to the player by printing to console
    if (GetComponent<Collider>().bounds.Intersects(player.GetComponent<Collider>().bounds))
    {
      Debug.Log("Player is touching");
      return true;
    }
    else
    {
      return false;
    }
  }
  
  public void FreezePosition()
  {
    // freeze position of enemy
    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
  }

  public void UnfreezePosition()
  {
    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
  }

}