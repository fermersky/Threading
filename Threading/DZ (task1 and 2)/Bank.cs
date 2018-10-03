using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace DZ__task1_
{
    public class Bank
    {
        public Bank()
        {
            file = new FileInfo("banklog.txt");
        }
        string _name;
        int _moeny;
        int _percent;
        public int money
        {
            get { return _moeny; }
            set
            {
                _moeny = value;
                ThreadStart ts = new ThreadStart(Save);
                Thread t = new Thread(ts);
                t.Start();
            }
        }
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                ThreadStart ts = new ThreadStart(Save);
                Thread t = new Thread(ts);
                t.Start();
            }
        }
        public int percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                ThreadStart ts = new ThreadStart(Save);
                Thread t = new Thread(ts);
                t.Start();
            }
        }
        public FileInfo file { get; set; }
        public object TreaaStart { get; private set; }

        public void Save()
        {
            //FileInfo fi = new FileInfo("bank.txt");
            lock (this) {

                using (StreamWriter sw = new StreamWriter("bank.txt", false))
                {
                    sw.WriteLine("p = " + percent + "%");
                    sw.WriteLine("name = " + name);
                    sw.WriteLine("money = " + money + "$");
                }
            }
            
        }
    }
}
