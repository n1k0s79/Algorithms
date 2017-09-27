using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private System.Threading.CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var prog = new Progress<int>(x => this.progressBar1.Value = x);
            cts = new System.Threading.CancellationTokenSource();
            var result = await Task.Factory.StartNew( () => { return SlowProcess(true, prog, cts.Token); });
            this.Text = "Finished";
        }

        private bool SlowProcess(bool input, IProgress<int> prog, System.Threading.CancellationToken token)
        {
            for(int i = 0; i < 100; i++)
            {
                if (token.IsCancellationRequested) break;
                System.Threading.Thread.Sleep(50);
                prog.Report(i);
            }

            return input;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}