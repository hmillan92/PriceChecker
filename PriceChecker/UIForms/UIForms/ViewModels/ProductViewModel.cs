using Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace UIForms.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Producto> products;
        private bool isRefreshing;
        private string codArt;

        public ObservableCollection<Producto> Products
        {
            get => this.products; 
            set => this.SetValue(ref this.products, value);
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        public string CodArt
        {
            get => this.codArt;
            set => this.SetValue(ref this.codArt, value);
        }

        public ProductViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            this.IsRefreshing = true;

            var response = await this.apiService.GetListAsync<Producto>("http://192.168.0.104:8080", "/api", "/productos");

            this.IsRefreshing = false;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var myProducts = (List<Producto>)response.Result;
            this.Products = new ObservableCollection<Producto>(myProducts);
        }
    }
}
