using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

	public int name;
	public int type;// 0 regular room/ 1 stairs room(right side) goes up 2 stairs (leftside) goes down 3/initial room
	public int width;
	public int height; //floors

	public List<Room> leftRooms;
	public List<Room> rightRooms;
	public List<int> pathAvailable = new List<int>();
	// Use this for initialization
	void Start () {
		int count=1;
		switch (type) {
			
		case 0:
			{
				for (int i=0; i<height; i++) {
					for (int j=0; j<2; j++) {
						pathAvailable.Add (count);
						count++;
					}
				}
			}
		break;
		case 1:
			{
			pathAvailable.Add (1);
			pathAvailable.Add (4);
			}
		break;
		case 2:
		{
			pathAvailable.Add (3);
			pathAvailable.Add (2);
		}
		break;
		case 3:
		{
			pathAvailable.Add (2);
		}
			break;
		
		}
	
	}
	public bool hasPathAvailable(){
		if (pathAvailable.Count>0) {
			return true;
		}
		else{
			return false;
		}
	}
	public List<int> getPathAvailable (){
		return pathAvailable;

	}
	public void closePaths(){

			pathAvailable=new List<int>();
	}
	public void addPath(Room room, int path){
		for (int i=0; i< pathAvailable.Count; i++) {
			if(pathAvailable[i]==path){
				
				pathAvailable.RemoveAt(i);

			}		
		}
		if (path % 2 == 0) {
			rightRooms.Add (room);
		}
		else {
			
			leftRooms.Add (room);
		}
	
	}


	// Update is called once per frame
	void Update () {
	
	}
}
