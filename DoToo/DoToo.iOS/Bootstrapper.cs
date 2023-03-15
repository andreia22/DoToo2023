using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace DoToo.iOS
{
    internal class Bootstrapper : DoToo.Bootstrapper
    {

        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }
}