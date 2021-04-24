using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonController : MonoBehaviour
{
    public GameObject player;
    public void MiddleDown(){
        player.GetComponent<PlayerController>().up = true;
    }
    public void MiddleUp(){
        player.GetComponent<PlayerController>().up = false;
    }
    public void RightDown(){
        player.GetComponent<PlayerController>().right = true;
    }
    public void RightUp(){
        player.GetComponent<PlayerController>().right = false;
    }
    public void LeftDown(){
        player.GetComponent<PlayerController>().left = true;
    }
    public void LeftUp(){
        player.GetComponent<PlayerController>().left = false;
    }
}
