using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.PenguiniGames.randd
{
public class playerMovement : collisionBoxManager
{
    public float x,y,width,height,speed;
    public int type,id;
    collisionBox playerCollisionBox;
    public bool GizmosEnabled;
    public collisionBoxManager man;
    void Start()
    {
        playerCollisionBox = man.CreateCollisionBox(x,y,width,height,type,id);
        man.AddCollisionBoxToArray(playerCollisionBox,id);
        man.collisionBoxArray[id].x = transform.position.x + x;
            man.collisionBoxArray[id].y = transform.position.y + y;
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && !man.collisionBoxArray[id].isIntersecting)
        {                     
            Vector3 targetDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetDirection.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position,targetDirection,speed * Time.deltaTime);
            man.collisionBoxArray[id].x = transform.position.x + x;
            man.collisionBoxArray[id].y = transform.position.y + y;
        }
    }
     private void OnDrawGizmos()
    {
     
        if(GizmosEnabled){
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(man.collisionBoxArray[id].x, man.collisionBoxArray[id].y, 1), new Vector3(man.collisionBoxArray[id].x + width, man.collisionBoxArray[id].y, 1));
        Gizmos.DrawLine(new Vector3(man.collisionBoxArray[id].x, man.collisionBoxArray[id].y, 1), new Vector3(man.collisionBoxArray[id].x, man.collisionBoxArray[id].y + height, 1));
        Gizmos.DrawLine(new Vector3(man.collisionBoxArray[id].x + width, man.collisionBoxArray[id].y, 1), new Vector3(man.collisionBoxArray[id].x + width, man.collisionBoxArray[id].y + height, 1));
        Gizmos.DrawLine(new Vector3(man.collisionBoxArray[id].x, man.collisionBoxArray[id].y + height, 1), new Vector3(man.collisionBoxArray[id].x + width, man.collisionBoxArray[id].y + height, 1));
        }
    }
}
}