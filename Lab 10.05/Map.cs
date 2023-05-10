using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10._05
{
    public class Map
    {
        int[,] map;
        public int n { get { return map.GetLength(0); } }
        public int m { get { return map.GetLength(1); } }
        public void Load(string fileName)
        {
            List<string> mapAux = new List<string>();
            TextReader sr = new StreamReader(fileName);
            string buffer;
            while((buffer =  sr.ReadLine()) != null) 
            {
                mapAux.Add(buffer);
            }
            sr.Close();
            int n = mapAux.Count;
            int m = mapAux[0].Split(' ').Length;
            map = new int[n, m];
            for(int i = 0; i < n; i++) 
            {
                string[] strings = mapAux[i].Split(' ');
                for (int j = 0; j < m; j++) 
                    map[i,j] = int.Parse(strings[j]);       
            }
        }

        public List<string> View()
        {
            List<string> toR = new List<string>();

            for (int i = 0; i < n; i++) 
            {
                string buffer = "";
                for (int j = 0; j < m; j++)
                    buffer += map[i, j].ToString();
                toR.Add(buffer);
            }
            return toR;
        }

        public void Draw(MyGraphics handler)
        {
            Color color;
            float dW = (float)handler.resY / m;
            float dH = (float)handler.resX / n;
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < m; j++)
                {
                    switch(map[i,j]) 
                    {
                        case 1:
                            color = Color.Black;
                            break;
                        default:
                            color = handler.backColor;
                            break;
                    }
                    handler.grp.FillEllipse(new SolidBrush(color),j * dW, i * dH, dW, dH);
                    handler.grp.DrawEllipse(Pens.Gray, j * dW, i * dH, dW, dH);
                }
            }
        }

        public int CountNumOf1()
        {
            int nrOf1 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i,j] == 1)
                        nrOf1++;
                }
            }
            return nrOf1;
        }

        public void Tick()
        {
            int[,] local = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int nr = 0;
                    if (i - 1 >= 0 && j - 1 >= 0)
                        if (map[i - 1, j - 1] == 1)
                            nr++;
                    if (i - 1 >= 0)
                        if (map[i - 1, j] == 1)
                            nr++;
                    if (i - 1 >= 0 && j + 1 < m)
                        if (map[i - 1, j + 1] == 1)
                            nr++;
                    if (j - 1 >= 0)
                        if (map[i, j - 1] == 1)
                            nr++;
                    if (j + 1 < m)
                        if (map[i, j + 1] == 1)
                            nr++;
                    if (i + 1 < n && j - 1 >= 0)
                        if (map[i + 1, j - 1] == 1)
                            nr++;
                    if (i + 1 < n)
                        if (map[i + 1, j] == 1)
                            nr++;
                    if (i + 1 < n && j + 1 < m)
                        if (map[i + 1, j + 1] == 1)
                            nr++;
                    switch(map[i,j])
                    {
                        case 0:
                            if(nr >= 4)
                                local[i,j] = 1;
                            break;
                        case 1:
                            /*if(nr >= 9)
                                local[i,j] = 0;*/
                            local[i,j] = 1;
                            break;
                    }    
                }
            }
            map = local;
        }
    }
}
