using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace NN.Controls
{
    public class IntBox : TextBox, IConfigValue
    {
        public event Action Changed;

        public Const.Param ConfigParameter
        {
            get;
            set;
        }

        public int DefaultValue
        {
            get;
            set;
        }

        public int MinimumValue
        {
            get;
            set;
        }

        public int MaximumValue
        {
            get;
            set;
        }

        public IntBox()
        {
            TextChanged += IntBox_TextChanged;
        }

        private void IntBox_TextChanged(object sender, EventArgs e)
        {
            if (IsValid())
            {
                BackColor = Color.White;
                Changed();
            }
            else
            {
                BackColor = Color.Tomato;
            }
        }

        public bool IsValid()
        {
            return int.TryParse(Text, out int value) && value >= MinimumValue && value <= MaximumValue;
        }

        public int Value => IsValid() ? int.Parse(Text) : DefaultValue;

        public void Load(Config config)
        {
            Text = config.GetInt(ConfigParameter, DefaultValue).ToString();
        }

        public void Save(Config config)
        {
            config.Set(ConfigParameter, Value);
        }

        public void SetChangeEvent(Action action)
        {
            Changed -= action;
            Changed += action;
        }
    }
}
