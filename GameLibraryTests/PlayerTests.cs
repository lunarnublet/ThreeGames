﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void GreetTest()
        {
            Player p = new Player();
            p.Greet();
        }
    }
}