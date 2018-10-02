using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MapsPlayground.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataGridView;

namespace GMapWinForm
{
    public partial class Form1 : Form
    {
        private readonly IObjectToPlotRepository objectToPlotRepository;
        public Form1(IObjectToPlotRepository objectToPlotRepository)
        {
            this.objectToPlotRepository = objectToPlotRepository;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // http://www.independent-software.com/gmap-net-tutorial-maps-markers-and-polygons.html
            // Initialize map:
            gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.Position = new PointLatLng(40, -99);
            gMapControl1.Zoom = 4;

            objectToPlotBindingSource.DataSource = objectToPlotRepository.GetObjectsToPlot(30);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

            HitTestInfo test = dataGridView1.HitTest(e.X,e.Y);
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)dataGridView1.Rows[test.RowIndex].Cells[test.ColumnIndex];
            dataGridView1.DoDragDrop(cell, DragDropEffects.Move);
        }

        private void gMapControl1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewTextBoxCell)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void gMapControl1_DragDrop(object sender, DragEventArgs e)
        {
            // add the pin
            gMapControl1.Zoom = 4;
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(gMapControl1.FromLocalToLatLng(e.X, e.Y),
              GMarkerGoogleType.green);
            marker.DisableRegionCheck = true;
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)e.Data.GetData(typeof(DataGridViewTextBoxCell));

            marker.ToolTipText = cell.Value.ToString();
            markersOverlay.Markers.Add(marker);

            gMapControl1.Overlays.Add(markersOverlay);
            gMapControl1.Zoom = 4;



        }
    }
}
