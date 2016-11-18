using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {


	public GameObject[] rooms;
	public List<Vector3> createdRooms;
	private List<Room> cRooms;
	public int roomAmount;
	public float roomOffset;

	public float waitTime;

	// Use this for initialization
	void Start () {
		createRooms();
		StartCoroutine (GenerateLevel ());
		//yield return 0;
	}

	void createRooms(){
		int dir=0;// right
		
		Room room=rooms[0].GetComponent<Room>();
		cRooms = new List<Room> ();
		//CreateRoom(0);
		cRooms.Add(room);
		//MoveGen(dir,room.width);
		for (int i=1; i<roomAmount;i++){
			dir=Random.Range(0,1);//left right
			int r= Random.Range (1,rooms.Length);
			
			room=rooms[r].GetComponent<Room>();


			switch (room.type) {
				
			case 0:
			{
				room.addPath(cRooms[cRooms.Count-1],1);
			}
				break;
			case 1:
			{
				room.addPath(cRooms[cRooms.Count-1],1);
			}
				break;
			case 2:
			{
				
				room.addPath(cRooms[cRooms.Count-1],3);
			}
				break;
			
			
			}


			List<int>paths=cRooms[cRooms.Count-1].getPathAvailable();
			
			int path= Random.Range (0,paths.Count);

			/*
			if(room.width==1){
				
				MoveGen(dir,2.05f,room.width);
			}
			else if(room.width==2){
				
				MoveGen(dir,3.05f,room.width);
			}*/

			cRooms[cRooms.Count-1].addPath(room,path);
			cRooms.Add(room);
			//CreateRoom(r);

			//yield return new WaitForSeconds(waitTime);

		}
	}

	IEnumerator GenerateLevel(){


		
		CreateRoom(cRooms[0].name);
		for (int i=1; i<cRooms.Count;i++){

			Room room=cRooms[i];

			if(cRooms[i-1].width==1){
				if(room.width==1){
					
					MoveGen(0,2.05f,room.width);
				}
				else if(room.width==2){
					
					MoveGen(0,3.05f,room.width);
					}
			}
			else if(cRooms[i-1].width==2) {
				if(room.width==1){
					
					MoveGen(0,2.05f,room.width);
				}
				else if(room.width==2){
					
					
					MoveGen(0,4.08f,room.width);
				}


			}
			CreateRoom(room.name);
			yield return new WaitForSeconds(waitTime);
			
		}
		yield return 0;
	}


	//move the level generator to a direction up down right left
	void MoveGen(int dir,float offs,int width){
	
		switch(dir)
		{
			case 0:{
			transform.position=new Vector3(transform.position.x+(offs),transform.position.y);
			}
			break;
			case 1:{
			
			transform.position=new Vector3(transform.position.x-(offs*width),transform.position.y);
			}
			break;

		}
	}

	void CreateRoom(int roomIndex){

		if (!createdRooms.Contains (transform.position)) {
			GameObject roomObj;
			roomObj = Instantiate (rooms [roomIndex], transform.position, transform.rotation) as GameObject;
			createdRooms.Add (roomObj.transform.position);
		} 
		else {
			roomAmount++;
		}

	}
}
