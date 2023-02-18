using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Portability;
using PTMK;

namespace BenchmarkTests
{
    public class Testing
    {
        [Benchmark]
        public void SeedDataWithoutTransaction()
        {
            SeedData.GenerateData();
        }

    }
}
