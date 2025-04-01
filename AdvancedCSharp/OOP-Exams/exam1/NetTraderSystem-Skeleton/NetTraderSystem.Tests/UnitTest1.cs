using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace NetTraderSystem.Tests
{
    public class Tests
    {
        private const string _name = "ProductName";
        private const string _category = "ProductCategory";
        private const double _price = 1.0;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Constructor()
        {
            TradingPlatform tradingPlatform = new(1);

            Assert.AreEqual(0, tradingPlatform.Products.Count);
        }

        [Test]
        public void Test_AddProduct()
        {
            TradingPlatform tradingPlatform = new(1);
            Product product = new(_name, _category, _price);

            Assert.AreEqual($"Product {product.Name} added successfully", tradingPlatform.AddProduct(product));
        }

        [Test]
        public void Test_AddProduct_InventoryIsFull()
        {
            TradingPlatform tradingPlatform = new(1);
            Product product = new(_name, _category, _price);
            tradingPlatform.AddProduct(product);

            Assert.AreEqual("Inventory is full", tradingPlatform.AddProduct(product));

        }

        [Test]
        public void Test_RemoveProduct_ReturnTrue()
        {
            TradingPlatform tradingPlatform = new(1);
            Product product = new(_name, _category, _price);
            tradingPlatform.AddProduct(product);

            Assert.AreEqual(true, tradingPlatform.RemoveProduct(product));
        }

        [Test]
        public void Test_RemoveProduct_ReturnFalse()
        {
            TradingPlatform tradingPlatform = new(1);
            Product product = new(_name, _category, _price);
            Product notAddedProduct = new(_name + "1", _category, _price);
            tradingPlatform.AddProduct(product);

            Assert.AreEqual(false, tradingPlatform.RemoveProduct(notAddedProduct));
        }

        [Test]
        public void Test_SellProduct_Successful()
        {
            TradingPlatform tradingPlatform = new(1);
            Product product = new(_name, _category, _price);
            //Product notAddedProduct = new(_name + "1", _category, _price);
            tradingPlatform.AddProduct(product);

            Assert.AreEqual(product, tradingPlatform.SellProduct(product));
        }

        [Test]
        public void Test_SellProduct_Unsuccessful()
        {
            TradingPlatform tradingPlatform = new(1);
            Product product = new(_name, _category, _price);
            Product notAddedProduct = new(_name + "1", _category, _price);
            tradingPlatform.AddProduct(product);

            Assert.AreEqual(null, tradingPlatform.SellProduct(notAddedProduct));
        }

        [Test]
        public void Test_InventoryReport()
        {
            TradingPlatform tradingPlatform = new(2);
            Product firstProduct = new(_name, _category, _price);
            tradingPlatform.AddProduct(firstProduct);
            Product secondProduct = new(_name + "1", _category, _price);
            tradingPlatform.AddProduct(secondProduct);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inventory Report:");
            sb.AppendLine($"Available Products: {tradingPlatform.Products.Count}");

            foreach (var product in tradingPlatform.Products)
            {
                sb.AppendLine(product.ToString());
            }

            string expectedReport = sb.ToString().TrimEnd();

            Assert.AreEqual(expectedReport, tradingPlatform.InventoryReport());
        }
    }
}