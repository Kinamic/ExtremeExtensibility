using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginQueMandaCoheteALaLuna
{
    public class RocketLauncher : IPlugin
    {
        public List<ToolStripMenuItem> MenuItems => new List<ToolStripMenuItem>()
        {
            new ToolStripMenuItem("Enviar Cohete", null, new EventHandler((src, args) => MessageBox.Show("Cohete en la luna!!!!!!")))
        };

        public string Name => "Lanzador de cohetes";
    }
}
