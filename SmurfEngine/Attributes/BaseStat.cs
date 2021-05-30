﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmurfEngine.Attributes
{
    public class BaseStat
    {
        public virtual string Name { get; set; }
        public virtual int BaseValue { get; set; }
        public virtual float BaseMultiplier { get; set; }
    }
}
