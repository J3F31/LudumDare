//Author : Federico J. Lagar
//Date : 28.09.2020 - 23:48 UTC+2 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.PenguiniGames.randd
{
    public class collisionBoxManager : MonoBehaviour
{
   public collisionBox[] collisionBoxArray;
   void Awake()
    {
        InitializeCollisionBoxArray(100);
    }
   void InitializeCollisionBoxArray(int collisionBoxArrayIndex)
   {
       collisionBoxArray = new collisionBox[collisionBoxArrayIndex];
   }
   public collisionBox CreateCollisionBox(float x,float y, float width,float height,int type,int id)
   {
       collisionBox col = new collisionBox(x,y,width,height,type,id);
       return col;
   }
   public void AddCollisionBoxToArray(collisionBox _collisionBox, int _id)
   {
       collisionBoxArray[_id] = _collisionBox;
   }
   void Update(){
       if(collisionBoxArray[6].x + collisionBoxArray[6].width > collisionBoxArray[7].x){
           collisionBoxArray[6].isIntersecting = true;
       }
   }
}}

   