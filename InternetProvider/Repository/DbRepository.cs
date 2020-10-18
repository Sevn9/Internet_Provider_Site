using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class DbRepository : IRepository<object>
    {
        private const string connectionString = "Host=localhost;Username=postgres;Password=Kekmlg1337;Database=internetprovider";

        public DataConnection _context
        {
            get
            {
                var builder = new LinqToDbConnectionOptionsBuilder();

                builder.UsePostgreSQL(connectionString);

                return new DataConnection(builder.Build());
            }
        }

        private ITable<Account> Accounts => _context.GetTable<Account>();
        private ITable<Service> Services => _context.GetTable<Service>();
        private ITable<TariffPlan> TariffPlans => _context.GetTable<TariffPlan>();

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
                default:
                    throw new NotImplementedException();
            };
        }

        private void CreateAccount(Account item)
        {
            _context.Insert(item);
        }

        private void CreateService(Service item)
        {
            _context.Insert(item);
        }

        private void CreateTariff(TariffPlan item)
        {
            _context.Insert(item);
        }

        public void Delete(object item)
        {
            _context.Delete(item);
        }
    
        public object GetItem(Guid id, Type type)
        {
            return type.Name switch
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

        public IEnumerable<object> GetItemList(Type type)
        {
            return type.Name switch
            {
                "Account" => GetAccountList(),
                "Service" => GetServiceList(),
                "TariffPlan" => GetTariffList(),
                _ => throw new NotImplementedException(),
            };
        }

        private IEnumerable<Account> GetAccountList()
        {
            return Accounts.ToList();
        }

        private IEnumerable<Service> GetServiceList()
        {
            return Services.ToList();
        }

        private IEnumerable<TariffPlan> GetTariffList()
        {
            return TariffPlans.ToList();
        }

        public void Update(object item)
        {
            _context.Update(item);
        }

        public void Dispose()
        {
            _context.Dispose();
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
