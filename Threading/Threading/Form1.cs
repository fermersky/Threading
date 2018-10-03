using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threading
{
    public partial class Form1 : Form
    {
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();

            thread = new Thread(new ThreadStart(TimerUpdt));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // delegate without params
            ThreadStart threadStart = new ThreadStart(Method);
            // thread
            Thread thread = new Thread(threadStart);
            //thread.Start();

            for (int i = 0; i < 1000; i++)
            {
                //Thread.Sleep(200);
                Console.WriteLine("Hello in Main");
            }


            ParameterizedThreadStart pts = new ParameterizedThreadStart(Method2);
            Thread thread1 = new Thread(pts);
            thread1.Start("hello" as object);
            
        }

        private void Method2(object str)
        {
            Thread.Sleep(3000);
            MessageBox.Show(str.ToString());
        }

        private void TimerUpdt()
        {
            while (true)
            {
                label1.Invoke(new Action(() => 
                {
                    label1.Text = DateTime.Now.ToLongTimeString();
                }));

                Thread.Sleep(1000);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            thread.Start();
        }

        private void Method()
        {
            for (int i = 0; i < 1000; i++)
            {
               // Thread.Sleep(200);
                Console.WriteLine("\t\tHello in Thread");
            }
        }
    }
}
