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
        public event Action Changed;

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
            Range.ForEach(CtlPanel.Controls.OfType<IConfigValue>(), c => c.SetChangeEvent(OnChanged));
        }

        public void Load(Config config)
        {
            var settings = new Settings();
            Range.ForEach(CtlPanel.Controls.OfType<IConfigValue>(), c => c.Load(config));
            settings.SkipRoundsToDrawErrorMatrix = CtlSkipRoundsToDrawErrorMatrix.Value;
            Settings = settings;
        }

        public void Save(Config config)
        {
            Range.ForEach(CtlPanel.Controls.OfType<IConfigValue>(), c => c.Save(config));
        }

        public bool IsValid()
        {
            return CtlPanel.Controls.OfType<IConfigValue>().All(c => c.IsValid());
        }

        public void SetChangeEvent(Action action)
        {
            Changed += action;
        }

        private void OnChanged()
        {
            Changed();
        }
    }

    public class Settings
    {
        public int SkipRoundsToDrawErrorMatrix;
    }

}
