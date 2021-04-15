// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CheckRoom : MonoBehaviour
// {
//     public List<GameObject> emptyRoomPoses;
//     public LayerMask whatIsRoom;
//     public LevelGeneration levelGeneration;

//     public float movePos = 20f;
//     public int maxRoomAmount = 10;
//     public List<int> canSpawnPoses;
//     public List<int> spawnType;
//     public List<int> spawnAngle;

//     private Vector3[] coordinates = {Vector3.up * 20, Vector3.right * 20, Vector3.down * 20, Vector3.left * 20};
//     private int[] roomType = {0, 0, 0, 0};
//     private bool canSpawn;
//     private int roomsAmount;
//     private bool stopChecking;

//     private void Update() {
//         if(levelGeneration.stopGeneration2 && !stopChecking) {
//             roomsAmount = levelGeneration.roomsAmount;     
//             Debug.Log(roomsAmount); 
//             if (16 - roomsAmount == emptyRoomPoses.Count) {
//                 DetermineWhereToSpawn();

//                 SpawnRooms();
//             }
//         }
        
//     }

//     private void DetermineWhereToSpawn() {
//         for (int i = 0; i < emptyRoomPoses.Count; i++) {
//             canSpawn = false;
//             roomType = new int[] {0,0,0,0};
//             if(roomsAmount >= maxRoomAmount) {
//                 break;
//             }
//             for (int j = 0; j < coordinates.Length; j++) {
//                 if(emptyRoomPoses[i] != null) {
//                     Collider2D gotRoom = Physics2D.OverlapCircle(emptyRoomPoses[i].transform.position + coordinates[j], 1, whatIsRoom);

//                     if(gotRoom) {
//                         Debug.Log("Got Room");

//                         roomType[j] = 1;

//                         canSpawn = true;
//                         // if ((gotRoom.GetComponent<RoomType>().firstRoom || gotRoom.GetComponent<RoomType>().lastRoom)) {
//                         //     canSpawn = false;
//                         //     break;
//                         // }
                        
//                     }
//                 }

//             }
//             if(canSpawn) {
//                 Debug.Log("Spawn Room");
//                 canSpawnPoses.Add(i);
//                 Debug.Log(roomType[0] +"," + roomType[1] + "," + roomType[2] +"," + roomType[3] );
//                 int sum = roomType[0] + roomType[1] + roomType[2] + roomType[3];

//                 if(roomType[0] == 1) {
//                     spawnType.Add(1);
//                 }
//                 else if(roomType[1] == 1) {
//                     spawnType.Add(2);

//                 }
//                 else if (roomType[2] == 1) {
//                     spawnType.Add(3);
                    
//                 }
//                 else if (roomType[3] == 1) {
//                     spawnType.Add(4);
                    
//                 }
//                 roomsAmount++;
//                 //emptyRoomPoses[i].GetComponent<SpawnRooms>().SpawnRoom();
//             }
//             else {
//                 Destroy(emptyRoomPoses[i]);
//             }
//         }
//     }

//     private void SpawnRooms() {
//         int count = 0;
//         foreach (int canSpawnPose in canSpawnPoses){
//             if(emptyRoomPoses[canSpawnPose] != null) {
//                 emptyRoomPoses[canSpawnPose].GetComponent<SpawnRooms>().SpawnRoom(spawnType[count]);
//             }
//             count++;
//         }


//         stopChecking = true;
//     }

// }
