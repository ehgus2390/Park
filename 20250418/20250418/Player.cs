using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player
{
    internal class Player : CUnit
    {
        private CIventory inventory;

        public Player() 
        {
            inventory = new CInvevtory();
            InitStatus();
        }
    }
}
