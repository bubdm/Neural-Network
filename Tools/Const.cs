﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Const
    {
        public const int UnknownId = -1;
        public const int CurrentValue = -1;
        public const int InputLayerId = 0;
        public const int OutputLayerId = 1;
        public const double InitializerSkipValue = double.NaN;

        public const int DefaultInputNeuronsCount = 100;
        public const int DefaultOutputNeuronsCount = 11; // 0 1 2 3 4 5 6 7 8 9 10

        public enum Toggle
        {
            On,
            Off
        }

        public enum Param
        {
            ScreenWidth,
            ScreenHeight,
            ScreenLeft,
            ScreenTop,
            OnTop,
            PointSize,
            PointsArrangeSnap,
            DataPanelWidth,
            AxisOffset,

            NetworkName,
            CurrentLayerIndex,
            InputNeuronsMinCount,
            InputNeuronsMaxCount,
            InputNeuronsCount,
            RandomizeMode,
            ActivationInitializer,
            ActivationInitializerParamA,
            WeightsInitializer,
            WeightsInitializerParamA,
            HiddenLayers,
            Neurons,
            RandomizeModeParamA,
            IsBias,
            IsBiasConnected,
            LearningRate,
            InputActivationFunc,
            InputInitial0,
            InputInitial1,

            // Settings

            SettingsSkipRoundsToDrawErrorMatrix
        }
    }

    public static class Notification
    {
        public enum ParameterChanged
        {
            Randomizer,
            Structure,
            NeuronsCount
        }
    }
}
