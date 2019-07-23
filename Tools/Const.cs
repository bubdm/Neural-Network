using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Const
    {
        public const int UnknownId = -1;
        public const int InputLayerId = 0;
        public const int OutputLayerId = 0;

        public enum Param
        {
            ScreenWidth,
            ScreenHeight,
            ScreenLeft,
            ScreenTop,
            OnTop,
            PointsCount,
            PointSize,
            PointsArrangeSnap,
            DataPanelWidth,
            AxisOffset,

            NetworkName,
            InputNeuronsMinCount,
            InputNeuronsMaxCount,
            InputNeuronsCount,
            DefaultOutputNeuronsCount,
            Randomizer,
            HiddenLayers,
            NeuronsCount,
            Neurons
        }
    }

    public static class Notification
    {
        public enum ParameterChanged
        {
            Randomizer,
            Structure
        }
    }
}
