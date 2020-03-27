using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TELTAS300Emulator
{
    public class Emulation
    {
        public bool Stop 
        { 
            get { return false; }
            set 
            {
                LoadPorts.ForEach(l => l.Stop=value);
            } 
        }
        
        public List<LoadPort> LoadPorts { get; }

        public Emulation()
        {
            LoadPorts = new List<LoadPort>(4);
            LoadPorts.Add(new LoadPort(AppConfiguration.Port1,0));
            LoadPorts.Add(new LoadPort(AppConfiguration.Port2,1));
            LoadPorts.Add(new LoadPort(AppConfiguration.Port3,2));
            LoadPorts.Add(new LoadPort(AppConfiguration.Port4,3));
        }

        public void Start()
        {
            LoadPorts.ForEach(l=> l.Start());
        }
    }
}
