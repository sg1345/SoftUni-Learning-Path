using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Core
{
    public class Controller : IController
    {
        private IApplication _application;
        private int adminCount = 0;

        public Controller()
        {
            _application = new Application();
        }

        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            if (productType != typeof(Item).Name && productType != typeof(Service).Name)
                return string.Format(OutputMessages.ProductIsNotPresented, productType);

            if (this._application.Products.Exists(productName))
                return string.Format(OutputMessages.ProductNameDuplicated, productName);

            if (!this._application.Users.Exists(userName) || !this._application.Users.GetByName(userName).HasDataAccess)
                return string.Format(OutputMessages.UserIsNotAdmin, userName);

            IProduct product;
            if (productType == typeof(Item).Name)
                product = new Item(productName, basePrice);
            else
                product = new Service(productName, basePrice);

            this._application.Products.AddNew(product);
            return string.Format(OutputMessages.ProductAdded, productType, productName, $"{product.BasePrice:f2}");
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Application administration:");

            foreach (Admin admin in this._application.Users.Models.Where(u => u.HasDataAccess).OrderBy(u => u.UserName))
            {
                sb.AppendLine(admin.ToString());
            }

            sb.AppendLine("Clients:");
            foreach (Client client in this._application.Users.Models.Where(u => !u.HasDataAccess).OrderBy(u => u.UserName))
            {
                sb.AppendLine(client.ToString());

                if (client.Purchases.Any(p => p.Value))
                {
                    sb.AppendLine($"-Black Friday Purchases: {client.Purchases.Where(p=>p.Value).Count()}");

                    foreach (var purchase in client.Purchases.Where(p=>p.Value))
                    {
                        sb.AppendLine($"--{purchase.Key}");
                    }
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            if (!this._application.Users.Exists(userName) || this._application.Users.GetByName(userName).HasDataAccess)
                return string.Format(OutputMessages.UserIsNotClient, userName);

            if (!this._application.Products.Exists(productName))
                return string.Format(OutputMessages.ProductDoesNotExist, productName);

            if (this._application.Products.Exists(productName) && this._application.Products.GetByName(productName).IsSold)
                return string.Format(OutputMessages.ProductOutOfStock, productName);

            Client user = this._application.Users.GetByName(userName) as Client;
            user.PurchaseProduct(productName, blackFridayFlag);

            this._application.Products.GetByName(productName).ToggleStatus();

            if (user.Purchases[productName] == true)
                return string.Format(OutputMessages.ProductPurchased, userName, productName, $"{this._application.Products.GetByName(productName).BlackFridayPrice:f2}");
            else
                return string.Format(OutputMessages.ProductPurchased, userName, productName, $"{this._application.Products.GetByName(productName).BasePrice:f2}");


        }

        public string RefreshSalesList(string userName)
        {
            if (!this._application.Users.Exists(userName) || this._application.Users.Models.Any(u=>u.UserName== userName && !u.HasDataAccess))
                return string.Format(OutputMessages.UserIsNotAdmin, userName);

            var soldProducts = this._application.Products.Models.Where(p => p.IsSold).ToList();
            foreach (var product in soldProducts)
            {
                product.ToggleStatus();
            }

            return string.Format(OutputMessages.SalesListRefreshed, soldProducts.Count());
        }

        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {

            if (this._application.Users.Exists(userName))
                return string.Format(OutputMessages.UserAlreadyRegistered, userName);

            if (this._application.Users.Models.Any(u => u.Email == email))
                return string.Format(OutputMessages.SameEmailIsRegistered, email);

            IUser user;
            if (hasDataAccess == true)
            {
                if (adminCount < 2)
                {
                    user = new Admin(userName, email);
                    adminCount++;
                    this._application.Users.AddNew(user);

                    return string.Format(OutputMessages.AdminRegistered, userName);
                }
                else
                {
                    return string.Format(OutputMessages.AdminCountLimited);
                }
            }
            else
            {
                user = new Client(userName, email);
                this._application.Users.AddNew(user);

                return string.Format(OutputMessages.ClientRegistered, userName);
            }
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            if (!this._application.Products.Exists(productName))
                return string.Format(OutputMessages.ProductDoesNotExist, productName);

            if (!this._application.Users.Exists(userName) || !this._application.Users.GetByName(userName).HasDataAccess)
                return string.Format(OutputMessages.UserIsNotAdmin, userName);

            IProduct product = this._application.Products.GetByName(productName);
            double oldPriceValue = product.BasePrice;
            product.UpdatePrice(newPriceValue);

            return string.Format(OutputMessages.ProductPriceUpdated, productName, $"{oldPriceValue:f2}", $"{newPriceValue:f2}");
        }
    }
}
