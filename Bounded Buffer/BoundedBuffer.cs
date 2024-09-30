using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bounded_Buffer
{
    public class BoundedBuffer
    {
        private Queue _buffer = new Queue();
        private Semaphore empty = new Semaphore(0,10);
        private Semaphore full =new Semaphore(10,10);
        private object _lockObj = new object();


     public void Insert(Item item)
        {
            full.WaitOne();
            lock (_lockObj)
            {
                _buffer.Enqueue(item);
                Console.WriteLine(item);
            }
            full.Release();
        }
        public void Take() { 
         empty.WaitOne();
            lock (_lockObj)
            {
                Item item = (Item)_buffer.Dequeue();
                Console.WriteLine(item);
            }
            full.Release();
        
        }

        
    }
}
