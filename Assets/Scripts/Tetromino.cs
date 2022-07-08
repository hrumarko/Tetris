using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    static int height = 20;
    static int width = 10;
    public Vector3 rotationPoint;
    Transform[,] field = new Transform[height, width];

    private void Update() {
        Moving();
        Rotate();
    }

    private void FixedUpdate() {
        Falling();
    }

    void Moving(){
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.position += new Vector3(-1, 0, 0);
            if(!isValid()){
                transform.position += new Vector3(1, 0, 0);
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            transform.position += new Vector3(1, 0, 0);
            if(!isValid()){
                transform.position += new Vector3(-1, 0, 0);
            }
        }
    }

    bool isValid(){
        foreach(Transform child in transform){
            int posX = Mathf.RoundToInt(child.transform.position.x);
            int posY = Mathf.RoundToInt(child.transform.position.y);

            if(posX >= width || posX < 0 || posY < 0){
                return false;
            }
        }
        return true;
    }

    void Rotate(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
            if(!isValid()){
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
            }
        }
    }

    void Falling(){
        transform.position += new Vector3(0, -1, 0);
        if(!isValid()){
            transform.position += new Vector3(0, 1, 0);
            this.enabled = false;
            FindObjectOfType<Spawner>().Spawn();
            
        }
    }
}
