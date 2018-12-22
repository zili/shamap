using GeoAPI.Geometries;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using SharpMap.Styles;
using System;
using System.Data;
using System.Drawing;
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
        VectorLayer l, s;

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "server=localhost;port=5432;database=testdb;user=postgres;pwd=zili";
            n.NpgsqlConnection cnx = new n.NpgsqlConnection(str);
            n.NpgsqlCommand cmd = new n.NpgsqlCommand("SELECT code, nom FROM public.quartier;", cnx);
            n.NpgsqlDataAdapter ada = new n.NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            grd.DataSource = dt;
            s = new VectorLayer("s");
            l = new VectorLayer("l")
            {
                DataSource = new PostGIS(str, "quartier", "zone", "code")
            };

            VectorStyle style = new VectorStyle
            {
                Fill = Brushes.Green,
                Outline = Pens.Black,
                EnableOutline = true
            };

            VectorStyle styleSelected = new VectorStyle
            {
                Fill = Brushes.Yellow,
                Outline = Pens.Blue,
                EnableOutline = true
            };

            s.Style = styleSelected;
            l.Style = style;

            mp.Map.Layers.Add(l);

            mp.Map.ZoomToExtents();
            mp.Refresh();

        }

        private void mp_MouseDown(GeoAPI.Geometries.Coordinate worldPos, MouseEventArgs imagePos)
        {
            FeatureDataSet selected = new FeatureDataSet();
            Envelope boundingBox = new Envelope(worldPos);
            boundingBox.ExpandBy(0.01);

            l.DataSource.ExecuteIntersectionQuery(boundingBox, selected);

            if (selected.Tables[0].Count == 0) return;

            Text = selected.Tables[0].Rows[0]["nom"].ToString();
            s.DataSource = new GeometryProvider(selected.Tables[0]);

            if (mp.Map.FindLayer("s") != null)
            {
                mp.Map.Layers.Add(s);
            }

            mp.Refresh();
        }
    }
}
