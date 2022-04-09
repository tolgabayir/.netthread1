using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    internal class Program
    {

        //3 thread var - publissher
        //2 thread var - consumer

        static Queue<String> queue = new Queue<String>();

        static void Main(string[] args)
        {
            //kuyruğa veri ekliycekler
            Thread tp1 = new Thread(QueueEkle);
            Thread tp2 = new Thread(QueueEkle);
            Thread tp3 = new Thread(QueueEkle);
            //kuyruktan veri ertilecek
            Thread tc1 = new Thread(QueueOku);
            Thread tc2 = new Thread(QueueOku);
            tp1.Start(1);
            tp2.Start(2); 
            tp3.Start(3);
            tc1.Start(1);
            tc2.Start(2);
        }


        static void QueueEkle(object threadNumarasi)
        {
            while (true)
            {

                try
                {
                    Thread.Sleep(300);
                    queue.Enqueue(threadNumarasi.ToString() + ". Thread tarafından publish edildi...");
                }
                catch (Exception)
                {
                    Console.WriteLine("kuyruk doldu");
                }
            }
        }
        static void QueueOku(object threadNumarasi)
        {
            while (true)
            {
                try
                {
                   Thread.Sleep(200);
                    String okunanVeri = queue.Dequeue();
                    Console.WriteLine(okunanVeri + " --- ve " + threadNumarasi.ToString() + ". Thread tarafından consume edildi...");
                }
                catch (Exception)
                {
                    Console.WriteLine("Şu anda veri bekleniyor");
                }
            }

        }
    }
}