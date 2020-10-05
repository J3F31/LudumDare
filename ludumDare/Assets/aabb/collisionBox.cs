//Author : Federico J. Lagar
//Date : 28.09.2020 - 23:48 UTC+2 
using System.Collections;
using System.Collections.Generic;

namespace Com.PenguiniGames.randd
{
    public class collisionBox
    {

        public float x{get;set;}
        public float y {get;set;}
        public float width {get;set;}
        public float height {get;set;}
        public int type{get;set;}
        public int id{get;set;}
        public bool isIntersecting{get;set;}
        public bool isMoving{get;set;}

    public collisionBox(float _x, float _y, float _width, float _height, int _type, int _id)
    {
      this.x = _x;
      this.y = _y;
      this.width = _width;
      this.height = _height;
      this.type = _type;
      this.id = _id;
    }
}
}