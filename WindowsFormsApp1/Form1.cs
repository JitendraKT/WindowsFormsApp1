using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  async void btnProcessFIle_Click(object sender, EventArgs e)
        {

            //lblCount.Text = "Processing file. Please wait...";
            //int count = CountCharacters();
            //lblCount.Text = count.ToString() + " characters in file";
            // Create a task to execute CountCharacters() function
            // CountCharacters() function returns int, so we created Task<int>
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();

            lblCount.Text = "Processing file. Please wait...";
            // Wait until the long running task completes
            int count = await task;
            lblCount.Text = count.ToString() + " characters in file";
        }

        private int CountCharacters()
        {
            int count = 0;

            //count = count + 30;
           // Create a StreamReader and point it to the file to read
            using (StreamReader reader = new StreamReader("D:\\Working\\Working\\Data.txt"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                string test = string.Empty;
                // Make the program look busy for 5 seconds
                Thread.Sleep(15000);
            }
            //Thread.Sleep(5000);
            return count;
        }

    }
}
