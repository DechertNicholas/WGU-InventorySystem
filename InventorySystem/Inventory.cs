using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    public class Inventory
    {
        public BindingList<Product> Products { get; set; }
        public BindingList<Part> AllParts { get; set; }

        // These properties keep track of the last ID used. They are incremented with AddProduct() and AddPart()
        private int LastProductId { get; set; } = 1;
        private int LastPartId { get; set; } = 1;

        public Inventory()
        {
            this.AllParts = new BindingList<Part>();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public Product LookupProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public void AddPart(Part part)
        {
            part.PartID = LastPartId;
            LastPartId++;
            AllParts.Add(part);
        }

        public bool DeletePart(Part part)
        {
            return AllParts.Remove(LookupPart(part.PartID));
        }

        public Part LookupPart(int partID)
        {
            return AllParts.FirstOrDefault(p => p.PartID == partID);
        }

        public void UpdatePart(int partID, Part part)
        {
            AllParts[AllParts.IndexOf(LookupPart(partID))] = part;
        }
    }
}
