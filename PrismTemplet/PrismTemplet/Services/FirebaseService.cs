using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using PrismTemplet.Dto;

namespace PrismTemplet.Services
{
    public class FirebaseService
    {
        FirebaseClient firebase = new FirebaseClient("https://money-39dec.firebaseio.com/");
        public async Task<List<MoneyModel>> GetListMoney()
        {
          
            return (await firebase.Child("Moneys").OnceAsync<MoneyModel>()).Select(item => new MoneyModel
            {
                Date = item.Object.Date,
                Money = item.Object.Money,
                Title = item.Object.Title,
                Key = item.Key

            }).ToList();
        }
        public async Task AddMoney(DateTime date, string money, string title)
        {

            await firebase.Child("Moneys").PostAsync(new MoneyModel() { Date = date, Money = money, Title = title });
        }
        public async Task UpdateMoney(DateTime date, string money, string title, string index)
        {

            var toUpdatePerson = (await firebase.Child("Moneys").OnceAsync<object>()).Where(a => a.Key == index).FirstOrDefault();
            await firebase.Child("Moneys").Child(toUpdatePerson.Key).PutAsync(new MoneyModel() { Date = date, Money = money, Title = title });
        }
        public async Task DeleteMoney(string index)
        {
            var toDeleteMoney = (await firebase.Child("Moneys").OnceAsync<object>()).Where(a => a.Key == index).FirstOrDefault();
            await firebase.Child("Moneys").Child(toDeleteMoney.Key).DeleteAsync();
        }
    }
}
