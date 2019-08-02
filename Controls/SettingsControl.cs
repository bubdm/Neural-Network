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
        public event Action Changed = new Action(() => { });

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
            Range.ForEach(CtlPanel.Controls.OfType<IConfigValue>(), c => c.Load(config));
            Range.ForEach(CtlPanel.Controls.OfType<IConfigValue>(), c => c.SetChangeEvent(OnChanged));
            OnChanged();
        }

        public void Save(Config config)
        {
            Range.ForEach(CtlPanel.Controls.OfType<IConfigValue>(), c => c.Save(config));
        }

        public void Vanish(Config config)
        {
            Range.ForEach(CtlPanel.Controls.OfType<IConfigValue>(), c => c.Vanish(config));
        }

        public bool IsValid()
        {
            return CtlPanel.Controls.OfType<IConfigValue>().All(c => c.IsValid());
        }

        public void SetChangeEvent(Action action)
        {
            Changed -= action;
            Changed += action;
        }

        private void OnChanged()
        {
            var settings = new Settings();
            settings.SkipRoundsToDrawErrorMatrix = CtlSkipRoundsToDrawErrorMatrix.Value;
            settings.SkipRoundsToDrawNetworks = CtlSkipRoundsToDrawNetworks.Value;
            Settings = settings;

            Changed();
        }
    }

    public class Settings
    {
        public int SkipRoundsToDrawErrorMatrix;
        public int SkipRoundsToDrawNetworks;
    }

}
