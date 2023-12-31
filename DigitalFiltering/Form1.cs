﻿using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalFiltering
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Random random = new Random();
        const int ViewportPointCount = 1000;
        ObservableCollection<DataPoint> dataPoints = new ObservableCollection<DataPoint>();
        WaveGenerator waveGenerator = new WaveGenerator(WaveType.Sinewave);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Start();
            timer.Tick += Timer_Tick;
            chartControl1.Dock = DockStyle.Fill;
            Series series = new Series();
            series.ChangeView(ViewType.Line);
            series.DataSource = dataPoints;
            series.DataSourceSorted = true;
            series.ArgumentDataMember = "Argument";
            series.ValueDataMembers.AddRange("Value");
            chartControl1.Series.Add(series);

            LineSeriesView seriesView = (LineSeriesView)series.View;
            seriesView.LastPoint.LabelDisplayMode = SidePointDisplayMode.SeriesPoint;
            seriesView.LastPoint.Label.TextPattern = "{V:f2}";
            //seriesView.Color = Color.FromKnownColor((KnownColor)random.Next(0, 100));
            seriesView.Color = Color.Black;

            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            diagram.AxisX.VisualRange.EndSideMargin = 200;
            diagram.DependentAxesYRange = DefaultBoolean.True;
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;
            WaveGenerator.Frequency = 100;
            waveGenerator.Amplitude = 1;
           // waveGenerator.SampleCount = 600;
        }
        int i = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            dataPoints.Add(new DataPoint(i,waveGenerator.GenerateWave.Invoke()));
            if (dataPoints.Count > ViewportPointCount)
                dataPoints.RemoveAt(0);
            chartControl1.Refresh();
            i++;
        }
    }

    public class DataPoint
    {
        public int Argument { get; set; }
        public double Value { get; set; }
        public DataPoint(int argument, double value)
        {
            Argument = argument;
            Value = value;
        }
    }
}
