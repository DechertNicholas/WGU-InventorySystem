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
            this.Products = new BindingList<Product>();
        }

        public void AddProduct(Product product)
        {
            product.ProductID = LastProductId;
            LastProductId++;
            Products.Add(product);
        }

        public bool RemoveProduct(int productID)
        {
            return Products.Remove(LookupProduct(productID));
        }

        public Product LookupProduct(int productID)
        {
            return Products.FirstOrDefault(p => p.ProductID == productID);
        }

        public void UpdateProduct(int productID, Product product)
        {
            Products[Products.IndexOf(LookupProduct(productID))] = product;
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

        public Part LookupPart(string partName)
        {
            return AllParts.FirstOrDefault(p => p.Name == partName);
        }

        public void UpdatePart(int partID, Part part)
        {
            AllParts[AllParts.IndexOf(LookupPart(partID))] = part;
        }
    }
}
