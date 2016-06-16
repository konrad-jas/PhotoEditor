using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace PhotoEditor.Core.ViewModels
{
	public abstract class BaseViewModel : MvxViewModel
	{
		private readonly AutoResetEvent _resetEvent = new AutoResetEvent(true);
		private bool _working;

		public bool Working
		{
			get { return _working; }
			set { SetProperty(ref _working, value); }
		}

		public async void RunInBackground<TArg>(Func<Task<TArg>> backgroundTask, Action<TArg> callbackAction = null)
		{
			await Task.Run(() => _resetEvent.WaitOne());
			Working = true;
			var result = await Task.Run(async () => await backgroundTask());
			if (result != null)
				callbackAction?.Invoke(result);

			Working = false;
			_resetEvent.Set();
		}
	}
}
