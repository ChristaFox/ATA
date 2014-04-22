using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples_To_Apples
{
    class Player
    {
        public int playerNum; //we will need to update this once we figure out how many players are connected
        public int awesomePoints = 0;
        public Boolean isJudge = true;

        public Player(int number)
        {
            playerNum = number;
        }
    }
}
