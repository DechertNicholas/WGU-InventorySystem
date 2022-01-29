using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    public class Product
    {
        public BindingList<Part> AssociatedParts { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public void AddAssociatedpart(Part part)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAssociatedPart(int partID)
        {
            throw new NotImplementedException();
        }

        public Part LookupAssociatedPart(int partID)
        {
            throw new NotImplementedException();
        }
    }
}
