using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using PhotoEditor.Core.Services;

namespace PhotoEditor.Core.ViewModels
{
	public class FirstViewModel : BaseViewModel
	{
		private readonly ISoapServiceProxy _serviceProxy;
		private string _result = "Hello";

		public string Result
		{
			get { return _result; }
			set { SetProperty(ref _result, value); }
		}

		public FirstViewModel(ISoapServiceProxy serviceProxy)
		{
			_serviceProxy = serviceProxy;
			CallFirstMethodCommand = new MvxCommand(CallFirstMethodAction);
			CallSecondMethodCommand = new MvxCommand(CallSecondMethodAction);
		}

		public ICommand CallSecondMethodCommand { get; private set; }
		private void CallSecondMethodAction()
		{
			RunInBackground(() => _serviceProxy.Method2(), result => Result = result);
		}

		public ICommand CallFirstMethodCommand { get; private set; }
		private void CallFirstMethodAction()
		{
			RunInBackground(() => _serviceProxy.Method1(), result => Result = result);
		}
	}
}
