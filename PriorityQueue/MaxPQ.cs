using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    public class MaxPQ<TKey> where TKey: IComparable<TKey>
    {
        private TKey[] pq;
        private int count = 0;

        public int Size => count;

        public bool IsEmpty => count == 0;

        public MaxPQ(int max)
        {
            this.pq = new TKey[max + 1];
        }

        public void Insert(TKey v)
        {
            this.pq[++count] = v;
            this.Swim(this.count);
        }

        public TKey DeleteMax()
        {
            TKey max = this.pq[1];
            this.Exchange(1, count--);
            pq[count + 1] = default(TKey);
            this.Sink(1);
            return max;
        }

        private bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        private void Exchange(int i, int j)
        {
            TKey temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }
        
        private void Swim(int k)
        {
            while(k > 1 && this.Less(k/2, k))
            {
                this.Exchange(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while(2*k <= this.count)
            {
                int j = 2 * k;
                if(j < this.count && this.Less(j, j+1))
                {
                    j++;
                }

                if(!this.Less(k, j))
                {
                    break;
                }

                this.Exchange(k, j);
                k = j;
            }
        }
    }
}
