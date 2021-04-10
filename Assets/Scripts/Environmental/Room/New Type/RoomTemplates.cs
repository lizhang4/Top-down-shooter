using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] rooms;


    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;




    public GameObject closedRoom;

    public GameObject LB, 
    LR,
    RB,
    TB,
    TL,
    TR,
    LRB,
    LRT,
    TLB,
    TRB;
    public LayerMask whatIsRoom;

    public List<GameObject> addedRooms;
    public List<Vector3> connectionRoomPos;

    public float waitTime = 2;
    private bool spawnedBoss;
    private bool spawnedConnectionRoom;
    private bool stopGeneration;

    public GameObject boss;
    private int currentLength = -1;
    private int counter = 0;

    private void Start() {
        counter = 0;
    }


    private void Update() {
        if(stopGeneration == false) {
            if (waitTime <= 0) {
                if(currentLength == addedRooms.Count) {
                    Debug.Log("stop generation " + currentLength);
                    stopGeneration = true;
                }
                currentLength = addedRooms.Count;    
                waitTime = 0.5f;
            }
            else {
                waitTime -= Time.deltaTime;
            }

        }

        if(stopGeneration && counter < connectionRoomPos.Count) {
            AddConnectingRoom();
        }

        
    }

    private void AddConnectingRoom() {
        // Check what room to add
        // top
        int sum = 0;
        int rotation = 0;
        if (Physics2D.OverlapCircle(connectionRoomPos[counter] + Vector3.up *10, 5f, whatIsRoom)) {
            if(Physics2D.OverlapCircle(connectionRoomPos[counter] + Vector3.up *10, 1f, whatIsRoom) == null) {
                sum++;
                rotation  = rotation + 1000;
                Debug.Log("TOP");

            }
        }
        if (Physics2D.OverlapCircle(connectionRoomPos[counter] + Vector3.right *15, 5f, whatIsRoom)) {
            if(Physics2D.OverlapCircle(connectionRoomPos[counter] + Vector3.right *15, 1f, whatIsRoom) == null) {
                sum++;
                rotation  = rotation + 100;
                Debug.Log("Right");
            }

            
        }
        if (Physics2D.OverlapCircle(connectionRoomPos[counter] + Vector3.down *10,5f, whatIsRoom)) {
            if(Physics2D.OverlapCircle(connectionRoomPos[counter] + Vector3.down *10, 1f, whatIsRoom) == null) {
                sum++;
                rotation  = rotation + 10;
                Debug.Log("Down");

            }

        }
        if (Physics2D.OverlapCircle(connectionRoomPos[counter] + Vector3.left *15, 5f, whatIsRoom) ) {
            if(Physics2D.OverlapCircle(connectionRoomPos[counter] + Vector3.left *15, 1f, whatIsRoom) == null ) {
                sum++;
                rotation  = rotation + 1;
                Debug.Log("Left");
            }

        }

        if (sum == 4) {
            Debug.Log(4);
            Instantiate(closedRoom, connectionRoomPos[counter], Quaternion.identity);
        }
        else if(sum == 3) {
            Debug.Log(3);

            if(rotation == 1110) { //TRB
                Instantiate(TRB, connectionRoomPos[counter], TRB.transform.rotation);
            }
            else if(rotation == 1101) { //TRL
                Instantiate(LRT, connectionRoomPos[counter], LRT.transform.rotation);
            }
            else if(rotation == 1011) { //TBL
                Instantiate(TLB, connectionRoomPos[counter], TLB.transform.rotation);
            }
            else if(rotation == 0111) { //RBL
                Instantiate(LRB, connectionRoomPos[counter], LRB.transform.rotation);
            }
        }
        else if(sum == 2) {
            Debug.Log(2);
            

            if(rotation == 1100) { //TR
                Instantiate(TR, connectionRoomPos[counter], TR.transform.rotation);
            }
            else if(rotation == 1001) { //TL
                Instantiate(TL, connectionRoomPos[counter], TL.transform.rotation);

            }
            else if(rotation == 0110) { //RB
                Instantiate(RB, connectionRoomPos[counter], RB.transform.rotation);

            }
            else if(rotation == 0011) { // BL
                Instantiate(LB, connectionRoomPos[counter], LB.transform.rotation);

            }
            else if(rotation == 1010) {//TB
                Instantiate(TB, connectionRoomPos[counter], TB.transform.rotation);
            }
            else if(rotation == 0101) {//RL
                Instantiate(LR, connectionRoomPos[counter], LR.transform.rotation);
            }
        }

        counter++;
    }

    private void OnDrawGizmos() {
        if (connectionRoomPos.Count >= 1) {
            Gizmos.DrawWireSphere(connectionRoomPos[0]+ Vector3.left *15, 1f);
            Gizmos.DrawWireSphere(connectionRoomPos[0]+ Vector3.right *15, 1f);
            Gizmos.DrawWireSphere(connectionRoomPos[0]+ Vector3.up *10, 1f);
            Gizmos.DrawWireSphere(connectionRoomPos[0]+ Vector3.down *10, 1f);
        }

    }
    
}
