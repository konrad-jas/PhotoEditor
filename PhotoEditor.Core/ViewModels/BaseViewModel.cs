using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace PhotoEditor.Core.ViewModels
{
	public abstract class BaseViewModel : MvxViewModel
	{
		private bool _working;

		public bool Working
		{
			get { return _working; }
			set { SetProperty(ref _working, value); }
		}

		public async void RunInBackground<TArg>(Func<Task<TArg>> backgroundTask, Action<TArg> callbackAction = null)
		{
			Working = true;
			var result = await Task.Run(async () => await backgroundTask());
			if (result != null)
				callbackAction?.Invoke(result);

			Working = false;
		}
	}
}
