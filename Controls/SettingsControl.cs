using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace NN.Controls
{
    public partial class SettingsControl : UserControl, IConfigValue
    {
        object Locker = new object();
        Settings _Settings;
        public Settings Settings
        {
            get
            {
                lock (Locker)
                {
                    return _Settings;
                }
            }

            set
            {
                lock (Locker)
                {
                    _Settings = value;
                }
            }
        }

        public SettingsControl()
        {
            InitializeComponent();
        }

        public void Load(Config config)
        {
            var settings = new Settings();

            foreach (var value in CtlPanel.Controls.OfType<IConfigValue>())
            {
                value.Load(config);
            }

            settings.SkipRoundsToDrawErrorMatrix = CtlSkipRoundsToDrawErrorMatrix.Value;

            Settings = settings;
        }

        public void Save(Config config)
        {
            foreach (var value in CtlPanel.Controls.OfType<IConfigValue>())
            {
                value.Save(config);
            }
        }

        public bool IsValid()
        {
            foreach (var value in CtlPanel.Controls.OfType<IConfigValue>())
            {
                if (!value.IsValid())
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Settings
    {
        public int SkipRoundsToDrawErrorMatrix;
    }

}
