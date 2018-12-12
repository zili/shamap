using GeoAPI.Geometries;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using n = Npgsql;

namespace shamap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        VectorLayer l;
        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "server=localhost;port=5432;database=testdb;user=postgres;pwd=zili";
            n.NpgsqlConnection cnx = new n.NpgsqlConnection(str);
            n.NpgsqlCommand cmd = new n.NpgsqlCommand("SELECT code, nom FROM public.quartier;", cnx);
            n.NpgsqlDataAdapter ada = new n.NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            grd.DataSource = dt;
            l = new VectorLayer("")
            {
                DataSource = new PostGIS(str, "quartier", "zone", "code")
            };
            l.Style.Fill = System.Drawing.Brushes.BlueViolet;
            mp.Map.Layers.Add(l);
            mp.Map.ZoomToExtents();
            mp.Refresh();

        }

        private void mp_MouseDown(GeoAPI.Geometries.Coordinate worldPos, MouseEventArgs imagePos)
        {
            FeatureDataSet selectedGeometry = new FeatureDataSet();
            VectorLayer theLayer = (VectorLayer)mp.Map.FindLayer("").FirstOrDefault();

            if (theLayer != null)
            {
                if (!theLayer.DataSource.IsOpen)
                {
                    theLayer.DataSource.Open();
                }

                Envelope boundingBox = new Envelope(worldPos);

                if (Math.Abs(boundingBox.Area - 0.0) < 0.01)
                {
                    boundingBox.ExpandBy(0.01);
                }

                theLayer.DataSource.ExecuteIntersectionQuery(boundingBox, selectedGeometry);


                theLayer.DataSource.Close();

            }
        }
    }
}
