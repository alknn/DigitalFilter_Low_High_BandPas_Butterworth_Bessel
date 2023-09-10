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
        public static int Frequency;
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
        double T = 1f / 100;
        double t2 = 0;
        double T2 = 1f / 20;
        double t3 = 0;
        double T3 = 1f / 200;
        double t4 = 0;
        double T4 = 1f / 18;
        Random random = new Random();
        private double GenerateSinewave( )
        {
            double amplitude = Amplitude;
            while ( t <=  1)
            {
                t += T;
                t2 += T2;
                t3 += T3;
                t4 += T4;
                if (t > 1) { t = 0; t2 = 0; t3 = 0;  }
                return amplitude  * Math.Sin(2 * Math.PI * t) + 0.1 * random.NextDouble() * Math.Sin(2 * Math.PI * t2) ;

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
