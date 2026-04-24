using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Text
{
    internal abstract class Event
    {
        public string eventName;

        public abstract void Execute(GameManager manager);
    }
}

