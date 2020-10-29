using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Coordinates
{
    public class Cord
    {
        public string nameC { get; set; }

        public double xC { get; set; }

        public double yC { get; set; }

        public double zC { get; set; }

        public Cord(string name, double x, double y, double z)
        {
            nameC = name;
            xC = x;
            yC = y;
            zC = z;
        }

        public static void Mto1970(List<Cord> CoordinatesList)
        {
            
            for(int i = 0; i < CoordinatesList.Count; i++)
            {
                CoordinatesList[i].xC += 4580000;
                CoordinatesList[i].yC += 9430000;
              
            }


           
        }
        public static IList<Cord> B70toM(List<Cord> CoordinatesList)
        {

            for (int i = 0; i < CoordinatesList.Count; i++)
            {
                CoordinatesList[i].xC -= 4580000;
                CoordinatesList[i].yC -= 9430000;

            }


            return CoordinatesList;
        }

        public static string printCord(List<Cord> Cordinates, string delimiter, string newLine)
        {

            string output = "";
            for (int i = 0; i < Cordinates.Count; i++)
            {
                output += Cordinates[i].nameC + delimiter + Cordinates[i].xC + delimiter + Cordinates[i].yC + delimiter + Cordinates[i].zC + newLine;
            }
            return output;
        }



    }

}