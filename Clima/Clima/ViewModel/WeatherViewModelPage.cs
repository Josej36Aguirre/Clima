

namespace Clima.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using Xamarin.Forms;
    using Model;

    public class WeatherViewModelPage:NotificableViewModel
    {
        #region Atributos
        private string ubicacion;
        private string pais;
        private string resultTerm;
        private string region;
        private string ultimaActualizacion;
        private string clima;
        private string temperatura;
        private ImageSource imagen;
        #endregion

      

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }
      

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }


        public string ResultTerm
        {
            get { return resultTerm; }
            set { resultTerm = value; }
        }

       

        public string Region
        {
            get { return region; }
            set { region = value; }
        }
      

        public string UltimaActualizacion
        {
            get { return ultimaActualizacion; }
            set { ultimaActualizacion = value; }
        }

     

        public string Clima
        {
            get { return clima; }
            set { clima = value; }
        }
        
        public string Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }


        public ImageSource Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public ICommand BuscarComand()
        {
            get{
                return new RelayComand(Buscar);
            }

        }
        public async void Buscar()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(ObtenerURL());
            var response = await cliente.GetAsync(cliente.BaseAddress);
            response.EnsureSuccessStatusCode();
            var jsonResult = response.Content.ReadAsByteArrayAsync().Result;
            var weatherModel = Weather. .Model.FromJson(jsonResult);
            FijarValores(weatherModel);
        }
        public string ObtenerURL()
        {
            string serviceURL = $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22Tunja%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
            return serviceURL;
        }
        public void FijarValores(Weather weatherModel)
        {


        }
        

        

    }
}
