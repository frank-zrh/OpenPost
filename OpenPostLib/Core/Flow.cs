﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPostLib.Core
{
    public class Flow
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public Action rootAction;             
        public Flow(Action root)
        {
            this.rootAction = root;
        }
    }
}
