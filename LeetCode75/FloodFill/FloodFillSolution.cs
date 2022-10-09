using System;

namespace LeetCode75.FloodFill
{
    //https://leetcode.com/problems/flood-fill/
    
    public static class FloodFillSolution
    {
        public static void Run()
        {
            var image = new int[][]
            {
                new[]
                {
                    1, 1, 1
                },
                new[]
                {
                    1, 1, 0
                },
                new[]
                {
                    1, 0, 1
                }
            };

            Print(image);

            image = FloodFill(image, 1, 1, 2);
            
            Console.WriteLine();
            Print(image);
        }

        public static void Print(int[][] image)
        {
            for (int i = 0; i < image.Length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < image[i].Length; j++)
                {
                    Console.Write(image[i][j] + " ");
                }
            }
        }
        
        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color)
            {
                return image; 
            }
            Fill(image, sr, sc, image[sr][sc], color );

            return image;
        }


        private static void Fill(int[][] image, int sr, int sc, int currentColor, int newColor)
        {
            if (sc < 0 || sr < 0 || sr>= image.Length || sc >= image[0].Length || image[sr][sc] != currentColor )
            {
                return;
            }

            image[sr][sc] = newColor;
            
            Fill(image, sr-1, sc, currentColor, newColor );
            Fill(image, sr+1, sc, currentColor, newColor );
            Fill(image, sr, sc-1, currentColor, newColor );
            Fill(image, sr, sc+1, currentColor, newColor );
        }
        
    }
}