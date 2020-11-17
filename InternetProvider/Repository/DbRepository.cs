using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DbRepository
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=access;Database=internetprovider";

        public DataConnection Context
        {
            get
            {
                var builder = new LinqToDbConnectionOptionsBuilder();

                builder.UsePostgreSQL(connectionString);

                return new DataConnection(builder.Build());
            }
        }

        private ITable<Account> Accounts => Context.GetTable<Account>();
        private ITable<Service> Services => Context.GetTable<Service>();
        private ITable<TariffPlan> TariffPlans => Context.GetTable<TariffPlan>();
        private ITable<Review> Reviews => Context.GetTable<Review>();

        public void Create(object item)
        {
            switch (item.GetType().Name)
            {
                case ("Account"):
                    CreateAccount((Account)item);
                    break;
                case ("Service"):
                    CreateService((Service)item);
                    break;
                case ("TariffPlan"):
                    CreateTariff((TariffPlan)item);
                    break;
                case ("Review"):
                    CreateReview((Review)item);
                    break;
                default:
                    throw new NotImplementedException();
            };
        }

        private void CreateReview(Review item)
        {
            Context.Insert(item);
        }

        private void CreateAccount(Account item)
        {
            Context.Insert(item);
        }

        private void CreateService(Service item)
        {
            Context.Insert(item);
        }

        private void CreateTariff(TariffPlan item)
        {
            Context.Insert(item);
        }

        public void Delete(object item)
        {
            Context.Delete(item);
        }
    
        public object GetItem(Guid id, string type)
        {
            return type switch
            {
                "Account" => GetAccount(id),
                "Service" => GetService(id),
                "TariffPlan" => GetTariff(id),
                _ => throw new NotImplementedException(),
            };
        }

        private Account GetAccount(Guid id)
        {
            return Accounts.FirstOrDefault(x => x.Id == id);
        }

        private Service GetService(Guid id)
        {
            return Services.FirstOrDefault(x => x.Id == id);
        }

        private TariffPlan GetTariff(Guid id)
        {
            return TariffPlans.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<object> GetItemList(string type)
        {
            return type switch
            {
                "Account" => GetAccountList(),
                "Service" => GetServiceList(),
                "TariffPlan" => GetTariffList(),
                _ => throw new NotImplementedException(),
            };
        }

        public IEnumerable<Review> GetReviewList(Guid id)
        {
            var list = Reviews.Where(x => x.ItemTypeId == id).ToList();
            if (list != null)
                return list;
            return null;
        }

        private IEnumerable<Account> GetAccountList()
        {
            var list = Accounts.ToList();
            if (list != null)
                return list;
            return null;
        }

        private IEnumerable<Service> GetServiceList()
        {
            var list = Services.ToList();
            if (list != null)
                return list;
            return null;
        }

        private IEnumerable<TariffPlan> GetTariffList()
        {
            var list = TariffPlans.ToList();
            if (list != null)
                return list;
            return null;
        }

        public void Update(object item)
        {
            switch (item.GetType().Name)
            {
                case ("Account"):
                    UpdateAccount((Account)item);
                    break;
                case ("Service"):
                    UpdateSerivce((Service)item);
                    break;
                case ("TariffPlan"):
                    UpdateTariffPlan((TariffPlan)item);
                    break;
                case ("Review"):
                    UpdateReview((Review)item);
                    break;
                default:
                    throw new NotImplementedException();
            };
        }

        private void UpdateReview(Review item)
        {
            Context.Update(item);
        }

        private void UpdateTariffPlan(TariffPlan item)
        {
            Context.Update(item);
        }

        private void UpdateSerivce(Service item)
        {
            Context.Update(item);
        }

        private void UpdateAccount(Account item)
        {
            Context.Update(item);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public Account GetAccountByEmail(string email)
        {
            return Accounts.FirstOrDefault(x => x.Email == email);
        }

        public Account GetAccountByPhoneNumber(string phoneNumber)
        {
            return Accounts.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
        }
    }
}
