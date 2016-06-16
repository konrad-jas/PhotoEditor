using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using PhotoEditor.Core.Services;

namespace PhotoEditor.Core.ViewModels
{
	public class FirstViewModel : BaseViewModel
	{
		private readonly ISoapServiceClient _serviceClient;
		private string _weatherReport;
		private string _city = "City name";
		private string _country = "Country name";

		public string WeatherReport
		{
			get { return _weatherReport; }
			set { SetProperty(ref _weatherReport, value); }
		}

		public string City
		{
			get { return _city; }
			set { SetProperty(ref _city, value); }
		}

		public string Country
		{
			get { return _country; }
			set { SetProperty(ref _country, value); }
		}

		public FirstViewModel(ISoapServiceClient serviceClient)
		{
			_serviceClient = serviceClient;
			CallFirstMethodCommand = new MvxCommand(CallFirstMethodAction);
		}


		public ICommand CallFirstMethodCommand { get; private set; }
		private  void CallFirstMethodAction()
		{
			RunInBackground(() => _serviceClient.GetWeather(City, Country), result => WeatherReport = result);
		}
	}
}
