using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples_To_Apples
{
    class Player
    {
        private int playerNum;
        private int awesomePts = 0;
        private Boolean isJudge = false;

        public Player(int number)
        {
            playerNum = number;
        }

        public int getPlayerNum()
        {
            return playerNum;
        }

        public int getAwesomePts()
        {
            return awesomePts;
        }

        public void incAwesomePts()
        {
            awesomePts++;
        }

        public Boolean getIsJudge()
        {
            return isJudge;
        }

        public void setIsJudge(Boolean jud)
        {
            isJudge = jud;
        }
    }
}
