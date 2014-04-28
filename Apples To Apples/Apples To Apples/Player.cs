using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples_To_Apples
{
    class Player
    {
        public int playerNum; //we will need to figure out how to retrieve this num from website
        public int awesomePts = 9;
        public Boolean isJudge = false;

        public Player(int number)
        {
            playerNum = number;
        }

        public int getAwesomePts()
        {
            return awesomePts;
        }

        public void setAwesomePts(int newPts)
        {
            awesomePts = newPts;
        }
    }
}
