using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterExample.Services {
    public class TimeAverager {

        private readonly ConcurrentBag<long> times = new ConcurrentBag<long>();

        public void addTime(long time) {
            times.Add(time);
        }

        public double CalculateAverage() {
            return times.DefaultIfEmpty(0).Average();
        }
    }
}
