using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public class Item
    {
        public int no;
        public float width;
        public float depth;
        public float height;
        public int quantity;
        public string color;
        public float[] positon = {0,0,0};
        public float volume()
        {
           return width * depth * height;
        } 

        public List<float> Get_dimension()
        {
            var dim = new List<float>();

            dim.Add(width);
            dim.Add(depth);
            dim.Add(height);
            return dim;
        }
        public List<float> Pick_Box()
        {
            var pos = new List<float>();

            pos.Add(positon[0] + width/2);
            pos.Add(positon[1] + depth/2);
            pos.Add(positon[2] + height);
            return pos;
        }


    }
}


