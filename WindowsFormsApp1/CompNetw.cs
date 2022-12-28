using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public class CompNetw:Main
    {     
        public int maxradius;
        public int MaxConnected;      
        public int numberOfCon;
        public CompNetw(int Number, int Coordinate, int NumberOfCon)
        {
            number = Number;
            coordinate = Coordinate;
            numberOfCon = NumberOfCon;
            maxradius = 30;
            MaxConnected = 2;
        }
       
        
    }
}