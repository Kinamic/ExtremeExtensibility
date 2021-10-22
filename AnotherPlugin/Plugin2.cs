using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherPlugin
{
    public class Plugin2 : IPlugin
    {
        public List<System.Windows.Forms.ToolStripMenuItem> MenuItems => new List<System.Windows.Forms.ToolStripMenuItem>
        {
            new System.Windows.Forms.ToolStripMenuItem("Hago cosas mágicas", null, new EventHandler((src, args) => {
                var form = new Form1();
                form.Show();
            }))
        };

        public string Name => "Otro plugin";
    }
}
