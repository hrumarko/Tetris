using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    static int height = 20;
    static int width = 10;
    public float speed;
    public Vector3 rotationPoint;
    private static Transform[,] field = new Transform[height, width];

    private void Update() {
        Moving();
        Rotate();
        BigSpeed();
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
            if(posY <= 19){
                if (field[posY, posX] != null)
                return false;
            }
        }
        return true;
    }

    void BigSpeed(){
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            Time.fixedDeltaTime = speed;
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)){
            Time.fixedDeltaTime = 0.6f;
        }
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
            SetInField();
            CheckLines();            
            FindObjectOfType<Spawner>().Spawn();
            
        }
    }


    void SetInField(){
        foreach(Transform child in transform){
            int posX = Mathf.RoundToInt(child.transform.position.x);
            int posY = Mathf.RoundToInt(child.transform.position.y);

            field[posY, posX] = child;
        }
    }
    
    void CheckLines(){
        
        for(int i = height-1; i >= 0; i--){
            if(HasLine(i)){
                
                DeleteLine(i);
                //RowLine(i);
            }
        }
    }

    bool HasLine(int i){
        for(int j = 0; j < width; j++){
            if(field[i, j] == null)
            return false;
        }
        return true;
    }

    void DeleteLine(int i){
        
        for(int j = 0; j < width; j++){
            Destroy(field[i, j].gameObject);
            field[i, j] = null;
        }
    }
}
