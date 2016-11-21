using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

	public int rName;
	public int type;// 0 regular room/ 1 stairs room(right side) goes up 2 stairs (leftside) goes down 3/initial room
	public int width;
	public int height; //floors
    public bool isEnd;
	public List<int> rooms;
	public List<int> pathAvailable = new List<int>();
    
    public GameObject door;
    public GameObject doorEnd;
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
	public void addPath(int path){
	
        bool found=false; 
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i] == path)
            {

                found=true;

            }
        }
        if (found)
        {
            rooms.Add(path);
        }
	
	}
    /*
    public Vector3 getRightDoorPos(int path)
    {
        // 0 regular room/ 1 stairs room(right side) goes up 2 stairs(leftside) goes down 3 / initial room
        switch (type)
        {

            case 0:
                {
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            pathAvailable.Add(count);
                            count++;
                        }
                    }
                }
                break;
            case 1:
                {
                    pathAvailable.Add(1);
                    pathAvailable.Add(4);
                }
                break;
            case 2:
                {
                    pathAvailable.Add(3);
                    pathAvailable.Add(2);
                }
                break;
            case 3:
                {
                    pathAvailable.Add(2);
                }
                break;

        }


    }
    */




    public void CreateDoors()
    {
        if (pathAvailable.Count > 0) {
            for (int i = 0; i < pathAvailable.Count; i++)
            {
                GameObject roomObj;
                //right door
                if (pathAvailable[i] % 2 == 0)
                {
                    if (!isEnd)
                    {
                


                        switch (type)
                        {



                            case 1:
                                {
                                    
                                    roomObj = Instantiate(door, new Vector3(transform.position.x + 0.62f + (1.02f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 2 * 1f) - (1.58f * (height - 1)), 0), transform.rotation) as GameObject;

                                }
                                break;
                            case 2:
                                {
                                    roomObj = Instantiate(door, new Vector3(transform.position.x + 0.62f + (1.02f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 2 * 1f) - (1.41f * (height - 1)), 0), transform.rotation) as GameObject;

                                }
                                break;


                            default:
                                roomObj = Instantiate(door, new Vector3(transform.position.x + 0.62f + (1.04f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 4 * 2f), 0), transform.rotation) as GameObject;


                                break;
                        }

                    }
                    else {

                        switch (type)
                        {



                            case 1:
                                {

                                    roomObj = Instantiate(doorEnd, new Vector3(transform.position.x + 0.62f + (1.02f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 2 * 1f) - (1.58f * (height - 1)), 0), transform.rotation) as GameObject;

                                }
                                break;
                            case 2:
                                {
                                    roomObj = Instantiate(doorEnd, new Vector3(transform.position.x + 0.62f + (1.02f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 2 * 1f) - (1.41f * (height - 1)), 0), transform.rotation) as GameObject;

                                }
                                break;


                            default:
                                roomObj = Instantiate(doorEnd, new Vector3(transform.position.x + 0.62f + (1.04f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 4 * 2f), 0), transform.rotation) as GameObject;


                                break;
                        }
                    }
                }
                //left door
                else
                {


                    switch (type)
                    {

                        

                        case 1:
                            {
                                roomObj = Instantiate(door, new Vector3(transform.position.x - 0.62f - (1.02f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 2 * 1f) - (0.416f * (height - 1)), 0), transform.rotation) as GameObject;

                            }
                            break;
                        case 2:
                            {
                                roomObj = Instantiate(door, new Vector3(transform.position.x - 0.62f - (1.02f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 2 * 1f) - (0.57f * (height - 1)), 0), transform.rotation) as GameObject;

                            }
                            break;


                        default:
                            roomObj = Instantiate(door, new Vector3(transform.position.x - 0.62f - (1.02f * (width - 1)), transform.position.y - 0.03f + (pathAvailable[i] / 2 * 1f) - (0.416f * (height - 1)), 0), transform.rotation) as GameObject;

                            break;
                    }



                }
            

                roomObj.transform.parent = transform;
            }
        }
        

    }


    // Update is called once per frame
    void Update () {
	
	}
}
