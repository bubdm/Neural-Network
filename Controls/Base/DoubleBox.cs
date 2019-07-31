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
    public class DoubleBox : TextBox, IConfigValue
    {
        public event Action Changed = new Action(() => { });

        public Const.Param ConfigParameter
        {
            get;
            set;
        }

        public string DefaultValue
        {
            get;
            set;
        }

        public double MinimumValue
        {
            get;
            set;
        }

        public double MaximumValue
        {
            get;
            set;
        }

        public bool IsNullAllowed
        {
            get;
            set;
        }

        public DoubleBox()
        {
            TextChanged += DoubleBox_TextChanged;
        }

        private void DoubleBox_TextChanged(object sender, EventArgs e)
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
            if (IsNull() && IsNullAllowed)
            {
                return true;
            }

            return Converter.TryTextToDouble(Text, out double? value) && value >= MinimumValue && value <= MaximumValue;
        }

        public bool IsNull()
        {
            return String.IsNullOrEmpty(Text);
        }

        public double Value => IsValid() ? Converter.TextToDouble(Text).Value : throw new InvalidValueException(ConfigParameter, Text);
        public double? ValueOrNull => IsNull() && IsNullAllowed ? (double?)null : IsValid() ? Converter.TextToDouble(Text) : throw new InvalidValueException(ConfigParameter, Text);

        public void Load(Config config)
        {
            Text = Converter.DoubleToText(config.GetDouble(ConfigParameter, Converter.TextToDouble(DefaultValue)));
        }

        public void Save(Config config)
        {
            config.Set(ConfigParameter, Value);
        }

        public void Vanish(Config config)
        {
            config.Remove(ConfigParameter);
        }

        public void SetChangeEvent(Action action)
        {
            Changed -= action;
            Changed += action;
        }
    }
}
