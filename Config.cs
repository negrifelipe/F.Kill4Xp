using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace F.Kill4Xp
{
    public class Config : IRocketPluginConfiguration
    {
        public uint Xp4Kill;
        public uint HsXp4Kill;

        public void LoadDefaults()
        {
            Xp4Kill = 50;
            HsXp4Kill = 75;
        }
    }
}
