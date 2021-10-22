using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtremeExtensibility
{
    public partial class Form1 : Form
    {
        List<IPlugin> Plugins { get; set; }
        public Form1()
        {
            InitializeComponent();
            Plugins = new List<IPlugin>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(".");
            
            watcher.Changed += Watcher_Changed;
            watcher.EnableRaisingEvents = true;
            LoadPersistenceMethods();
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                LoadPersistenceMethods();
                UpdatePlugins();
            }));
        }

        private void UpdatePlugins()
        {
            menuStrip1.Items.Clear();


            foreach (var file in Directory.GetFiles(".", "*.dll"))
            {
                var assembly = Assembly.LoadFile(Directory.GetCurrentDirectory() + "/" + file);

                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Any(i => i == typeof(IPlugin)))
                    {
                        var plugin = Activator.CreateInstance(type) as IPlugin;
                        var pluginMenu = new ToolStripMenuItem(plugin.Name);
                        pluginMenu.DropDownItems.AddRange(plugin.MenuItems.ToArray());
                        pluginMenu.Visible = true;
                        menuStrip1.Items.Add(pluginMenu);
                    }
                }

            }
        }

        private void LoadPersistenceMethods()
        {
            cbPersistenceMethod.Items.Clear();
            foreach (var file in Directory.GetFiles(".", "*.dll"))
            {
                var assembly = Assembly.LoadFile(Directory.GetCurrentDirectory() + "/" + file);

                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetInterfaces().Any(i => i == typeof(IUserRepository)))
                    {
                        cbPersistenceMethod.Items.Add(Activator.CreateInstance(type));
                    }
                }

            }
        }

        private void btnLoadUsers_Click(object sender, EventArgs e)
        {
            lbUsers.Items.Clear();
            IUserRepository persistenceMethod = cbPersistenceMethod.SelectedItem as IUserRepository;

            var users = persistenceMethod.GetUsers();

            foreach (var user in users)
            {
                lbUsers.Items.Add(user);
            }
        }
    }
}
