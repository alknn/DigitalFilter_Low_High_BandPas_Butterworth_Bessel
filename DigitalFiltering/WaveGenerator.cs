using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFiltering
{
    public enum WaveType
    {
        Sinewave,
        TriangleWave,
        SquareWave,
        Sawtoothwave,
    }

    public delegate double GenerateWave();

    public class WaveGenerator
    {
        private WaveType SignalWaveType;
        public double Amplitude;
        public int SampleCount;
        public bool IsContinueWave = false;
        public int Frequency;
        public GenerateWave GenerateWave;    
        public WaveGenerator( WaveType waveType) 
        {
            SignalWaveType = waveType;
            switch (SignalWaveType)
            {
                case WaveType.Sinewave:
                    GenerateWave += GenerateSinewave;
                    break;
                case WaveType.TriangleWave:
                    GenerateWave += GenerateTriangleWave;
                    break;
                case WaveType.SquareWave:
                    GenerateWave += GenerateSquareWave;
                    break;
                case WaveType.Sawtoothwave:
                    GenerateWave += GenerateSawtoothWave;
                    break;
            }
        }
        double t = 0;
        private double GenerateSinewave( )
        {
            double T = 1 / Frequency;
            double amplitude = Amplitude;
            while ( t <=  1)
            {
                t += T;
                if (t > 1)
                    t = 0;
                return amplitude * Math.Sin(2 * Math.PI * t);

            }
            return double.NaN;

        }
        private double GenerateTriangleWave()
        {
            return double.NaN;
        }
        private double GenerateSquareWave()
        {
            return double.NaN;
        }
        private double GenerateSawtoothWave()
        {
            return double.NaN;
        }


    }
}
