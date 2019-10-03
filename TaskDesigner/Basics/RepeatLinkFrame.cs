using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class RepeatLinkFrame
    {
        public bool Active;
        public int RepeatationNumber;
        public int CurrentRepeatationNumber;
        public int CurrentIndex; 
        //public int FrameCount;
        public int Length;
        public int[] FrameIndexes;
        public int RandomLocation;
        public int LeftOrRight;
        Random rnd = new Random();
        public RepeatLinkFrame()
        {
            Active = false;
            RepeatationNumber = 1;
            CurrentRepeatationNumber = 0;
            CurrentIndex = 0;
            Length = 2;
            //FrameCount = 2;
            FrameIndexes = new int[Length];
            RandomLocation = 0;
            LeftOrRight = 1;
            for (int i = 0; i < Length; i++)
                FrameIndexes[i] = new int();
        }

        public void SetProperties(bool active, int repeatationNumber, int length, int random)
        {
            this.Active = active;
            this.RepeatationNumber = repeatationNumber;
            this.Length = length;
            this.RandomLocation = random;
        }

        public void SetRandomLocation(int mode)
        {
            RandomLocation = mode;
        }

        public int Makerand()
        {
            return (rnd.Next(1, 1000) % 2) + 1;
        }

    }
}
