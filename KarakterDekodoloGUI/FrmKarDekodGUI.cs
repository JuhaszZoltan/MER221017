using System.Runtime.CompilerServices;

namespace KarakterDekodoloGUI
{
    public partial class FrmKarDekodGUI : Form
    {
        public Label[,] Matrix { get; set; }


        public FrmKarDekodGUI()
        {
            InitializeComponent();
            Matrix = new Label[7, 4];
        }

        private void FrmKarDekodGUI_Load(object sender, EventArgs e)
        {
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    Matrix[s, o] = new Label()
                    {
                        AutoSize = false,
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Bounds = new(
                            x: (pnlDina.Width / 2) - (Matrix.GetLength(1) * 50 / 2) + (o * 50),
                            y: (pnlDina.Height / 2) - (Matrix.GetLength(0) * 50 / 2) +  (s * 50),
                            width: 50,
                            height: 50),
                        Text = "0",
                        TextAlign = ContentAlignment.MiddleCenter,
                    };
                    Matrix[s, o].Click += Label_Click;
                    pnlDina.Controls.Add(Matrix[s, o]);
                }
            }
        }

        private void Label_Click(object? sender, EventArgs e)
        {
            if (sender is Label)
            {
                if ((sender as Label).Text == "0")
                {
                    (sender as Label).Text = "1";
                    (sender as Label).BackColor = Color.Gray;
                }
                else if ((sender as Label).Text == "1")
                {
                    (sender as Label).Text = "0";
                    (sender as Label).BackColor = Color.White;
                }
            }
        }
    }
}