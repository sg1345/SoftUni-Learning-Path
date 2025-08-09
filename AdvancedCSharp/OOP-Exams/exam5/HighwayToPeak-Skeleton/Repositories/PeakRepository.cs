using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private List<IPeak> all;

        public PeakRepository()
        {
            this.all = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => all.AsReadOnly();

        public void Add(IPeak model)
        {
            all.Add(model);
        }

        public IPeak Get(string name) => All.FirstOrDefault(p => p.Name == name)!;
    }
}
