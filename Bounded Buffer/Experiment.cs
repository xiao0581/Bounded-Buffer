using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bounded_Buffer
{
    public class Experiment
    {
        private ConcurrentQueue<Item> queue = new ConcurrentQueue<Item>();
        private Random random = new Random();
        private BoundedBuffer buffer = new BoundedBuffer();
        public void Producer()
        {

            while (true)
            {
                Thread.Sleep(random.Next(20));
                buffer.Insert(new Item(random.Next(100)));



            }
        }
        public void Consumer()
        {
            Random random = new Random();
            while (true)
            {
                Thread.Sleep(random.Next(10));
               buffer.Take();
               
            }
        }
        public void Start()
        {

            Thread producer = new Thread(Producer);
            Thread producer1 = new Thread(Producer);
            Thread producer2 = new Thread(Producer);
            Thread producer3 = new Thread(Producer);
            producer.Start();
            producer1.Start();
            producer2.Start();
            producer3.Start();


            Thread consumer1 = new Thread(Consumer);
            Thread consumer = new Thread(Consumer);
            consumer1.Start();
            consumer.Start();
        } 
    }
}
