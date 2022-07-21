using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swdfactory
{
    class FindPath
    {
        public int Y { get; set; }
        public int X { get; set; }
        public int startY { get; set; }
        public int startX { get; set; }
        public int finishY { get; set; }
        public int finishX { get; set; }

        public FindPath(int y, int x, int starty, int startx, int finishy, int finishx)
        {
            this.Y = y;
            this.X = x;
            this.startY = starty;
            this.startX = startx;
            this.finishY = finishy;
            this.finishX = finishx;
        }

        public void Task()
        {
            int[,] map = new int[Y, X];
            int counter = 1;
            //Generate map with unique numbers
            for (int i = 0; i < Y; i++)
            {
                for (int k = 0; k < X; k++)
                {
                    map[i, k] = counter;
                    counter++;
                }
            }
            //Show map
            ShowMatrix(map);
            Console.WriteLine($"Position A is on Y: {startY} and X: {startX}");
            Console.WriteLine($"Position B is on Y: {finishY} and X: {finishX}");
            //Checks if the pont B is above point A and to the right
            if (startY <= finishY || startX >= finishX)
            {
                Console.WriteLine("Point B can't be below or to the left relative to point A");
            }
            else
            {
                int pathsQuantity = 1;
                List<int[]> storeUniquePaths = new List<int[]>();                
                
                for (int i = 0; i < pathsQuantity; i++)
                {
                    bool isItNotTheSame = false;
                    
                    //If list of all paths is empty then we add the first path
                    if (storeUniquePaths.Count() == 0)
                    {
                        //Each path we initialize this array fot storing single unique path
                        int[] uniquePath = new int[(startY - finishY) + (finishX - startX) + 1];                       
                        int CounterXDirection = 0;
                        int pathIndex = 0;
                        for (int y = startY - 1 ; y >= finishY - 1; y--)
                        {
                            for (int x = (startX - 1) + CounterXDirection; x < finishX; x++)
                            {
                                uniquePath[pathIndex] = map[y, x];
                                pathIndex++;
                                if (CounterXDirection < finishX - 1)
                                {
                                    CounterXDirection++;
                                }                               
                            }
                        }
                        storeUniquePaths.Add(uniquePath);
                        pathsQuantity++;
                    }
                    else
                    {
                        int removeXCounter = 0;                        
                        int trackY = (startY - 1);
                        //WHILE loop is mostly for change the path to find a new one
                        while (!isItNotTheSame)
                        {
                            //Each path we initialize this array fot storing single unique path
                            int[] uniquePath = new int[(startY - finishY) + (finishX - startX) + 1];
                            int pathIndex = 0;
                            int XRestriction = 0;

                            for (int y = (startY - 1); y >= finishY - 1; y--)
                            {
                                for (int x = (startX - 1) + XRestriction; x < finishX - removeXCounter; x++)
                                {
                                    uniquePath[pathIndex] = map[y, x];
                                    pathIndex++;
                                    if (XRestriction < (finishX - 1) - removeXCounter)
                                    {
                                        XRestriction++;
                                    }
                                }

                                for (int m = 0; m < removeXCounter; m++)
                                {
                                    for (int j = (startX - 1) + XRestriction; j < finishX; j++)
                                    {
                                        uniquePath[pathIndex] = map[trackY, j];
                                        pathIndex++;

                                    }
                                    y = trackY;
                                    removeXCounter = 0;
                                    if (XRestriction < (finishX - 1) - removeXCounter)
                                    {
                                        XRestriction++;
                                    }
                                }

                            }

                            //Loop over eachs unique path in list and compare it with new path
                            for (int k = 0; k < storeUniquePaths.Count(); k++)
                            {
                                //If path is the same then change the path
                                if (ArrayComparison(storeUniquePaths[k], uniquePath))
                                {
                                    removeXCounter++;
                                    trackY--;
                                    isItNotTheSame = false;
                                    break;
                                }
                                else
                                {
                                    isItNotTheSame = true;
                                }
                            }
                            if (isItNotTheSame)
                            {
                                storeUniquePaths.Add(uniquePath);
                                //if (startX != finishX - removeXCounter)
                                //{
                                //    pathsQuantity++;
                                //}
                            }


                        }
                    }
                }

                Console.WriteLine("Path Quantity: {0}", pathsQuantity);
                //ShowMatrix(storeUniquePaths);
                ShowPaths(storeUniquePaths);
                
            }
        }

        

        public bool ArrayComparison<T>(T[] firstArray, T[] secondArray)
        {
            return Enumerable.SequenceEqual(firstArray, secondArray);
        }

        public void ShowMatrix(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {                
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    Console.Write(array[i, k] + "\t");
                }
                Console.WriteLine("\n");
            }
        }
        public void ShowPaths(List<int[]> list)
        {
            foreach (var item in list)
            {
                Console.Write("Key -> ");
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(item[i] + " ");
                }
                Console.WriteLine(" ");
            }
        }

    }
}